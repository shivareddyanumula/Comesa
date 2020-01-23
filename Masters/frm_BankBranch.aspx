<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_BankBranch.aspx.cs" Inherits="Masters_frm_BankBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_BranchHeader" runat="server" Text="Bank Branch Code" Font-Bold="True"
                    meta:resourcekey="lbl_BranchHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_BB_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_BB_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="Rg_BankBranch" runat="server" AutoGenerateColumns="False" AllowFilteringByColumn="true"
                                        GridLines="None" OnNeedDataSource="Rg_BankBranch_NeedDataSource" AllowPaging="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BRANCH_ID" UniqueName="BRANCH_ID" HeaderText="ID"
                                                    meta:resourcekey="BRANCH_ID" Visible="False" >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BRANCH_BANK_ID" UniqueName="BANK_CODE" HeaderText="Bank Name"
                                                    meta:resourcekey="BANK_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BRANCH_CODE" UniqueName="BRANCH_CODE" HeaderText=" code"
                                                    meta:resourcekey="BRANCH_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BRANCH_NAME" UniqueName="BRANCH_NAME" HeaderText=" Name"
                                                    meta:resourcekey="BRANCH_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("BRANCH_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_BB_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                              <%--  <td colspan="4" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_BankBranchDetails" runat="server" Text="Bank Branch Code" meta:resourcekey="lbl_BankBranchDetails"></asp:Label>
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BankCode" runat="server" meta:resourcekey="lbl_BankCode" Text="Bank Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BankCode" runat="server" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1"
                                        meta:resourcekey="rcmb_BankCode" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BankCode" runat="server" ControlToValidate="rcmb_BankCode"
                                        meta:resourcekey="rfv_rcmb_BankCode" ErrorMessage="Please Select Bank Name" InitialValue="Select"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BranchId" runat="server" meta:resourcekey="lbl_BranchCode" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_BranchCode" runat="server" meta:resourcekey="lbl_BranchCode" Text=" Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_BranchCode" runat="server" TabIndex="2"
                                        Skin="WebBlue" MaxLength="50" Style="text-transform: uppercase;">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BranchCode" ControlToValidate="rtxt_BranchCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Code"
                                        meta:resourcekey="rfv_rtxt_BranchCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BranchName" runat="server" Text=" Name" meta:resourcekey="lbl_BranchName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BranchName" runat="server" TabIndex="3" 
                                        MaxLength="100" Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BranchName" runat="server" ControlToValidate="rtxt_BranchName"
                                        meta:resourcekey="rfv_rtxt_BranchName" ErrorMessage="Please Enter Name"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="4"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button runat="server" ID="btn_Save" Text="Save" ValidationGroup="Controls" OnClick="btn_Save_Click"
                                        Visible="false" TabIndex="4" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="5"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
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
