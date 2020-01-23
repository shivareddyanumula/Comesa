<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="TaxationMaster.aspx.cs" Inherits="Pension_TaxationMaster" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <style type="text/css">
        .setWidth {
            width: 75px !important;
        }
    </style>
    <telerik:RadAjaxManagerProxy ID="RAM_MedicalBenfitClaim" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenfitClaim">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lbl_TaxationMaster" runat="server" Font-Bold="True" Text="Taxation Master"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="left">
                <asp:Label ID="lbl_Taxation" runat="server" Text="Taxation"></asp:Label>
            </td>
            <td>
                <b>: </b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcb_Taxation" Skin="WebBlue" runat="server" MarkFirstMatch="true"
                    MaxHeight="120px" AutoPostBack="True" OnSelectedIndexChanged="rcb_Taxation_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                        <telerik:RadComboBoxItem runat="server" Text="Below 10yrs" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Above 10yrs" Value="2" />
                    </Items>
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="rfv_Taxation" runat="server" ControlToValidate="rcb_Taxation"
                    InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select Taxation Type"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_FinancialPeriod" runat="server" Text="Financial Period"></asp:Label>
            </td>
            <td>
                <b>: </b>
            </td>
            <td align="left">
                <telerik:RadComboBox Skin="WebBlue" ID="rcb_FinancialPeriod" runat="server" MarkFirstMatch="true" Filter="Contains"
                    MaxHeight="120px" AutoPostBack="True" OnSelectedIndexChanged="rcb_FinancialPeriod_SelectedIndexChanged">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="rfv_FinancialPeriod" runat="server" ControlToValidate="rcb_FinancialPeriod"
                    InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
            </td>

        </tr>


        <tr>
            <td align="left" style="width: 98%" colspan="3">
                <telerik:RadGrid ID="RG_TaxationSlab" runat="server" AutoGenerateColumns="False"
                    Skin="WebBlue" GridLines="None" Visible="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="TAXATIONMASTER_SLAB_ID" UniqueName="TAXATIONMASTER_SLAB_ID" HeaderText="ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TAXATIONMASTER_SLAB_NAME" UniqueName="TAXATIONMASTER_SLAB_NAME" HeaderText="Slab Name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Slab Amount" UniqueName="SlabAmount">
                                <ItemTemplate>
                                    <telerik:RadNumericTextBox ID="txt_SlabAmount" CssClass="setWidth" runat="server"
                                        Text='<%# Eval("TAXATIONMASTER_SLAB_AMOUNT") %>'
                                        ValidationGroup="Controls" MaxLength="12" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_SlabAmount"
                                        Text="*" ErrorMessage="Please Enter Amount" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Percentage" UniqueName="Percentage">
                                <ItemTemplate>
                                    <telerik:RadNumericTextBox ID="txt_Percentage" CssClass="setWidth" runat="server" Text='<%# Eval("TAXATIONMASTER_SLAB_PER") %>'
                                        ValidationGroup="Controls" MaxLength="2" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Percentage" runat="server" ControlToValidate="txt_Percentage"
                                        Text="*" ErrorMessage="Please Enter Percentage" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" CausesValidation="true"
                    ValidationGroup="Controls" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                <asp:ValidationSummary ID="vs_Salary" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
</asp:Content>