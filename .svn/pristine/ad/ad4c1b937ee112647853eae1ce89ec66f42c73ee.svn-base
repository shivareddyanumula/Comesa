<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_idp.aspx.cs" Inherits="PMS_frmIDP" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_IDP" runat="server" Text="Individial Development Plan"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_Idpform" runat="server" meta:resourcekey="RM_IdpformResource1">
                    <telerik:RadPageView ID="RP_Idpform" runat="server" meta:resourcekey="RP_IdpformResource1">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Idpform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        Skin="WebBlue" PageSize="5" AllowFilteringByColumn="True"
                                        OnNeedDataSource="RG_Idpform_NeedDataSource1" GridLines="None" meta:resourcekey="RG_IdpformResource1">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Employee" DataField="EMPLOYEE_NAME" UniqueName="EMPLOYEE_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="IDP" DataField="IDP_NAME" meta:resourcekey="GridBoundColumnResource1"
                                                    UniqueName="IDP_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="IDP_DESCRIPTION" meta:resourcekey="GridBoundColumnResource2"
                                                    UniqueName="IDP_DESCRIPTION">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Date" DataField="IDP_STARTDATE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="IDP_STATUS">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn HeaderText="End Date" DataField="IDP_ENDDATE">
                                                </telerik:GridBoundColumn>--%>

                                                <%-- <telerik:GridBoundColumn DataField="IDP_APPRAISALCYCLE" UniqueName="IDP_APPRAISALCYCLE" HeaderText="Appraisal Cycle"
                                                    >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" meta:resourcekey="GridTemplateColumnResource1"
                                                    UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("IDP_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_AddResource1">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_Idpform2" runat="server" Width="100%" meta:resourcekey="RP_Idpform2Resource1">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_Det" runat="server" Text="Details"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_id" runat="server" Text="[lblid]" Visible="False" meta:resourcekey="lbl_idResource1"></asp:Label>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" meta:resourcekey="lbl_BusinessUnitResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_BusinessUnit" AutoPostBack="True" runat="server" OnSelectedIndexChanged="RCB_BusinessUnit_SelectedIndexChanged"
                                        meta:resourcekey="RCB_BusinessUnitResource1" Width="130px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_RCB_BusinessUnit" runat="server" ControlToValidate="RCB_BusinessUnit"
                                        ErrorMessage="Please Select BusinessUnit" Text="*" ValidationGroup="controls" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_EmployeeName" runat="server" Text="Employee" meta:resourcekey="lbl_EmployeeNameResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: right"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_EmployeeName" AutoPostBack="True" runat="server"
                                        Width="130px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                        OnSelectedIndexChanged="RCB_EmployeeName_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_EmployeeName" runat="server" ControlToValidate="RCB_EmployeeName"
                                        ErrorMessage="Please Select Employee" Text="*" ValidationGroup="controls" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: left">IDP
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_IDP" runat="server" meta:resourcekey="txt_IDPResource1" Width="130px" MaxLength="1000"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_IDP" runat="server" ErrorMessage="Please Enter IDP"
                                        Text="*" ValidationGroup="controls" ControlToValidate="txt_IDP"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: small;">
                                    <asp:Label ID="lbl_Description" runat="server" Text="Description" meta:resourcekey="lbl_DescriptionResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine" meta:resourcekey="txt_DescriptionResource1"
                                        Width="130px" MaxLength="1000"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: left">
                                    <asp:Label ID="lbl_StartDate" runat="server" Text="Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RDP_StartDate" runat="server" meta:resourcekey="RDP_DateResource1"
                                        Width="130px">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Date" runat="server" ErrorMessage="Please Enter Start Date"
                                        Text="*" ValidationGroup="controls" ControlToValidate="RDP_StartDate"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: left">
                                    <asp:Label ID="lbl_EndDate" runat="server" Text="End Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RDP_EndDate" runat="server" Width="130px" >
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter End Date"
                                        Text="*" ValidationGroup="controls" ControlToValidate="RDP_EndDate"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ctl_rdtp_EndDate" runat="server" ControlToCompare="RDP_StartDate"
                                        ControlToValidate="RDP_EndDate" ErrorMessage="End Date Should Be Greater Than Start Date"
                                        Operator="GreaterThanEqual" Text="*" ValidationGroup="controls" Type="Date"></asp:CompareValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: left">
                                    <asp:Label ID="lbl_Comments" runat="server" Text="Comments" meta:resourcekey="lbl_CommentsResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Comments" runat="server" TextMode="MultiLine" meta:resourcekey="txt_CommentsResource1"
                                        Width="130px" MaxLength="1000"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_status" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_status" runat="server" Skin="WebBlue" Enabled="false">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>

                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <%-- <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_appr_cycle" runat="server" CssClass="LABELSS" Text="Appraisal Cycle"></asp:Label>
                                </td>
                                <td>
                                   <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_apprcycle" runat="server" MarkFirstMatch="true" 
                                        Width="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcm_apprcycle_id" runat="server" ControlToValidate="rcm_apprcycle"
                                        ErrorMessage="Please Select Appraisal Cycle" InitialValue="Select" ValidationGroup="controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_SAVE" runat="server" Text="Save" OnClick="btn_SAVE_Click"
                                        meta:resourcekey="btn_SAVEResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small"
                                        OnClientClick="disableButton(this,'controls')" UseSubmitBehavior="false" />&nbsp;
                                    <asp:Button ID="btn_UPDATE" runat="server" Text="Update" ValidationGroup="controls"
                                        OnClick="btn_UPDATE_Click" meta:resourcekey="btn_UPDATEResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small" />&nbsp;
                                    <asp:Button ID="btn_CANCEL" runat="server" Text="Cancel" OnClick="btn_CANCEL_Click"
                                        meta:resourcekey="btn_CANCELResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="VS_IDPFORM" runat="server" ValidationGroup="controls"
                            ShowMessageBox="True" ShowSummary="False" meta:resourcekey="VS_IDPFORMResource1" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>