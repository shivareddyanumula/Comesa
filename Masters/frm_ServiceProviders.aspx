<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_ServiceProviders.aspx.cs" Inherits="Masters_frm_ServiceProviders" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cntServiceProviders" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_ServiceProviders" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_ServiceProviders">
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
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ServiceProviderHeader" runat="server" Text="Service Provider" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_ServiceProviders" runat="server" AutoGenerateColumns="False" ShowHeader="true"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_ServiceProviders_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true" Width="450px">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ServiceProvider_ID" UniqueName="ServiceProvider_ID" HeaderText="ID"
                                                            meta:resourcekey="ServiceProvider_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ServiceProvider_NAME" UniqueName="ServiceProvider_NAME" HeaderText=" Service Provider Name"
                                                            meta:resourcekey="ServiceProvider_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" Width="25px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="SERVICEPROVIDER_KeyContactPersonName" UniqueName="SERVICEPROVIDER_KeyContactPersonName" HeaderText="Contact Name"
                                                            meta:resourcekey="SERVICEPROVIDER_KeyContactPersonName">
                                                            <HeaderStyle HorizontalAlign="Center" Width="25px" />
                                                        </telerik:GridBoundColumn>
                                                        <%-- <telerik:GridBoundColumn DataField="SERVICEPROVIDER_CONTACTNUMBER" UniqueName="SERVICEPROVIDER_CONTACTNUMBER" HeaderText="Contact No"
                                                            meta:resourcekey="SERVICEPROVIDER_CONTACTNUMBER">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>   --%>

                                                        <telerik:GridNumericColumn DataField="SERVICEPROVIDER_CONTACTNUMBER" UniqueName="SERVICEPROVIDER_CONTACTNUMBER"
                                                            HeaderText="Contact No" meta:resourcekey="SERVICEPROVIDER_CONTACTNUMBER" FilterControlWidth="75px">
                                                            <HeaderStyle HorizontalAlign="Center" Width="25px" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ServiceProvider_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
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

                                </table>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="50%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ServiceProviderID" runat="server" Visible="False" meta:resourcekey="lbl_ServiceProviderID"></asp:Label>
                                    <asp:Label ID="lbl_ServiceProviderName" runat="server" Text="Name" meta:resourcekey="lbl_ServiceProviderName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ServiceProviderName" runat="server" TabIndex="1"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_ServiceProviderName" ControlToValidate="rtxt_ServiceProviderName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name"
                                        meta:resourcekey="rfv_rtxt_ServiceProviderName">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_ServiceProviderName" ErrorMessage="Enter only Alphabets for Name"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblServiceProviderAddress" runat="server" Text="Address" meta:resourcekey="lblServiceProviderAddress"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ServiceProviderAddress" runat="server" Skin="WebBlue" MaxLength="500" TextMode="MultiLine" TabIndex="2">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="rtxt_ServiceProviderAddress"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Address"
                                        meta:resourcekey="rfv_rtxt_ServiceProviderName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmailID" runat="server" Text="Email Id" meta:resourcekey="lblEmailID"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radEmailID" runat="server" Skin="WebBlue" MaxLength="50" TabIndex="3">
                                    </telerik:RadTextBox>
                                    <asp:RegularExpressionValidator ID="rev_EmailID" runat="server" ControlToValidate="radEmailID" ErrorMessage="Please Enter Valid Email ID"
                                        Text="*" Display="Dynamic" ValidationGroup="Controls"
                                        ValidationExpression="\w+([_.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_EmailID" runat="server" ErrorMessage="Please Enter Email ID"
                                        Text="*" ValidationGroup="Controls" ControlToValidate="radEmailID"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblContactName" runat="server" Text="Key Contact Person Name" meta:resourcekey="lblContactName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radContactName" runat="server" Skin="WebBlue" MaxLength="50" TabIndex="4">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="radContactName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Contact Name"
                                        meta:resourcekey="rfv_rtxt_ServiceProviderName">*</asp:RequiredFieldValidator>

                                    <%--                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="radContactName" ErrorMessage="Enter only Alphabets for Contact Name"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="radContactName"
                                        ErrorMessage="Please Enter Only Alphabets" ValidationExpression="^[a-zA-Z\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact Number" meta:resourcekey="lblContactNo"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="radContactNo" runat="server" Skin="WebBlue" MaxLength="13" Mask="+### ### #######" TabIndex="5">
                                    </telerik:RadMaskedTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txt_PhoneNumber" runat="server" ControlToValidate="radContactNo"
                                        ErrorMessage="Please Enter Contact Number" ValidationGroup="Controls">*</asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAlternateContact1" runat="server" Text="Alternate Contact Number 1" meta:resourcekey="lblAlternateContact1"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="radAlternateContact1" runat="server" Skin="WebBlue" MaxLength="13" Mask="+### ### #######" TabIndex="6">
                                    </telerik:RadMaskedTextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radAlternateContact1"
                                        ErrorMessage="Please Enter Alternative Contact Number 1" ValidationGroup="Controls">*</asp:RequiredFieldValidator> --%>
                                    <%--<asp:CompareValidator ID="CompareValidatorContact" runat="server" ControlToCompare="radContactNo"
                                                 ControlToValidate="radAlternateContact1" Display="None" ErrorMessage="Contact Number and Alternative Contact Number Cannot be Same"
                                            Operator = "LessThanEqual" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>  --%>                            
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAlternateContact2" runat="server" Text="Alternate Contact Number 2" meta:resourcekey="lblAlternateContact2"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="radAlternateContact2" runat="server" Skin="WebBlue" MaxLength="13" Mask="+### ### #######" TabIndex="7">
                                    </telerik:RadMaskedTextBox>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="radAlternateContact2"
                                        ErrorMessage="Please Enter Alternative Contact Number 2" ValidationGroup="Controls">*</asp:RequiredFieldValidator>  --%>
                                    <%--<asp:CompareValidator ID="CompareValidatorContact2" runat="server" ControlToCompare="radAlternateContact1"
                                                 ControlToValidate="radAlternateContact2" Display="None" ErrorMessage="Both Alternative Contact Numbers Cannot be Same"
                                            Operator = "LessThanEqual" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>    --%>                            
                                </td>
                            </tr>
                            <tr id="trifimsnumber" runat="server">
                                <td>
                                    <asp:Label ID="lblIFMISNumber" runat="server" Text="IFMIS Number" meta:resourcekey="lblIFMISNumber"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="radIFMISNumber" runat="server" Skin="WebBlue" MaxLength="13" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" TabIndex="8">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txtbx_IFMISNumber" runat="server" ErrorMessage="Please enter IFMIS Number"
                                        Text="*" ValidationGroup="Controls" ControlToValidate="radIFMISNumber"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trpinnumber" runat="server">
                                <td>
                                    <asp:Label ID="lblPinNumber" runat="server" Text="Pin Number" meta:resourcekey="lblPinNumber"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radPinNumber" runat="server" Skin="WebBlue" MaxLength="13" TabIndex="9">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txtbx_PinNumber" ControlToValidate="radPinNumber"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Pin Number" Text="*"
                                        meta:resourcekey="rfv_rtxt_ServiceProviderName"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="radPinNumber"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                    <%--<telerik:RadNumericTextBox ID="radPinNumber" runat="server" Skin="WebBlue" MaxLength="13"  NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>   
                                     <asp:RequiredFieldValidator ID="rfv_txtbx_PinNumber" runat="server" ErrorMessage="Please enter Pin Number"
                                                         Text="*" ValidationGroup="Controls" ControlToValidate="radPinNumber"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator> --%>                                 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblServiceProviderType" runat="server" Text="Service Provider Type" meta:resourcekey="lblServiceProviderType"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="radServiceProviderType" runat="server" EmptyMessage="Select" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="radServiceProviderType_SelectedIndexChanged" TabIndex="10" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_ServiceProviderType" runat="server" ControlToValidate="radServiceProviderType" ErrorMessage="Please Select Service Provider Type"
                                        InitialValue="Select" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_ServiceProviderType"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr id="trexpenditure" runat="server">
                                <td>
                                    <asp:Label ID="lblExpenditureName" runat="server" Text="Expenditure Names" meta:resourcekey="lblExpenditureName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadListBox CheckBoxes="true" ID="radExpenditureName" runat="server" Skin="WebBlue" Height="100px" TabIndex="11">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="13"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="12"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="14"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_ServiceProvider" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>

    </table>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
</asp:Content>--%>