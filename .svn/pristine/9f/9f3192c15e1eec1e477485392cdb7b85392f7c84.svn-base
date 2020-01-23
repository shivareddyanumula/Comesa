<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_IntrstOnRegUnRegAcct.aspx.cs" Inherits="Pension_frm_IntrstOnRegUnRegAcct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Heading" runat="server" Text="Interest On Registered and UnRegistered Accounts" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_IntrstOnRegstUnRegstAcct" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_IntrstOnRegstUnRegstAcct" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_IntrstOnRegstUnRegstAcct_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="INT_ID" UniqueName="INT_ID" HeaderText="ID"
                                                            meta:resourcekey="INT_ID" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME" HeaderText="Financial Year"
                                                            meta:resourcekey="PERIOD_NAME" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridNumericColumn DataField="INT_NORMAL_AMT" UniqueName="INT_NORMAL_AMT" HeaderText="Normal"
                                                            meta:resourcekey="INT_NORMAL_AMT" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridNumericColumn DataField="INT_REGISTERED_AMT" UniqueName="INT_REGISTERED_AMT" HeaderText="Registered"
                                                            meta:resourcekey="INT_REGISTERED_AMT" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridNumericColumn DataField="INT_UNREGISTERED_AMT" UniqueName="INT_UNREGISTERED_AMT" HeaderText="UnRegistered" meta:resourcekey="INT_UNREGISTERED_AMT" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("INT_ID") %>'
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
                                    <tr>
                                        <td>

                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                    <td></td>
                                                </tr>

                                            </table>

                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_IntrstOnRegstUnRegstAcct" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td colspan="3" align="center" style="font-weight: bold;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblInterestID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblFinancialYear" runat="server" Text="Financial Year"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_FinancialYear" runat="server" ValidationGroup="Controls" Filter="Contains"></telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_FinancialYear" runat="server" Text="*"
                                                ControlToValidate="rcmb_FinancialYear" ValidationGroup="Controls" InitialValue="Select"
                                                Display="Dynamic" ErrorMessage="Please Select Financial Year"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblNormal" runat="server" Text="Normal"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Normal" runat="server" Type="Percent" MinValue="0" MaxValue="100"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Normal" runat="server" ControlToValidate="rtxt_Normal" ValidationGroup="Controls" ErrorMessage="Please Enter Interest % for Normal Account" Text="*"></asp:RequiredFieldValidator>

                                            <%--<telerik:RadNumericTextBox ID="radPensionIDNo" runat="server" Skin="WebBlue" MaxLength="7" MinValue="0"
                                                NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="">
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_ExpenditureName" runat="server" Text="*"
                                                ControlToValidate="radPensionIDNo" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter ID Number"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblRegistered" runat="server" Text="Registered"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Registered" runat="server" Type="Percent" MinValue="0" MaxValue="100"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Registered" runat="server" ControlToValidate="rtxt_Registered" ValidationGroup="Controls" ErrorMessage="Please Enter Interest % for Registered Account" Text="*"></asp:RequiredFieldValidator>

                                            <%--<telerik:RadNumericTextBox ID="radPensionIDNo" runat="server" Skin="WebBlue" MaxLength="7" MinValue="0"
                                                NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="">
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_ExpenditureName" runat="server" Text="*"
                                                ControlToValidate="radPensionIDNo" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter ID Number"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUnRegistered" runat="server" Text="UnRegistered"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_UnRegistered" runat="server" Type="Percent" MinValue="0" MaxValue="100"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_UnRegistered" runat="server" ControlToValidate="rtxt_UnRegistered" ValidationGroup="Controls" ErrorMessage="Please Enter Interest % for UnRegistered Account" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_IntrstOnRegstUnRegstAcct" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>

                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />
                                <asp:PostBackTrigger ControlID="btn_Update" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>