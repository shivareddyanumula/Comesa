<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsMgrAppraisal.aspx.cs" Inherits="PMS_frm_PmsMgrAppraisal" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1 {
            width: 50px;
        }

        .style3 {
            text-align: left;
        }

        .style4 {
            text-align: left;
            font-weight: bold;
        }

        .style5 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function openRadWin(str) {
                var WND = radopen(str, "RW_IDP");
                WND.SetTitle("IDP Details");
                WND.Width = "500PX";
                WND.Height = "400PX";
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
                Height="400px" Title="IDP" AutoSize="true" VisibleStatusbar="false"
                ReloadOnShow="true" Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true"
                meta:resourcekey="RW_IDPResource1">
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
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="GridFormDetailsViews"
        Skin="WebBlue" />
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Appraisal_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    meta:resourcekey="Rm_Appraisal_PAGEResource1">
                    <telerik:RadPageView ID="Rp_Appraisal_VIEWDETAILS" runat="server" Selected="True"
                        meta:resourcekey="Rp_Appraisal_VIEWDETAILSResource1">
                        <center>
                            <b>Manager Appraisal</b></center>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center"></td>
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
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" MarkFirstMatch="true"
                                        Width="200px" meta:resourcekey="rcmb_BusinessUnitTypeResource1" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType"
                                        runat="server" ValidationGroup="Controls4" ErrorMessage="Please Select BusinessUnit"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnitTypeResource1" Text="*"></asp:RequiredFieldValidator>
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
                                        Width="200px" meta:resourcekey="rcmb_EmployeeTypeResource1" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" ControlToValidate="rcmb_EmployeeType"
                                        runat="server" ValidationGroup="Controls4" ErrorMessage="Please Select Employee"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1" Text="*"></asp:RequiredFieldValidator>
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
                                    <asp:Label ID="lbl_Role" runat="server" Text="Role" meta:resourcekey="lbl_RoleResource1"></asp:Label>
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
                                    <asp:Label ID="lbl_givefeedback" runat="server" Text="Appraisal For" meta:resourcekey="lbl_givefeedbackResource2"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_feedback" runat="server" AutoPostBack="True" Width="200px"
                                        OnSelectedIndexChanged="rcmb_feedback_indexchanged" MarkFirstMatch="true"
                                        meta:resourcekey="rcmb_feedbackResource1">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" runat="server" meta:resourcekey="RadComboBoxItemResource1" />
                                            <telerik:RadComboBoxItem Text="GOAL" Value="1" runat="server" meta:resourcekey="RadComboBoxItemResource2" />
                                            <telerik:RadComboBoxItem Text="KRA" Value="2" runat="server" meta:resourcekey="RadComboBoxItemResource3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_feedback" ControlToValidate="rcmb_feedback"
                                        runat="server" ValidationGroup="Controls4" ErrorMessage="Please Give Feedback"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_feedbackResource1" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Project" runat="server" Text="Project" meta:resourcekey="lbl_ProjectResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left" class="style3">
                                    <telerik:RadTextBox ID="rtxt_Project" runat="server" MaxLength="40"
                                        meta:resourcekey="rtxt_ProjectResource1">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Appraisal_Date" runat="server" Text="Appraisal Date" meta:resourcekey="lbl_Appraisal_DateResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_DATEofAppraisal" runat="server" meta:resourcekey="rdtp_DATEofAppraisalResource1">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="MM-dd-yyyy" DisplayDateFormat="MM-dd-yyyy" LabelCssClass=""
                                            Width="">
                                        </DateInput>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_rdtp_DATE" runat="server" ControlToValidate="rdtp_DATEofAppraisal"
                                        ErrorMessage="Date Of Appraisal Cannot Be Empty" ValidationGroup="Controls4"
                                        meta:resourcekey="rfv_rdtp_DATEResource1">*</asp:RequiredFieldValidator>--%>
                                </td>
                                <td>
                                    <asp:Label ID="LBL_AppraisalCycle" runat="server" Text="Appraisal Cycle" meta:resourcekey="LBL_AppraisalCycleResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left" class="style3">
                                    <telerik:RadTextBox ID="rtxt_AppraisalCycle" runat="server" MaxLength="40"
                                        meta:resourcekey="rtxt_AppraisalCycleResource1">
                                    </telerik:RadTextBox>
                                    <asp:Label ID="LBL_Appraise_Id" runat="server" Text="Appraisal Cycle :" Visible="False"
                                        meta:resourcekey="LBL_Appraise_IdResource1"></asp:Label>
                                </td>
                            </tr>
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="LABELSS"
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls4" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="Rm_Appraisal_GOALKRA" runat="server" SelectedIndex="0"
                    ScrollBars="Auto" Width="100%">
                    <telerik:RadPageView ID="Rp_Appraisal_Goal_VIEWMAIN" runat="server" Selected="True"
                        meta:resourcekey="Rp_Appraisal_Goal_VIEWMAINResource1">
                        <table align="center" width="100%">
                            <caption>
                            </caption>
                            <caption>
                                <tr>
                                    <td align="center"></td>
                                    <caption>
                                    </caption>
                                </tr>
                            </caption>
            </td>
        </tr>
        <caption>
            <caption>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblgoal" runat="server" Text="Goal Detalis"> </asp:Label>
                    </td>
                    <caption>
                    </caption>
                </tr>
            </caption>
            </tr>
                                <caption>
                                    <caption>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="Rg_Appraisal_Goal" runat="server" AutoGenerateColumns="False"
                                                    meta:resourcekey="Rg_Appraisal_GoalResource1"
                                                    OnRowCommand="Rg_Appraisal_Goal_RowCommand" ShowHeader="False" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                                            <ItemTemplate>
                                                                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                    <tr>
                                                                        <td class="style4">Name
                                                                        </td>
                                                                        <td class="style4">:
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_GoalName" runat="server"
                                                                                meta:resourcekey="lbl_GoalNameResource1" Text='<%# Eval("GSDTL_NAME") %>'></asp:Label>
                                                                        </td>
                                                                        <td class="style3">&#160;&#160;<b>Timelines &#160;</b>
                                                                        </td>
                                                                        <td class="style4">:
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_timelines" runat="server"
                                                                                Text='<%# Eval("GSDTL_TIMELINES") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4">Measure
                                                                        </td>
                                                                        <td class="style4">:
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_GoalMeasure" runat="server"
                                                                                meta:resourcekey="lbl_GoalMeasureResource1" Text='<%# Eval("GSDTL_MEASURE") %>'></asp:Label>
                                                                        </td>
                                                                        <td class="style3">
                                                                            <b>Target</b>
                                                                        </td>
                                                                        <td class="style3">:
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_target" runat="server" Text='<%# Eval("GSDTL_TARGET") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4">Weightage
                                                                        </td>
                                                                        <td class="style4">:
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_GoalWeightage" runat="server"
                                                                                meta:resourcekey="lbl_GoalWeightageResource1"
                                                                                Text='<%# Eval("GSDTL_WEIGHTAGE") %>'></asp:Label>
                                                                        </td>
                                                                        <td class="style3">
                                                                            <b>Target Achieved</b>
                                                                        </td>
                                                                        <td class="style3">:
                                                                        </td>
                                                                        <td class="style3">
                                                                            <telerik:RadRating ID="ratingPie" runat="server" ItemHeight="20px"
                                                                                ItemWidth="20px" SelectionMode="Single">
                                                                                <Items>
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/6.gif"
                                                                                        HoveredSelectedImageUrl="../Images/6.gif" ImageUrl="../Images/1.gif"
                                                                                        SelectedImageUrl="../Images/6.gif" ToolTip="0%" Value="1" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/7.gif"
                                                                                        HoveredSelectedImageUrl="../Images/7.gif" ImageUrl="../Images/2.gif"
                                                                                        SelectedImageUrl="../Images/7.gif" ToolTip="25%" Value="2" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/8.gif"
                                                                                        HoveredSelectedImageUrl="../Images/8.gif" ImageUrl="../Images/3.gif"
                                                                                        SelectedImageUrl="../Images/8.gif" ToolTip="50%" Value="3" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/9.gif"
                                                                                        HoveredSelectedImageUrl="../Images/9.gif" ImageUrl="../Images/4.gif"
                                                                                        SelectedImageUrl="../Images/9.gif" ToolTip="75%" Value="4" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/10.gif"
                                                                                        HoveredSelectedImageUrl="../Images/10.gif" ImageUrl="../Images/5.gif"
                                                                                        SelectedImageUrl="../Images/10.gif" ToolTip="100%" Value="5" />
                                                                                </Items>
                                                                            </telerik:RadRating>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4"></td>
                                                                        <td class="style4"></td>
                                                                        <td class="style3">
                                                                            <%--  <asp:Label ID="lbl_GoalDate" runat="server" meta:resourcekey="lbl_GoalDateResource1"
                                                                    Text='<%# Eval("GSDTL_DATE") %>' Width="125px"></asp:Label>--%>
                                                                            <asp:Label ID="lbl_Goal_Id" runat="server" Text='<%# Eval("GSDTL_ID") %>'
                                                                                Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td class="style3">&#160;&#160;</td>
                                                                        <td class="style3">&#160;&#160;</td>
                                                                        <td class="style3">&#160;&#160;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4" colspan="7">
                                                                            <asp:LinkButton ID="lnk_GoalEmployeeComments" runat="server"
                                                                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="GoalEmployee_Feed"
                                                                                Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                                Text="+&amp;nbsp;Employee&amp;nbsp;Comments"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4" colspan="7">
                                                                            <asp:TextBox ID="txt_GoalEmployeeFeedback" runat="server" Height="49px"
                                                                                meta:resourcekey="txt_GoalEmployeeFeedbackResource1" TextMode="MultiLine"
                                                                                Visible="False" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4" colspan="7">
                                                                            <asp:LinkButton ID="lnk_GoalManagerComments" runat="server"
                                                                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="GoalMgr_Feed"
                                                                                Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                                Text="+&amp;nbsp;Manager&amp;nbsp;Feedback"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4" colspan="7">
                                                                            <asp:TextBox ID="txt_GoalManagerFeedback" runat="server" Height="54px"
                                                                                MaxLength="4000" meta:resourcekey="txt_GoalManagerFeedbackResource1"
                                                                                TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
                                                                            <br />
                                                                            <telerik:RadRating ID="rdrtg_GoalMgr" runat="server">
                                                                            </telerik:RadRating>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4" colspan="7"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style4" colspan="7">
                                                                            <asp:Button ID="btn_GoalMgrSubmit" runat="server"
                                                                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="btn_GoalMgrSubmit"
                                                                                meta:resourcekey="btn_GoalMgrSubmitResource1" Text="Submit" Visible="False" />
                                                                            <asp:Button ID="btn_GoalMgrupdate" runat="server"
                                                                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="btn_GoalMgrupdate"
                                                                                Text="Update" Visible="False" />
                                                                            &#160;<asp:Button ID="btn_GoalMgrCancel" runat="server"
                                                                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="btn_GoalMgrCancel"
                                                                                meta:resourcekey="btn_GoalMgrCancelResource1" Text="Cancel" Visible="False" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </caption>
                                    </tr>
                                    <caption>
                                        <caption>
                                            <tr>
                                                <td class="style5">
                                                    <asp:Label ID="lbl_GoalAvgRtg" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                        Text="Average&amp;nbsp;Rating"> </asp:Label>
                                                    <telerik:RadNumericTextBox ID="rnt_GoalAvgrtg" runat="server">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                        </caption>
                                        </tr>
                                        <tr>
                                            <td>
                                                <center>
                                                    <asp:Button ID="btn_goalmgrfinalise" runat="server"
                                                        OnClick="btn_goalmgrfinalise_Click" Text="Finalise" />
                                                </center>
                                            </td>
                                        </tr>
                                        <caption>
                                            <caption>
                                                <tr>
                                                    <td align="left" class="style5">
                                                        <asp:LinkButton ID="lnk_Idp" runat="server" Text="+ View IDP">
                                                        </asp:LinkButton>
                                                    </td>
                                                    <caption>
                                                    </caption>
                                                </tr>
                                            </caption>
                                            </tr>
                                            <caption>
                                                <caption>
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <br />
                                                        </td>
                                                        <caption>
                                                        </caption>
                                                    </tr>
                                                </caption>
                                                </tr>
                                                <caption>
                                                </caption>
                                            </caption>
                                        </caption>
                                    </caption>
                                </caption>
        </caption>
        <caption></caption>
        <caption>
        </caption>
    </table>
    </telerik:RadPageView>
    <telerik:RadPageView ID="Rp_Appraisal_Kra_VIEWMAIN" runat="server" Selected="True"
        meta:resourcekey="Rp_Appraisal_Kra_VIEWMAINResource1">
        <table align="center" width="100%">
            <caption>
                <caption>
                    <tr>
                        <td align="center"></td>
                        <caption>
                        </caption>
                    </tr>
                </caption>
                </tr>
        <caption>
            <caption>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblkra" runat="server" Text="KRA Detalis"></asp:Label>
                    </td>
                    <caption>
                    </caption>
                </tr>
            </caption>
            <caption>
                <caption>
                    <tr>
                        <td>
                            <asp:GridView ID="Rg_Appraisal_Kra" runat="server" AutoGenerateColumns="False" meta:resourcekey="Rg_Appraisal_KraResource1"
                                OnRowCommand="Rg_Appraisal_Kra_Command"
                                ShowHeader="False" Width="100%">
                                <Columns>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <table align="center" width="500px">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Kra_Id" runat="server"
                                                            meta:resourcekey="lbl_Kra_IdResource1" Text='<%# Eval("KRA_ID") %>'
                                                            Visible="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Kra_AppraisalCycle" runat="server"
                                                            meta:resourcekey="lbl_Kra_AppraisalCycleResource1"
                                                            Text='<%# Eval("GS_APPRAISAL_CYCLE") %>' Visible="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td><b>Name &#160;:</b>
                                                        <asp:Label ID="lbl_KraName" runat="server"
                                                            meta:resourcekey="lbl_KraNameResource1" Text='<%# Eval("KRA_NAME") %>'></asp:Label></td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                </tr>
                                                <tr>
                                                    <td><b>Timelines &#160;:</b>
                                                        <asp:Label ID="lbl_timelines" runat="server"
                                                            Text='<%# Eval("GS_KRA_TIMELINES") %>'></asp:Label></td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>
                                                        <b>Target &#160;:</b>
                                                        <asp:Label ID="lbl_target" runat="server" Text='<%# Eval("GS_KRA_TARGET") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td><b>Weightage &#160;:</b>
                                                        <asp:Label ID="lbl_KrawEIGHTAGE" runat="server"
                                                            Text='<%# Eval("KRA_WEIGHTAGE") %>'></asp:Label></td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>
                                                        <b>Target Achieved &#160;:</b> <%-- <asp:Label ID="lbl_targetachiev" runat="server" Text='<%# Eval("GS_KRA_TARGET_ACHEIVED") %>'></asp:Label>--%>
                                                        <telerik:RadRating ID="ratingPiekra" runat="server" ItemHeight="20px"
                                                            ItemWidth="20px" SelectionMode="Single">
                                                            <Items>
                                                                <telerik:RadRatingItem HoveredImageUrl="../Images/6.gif"
                                                                    HoveredSelectedImageUrl="../Images/6.gif" ImageUrl="../Images/1.gif"
                                                                    SelectedImageUrl="../Images/6.gif" ToolTip="0%" Value="1" />
                                                                <telerik:RadRatingItem HoveredImageUrl="../Images/7.gif"
                                                                    HoveredSelectedImageUrl="../Images/7.gif" ImageUrl="../Images/2.gif"
                                                                    SelectedImageUrl="../Images/7.gif" ToolTip="25%" Value="2" />
                                                                <telerik:RadRatingItem HoveredImageUrl="../Images/8.gif"
                                                                    HoveredSelectedImageUrl="../Images/8.gif" ImageUrl="../Images/3.gif"
                                                                    SelectedImageUrl="../Images/8.gif" ToolTip="50%" Value="3" />
                                                                <telerik:RadRatingItem HoveredImageUrl="../Images/9.gif"
                                                                    HoveredSelectedImageUrl="../Images/9.gif" ImageUrl="../Images/4.gif"
                                                                    SelectedImageUrl="../Images/9.gif" ToolTip="75%" Value="4" />
                                                                <telerik:RadRatingItem HoveredImageUrl="../Images/10.gif"
                                                                    HoveredSelectedImageUrl="../Images/10.gif" ImageUrl="../Images/5.gif"
                                                                    SelectedImageUrl="../Images/10.gif" ToolTip="100%" Value="5" />
                                                            </Items>
                                                        </telerik:RadRating>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_KraEmployeeComments" runat="server"
                                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="KraEmployee_Feed"
                                                            meta:resourcekey="lnk_KraEmployeeCommentsResource1"
                                                            Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                            Text="+ Employee Comments"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txt_KraEmployeeFeedback" runat="server" Height="77px"
                                                            MaxLength="4000" meta:resourcekey="txt_KraEmployeeFeedbackResource1"
                                                            TextMode="MultiLine" Visible="False" Width="500px"></asp:TextBox></td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                </tr>
                                                <tr>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_KraManagerComments" runat="server"
                                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="KraMgr_Feed"
                                                            Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                            Text="+ Manager Feedback"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txt_KraManagerFeedback" runat="server" Height="77px"
                                                            meta:resourcekey="txt_KraManagerFeedbackResource1" TextMode="MultiLine"
                                                            Visible="False" Width="500px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadRating ID="rdrtg_KraMgr" runat="server" Precision="Item"
                                                            Visible="False" />
                                                    </td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btn_KraMgrSubmit" runat="server"
                                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="btn_KraMgrSubmit"
                                                            meta:resourcekey="btn_KraMgrSubmitResource1" Text="Submit" Visible="False" />
                                                        <asp:Button ID="btn_KraMgrupdate" runat="server"
                                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="btn_KraMgrupdate"
                                                            Text="Update" Visible="False" />
                                                        <asp:Button ID="btn_KraMgrCancel" runat="server"
                                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="btn_KraMgrCancel"
                                                            meta:resourcekey="btn_KraMgrCancelResource1" Text="Cancel" Visible="False" /></td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                    <td>&#160;&#160;</td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </caption>
                <tr>
                    <td>
                        <tr>
                            <%--<td align="right">
                                    <asp:Label ID="lbl_KraAvgRtg" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        runat="server" Text="Average Rating :"></asp:Label>
                                </td>--%>
                            <caption>
                                <tr>
                                    <td class="style5">
                                        <asp:Label ID="lbl_KraAvgRtg" runat="server"
                                            Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                            Text="Average Rating :"></asp:Label>
                                        <telerik:RadNumericTextBox ID="rnt_KraAvgrtg" runat="server"
                                            Enabled="false" NumberFormat-AllowRounding="true">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </caption>
                        </tr>
                    </td>
                </tr>
            </caption>
        </caption>
                <caption>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btn_kramgrfinalise" runat="server" OnClick="btn_kramgrfinalise_Click"
                                Text="Finalise" />
                        </td>
                        <caption>
                        </caption>
                    </tr>
                </caption>
                </tr>
                                    <caption>
                                        <caption>
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:LinkButton ID="LNK_IDP22" runat="server" OnClientClick=" openRadWin('frm_idp.aspx'); return false;"
                                                        Text="+ View IDP"></asp:LinkButton>
                                                </td>
                                                <caption></caption>
                                            </tr>
                                        </caption>
                                        </tr>
                                        <caption></caption>
                                    </caption>
            </caption>
            </caption></caption>
        </table>
    </telerik:RadPageView>
    </telerik:RadMultiPage>
    <%-- <telerik:RadMultiPage ID="Rm_AppraisalDiscussion" runat="server" SelectedIndex="0"
                    meta:resourcekey="Rm_AppraisalDiscussionResource1">
                    <telerik:RadPageView ID="RP_AppraisalDiscussion_ViewDetails" runat="server" meta:resourcekey="RP_AppraisalDiscussion_ViewDetailsResource1"
                        Selected="True">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center">
                                    <center>
                                        <h4>
                                            Appraisal Discussion
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
                                        <asp:Label ID="lbl_Manager" runat="server" Text="Mgr Name" meta:resourcekey="lbl_Manager"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="rcmb_ManagerType" runat="server" Width="200px" meta:resourcekey="rcmb_ManagerTypeResource1"
                                            >
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_ManagerType" ControlToValidate="rcmb_ManagerType"
                                            runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Manager"
                                            InitialValue="Select" meta:resourcekey="rfv_rcmb_ManagerTypeResource1" Text="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_DateofDiscussion" runat="server" Text="Date of Discussion" CssClass="LABELSS"
                                            meta:resourcekey="lbl_DateofDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <telerik:RadDatePicker ID="rdtp_DateofDiscussion" runat="server" meta:resourcekey="rdtp_DateofDiscussionResource1"
                                            >
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelCssClass=""
                                                Width="">
                                            </DateInput>
                                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="rfv_rdtp_DateofDiscussion" runat="server" ControlToValidate="rdtp_DateofDiscussion"
                                            ErrorMessage="Please Enter Date of Discussion" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_DateofDiscussionResource1"
                                            Text="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_EmployeeComments" runat="server" CssClass="LABELSS" Text="Employee Comments"
                                            meta:resourcekey="lbl_EmployeeCommentsResource1"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_EmployeeCommentsAppDiscussion" runat="server" 
                                            TextMode="MultiLine" meta:resourcekey="rtxt_EmployeeCommentsAppDiscussionResource1">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_MgrCommentsAppDiscussion" runat="server" CssClass="LABELSS" Text="Mgr Comments"
                                            meta:resourcekey="lbl_MgrCommentsAppDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_MgrCommentsAppDiscussion" runat="server" 
                                            TextMode="MultiLine" meta:resourcekey="rtxt_MgrCommentsAppDiscussionResource1">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                            Text="Save" ValidationGroup="Controls" />
                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                            Text="Cancel" Visible="False" />
                                        <asp:ValidationSummary ID="vs_AppraisalDiscussion" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </td>
                                </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>--%>
    <%-- <telerik:RadMultiPage ID="Rm_AppraisalDiscussion" runat="server" SelectedIndex="0"
                    meta:resourcekey="Rm_AppraisalDiscussionResource1">
                    <telerik:RadPageView ID="RP_AppraisalDiscussion_ViewDetails" runat="server" meta:resourcekey="RP_AppraisalDiscussion_ViewDetailsResource1"
                        Selected="True">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center">
                                    <center>
                                        <h4>
                                            Appraisal Discussion
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
                                        <asp:Label ID="lbl_Manager" runat="server" Text="Mgr Name" meta:resourcekey="lbl_Manager"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="rcmb_ManagerType" runat="server" Width="200px" meta:resourcekey="rcmb_ManagerTypeResource1"
                                            >
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_ManagerType" ControlToValidate="rcmb_ManagerType"
                                            runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Manager"
                                            InitialValue="Select" meta:resourcekey="rfv_rcmb_ManagerTypeResource1" Text="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_DateofDiscussion" runat="server" Text="Date of Discussion" CssClass="LABELSS"
                                            meta:resourcekey="lbl_DateofDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <telerik:RadDatePicker ID="rdtp_DateofDiscussion" runat="server" meta:resourcekey="rdtp_DateofDiscussionResource1"
                                            >
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelCssClass=""
                                                Width="">
                                            </DateInput>
                                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="rfv_rdtp_DateofDiscussion" runat="server" ControlToValidate="rdtp_DateofDiscussion"
                                            ErrorMessage="Please Enter Date of Discussion" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_DateofDiscussionResource1"
                                            Text="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_EmployeeComments" runat="server" CssClass="LABELSS" Text="Employee Comments"
                                            meta:resourcekey="lbl_EmployeeCommentsResource1"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_EmployeeCommentsAppDiscussion" runat="server" 
                                            TextMode="MultiLine" meta:resourcekey="rtxt_EmployeeCommentsAppDiscussionResource1">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_MgrCommentsAppDiscussion" runat="server" CssClass="LABELSS" Text="Mgr Comments"
                                            meta:resourcekey="lbl_MgrCommentsAppDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_MgrCommentsAppDiscussion" runat="server" 
                                            TextMode="MultiLine" meta:resourcekey="rtxt_MgrCommentsAppDiscussionResource1">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                            Text="Save" ValidationGroup="Controls" />
                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                            Text="Cancel" Visible="False" />
                                        <asp:ValidationSummary ID="vs_AppraisalDiscussion" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </td>
                                </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>--%>
    </td> </tr> </table>
</asp:Content>