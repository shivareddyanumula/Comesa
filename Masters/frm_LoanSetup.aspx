<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_LoanSetup.aspx.cs" Inherits="Masters_frm_LoanSetup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <style type="text/css">
        .setWidth {
            width: 75px !important;
        }
    </style>

    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 1014px; overflow: auto;">
                    <table align="center">
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_LoanSetup" runat="server" Text="Loan Setup" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left">
                                            <asp:Label ID="Label1" runat="server" Visible="False" meta:resourcekey="lblTrainigRequestId"></asp:Label>
                                            <asp:Label ID="lbl_financialPeriod" runat="server" Text="Finalical Period" meta:resourcekey="lbl_financialPeriod"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rc_financialPeriod" runat="server" Skin="WebBlue" AutoPostBack="true"
                                                OnSelectedIndexChanged="rc_FinalicalPeriod_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_financialPeriod" runat="server" ControlToValidate="rc_financialPeriod"
                                                meta:resourcekey="rfv_financialPeriod" ErrorMessage="Please Select financial Period"
                                                InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left"></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <telerik:RadGrid ID="RG_TrainingApproval" runat="server" AutoGenerateColumns="False" GridLines="None" Skin="WebBlue" Visible="false">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="PAYITEM_ID" UniqueName="PAYITEM_ID" HeaderText="Factors"
                                                meta:resourcekey="PAYITEM_ID" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" UniqueName="PAYITEM_PAYITEMNAME"
                                                HeaderText="Type of Loan " meta:resourcekey="PAYITEM_PAYITEMNAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="1" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1"
                                                HeaderText="Loan Process Type">
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="rc_LoanProcessType" runat="server" Enabled='<%# Convert.ToBoolean(Eval("LOANSETUP_ADDED")) %>'
                                                        Skin="WebBlue" Style="width: 150px;">
                                                        <Items>

                                                            <telerik:RadComboBoxItem runat="server" Text="Standard" Value="Standard" />
                                                            <%--<telerik:RadComboBoxItem runat="server" Text="Reducing Balance" Value="Reducing Balance"  />
                                                            <telerik:RadComboBoxItem runat="server" Text="Increasing Balance" Value="Increasing Balance"  />--%>
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_LoanProcessType" ErrorMessage="Please Select Loan Process Type"
                                                        ValidationGroup="Part" ControlToValidate="rc_LoanProcessType" InitialValue="">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="2" AllowFiltering="false" HeaderText="Min Tenure in Months">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="rtxt_Min" runat="server" Text='<%# Eval("LOANSETUP_MINTENUREMONTHS") %>'
                                                        Enabled='<%# Convert.ToBoolean(Eval("LOANSETUP_ADDED")) %>' MaxLength="2" MinValue="0" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" CssClass="setWidth" Skin="WebBlue">
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_Min" ErrorMessage="Please Select Min Tenure in Months"
                                                        ValidationGroup="Part" ControlToValidate="rtxt_Min" Text="*"></asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="3" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1"
                                                HeaderText="Max Tenure in Months">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="rtxt_Max" runat="server" Enabled='<%# Convert.ToBoolean(Eval("LOANSETUP_ADDED")) %>' Text='<%# Eval("LOANSETUP_MAXTENUREMONTHS") %>' CssClass="setWidth" Skin="WebBlue" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0"
                                                        MaxLength="3" MinValue="0">
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_Max" ErrorMessage="Please Select Max Tenure in Months"
                                                        ValidationGroup="Part" ControlToValidate="rtxt_Max" Text="*"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator runat="server" ID="cvMinMax" ErrorMessage="Max tenure should not be less than or equal to Min tenure" Text="*" ForeColor="Red"
                                                        ValidationGroup="Part" ControlToValidate="rtxt_Max" ControlToCompare="rtxt_Min" Operator="GreaterThanEqual"></asp:CompareValidator>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="4" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1"
                                                HeaderText="% of Interest">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="rtxt_Interest" runat="server" Enabled='<%# Convert.ToBoolean(Eval("LOANSETUP_ADDED")) %>' Text='<%# Eval("LOANSETUP_LOANINTEREST") %>' CssClass="setWidth" Skin="WebBlue" MinValue="0" MaxValue="100" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="2">
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_Interest" ErrorMessage="Please enter % of Interest"
                                                        ValidationGroup="Part" ControlToValidate="rtxt_Interest" Text="*"></asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="True" />
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btn_submit" runat="server" Text="Save" Visible="false"
                                    OnClick="btn_submit_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Part')" />
                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="false" OnClick="btn_Cancel_Click" />
                                <asp:ValidationSummary ID="vs_TrainerProf" runat="server" ShowMessageBox="True" ShowSummary="False"
                                    ValidationGroup="Part" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>