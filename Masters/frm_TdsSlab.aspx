<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TdsSlab.aspx.cs" Inherits="Masters_frm_TdsSlab" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="PAYE Slab" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_Main" runat="server" SelectedIndex="0" Height="490px"
                    Width="990px">
                    <telerik:RadPageView ID="rpv_Main" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Main" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        Skin="WebBlue" OnNeedDataSource="rg_Main_NeedDataSource" GridLines="None" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TDS_SLAB_NAME" HeaderText="Slab Name" UniqueName="TDS_SLAB_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TDS_SLAB_DESC" HeaderText="Slab Description" UniqueName="TDS_SLAB_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Businessunit Name" ItemStyle-HorizontalAlign="Left"
                                                    UniqueName="BUSINESSUNIT_CODE" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="TDS_NAME" HeaderText="PAYE Name" ItemStyle-HorizontalAlign="Left"
                                                    UniqueName="TDS_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="EDIT" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TDS_SLAB_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" Text="Add" OnCommand="lnk_Add_Command">
                                                    </asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpv_Details" runat="server">
                        <table align="center">
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" 
                                        AutoPostBack="true" 
                                        onselectedindexchanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_tdsname" runat="server" Text="PAYE Name">
                                    </asp:Label></td>
                                <td>
                                    <b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_tdsname" runat="server" Skin="WebBlue" MarkFirstMatch="true" TabIndex="1"
                                        AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_tdsname_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_tdsname" runat="server"
                                        ControlToValidate="rcmb_tdsname" ErrorMessage="Please Select PAYE Name" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Tdsname" runat="server" ErrorMessage="Enter Alphabets Only For PAYE Name"
                                        ControlToValidate="rcmb_tdsname" ValidationExpression="^[a-zA-z''-'\s]{1,40}$">*</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr id="trTxtSlab" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_TdsSlabName" runat="server" Text="Slab Name">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TdsSlabName" runat="server" Skin="WebBlue" TabIndex="2"
                                        MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_TdsSlabName" runat="server"
                                        ControlToValidate="rtxt_TdsSlabName" ErrorMessage="Please Enter Slab Name"
                                        Text="*" ValidationGroup="Controls">
                                        <asp:RegularExpressionValidator ID="rev_TdsSlabname" runat="server" ErrorMessage="Enter Alphabets Only For Name"
                                            ControlToValidate="rtxt_TdsSlabName" ValidationExpression="^[a-zA-z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trRcmbSlab" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lblSlab" runat="server" Text="Slab Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmbSlab" runat="server" MarkFirstMatch="true" TabIndex="3" Filter="Contains"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_tdsslabname" runat="server"
                                        ControlToValidate="rcmbSlab" ErrorMessage="Please Select Slab" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsSlabDesc" runat="server" Text="
                                        
                                        Slab Description">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TdsSlabDesc" runat="server" Skin="WebBlue" TabIndex="4"
                                        MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>

                        </table>
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" TabIndex="5"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" TabIndex="5"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" TabIndex="6"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_TDS" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>