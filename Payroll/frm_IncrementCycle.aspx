<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_IncrementCycle.aspx.cs" Inherits="Payroll_frm_IncrementCycle" %>


<asp:Content ID="cnt_IncrementCycle" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_IncrementCycle" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_IncrementCycle">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_IncrementCycleHeader" runat="server" Text="Increment Cycle" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_IncrementCycle" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_IncrementCycle_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="PERIOD_ID" UniqueName="PERIOD_ID" HeaderText="PERIOD_ID"
                                                            meta:resourcekey="PERIOD_ID" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME" HeaderText="Financial Period"
                                                            meta:resourcekey="PERIOD_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERIOD_STARTDATE" UniqueName="PERIOD_STARTDATE" HeaderText="Start Date"
                                                            meta:resourcekey="PERIOD_STARTDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERIOD_ENDDATE" UniqueName="PERIOD_ENDDATE" HeaderText="End Date"
                                                            meta:resourcekey="PERIOD_ENDDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="INCREMENTCYCLE_MONTH" UniqueName="INCREMENTCYCLE_MONTH" HeaderText="No of Cycles"
                                                            meta:resourcekey="INCREMENTCYCLE_MONTH">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PERIOD_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                            UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger ControlID="btn_Imp_Businessunit" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="40%">
                            <tr>
                                <td>Financial Period
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_FinPeriod" runat="server" meta:resourcekey="rcmb_FinPeriod" Enabled="false" DataTextField="PERIOD_NAME" DataValueField="PERIOD_ID" AutoPostBack="true" OnSelectedIndexChanged="rcmb_FinPeriod_SelectedIndexChanged"
                                        Skin="WebBlue" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_FinPeriod" runat="server" ControlToValidate="rcmb_FinPeriod"
                                        ErrorMessage="Please Select Financial Period" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>No of Cycle
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Cycles" runat="server" meta:resourcekey="rcmb_Cycles" Enabled="false" TabIndex="2"
                                        Skin="WebBlue">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem Text="2" Value="2" />
                                            <telerik:RadComboBoxItem Text="3" Value="3" />
                                            <telerik:RadComboBoxItem Text="4" Value="4" />
                                            <telerik:RadComboBoxItem Text="6" Value="6" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Cycles" runat="server" ControlToValidate="rcmb_Cycles"
                                        ErrorMessage="Please Select Cycle" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Generate" runat="server" OnClick="btnGenerate_Click" Text="Generate" ValidationGroup="Controls" TabIndex="3" />
                                    <asp:Button ID="btn_GenerateCancel" runat="server" OnClick="btn_GenerateCancel_Click" Text="Cancel" TabIndex="4" />
                                    <asp:ValidationSummary ID="ValidationSummaryGenerate" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr id="tr_GenerateCycles" runat="server" visible="false">
                                <td colspan="4" align="center">
                                    <br />

                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="rg_FinCycles" runat="server" AutoGenerateColumns="False"
                                                    GridLines="None" Skin="WebBlue" OnNeedDataSource="rg_FinCycles_NeedDataSource"
                                                    AllowPaging="True" AllowFilteringByColumn="true">
                                                    <MasterTableView CommandItemDisplay="None">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="PERIODID" UniqueName="PERIODID" HeaderText="ID"
                                                                meta:resourcekey="PERIODID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SRNO" UniqueName="SRNO" HeaderText="Sr No"
                                                                meta:resourcekey="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="STARTMONTH_ID" UniqueName="STARTMONTH_ID" HeaderText="STARTMONTH_ID"
                                                                meta:resourcekey="STARTMONTH_ID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="StartMonth" UniqueName="StartMonth" HeaderText="Start Month"
                                                                meta:resourcekey="StartMonth">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ENDMONTH_ID" UniqueName="ENDMONTH_ID" HeaderText="ENDMONTH_ID"
                                                                meta:resourcekey="ENDMONTH_ID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EndMonth" UniqueName="EndMonth" HeaderText="End Month"
                                                                meta:resourcekey="EndMonth">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle AlwaysVisible="True" />
                                                    <FilterMenu Skin="WebBlue">
                                                    </FilterMenu>
                                                    <HeaderContextMenu Skin="WebBlue">
                                                    </HeaderContextMenu>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <br />
                                                <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="5"
                                                    Text="Save" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                                <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="6"
                                                    Text="Cancel" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>

    </table>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
</asp:Content>--%>