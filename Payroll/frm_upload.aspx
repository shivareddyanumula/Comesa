<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_upload.aspx.cs" Inherits="frm_upload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="upd_Panel_Upload" runat="server">
                    <ContentTemplate>
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadMultiPage ID="rmp_documentcenter" runat="server" SelectedIndex="0">
                                        <telerik:RadPageView ID="rpv_uploadedfiles" runat="server">
                                            <table align="center">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lbl_uploadedfiles" runat="server" Text="Document Manager" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadGrid ID="rg_uploadedfiles" runat="server"
                                                            AllowFilteringByColumn="false" AutoGenerateColumns="False" Skin="Office2007"
                                                            GridLines="None" AllowSorting="True" Width="500px">
                                                            <MasterTableView CommandItemDisplay="Top">
                                                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="File Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtn_download" Text='<%#  Eval("UPLOAD_FILENAME") %>' runat="server"
                                                                                OnCommand="lbtn_download_OnCommand" CommandArgument='<%#Eval("UPLOAD_FILE_PATH") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridBoundColumn DataField="UPLOAD_FOLDER_NAME" UniqueName="UPLOAD_FOLDER_NAME"
                                                                        AllowFiltering="false" HeaderText="Folder" meta:resourcekey="UPLOAD_FOLDER_NAME">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="UPLOAD_CREATEDDATE" UniqueName="UPLOAD_CREATEDDATE"
                                                                        AllowFiltering="false" HeaderText="Created&nbsp;Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                                        AllowFiltering="false" HeaderText="Business&nbsp;Unit">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <%--<telerik:GridTemplateColumn AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtn_download" Text="Download&nbsp;File" runat="server" OnCommand="lbtn_download_OnCommand"
                                                                                CommandArgument='<%#Eval("UPLOAD_FILE_PATH") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>--%>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtn_delete" Text="Delete" runat="server" OnCommand="lbtn_delete_OnCommand"
                                                                                OnClientClick="return confirm('Are you sure you want to delete?')" CommandArgument='<%#Eval("UPLOAD_FILE_PATH") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <PagerStyle AlwaysVisible="True" />
                                                                <CommandItemTemplate>
                                                                    <div align="right">
                                                                        <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_add" meta:Resourcekey="lnk_Add"
                                                                            Text="Upload Files" Font-Bold="True"></asp:LinkButton>
                                                                    </div>
                                                                </CommandItemTemplate>
                                                            </MasterTableView>
                                                            <HeaderContextMenu Skin="WebBlue">
                                                            </HeaderContextMenu>
                                                            <PagerStyle AlwaysVisible="True" />
                                                            <FilterMenu Skin="WebBlue">
                                                            </FilterMenu>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="rpv_uploadfiles" runat="server">
                                            <table align="center">
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lbl_uploadfiles" runat="server" Text="Upload&nbsp;Files" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_businessunit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadComboBox ID="rcmb_businessunit" runat="server" AutoPostBack="True" MaxHeight="120px"
                                                            MarkFirstMatch="true" OnSelectedIndexChanged="RadComboBox1_SelectedIndexChanged" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_businessunit" runat="server"
                                                            ControlToValidate="rcmb_businessunit"
                                                            ErrorMessage="Please&nbsp;Select&nbsp;BusinessUnit " InitialValue="Select"
                                                            ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_newfolder" runat="server"
                                                            Text="Create&nbsp;a&nbsp;new&nbsp;folder"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rb_newfolder" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_previousfolder" runat="server" Text="Previous&nbsp;Folders"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadComboBox ID="rcmb_prev_folder" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_PrevFolder" runat="server" Enabled="false" ControlToValidate="rcmb_prev_folder" InitialValue="Select"
                                                            ErrorMessage="Please&nbsp;Select&nbsp;Previous&nbsp;Folder" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_foldername" runat="server" Text="Folder&nbsp;Name"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <b>:</b>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadTextBox ID="txt_foldername" runat="server" MaxLength="100">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_FolderName" runat="server" Enabled="false" ControlToValidate="txt_foldername"
                                                            ErrorMessage="Please&nbsp;Enter&nbsp;Folder&nbsp;Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_filename" runat="server" Text="File Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadTextBox ID="txt_filename" runat="server" MaxLength="100">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_txt_filename" runat="server"
                                                            ControlToValidate="txt_filename" Display="Static"
                                                            ErrorMessage="Please&nbsp;Enter&nbsp;File&nbsp;Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_upload" runat="server" Text="Upload"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="fileupload_upload" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click"
                                                            Text="Upload" ValidationGroup="Controls" />
                                                        <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click"
                                                            Text="Cancel" />
                                                        <asp:ValidationSummary ID="vs_upload" runat="server" ShowMessageBox="True"
                                                            ShowSummary="False" ValidationGroup="Controls" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="rpv_download" runat="server">
                                            <table align="center">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lbl_dwnloadfiles" runat="server" Text="Document Manager" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadGrid ID="rg_download" runat="server" AutoGenerateColumns="False" Width="500px"
                                                            Skin="Office2007" GridLines="None" AllowSorting="True" AllowFilteringByColumn="false">
                                                            <MasterTableView>
                                                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="File Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtn_download" Text='<%#  Eval("UPLOAD_FILENAME") %>' runat="server"
                                                                                OnCommand="lbtn_download_OnCommand" CommandArgument='<%#Eval("UPLOAD_FILE_PATH") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridBoundColumn DataField="UPLOAD_FOLDER_NAME" UniqueName="UPLOAD_FOLDER_NAME"
                                                                        HeaderText="Category" meta:resourcekey="UPLOAD_FOLDER_NAME">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="UPLOAD_CREATEDDATE" UniqueName="UPLOAD_CREATEDDATE"
                                                                        AllowFiltering="false" HeaderText="Created&nbsp;Date">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                                        AllowFiltering="false" HeaderText="Business&nbsp;Unit">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                                <EditFormSettings>
                                                                    <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                                        UpdateImageUrl="Update.gif">
                                                                    </EditColumn>
                                                                </EditFormSettings>
                                                                <PagerStyle AlwaysVisible="True" />
                                                            </MasterTableView>
                                                            <HeaderContextMenu Skin="WebBlue">
                                                            </HeaderContextMenu>
                                                            <PagerStyle AlwaysVisible="True" />
                                                            <FilterMenu Skin="WebBlue">
                                                            </FilterMenu>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_upload" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>