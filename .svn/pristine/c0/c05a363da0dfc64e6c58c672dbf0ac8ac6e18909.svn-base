<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SMHRMaster.master" CodeFile="frm_CMPform.aspx.cs" Inherits="PMS_frm_CMPform" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CMP" runat="server" Text="Competencies" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_CMPform" runat="server">
                    <telerik:RadPageView ID="RP_CMPform" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_CMPform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        PageSize="5" Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True" OnNeedDataSource="RG_cmpform_NeedDataSource"
                                        meta:resourcekey="RG_cmpformResource1" Width="900px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Business Unit" DataField="BUSINESSUNIT_CODE"
                                                    Visible="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="CMP ID" DataField="CMP_ID" UniqueName="column11"
                                                    meta:resourcekey="GridBoundColumnResource11" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="CMP Name" DataField="CMP_NAME" UniqueName="column"
                                                    meta:resourcekey="GridBoundColumnResource1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="CMP_DESCRIPTION" UniqueName="column1"
                                                    meta:resourcekey="GridBoundColumnResource2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="CMP_STATUS" UniqueName="column12"
                                                    meta:resourcekey="GridBoundColumnResource2">
                                                </telerik:GridBoundColumn>
                                                <%--  <telerik:GridBoundColumn HeaderText="Status" DataField="CMP_STATUS" UniqueName="CMP_STATUS"
                                                    meta:resourcekey="GridBoundColumnResource3">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("CMP_ID") %>'
                                                            meta:resourcekey="lnk_EditResource1">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_ADD" runat="server" OnCommand="lnk_Add_Command" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_cmpformview2" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_CMPdet" runat="server" Text="" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" Width="150px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Business Unit is Mandatory" ValidationGroup="CONTROLS" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Position" runat="server" meta:resourcekey="lbl_Position"
                                        Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_POS" runat="server" Width="150px" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_POS" runat="server" ControlToValidate="rcmb_POS"
                                        ErrorMessage="Position is Mandatory" ValidationGroup="CONTROLS" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>

                            <tr>
                                <td style="text-align: left; width: 150px">
                                    <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="False" meta:resourcekey="lbl_idResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small"></asp:Label>
                                    <asp:Label ID="lbl_cmpname" runat="server" Text="CMP Name" Style="text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: small;"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_cmpname" runat="server" MaxLength="1000" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_cmpname"
                                        ErrorMessage="Please Enter CMP Name" Text="*" ValidationGroup="CONTROLS"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_description" runat="server" Text="Description" Style="text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: small;"
                                        meta:resourcekey="lbl_descriptionResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_description"
                                        ErrorMessage="Please Enter Description" Text="*" ValidationGroup="CONTROLS"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_status" runat="server" Text="Inactive" Style="text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: small;"></asp:Label>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="cln_status" Text=":" runat="server"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkbx_status" runat="server"></asp:CheckBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_SAVE" runat="server" Text="Save" OnClick="btn_SAVE_Click1" meta:resourcekey="btn_SAVEResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small" OnClientClick="disableButton(this,'CONTROLS')"
                                        UseSubmitBehavior="false" />&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"
                                        ValidationGroup="CONTROLS" meta:resourcekey="btn_UpdateResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small" />&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                                        meta:resourcekey="btn_CancelResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="vs_CMPSummary" runat="server" ValidationGroup="CONTROLS"
                            ShowMessageBox="True" ShowSummary="False" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>