<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_DependentAllowance.aspx.cs" Inherits="frm_DependentAllowance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadWindow runat="server" ID="rwcontrols" VisibleOnPageLoad="false" Width="350px" Height="400px" Behaviors="Close">
        <ContentTemplate>
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
                                        <asp:Label ID="lbl_Allowance" runat="server" Text="Allowance" Style="font-weight: 700"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td align="left">
                                                    <asp:Label ID="Label" runat="server" Visible="true" meta:resourcekey="lblFromPeriodId"></asp:Label>
                                                    <asp:Label ID="lbl_FromPeriod" runat="server" Text="Financial Period" meta:resourcekey="lblFromPeriodId"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_FromPeriod" runat="server" MarkFirstMatch="true"
                                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_FromPeriod_SelectedIndexChanged"
                                                        MaxHeight="200" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <telerik:RadGrid ID="RG_Allowance" runat="server" AutoGenerateColumns="False" GridLines="None" Skin="WebBlue" Visible="true">
                                            <MasterTableView NoMasterRecordsText="No Records to display">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_RANK" UniqueName="EMPLOYEEGRADE_RANK" HeaderText="S.NO"
                                                        meta:resourcekey="EMPLOYEEGRADE_RANK" Visible="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE"
                                                        HeaderText="Scale " meta:resourcekey="EMPLOYEEGRADE_CODE">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn UniqueName="Allowance($) Per Dependent" AllowFiltering="false" HeaderText="Allowance($) Per Dependent">
                                                        <ItemTemplate>
                                                            <telerik:RadTextBox ID="txtDependent" runat="server" Text='<%# Eval("Dependent") %>'>
                                                            </telerik:RadTextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn UniqueName="Dependents Eligible" AllowFiltering="false" HeaderText="No. of Dependents Eligible">
                                                        <ItemTemplate>
                                                            <telerik:RadTextBox ID="txtEligible" runat="server" MaxLength="10" Text='<%# Eval("Eligible") %>'>
                                                            </telerik:RadTextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btn_submit" runat="server" Text="Save" Visible="true"
                                            OnClick="btn_submit_Click" UseSubmitBehavior="false" ValidationGroup="Part" />
                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="true" OnClick="btn_Cancel_Click" />
                                        <asp:ValidationSummary ID="vs_TrainerProf" runat="server" ShowMessageBox="True" ShowSummary="False"
                                            ValidationGroup="Part" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>