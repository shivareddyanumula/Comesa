<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_YTDOpeningBalances.aspx.cs" Inherits="Payroll_frm_YTDOpeningBalances" %>

<asp:Content ID="cnt_YTDOB" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy runat="server" ID="RAM_Employee">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Period">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodElements">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Payitem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Btn_Finalize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_YTDHeader" runat="server" Text="YTD Opening Balances" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr align="center">
            <td>
                <telerik:RadMultiPage ID="Rm_YTDOB_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px">
                    <telerik:RadPageView ID="Rp_YTDob_ViewMain" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BU" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" AutoPostBack="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        ErrorMessage="Please Select Business Unit" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                                </td>
                                <td style="height: 17px">&nbsp;
                                </td>
                                <td style="height: 17px">
                                    <telerik:RadComboBox ID="rcmb_Period" runat="server" AutoPostBack="True" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Period" runat="server" ControlToValidate="rcmb_Period"
                                        ErrorMessage="Please Select Period" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="tr_prdtl" runat="server" visible="false">
                                <td align="left">
                                    <asp:Label ID="lbl_Period_Elements" runat="server" Text="Period&amp;nbsp;Elements"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PeriodElements" runat="server" AutoPostBack="True" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_PeriodElements_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodElements" runat="server" ControlToValidate="rcmb_PeriodElements"
                                        ErrorMessage="Please Select Period Elements" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PayItem" runat="server" Text="Pay Item"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Payitem" runat="server" AutoPostBack="True" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Payitem_SelectedIndexChanged" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_payitem" runat="server" ControlToValidate="rcmb_Payitem"
                                        ErrorMessage="Please Select Payitem" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_YTDOB" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_YTD_OpeningBalance_NeedDataSource"
                                        AllowPaging="false" ClientSettings-Scrolling-AllowScroll="true">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="YTD_ID" UniqueName="YTD_ID" HeaderText="YTD Id"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <%--     <telerik:GridTemplateColumn HeaderText="YTD Id">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_Ytd_Id" runat="server"   >
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" HeaderText="Employee Id"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_EMPCODE" UniqueName="EMP_EMPCODE " HeaderText="Employee Code">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" UniqueName="EMPNAME" HeaderText="Employee Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="POSITIONS_CODE" UniqueName="POSITIONS_CODE "
                                                    HeaderText="Designation">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--  <telerik:GridBoundColumn DataField="YTD_OLDBALANCE" UniqueName="YTD_OLDBALANCE" HeaderText="Old Balance">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn HeaderText="Existing Balance">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txt_oldbalance" runat="server" Text='<%# Convert.ToDouble(Eval("YTD_OLDBALANCE")) %>'
                                                            ReadOnly="true">
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="New Balance">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rnt_NewBal" runat="server" Text='<%# Convert.ToDouble(Eval("YTD_NEWBALANCE")) %>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ActiveItemStyle HorizontalAlign="Center" />
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="center" colspan="3">&nbsp;<asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click"
                                    Visible="false" Width="75px" ValidationGroup="Controls" />
                                    &nbsp;<asp:Button ID="Btn_Finalize" runat="server" Text="Finalize" OnClick="Btn_Finalize_Click"
                                        Visible="false" Width="75px" ValidationGroup="Controls" />
                                    &nbsp;<asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click"
                                        Visible="false" Width="75px" />
                                    <asp:ValidationSummary ID="vs_YTD" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>