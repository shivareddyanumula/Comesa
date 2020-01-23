<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_SubDivision.aspx.cs" Inherits="Masters_frm_SubDivision" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Sub Function" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_SubDivision" runat="server">
                    <telerik:RadPageView ID="RPV_SubDivision" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_SubDivision" runat="server" AllowFilteringByColumn="true" AllowPaging="true" AllowSorting="true"
                                        AutoGenerateColumns="false" GridLines="None" OnNeedDataSource="rg_SubDivision_NeedDataSource"
                                        PagerStyle-AlwaysVisible="true" Skin="WebBlue">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SUBDIVISION_ID" UniqueName="SUBDIVISION_ID"
                                                    Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    UniqueName="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SUBDIVISION_NAME" HeaderText="Name"
                                                    UniqueName="SUBDIVISION_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SUBDIVISION_DESC" HeaderText="Description"
                                                    UniqueName="SUBDIVISION_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIV_CODE" HeaderText="Function"
                                                    UniqueName="SMHR_DIV_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SUBDIVISION_STATUS" HeaderText="Status"
                                                    UniqueName="SUBDIVISION_STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left" UniqueName="ColEdit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server"
                                                            CommandArgument='<%# Eval("SUBDIVISION_ID") %>' meta:resourcekey="lnk_Edit"
                                                            OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>
                                            </Columns>

                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add"
                                                        OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                        <FilterMenu Skin="WebBlue"></FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue"></HeaderContextMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_SubDivisionDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Bu" runat="server" Text="Business Unit"></asp:Label>
                                    <asp:Label ID="lbl_ID" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Bu" runat="server" AutoPostBack="true" Filter="Contains"
                                        MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Bu_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Bu" runat="server" InitialValue="Select"
                                        ControlToValidate="rcmb_Bu" ErrorMessage="Please Select Business Unit" Text="*"
                                        ValidationGroup="Controls"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Department" runat="server" AutoPostBack="true" Filter="Contains"
                                        MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Department" runat="server" InitialValue="Select"
                                        ControlToValidate="rcmb_Department" ErrorMessage="Please Select Department"
                                        Text="*" ValidationGroup="Controls"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Division" runat="server" Text="Function"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Division" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Division" runat="server" InitialValue="Select"
                                        ControlToValidate="rcmb_Division" ErrorMessage="Please Select Function"
                                        Text="*" ValidationGroup="Controls"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SubDivisionName" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_SubDivisionName" runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_SubDivisionName" runat="server"
                                        ControlToValidate="rtxt_SubDivisionName"
                                        ErrorMessage="Please Enter Sub Function" Text="*" ValidationGroup="Controls"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SubDivisionDesc" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_SubDivisionDesc" runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Active"
                                                Value="Active" />
                                            <telerik:RadComboBoxItem runat="server" Text="InActive" Value="InActive" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_summary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>