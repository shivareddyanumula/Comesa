<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Identification.aspx.cs" Inherits="HR_frm_Identification" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RSB_Employee" runat="server">

        <script type="text/javascript">
            function fnJSOnFormSubmit(sender, group) {
                var isGrpOneValid = Page_ClientValidate(group);
                var i;
                for (i = 0; i < Page_Validators.length; i++) {
                    ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
                }
                for (i = 0; i < Page_ValidationSummaries.length; i++) {
                    summary = Page_ValidationSummaries[i];
                    if (isGrpOneValid) {
                        sender.disabled = "disabled";
                        return true;
                    }

                    if (fnJSDisplaySummary(summary.validationGroup)) {
                        summary.style.display = "";
                    }
                }

            }


        </script>

    </telerik:RadScriptBlock>
    <telerik:RadAjaxManagerProxy ID="RAM_EmpIden" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_Identification">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Submit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcb_Employee">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 1014px; overflow: auto;">
                    <table style="width: 70%;" align="center">
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table style="width: 85%;" align="center">
                                    <tr>
                                        <td colspan="7" align="center">
                                            <asp:Label ID="lbl_Header" runat="server" meta:resourcekey="lbl_Header" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center"></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                            <asp:HiddenField ID="HF_ID" runat="server" />
                                        </td>
                                        <td>
                                            <b>:</b>

                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcb_BusinessUnit" runat="server" Skin="WebBlue"
                                                AutoPostBack="True" MarkFirstMatch="true" Filter="Contains"
                                                OnSelectedIndexChanged="rcb_BusinessUnit_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls" ControlToValidate="rcb_BusinessUnit" meta:resourcekey="rfv_BusinessUnit" ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Employee" runat="server" meta:resourcekey="lbl_Employee"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcb_Employee" runat="server" Skin="WebBlue" MaxHeight="120px" Filter="Contains"
                                                AutoPostBack="True" OnSelectedIndexChanged="rcb_Employee_SelectedIndexChanged" MarkFirstMatch="true">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls" ControlToValidate="rcb_Employee" meta:resourcekey="rfv_Employee" 
                                                ErrorMessage="Please Select Employee"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="7">
                                            <hr />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Type" runat="server" meta:resourcekey="lbl_Type"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcb_Type" runat="server" Skin="WebBlue"
                                                AutoPostBack="True" Filter="Contains"
                                                OnSelectedIndexChanged="rcb_Type_SelectedIndexChanged" Width="157px">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="Select"
                                                        Value="0" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Type" runat="server" InitialValue="Select" Text="*"
                                                ValidationGroup="Controls" ControlToValidate="rcb_Type" meta:resourcekey="rfv_Type"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Code" runat="server" meta:resourcekey="lbl_Code"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtb_Code" runat="server" Skin="WebBlue" MaxLength="20"
                                                Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Code" runat="server" Text="*" ValidationGroup="Controls"
                                                ControlToValidate="rtb_Code" meta:resourcekey="rfv_Code"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Name" runat="server" meta:resourcekey="lbl_Name"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_Name" runat="server" Skin="WebBlue" MaxLength="50"
                                                Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Name" runat="server" Text="*" ValidationGroup="Controls"
                                                ControlToValidate="rtxt_Name" meta:resourcekey="rfv_Name"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_IssueDate" runat="server" meta:resourcekey="lbl_IssueDate"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdp_IssueDate" runat="server" Skin="WebBlue">
                                                <DateInput Skin="WebBlue" LabelCssClass="" Width="">
                                                </DateInput>
                                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                    Skin="WebBlue">
                                                </Calendar>
                                                <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="lbl_ExpiryDate" runat="server" meta:resourcekey="lbl_ExpiryDate"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdp_ExpiryDate" runat="server" Skin="WebBlue">
                                                <DateInput Skin="WebBlue" LabelCssClass="" Width="">
                                                </DateInput>
                                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                    Skin="WebBlue">
                                                </Calendar>
                                                <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_IssuedOrg" runat="server" meta:resourcekey="lbl_IssuedOrg"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_IssuedOrg" runat="server" Skin="WebBlue"
                                                MaxLength="100" Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="8" align="center">
                                            <asp:Label ID="lbl_Message" runat="server" meta:resourcekey="lbl_Message" Visible="False"
                                                BackColor="White" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="width: 20%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_Submit" runat="server" Text="Save" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')"
                                                OnClick="btn_Submit_Click" meta:resourcekey="btn_Submit" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                                                meta:resourcekey="btn_Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 80%;" align="center">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="RG_Identification" runat="server" Skin="WebBlue"
                                                AutoGenerateColumns="False" GridLines="None" meta:resourcekey="RG_Identification">
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn Visible="false" DataField="IDNTMASTER_ID" UniqueName="IDNTMASTER_ID"
                                                            meta:resourcekey="IDNTMASTER_ID">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="IDNTMASTER_CODE" UniqueName="IDNTMASTER_CODE"
                                                            meta:resourcekey="IDNTMASTER_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="IDNTMASTER_NAME" UniqueName="IDNTMASTER_NAME"
                                                            meta:resourcekey="IDNTMASTER_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="IDNTMASTER_TYPE" UniqueName="IDNTMASTER_TYPE"
                                                            meta:resourcekey="IDNTMASTER_TYPE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="IDNTMASTER_ISSUEDT" UniqueName="IDNTMASTER_ISSUEDT"
                                                            meta:resourcekey="IDNTMASTER_ISSUEDT">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="IDNTMASTER_EXPIRYDT" UniqueName="IDNTMASTER_EXPIRYDT"
                                                            meta:resourcekey="IDNTMASTER_EXPIRYDT">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("IDNTMASTER_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                                            CancelImageUrl="Cancel.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                </MasterTableView>
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Summary" ValidationGroup="Controls" runat="server"
        ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vs_Summary" />
</asp:Content>