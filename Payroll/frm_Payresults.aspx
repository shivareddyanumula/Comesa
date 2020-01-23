<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Payresults.aspx.cs" Inherits="Payroll_frm_Payresults" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="cnt_frm_Payresults" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_OCcalc" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcmb_BUI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodMaster">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodElement">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function ShowResult(buID, prdID, mnth) {
                var win = window.radopen('../Payroll/Result.aspx?SRBUID=' + buID + "&SRPRDID=" + prdID + "&SRMNTH=" + mnth, "rwResult");
                win.center();
                win.set_modal(true);
            }

        </script>

        <script type="text/javascript">
            function ShowPop(url, ID, status, sal, TRID) {
                var win = window.radopen('../Payroll/frm_SalDetails.aspx?ID=' + url + '&PDID=' + ID + '&Status=' + status + '&sal=' + sal + '&Trid=' + TRID, "RW_SalDetails");
                win.center();
                win.set_modal(true);
            }

        </script>
        <script type="text/javascript">
            function ShowProvisional(EMPID, PRD, BU, PRDDTL, ORG) {
                var win = window.radopen('../Reportss/frmPreApprovalPayReport.aspx?EMPID=' + EMPID + '&PRD=' + PRD + '&BU=' + BU + '&PRDDTL=' + PRDDTL + '&ORG=' + ORG, "RadWindow1");
                win.center();
                win.set_modal(true);
                win.set_title("Provisional Pay Slip");
                win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
            }

        </script>
        <script type="text/javascript">
            function ShowPop_Pending(url, ID, BU, prddtl, paytran, Localisation) {
                var win = window.radopen('../Reportss/PreApprovalPayRegisterReport.aspx?PRD=' + url + '&ORG=' + ID + '&BU=' + BU + '&PRDDTL=' + prddtl + '&PAYTRAN=' + paytran + '&Localisation=' + Localisation, "RadWindow1");
                win.center();
                win.set_modal(true);
                win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
            }
        </script>



        <script type="text/javascript">
            function ShowPop_Approved(url, ID, BU, prddtl, paytran, Localisation) {
                var win = window.radopen('../Reportss/PayRegisterRowReport.aspx?PRD=' + url + '&ORG_ID=' + ID + '&BU=' + BU + '&PRDDTL=' + prddtl + '&PAYTRAN=' + paytran + '&Localisation=' + Localisation, "RadWindow1");
                win.center();
                win.set_modal(true);
                win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
            }
        </script>

    </telerik:RadScriptBlock>
    <script type="text/javascript" src="../maintainScrollPosition_IE.js"></script>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PayTransact" runat="server" Text="Payroll Results" meta:resourcekey="lbl_PayTransact" Font-Bold="true"></asp:Label>
                <td colspan="3" align="center" style="font-weight: bold;"></td>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Width="990px"
                    Height="490px" ScrollBars="Auto" meta:resourcekey="Rm_CY_page">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" meta:resourcekey="Rp_CY_ViewMain"
                        Selected="True">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" AutoPostBack="true" meta:resourcekey="rcmb_BUI" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BUI_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI" InitialValue="Select"
                                        ErrorMessage="Business Unit is a Mandatory Field" meta:resourcekey="rfv_rcmb_BUI"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodMaster" runat="server" meta:resourcekey="lbl_PeriodMaster"
                                        Text="Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_PeriodMaster" runat="server" AutoPostBack="True" meta:resourcekey="rcmb_PeriodMaster" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_PeriodMaster_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodMaster" runat="server" ControlToValidate="rcmb_PeriodMaster" InitialValue="Select"
                                        ErrorMessage="Period is Mandatory" meta:resourcekey="rfv_rcmb_PeriodMaster" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodElement" runat="server" meta:resourcekey="lbl_PeriodElement"
                                        Text="Period Element"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_PeriodElement" runat="server" AutoPostBack="True" meta:resourcekey="rcmb_PeriodElement" InitialValue="Select"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_PeriodElement_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodElement" runat="server" ControlToValidate="rcmb_PeriodElement"
                                        ErrorMessage="Period Element is Mandatory" meta:resourcekey="rfv_rcmb_PeriodElement"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodStatus" runat="server" meta:resourcekey="lbl_PeriodStatus"
                                        Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_PeriodStatus" runat="server" AutoPostBack="True" meta:resourcekey="rcmb_PeriodStatus"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_PeriodStatus_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="Pending" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Text="Rejected" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="Approved" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Trasaction" runat="server" Text="Transaction"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_Transaction" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcb_Transaction_SelectedIndexChanged"
                                        MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Button runat="server" ID="btnShowResult" Text="Show Result" ValidationGroup="Controls" OnClick="btnShowResult_Click" />
                                </td>
                                <td></td>
                                <td align="left">
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:LinkButton ID="lnk" runat="server" OnClick="lnk_Click" Text="Click here to see Pre-Payroll Approval Details" Visible="false"></asp:LinkButton>
                                    <br />
                                    <asp:LinkButton ID="lnk_Approved" runat="server"
                                        Text="Click here to see Post-Payroll Approval Details" Visible="false"
                                        OnClick="lnk_Approved_Click"></asp:LinkButton>
                                </td>

                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="left" colspan="3">
                                    <telerik:RadGrid ID="Rg_PayReults" runat="server" AutoGenerateColumns="false" GridLines="None"
                                        meta:resourcekey="Rg_PayReults" Skin="WebBlue" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMP_ID" HeaderText="EMP_ID" UniqueName="EMP_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" HeaderText="Employee Name" UniqueName="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPDOJ" HeaderText="Date Of Join" UniqueName="EMPDOJ" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Position" UniqueName="POSITIONS_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CURR_CODE" HeaderText="Currency" UniqueName="CURR_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SALARY" HeaderText="Salary" UniqueName="SALARY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Grade">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SAL_FLAG" UniqueName="SAL_FLAG" HeaderText="Flag" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn>
                                                    <ItemTemplate>
                                                        <u>
                                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                                                CommandName='<%# Eval("SALARY") %>' OnCommand="lnk_Edit_Command" Text="View&nbsp;Details"></asp:LinkButton>
                                                        </u>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn>
                                                    <ItemTemplate>
                                                        <u>
                                                            <asp:LinkButton ID="lnk_View" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                                                CommandName='<%# Eval("SALARY") %>' OnCommand="lnk_View_Command" Text="View&nbsp;Provisional&nbsp;Slip" Visible="false"></asp:LinkButton>
                                                        </u>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="vs_PayResults" runat="server" meta:resourcekey="vs_PayResults"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server" meta:resourcekey="Rp_CY_ViewDetails">
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>