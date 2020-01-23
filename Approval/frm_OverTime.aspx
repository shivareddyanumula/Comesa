<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_OverTime.aspx.cs" Inherits="Approval_frm_OverTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 1014px; overflow: auto;">
                    <telerik:RadMultiPage ID="Rm_AOT_page" runat="server" SelectedIndex="0" 
                         Width="990px" Height="490px" ScrollBars="Auto" meta:resourcekey="Rm_OT_page">
                        <telerik:RadPageView ID="Rp_AOT_ViewMain" runat="server" Selected="True">
                            <table align="center">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lbl_OTApproval" runat="server" meta:resourcekey="lbl_OTApproval" Style="font-weight: 700"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <table align="center">
                                            <tr style="display: none">
                                                <td>
                                                    <asp:Label ID="lbl_ReportingMgr" runat="server" meta:resourcekey="lbl_ReportingMgr"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox  ID="rtxt_ReportingMgr"  Skin="WebBlue"  runat="server"
                                                        Width="125px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_ApprovalDate" runat="server" meta:resourcekey="lbl_ApprovalDate"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker   ID="rdp_ApprovalDate"  Skin="WebBlue"  runat="server">
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:Button ID="btn_Approve" runat="server" meta:resourcekey="btn_Approve" OnClick="btn_Approve_Click" />
                                                    <asp:Button ID="btn_Reject" runat="server" meta:resourcekey="btn_Reject" OnClick="btn_Reject_Click" />
                                                    <asp:Button ID="btn_refresh" Text = "Cancel" runat="server" meta:resourcekey="btn_refresh" OnClick="btn_Refresh_Click" />
                                                   
                                                </td>
                                                
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid  ID="RG_OTpproval" runat="server"  Skin="WebBlue"  GridLines="None"
                                            AutoGenerateColumns="False">
                                            <HeaderContextMenu  Skin="WebBlue" >
                                            </HeaderContextMenu>
                                            <MasterTableView>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk_Choose" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="EPMLOYEE&nbsp;ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempName" runat="server" Text='<%# Eval("EMPLOYEENAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                   <%-- <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>--%>
                                                     <telerik:GridBoundColumn DataField="EMP_GRADE" UniqueName="EMP_GRADE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="OTCALC_ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_id" runat="server" Text='<%# Eval("OTCALC_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <%--<telerik:GridTemplateColumn HeaderText="Leave&nbsp;Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempLeave" runat="server" Text='<%# Eval("HR_MASTER_DESC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>--%>
                                                   <%-- <telerik:GridTemplateColumn HeaderText="OT&nbsp;Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_date" runat="server" Text='<%# Eval("OVERTIME DATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>--%>
                                                     <telerik:GridTemplateColumn HeaderText="OT&nbsp;Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_date" runat="server" Text='<%# Eval("OVERTIME_DATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="OT&nbsp;Hours">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_hours" runat="server" Text='<%# Eval("OTCALC_WORKINGHOURS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_status" runat="server" Text='<%# Eval("OTCALC_STATUS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Month" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_prddtl_ID" runat="server" Text='<%# Eval("OTCALC_PERIODDTL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="BusinessUnit" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempottrans_BU_ID" runat="server" Text='<%# Eval("OTCALC_BUID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <%--<telerik:GridTemplateColumn UniqueName="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("OTCALC_ID") %>' 
                                                                OnCommand="lnk_Edit_Command">Edit
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>--%>
                                                </Columns>
                                            </MasterTableView>
                                            <FilterMenu  Skin="WebBlue" >
                                            </FilterMenu>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="Rp_AOT_ViewDetails" runat="server">
                            <table align="center" width="40%">
                                <tr>
                                    <td colspan="3" align="center" style="font-weight: bold;">
                                        <asp:Label ID="lbl_OTDetDetails" runat="server" Text="OT Details" meta:resourcekey="lbl_OTDetDetails"></asp:Label>
                                    </td>
                                    <td align="center" style="font-weight: bold;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OTDetID" runat="server" Visible="False" meta:resourcekey="lbl_OTDetID"></asp:Label>
                                        <asp:Label ID="lbl_OTDetEmpName" runat="server" Text="Employee&nbsp;Name" meta:resourcekey="lbl_OTDetEmpName"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadComboBox  ID="rcmb_OTDetEmployeeID" runat="server" AutoPostBack="True"
                                             Skin="WebBlue"  OnSelectedIndexChanged="rcmb_OTDetEmployeeID_SelectedIndexChanged"
                                            meta:resourcekey="rcmb_OTDetEmployeeID" Enabled="false" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetEmployeeID" runat="server" ControlToValidate="rcmb_OTDetEmployeeID"
                                            InitialValue="Select" ErrorMessage="Select a Employee" Text="*" ValidationGroup="Controls"
                                            meta:resourcekey="rfv_rcmb_OTDetEmployeeID"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OTDetOTType" runat="server" Text="OT Type" meta:resourcekey="lbl_OTDetOTType"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadComboBox  ID="rcmb_OTDetOTType" runat="server"  Skin="WebBlue" 
                                            meta:resourcekey="rcmb_OTDetOTType" Enabled="false" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetOTType" runat="server" ControlToValidate="rcmb_OTDetOTType"
                                            InitialValue="Select" ErrorMessage="Select a OT Type" Text="*" ValidationGroup="Controls"
                                            meta:resourcekey="rfv_rcmb_OTDetOTType"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OTDetPeriodMain" runat="server" meta:resourcekey="lbl_OTDetPeriodMain"
                                            Text="Period"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadComboBox  ID="rcmb_OTDetPeriodMain" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="rcmb_OTDetPeriodMain_SelectedIndexChanged"  Skin="WebBlue" 
                                            meta:resourcekey="rcmb_OTDetPeriodMain" Enabled="false" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetPeriodMain" runat="server" ControlToValidate="rcmb_OTDetPeriodMain"
                                            ErrorMessage="Select a Main Period " InitialValue="Select" Text="*" ValidationGroup="Controls"
                                            meta:resourcekey="rfv_rcmb_OTDetPeriodMain"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OTDetPeriodDetails" runat="server" meta:resourcekey="lbl_OTDetLType"
                                            Text="Period Details"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadComboBox  ID="rcmb_OTDetPeriodDetails" runat="server"  Skin="WebBlue" 
                                            meta:resourcekey="rcmb_OTDetPeriodDetails" Enabled="false" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetPeriodDetails" runat="server" ControlToValidate="rcmb_OTDetPeriodDetails"
                                            ErrorMessage="Select a Period Detail" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_OTDetPeriodDetails"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OTDetOTDate" runat="server" meta:resourcekey="lbl_OTDetOTDate"
                                            Text="OT Date"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker   ID="rdtp_OTDetOTDate" runat="server"  Skin="WebBlue" >                                            
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rdtp_OTDetOTDate" runat="server" ControlToValidate="rdtp_OTDetOTDate"
                                            ErrorMessage="OT Date cannot be Empty" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_OTDetOTDate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OTDetOTHours" runat="server" meta:resourcekey="lbl_OTDetOTHours"
                                            Text="No of Hours"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox  ID="rtxt_OTDetOTHours" runat="server"  Skin="WebBlue"  MinValue="0" MaxLength="12"
                                            Culture="English (United States)" LabelCssClass="" meta:resourcekey="rtxt_OTDetOTHours">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rtxt_OTDetOTHours" runat="server" ControlToValidate="rtxt_OTDetOTHours"
                                            ErrorMessage="No of Hours Cannot be Empty" Text="*" ValidationGroup="Controls"
                                            meta:resourcekey="rfv_rtxt_OTDetOTHours"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                            Text="Update" ValidationGroup="Controls" Visible="False" />
                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                            Text="Save" ValidationGroup="Controls" Visible="False" />
                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                            Text="Cancel" />
                                        <asp:ValidationSummary ID="vs_OTDet" runat="server" ShowMessageBox="True" ShowSummary="False"
                                            ValidationGroup="Controls" meta:resourcekey="vs_OTDet" />
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
