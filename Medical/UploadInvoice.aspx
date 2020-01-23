<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="UploadInvoice.aspx.cs" Inherits="Medical_UploadInvoice" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="cpUploadInvoice" ContentPlaceHolderID="cphDefault" runat="Server">

    <telerik:RadAjaxManagerProxy ID="RAM_UploadInvoice" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_UploadInvoice">
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
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
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
                <asp:Label ID="lbl_UploadInvoice" runat="server" Text="Upload Invoice" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CG_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CG_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="70%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_Categories" runat="server" AutoGenerateColumns="False"
                                                AllowFilteringByColumn="true" GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Categories_NeedDataSource"
                                                AllowPaging="True">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="InvoiceDocID" HeaderText="ID" meta:resourcekey="InvoiceDocID"
                                                            UniqueName="InvoiceDocID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="SERVICEPROVIDER_NAME" HeaderText="Service Provider Name" meta:resourcekey="SERVICEPROVIDER_NAME"
                                                            UniqueName="SERVICEPROVIDER_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Invoice" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <a id="D2" runat="server" target="_blank" href='<%#Eval("InvoiceDocument") %>'>Download Invoice</a>
                                                                <asp:Label ID="lbl_BioData" Text='<%#Eval("InvoiceDocument") %>' Visible="false" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                        <%-- <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("InvoiceDocID") %>'
                                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command" Text="Edit"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>--%>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                            UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command"
                                                                Text="Add"></asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <ActiveItemStyle HorizontalAlign="Center" />
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
                    <telerik:RadPageView ID="Rp_CG_ViewDetails" runat="server">
                        <asp:UpdatePanel ID="upnl" runat="server">

                            <ContentTemplate>
                                <table align="center">
                                    <tr>
                                        <td colspan="3" align="center" style="font-weight: bold;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_InvoiceDocID" runat="server" Visible="False" meta:resourcekey="lbl_InvoiceDocID"></asp:Label>
                                            <asp:Label ID="lbl_ServiceProviderName" runat="server" Text="Service Provider Name" meta:resourcekey="lbl_ServiceProviderName"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="RadServiceProviderName" runat="server" EmptyMessage="Select" Skin="WebBlue" MaxLength="50" Filter="Contains">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfv_ExpenditureName" runat="server" Text="*" InitialValue="Select"
                                                ControlToValidate="RadServiceProviderName" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Select Service Provider"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Upload" runat="server" Text="Invoice" meta:resourcekey="lbl_Upload"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FBrowse" runat="server" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="FBrowse"
                                                runat="Server" ErrorMessage="Only Excel files are allowed" ValidationGroup="Controls"
                                                Text="*" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                ControlToValidate="FBrowse" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Select file to upload"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                                Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center"><a id="D1" runat="server"
                                            href="~/Masters/Importsheets/Medical Claim Form.xls">Download Claim Form Template</a></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />

                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>