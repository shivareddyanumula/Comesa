<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_organisation.aspx.cs" Inherits="Masters_frm_organisation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%-- <telerik:RadAjaxManagerProxy ID="RAM_BusinessUnit" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Organisation">
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
    </telerik:RadAjaxManagerProxy>--%>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_OrganisationHeader" runat="server" Text="Organisation" Font-Bold="True"
                    meta:resourcekey="lbl_OrganisationHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_OG_page" runat="server" meta:resourcekey="Rm_BU_pageResource1">
                    <telerik:RadPageView ID="Rp_OG_ViewMain" runat="server" meta:resourcekey="Rp_BU_ViewMainResource1"
                        Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Organisation" runat="server" AutoGenerateColumns="False"
                                        AllowFilteringByColumn="True" AllowSorting="True" Skin="WebBlue" GridLines="None"
                                        AllowPaging="True" meta:resourceKey="Rg_Organisation" OnNeedDataSource="Rg_Organisation_NeedDataSource">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="" HeaderText="ID" meta:resourceKey="ORGANISATION_ID"
                                                    UniqueName="ORGANISATION_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ORGANISATION_NAME" HeaderText="Name" meta:resourcekey="ORGANISATION_NAME"
                                                    UniqueName="ORGANISATION_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ORGANISATION_DESC" HeaderText="Description" meta:resourcekey="ORGANISATION_DESC"
                                                    UniqueName="ORGANISATION_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ORGANISATION_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_AddResource2">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView><PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_OG_ViewDetails" runat="server" meta:resourcekey="Rp_BU_ViewDetailsResource1">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ORganisationID" runat="server" Visible="False" meta:resourcekey="lbl_ORganisationID"></asp:Label><asp:Label
                                        ID="lbl_OrganisationName" runat="server" Text="Name" meta:resourcekey="lbl_OrganisationName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_OrganisationName" runat="server" Skin="WebBlue" MaxLength="200"
                                        meta:resourcekey="rtxt_OrganisationName" TabIndex="1">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_OrganisationName" runat="server" ControlToValidate="rtxt_OrganisationName"
                                        ErrorMessage="Organisation Name cannot be Empty" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rtxt_OrganisationName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OrganisationDesc" runat="server" Text="Description" meta:resourcekey="lbl_OrganisationDesc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_OrganisationDesc" runat="server" Skin="WebBlue" meta:resourcekey="rtxt_OrganisationDesc"
                                        MaxLength="1000" LabelCssClass="" TabIndex="2">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OrganisationPack" runat="server" meta:resourcekey="lbl_OrganisationPack"
                                        Text="Package"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_Package" runat="server" MarkFirstMatch="true" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_OrganisationName0" runat="server" ControlToValidate="rcb_Package"
                                        ErrorMessage="Package cannot be Empty" InitialValue="Select" meta:resourcekey="rtxt_OrganisationName"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OrgsanitionAddress1" runat="server" Text="Present Address" meta:resourcekey="lbl_OrgsanitionAddress1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Address1" runat="server" TextMode="MultiLine"
                                        MaxLength="800" TabIndex="4">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OrgsanitionAddress2" runat="server" Text="Permanent Adress" meta:resourcekey="lbl_OrgsanitionAddress2"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Address2" runat="server" TextMode="MultiLine"
                                        MaxLength="800" TabIndex="5">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPINNumber" runat="server" Text="PIN Number" meta:resourcekey="lblPINNumber"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxtPINNumber" runat="server" TabIndex="6" MaxLength="12">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfPINNumber" runat="server" ControlToValidate="rtxtPINNumber"
                                        ErrorMessage="Pin Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxtPINNumber" ErrorMessage="Enter only Alphanumerics for PIN Number"
                                        ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,12}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNSSF" runat="server" Text="NSSF Number" meta:resourcekey="lblNSSF"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radNSSF" runat="server" TabIndex="6" MaxLength="15">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="radNSSF"
                                        ErrorMessage="NSSF Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="radNSSF" ErrorMessage="Enter only Alphanumerics for NSSF Number"
                                        ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,15}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNHIF" runat="server" Text="NHIF Number" meta:resourcekey="lblNHIF"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radNHIF" runat="server" TabIndex="6" MaxLength="10">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radNHIF"
                                        ErrorMessage="NHIF Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="radNHIF" ErrorMessage="Enter only Alphanumerics for NHIF Number"
                                        ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,10}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVAT" runat="server" Text="VAT Number" meta:resourcekey="lblVAT"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radVAT" runat="server" TabIndex="6" MaxLength="12">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="radVAT"
                                        ErrorMessage="VAT Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="radVAT" ErrorMessage="Enter only Alphanumerics for VAT Number"
                                        ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,12}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPostBoxNo" runat="server" Text="Post Office Box Number" meta:resourcekey="lblPostBoxNo"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxtPostBoxNo" runat="server" TabIndex="7" MaxLength="5">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfPostBoxNo" runat="server" ControlToValidate="rtxtPostBoxNo"
                                        ErrorMessage="Post Box Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="rtxtPostBoxNo" ErrorMessage="Enter only Alphanumerics for Post Office Box Number"
                                        ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,5}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFax" runat="server" Text="Fax Number" meta:resourcekey="lblFax"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="rtxtFax" runat="server" TabIndex="8" Mask="+### ### #######" MaxLength="13">
                                    </telerik:RadMaskedTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfFax" runat="server" ControlToValidate="rtxtFax"
                                        ErrorMessage="FAX No is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Phone1" runat="server" Text="Contact Number" meta:resourcekey="lbl_Phone1"></asp:Label>
                                </td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadMaskedTextBox ID="txt_PhoneNumber" runat="server" Mask="+### ### #######"
                                        MaxLength="13" TabIndex="9">
                                    </telerik:RadMaskedTextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfv_txt_PhoneNumber" runat="server" ControlToValidate="txt_PhoneNumber"
                                        ErrorMessage="Phone No is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Url" runat="server" meta:resourcekey="lbl_Url" Text="Website URL"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_URL" runat="server" TabIndex="10" MaxLength="200">
                                    </telerik:RadTextBox>
                                    <asp:Label ID="lbl_Example" runat="server" Text="Ex :  http://www.dhanushinfotech.com"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RegularExpressionValidator ID="RFV_URL" runat="server" ControlToValidate="rtxt_URL"
                                        ErrorMessage="Enter valid url" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Employees" runat="server" meta:resourcekey="lbl_Url" Text="Number of Employees"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="txt_Employees" runat="server" MinValue="0"
                                        MaxLength="7" TabIndex="11">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox><telerik:RadNumericTextBox ID="temp" runat="server" Style="display: none;"
                                        Value="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfv_Employees" runat="server" Text="*" ValidationGroup="Controls"
                                        ControlToValidate="txt_Employees" ErrorMessage="Enter the number Emloyees">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Employee Count Should be Greater the Existing Count Entered"
                                        ControlToCompare="temp" ControlToValidate="txt_Employees" ValidationGroup="Controls"
                                        Type="Integer" Operator="GreaterThanEqual"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lbl_EmpCount" runat="server" BackColor="Green" ForeColor="Black">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Applicant" runat="server" Text="Number of Applicants">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_Applicant" runat="server" MinValue="1"
                                        MaxLength="7" TabIndex="12">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                    <telerik:RadNumericTextBox ID="rntxt_Applicant_Temp" runat="server" Style="display: none;" MaxLength="10"
                                        Value="0" TabIndex="13">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Applicant" runat="server" Text="*" ControlToValidate="rntxt_Applicant"
                                        ValidationGroup="Controls" ErrorMessage="Enter Number Of Applicant">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Applicant Count Should be Greater the Existing Count Entered"
                                        ControlToCompare="rntxt_Applicant_Temp" ControlToValidate="rntxt_Applicant" ValidationGroup="Controls"
                                        Type="Integer" Operator="GreaterThanEqual"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lbl_ApplicantCount" runat="server" BackColor="Green" ForeColor="Black">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_sup_module" runat="server" Text="Super Modules">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>

                                    <asp:CheckBoxList ID="chklst_sup_module" runat="server"
                                        OnSelectedIndexChanged="chklst_sup_module_SelectedIndexChanged" AutoPostBack="true" TabIndex="15">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr id="tr_empcode_manual" runat="server">

                                <td>
                                    <asp:Label ID="lbl_empcode_manual" runat="server" Text="Is Employee Code Manual Entry"></asp:Label></td>

                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_empcode_manual" runat="server" AutoPostBack="true"
                                        OnCheckedChanged="chk_empcode_manual_CheckedChanged" TabIndex="16" />
                                </td>


                            </tr>
                            <tr id="tr_noofzeros" runat="server">
                                <td>
                                    <asp:Label ID="lbl_noofzeros" runat="server" Text="Enter Number Of Zero's"></asp:Label></td>
                                <td>
                                    <b>:</b></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_zeros" runat="server" MaxLength="1" MinValue="0" TabIndex="17"></telerik:RadNumericTextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rntxt_zeros" runat="server" Text="*" ControlToValidate="rntxt_zeros"
                                        ValidationGroup="Controls" ErrorMessage="Enter Number Of Zero's">
                                    </asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_AnnualProcess" runat="server" Text="Annual Process"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_AnnualProcess" runat="server" TabIndex="18"/>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Integration" runat="server" Text="Is&nbsp;SMPM&nbsp;Integration"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Integration" runat="server" TabIndex="19" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SmartOpsIntegration" runat="server" Text="Is&nbsp;SmartOps&nbsp;Integration"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_SmartOpsIntegration" runat="server" TabIndex="20" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ContactPerson" runat="server" Text="Contact Person"
                                        meta:resourcekey="lbl_ContactPerson"></asp:Label></td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ContactPerson" runat="server" MaxLength="200" TabIndex="21">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Contact_Person" runat="server" ControlToValidate="rtxt_ContactPerson"
                                        ErrorMessage="Contact Person is Mandatory" ValidationGroup="Controls"
                                        Text="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CPhone" runat="server"
                                        Text="Phone No" meta:resourcekey="lbl_CPhone"></asp:Label></td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadMaskedTextBox ID="rtxt_Cphone" runat="server" TabIndex="22"
                                        Mask="+### ### #######" MaxLength="13">
                                    </telerik:RadMaskedTextBox>

                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Cphone" runat="server"
                                        ControlToValidate="rtxt_Cphone" ErrorMessage="Phone No is Mandatory"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Email" runat="server"
                                        Text="Email ID"></asp:Label></td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="txt_Email" runat="server"
                                        EmptyMessageStyle-Font-Italic="true" MaxLength="50" Width="200px" TabIndex="23">
                                        <EmptyMessageStyle Font-Italic="True" />
                                    </telerik:RadTextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                        ControlToValidate="txt_Email" ErrorMessage="Email ID is Mandatory"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txt_Email" ErrorMessage="Enter Valid Email ID"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblalternateEmail" runat="server"
                                        Text="Alternate Email ID"></asp:Label></td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="radaletrnateemail" runat="server"
                                        EmptyMessageStyle-Font-Italic="true" MaxLength="50" Width="200px" TabIndex="23">
                                        <EmptyMessageStyle Font-Italic="True" />
                                    </telerik:RadTextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="radaletrnateemail" ErrorMessage="Alternate Email ID is Mandatory"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="radaletrnateemail" ErrorMessage="Enter Valid Alternate Email ID"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorNotification" runat="server" Text="Notify Errors To"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtErrorNotification" runat="server" Width="200px" AutoCompleteType="Email"></telerik:RadTextBox>
                                    <%--<asp:TextBox ID="txtErrorNotification" runat="server" Width="200px"></asp:TextBox>--%>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="revErrorNotification" runat="server" ControlToValidate="txtErrorNotification"
                                        ErrorMessage="Enter Valid Email ID's" ValidationExpression="^(\w([-_+.']*\w+)+@(\w(-*\w+)+\.)+[a-zA-Z]{2,4}[,;])*\w([-_+.']*\w+)+@(\w(-*\w+)+\.)+[a-zA-Z]{2,4}$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Variableamt" runat="server" 
                                        Text="Is Variable"></asp:Label></td><td align="left">
                                    <b>:</b>  </td>
                                <td align="left">
                                    <asp:CheckBox ID="chk_Variableamt" runat="server" AutoPostBack="true" 
                                        OnCheckedChanged="chk_Variableamt_CheckedChanged" TabIndex="24"/>
                                </td>
                                <td>
                                </td>
                            </tr>--%>

                            <tr id="MinPercentage" runat="server" visible="false">
                                <td align="left">
                                    <asp:Label ID="lbl_Percentage" runat="server" Text="Min Percentage"></asp:Label></td>
                                <td align="left">
                                    <b>:</b>  </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="rntxt_MinPercentage" runat="server"
                                        MaximumValue="1000" NumberFormat-AllowRounding="true" MaxLength="5"
                                        MinValue="0" TabIndex="25">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr id="MaxPercentage" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_maxpercentage" runat="server" Text="Max Percentage"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b> </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_MaxPercentage" runat="server"
                                        MaximumValue="1000" NumberFormat-AllowRounding="true" TabIndex="26">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Save" runat="server" meta:resourceKey="btn_Save"
                                        OnClick="btn_Save_Click" Text="Save" OnClientClick="fnJSOnFormSubmit(this,'Controls')" UseSubmitBehavior="false" TabIndex="27" />
                                    &nbsp;&nbsp;<asp:Button ID="btn_Cancel" runat="server" CausesValidation="False"
                                        meta:resourceKey="btn_Cancel" OnClick="btn_Cancel_Click" Text="Cancel" />
                                    <%-- ValidationGroup="Controls" --%>
                                    <asp:ValidationSummary ID="vs_BusinessUnit" runat="server"
                                        meta:resourceKey="vs_BusinessUnit" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">&nbsp;&nbsp;
                                </td>
                                <td align="center">&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>