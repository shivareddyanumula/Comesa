<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_InsuranceTransferFunds.aspx.cs" Inherits="Payroll_frm_InsuranceTransferFunds" %>

<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="padding-top: 2%">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                    Text="Insurance Transfer Amount"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rm_MR_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="RP_GRIDVIEW" runat="server" meta:resourcekey="RP_GRIDVIEW" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_transferfunds" runat="server" Skin="WebBlue" GridLines="None"
                                        AutoGenerateColumns="False" OnNeedDataSource="RG_transferfunds_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="True" AllowSorting="True">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TransferFundsID" HeaderText="" UniqueName="TransferFundsID"
                                                    Visible="False" FilterControlWidth="100px">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit" UniqueName="BUSINESSUNIT_CODE" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" HeaderText="Employee" UniqueName="EMPNAME" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" HeaderText="PayItem" UniqueName="PAYITEM_PAYITEMNAME" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="TransferFundsAmount" HeaderText="Transferred Amount"
                                                    UniqueName="TransferFundsAmount" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Incident_Edit" runat="server" CommandName="EditRec"
                                                            CommandArgument='<%# Eval("TransferFundsID") %>'
                                                            meta:resourcekey="lnk_Incident_EditResource1" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                    InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add"
                                                        OnClick="lnk_Add_Click"> Add</asp:LinkButton>
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_FORMVIEW" runat="server" meta:resourcekey="RP_FORMVIEW">
                        <table align="center">
                            <tr>
                                <td colspan="3" style="width: 150px;">
                                    <uc1:BUFilter runat="server" ID="BUFilter1" OnBUFilterRadEmployee_SelectedIndexChanged="BUFilter1Emp_SelectedIndexChanged" ShowBusinessUnitSpan="true" ShowEmployeeSpan="true" />
                                    <asp:RequiredFieldValidator ID="rfvBUFilter1Emp" runat="server" ControlToValidate="BUFilter1$RadEmployee"
                                        ErrorMessage="Please Select Employee" ValidationGroup="Controls" Display="None" InitialValue="Select"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvBUFilter1BU" runat="server" ControlToValidate="BUFilter1$RadBusinessUnit"
                                        ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" Display="None" EnableClientScript="true" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 154px">
                                    <asp:Label ID="lbl_payitem" runat="server" Text="pay Item"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_payitem" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_payitem_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfvpayitem" runat="server" ErrorMessage="Please Select pay Item"
                                        ControlToValidate="rcmb_payitem" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px">
                                    <asp:Label ID="lbl_AmountTransfer" runat="server" Text="Amount to Transfer"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rtxt_amounttransfer" runat="server" Enabled="false" EnableEmbeddedSkins="false" MaxLength="8">
                                    </telerik:RadNumericTextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter amount to transfer" Display="Dynamic" ControlToValidate="rtxt_amounttransfer"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnSave_Click" Text="Update" Visible="False"
                                        ValidationGroup="Controls" Width="61px"
                                        meta:resourcekey="btnEdit" CausesValidation="true" />
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Visible="False"
                                        ValidationGroup="Controls" meta:resourcekey="btnSave" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="5"
                                        OnClick="btnCancel_Click" meta:resourcekey="btnCancel" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vsIns" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vsIncidentMaster" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>