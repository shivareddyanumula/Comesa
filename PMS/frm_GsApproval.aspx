<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_GsApproval.aspx.cs" Inherits="PMS_frm_GsApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function ShowPop(EMP_ID, APPCYCLE_ID, STR) {
                var win = window.radopen('../PMS/frm_EMPAppraisalDetails.aspx?EMP_ID=' + EMP_ID + '&APPCYCLE_ID= ' + APPCYCLE_ID + '&STR= ' + STR, "RW_EMPAppraisalDetails");
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }
        </script>
    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Appr" runat="server" Text="Goal Setting Approval" Font-Bold="true"></asp:Label>
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

                                    <table align="center">
                                        <tr>
                                            <td colspan="3" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_BU" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true"
                                                    MaxHeight="120px" AutoPostBack="True" Filter="Contains"
                                                    OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_BU" ControlToValidate="rcmb_BU"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit"
                                                    InitialValue="Select">*</asp:RequiredFieldValidator>
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
                                                <telerik:RadComboBox ID="rtxt_AppraisalCycle" runat="server" Filter="Contains"
                                                    MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="rtxt_AppraisalCycle_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                                <asp:Label ID="lbl_type_text" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lbl_rolekra" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_RpMgr" runat="server" Text="Reporting Manager" meta:resourcekey="lbl_RpMgrResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcmb_RpMgr" runat="server" Filter="Contains"
                                                    MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="True" OnSelectedIndexChanged="rcmb_RpMgr_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <asp:Label ID="lbl_final" Visible="false" runat="server"></asp:Label>
                                        </tr>
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </table>

                                    <table align="center">
                                        <tr>
                                            <td align="center">
                                                <telerik:RadGrid ID="RG_ApprAppraisal" runat="server" AutoGenerateColumns="False"
                                                    GridLines="None" AllowFilteringByColumn="False" Width="700px" ClientSettings-Scrolling-AllowScroll="true"
                                                    ClientSettings-Scrolling-UseStaticHeaders="true">
                                                    <MasterTableView TableLayout="Fixed">
                                                        <Columns>
                                                            <telerik:GridBoundColumn HeaderText="EMP_ID" DataField="EMP_ID" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="GS_ID" DataField="GS_ID" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                                        Text="Check All" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMPLOYEE_NAME">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Designation" DataField="POSITIONS_CODE">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Scale" DataField="HR_MASTER_CODE">
                                                            </telerik:GridBoundColumn>
                                                            <%--<telerik:GridBoundColumn HeaderText="Project" DataField="PROJECT_NAME" >
                                                                </telerik:GridBoundColumn>--%>
                                                            <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_ViewDetails" runat="server" CommandArgument='<%# Eval("EMP_ID") %>' OnCommand="lnk_ViewDetailsCommand"
                                                                        meta:resourcekey="lnk_ViewDetails">View Details</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                    <table align="center">
                                        <tr id="tr_btns" runat="server">
                                            <td align="center" colspan="3">
                                                <asp:Button ID="btn_Approve" runat="server" Text="Approve"
                                                    OnClick="btn_Approve_Click" OnClientClick="disableButton(this,'')" UseSubmitBehavior="false" />
                                                <asp:Button ID="btn_Reject" runat="server" Text="Reject"
                                                    OnClick="btn_Reject_Click" OnClientClick="disableButton(this,'')" UseSubmitBehavior="false" />
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