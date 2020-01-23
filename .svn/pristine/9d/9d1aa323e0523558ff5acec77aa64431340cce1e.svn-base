<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_IntrstOnNormlContribution.aspx.cs" Inherits="Pension_frm_IntrstOnNormlContribution" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Heading" runat="server" Text="Interest On Normal Contributions" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_IntrstOnNormalContributions" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_IntrstOnNormalContributions" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_IntrstOnNormalContributions_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="PNCN_ID" UniqueName="PNCN_ID" HeaderText="ID"
                                                            meta:resourcekey="PNCN_ID" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME" HeaderText="Financial Year"
                                                            meta:resourcekey="PERIOD_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PNCN_QRTR1" UniqueName="PNCN_QRTR1" HeaderText="Quarter 1"
                                                            meta:resourcekey="PNCN_QRTR1">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="PNCN_QRTR2" UniqueName="PNCN_QRTR2" HeaderText="Quarter 2"
                                                            meta:resourcekey="PNCN_QRTR2">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PNCN_QRTR3" UniqueName="PNCN_QRTR3" HeaderText="Quarter 3"
                                                            meta:resourcekey="PNCN_QRTR3">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PNCN_QRTR4" UniqueName="PNCN_QRTR4" HeaderText="Quarter 4"
                                                            meta:resourcekey="PNCN_QRTR4">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PNCN_YEARLY_INTEREST" UniqueName="PNCN_YEARLY_INTEREST" HeaderText="Yearly Interest"
                                                            meta:resourcekey="PNCN_YEARLY_INTEREST">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PNCN_ID") %>'
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
                    <telerik:RadPageView ID="Rp_IntrstOnNormalContributions" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td colspan="3" align="center" style="font-weight: bold;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblPNCN_ID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblFinancialYear" runat="server" Text="Financial Year"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_FinancialYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_FinancialYear_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                                            <%--<asp:RequiredFieldValidator ID="rfv_rcmb_FinancialYear" runat="server" Text="*"
                                                ControlToValidate="rcmb_FinancialYear" InitialValue="Select"
                                                Display="Dynamic" ErrorMessage="Please Select Financial Year"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr id="trQrtr1" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lblQrtr1" runat="server" Text="Quarter 1"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Qrtr1" runat="server" MaxValue="100" MinValue="0" Type="Percent"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Qrtr1" runat="server" Text="*" ControlToValidate="rtxt_Qrtr1" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Enter Interest for Quarter1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trQrtr2" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lblQrtr2" runat="server" Text="Quarter 2"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Qrtr2" runat="server" MaxValue="100" MinValue="0" Type="Percent"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Qrtr2" runat="server" Text="*" ControlToValidate="rtxt_Qrtr2" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Enter Interest for Quarter2"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trQrtr3" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lblQrtr3" runat="server" Text="Quarter 3"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Qrtr3" runat="server" MaxValue="100" MinValue="0" Type="Percent"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Qrtr3" runat="server" Text="*" ControlToValidate="rtxt_Qrtr3" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Enter Interest for Quarter3"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trQrtr4" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lblQrtr4" runat="server" Text="Quarter 4"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Qrtr4" runat="server" MaxValue="100" MinValue="0" Type="Percent"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Qrtr4" runat="server" Text="*" ControlToValidate="rtxt_Qrtr4" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Enter Interest for Quarter4"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <%--<asp:PlaceHolder ID="phQuarters" runat="server"></asp:PlaceHolder>--%>
                                            <asp:Panel ID="phQuarters" runat="server"></asp:Panel>
                                        </td>
                                    </tr>
                                    <tr id="trYearlyIntrst" runat="server">
                                        <td>
                                            <asp:Label ID="lblYearlyInterest" runat="server" Text="Yearly Interest"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_YearlyInterest" runat="server" MaxValue="100" MinValue="0" Type="Percent"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_YearlyInterest" runat="server" Text="*" ControlToValidate="rtxt_YearlyInterest" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Enter Yearly Interest"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <%-- <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblRegistered" runat="server" Text="Registered"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Registered" runat="server" Type="Percent" MinValue="0" MaxValue="100"></telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Registered" runat="server" ControlToValidate="rtxt_Registered" ValidationGroup="Controls" ErrorMessage="Please Enter Interest % for Registered Account" Text="*"></asp:RequiredFieldValidator>
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
                                    </tr>--%>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" CausesValidation="false"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_IntrstOnNormalContributions" runat="server" ShowMessageBox="True" ShowSummary="False"
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