<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PeriodType.aspx.cs" Inherits="Masters_frm_PeriodType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" width="50%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PeriotypeHeader" runat="server" Text="Period Types" Font-Bold="True"
                    meta:resourcekey="lbl_PeriotypeHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_PT_page" runat="server" SelectedIndex="0"
                    Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_PT_ViewMain" runat="server">
                        <telerik:RadGrid  ID="Rg_PeriodType" runat="server" AutoGenerateColumns="False" GridLines="None"
                             Skin="WebBlue"  OnNeedDataSource="Rg_PeriodType_NeedDataSource">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="PERIODTYPE_ID" UniqueName="PERIODTYPE_ID" HeaderText="ID"
                                        meta:resourcekey="PERIODTYPE_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERIODTYPE_NAME" UniqueName="PERIODTYPE_NAME"
                                        HeaderText="Name" meta:resourcekey="PERIODTYPE_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERIODTYPE_NOOFDAYS" UniqueName="PERIODTYPE_NOOFDAYS"
                                        HeaderText="No of Days" meta:resourcekey="PERIODTYPE_NOOFDAYS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PERIODTYPE_ID") %>'
                                                OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColDelete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%# Eval("PERIODTYPE_ID") %>'
                                                OnCommand="lnk_Delete_Command" meta:resourcekey="lnk_Delete">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_Add">Add</asp:LinkButton></div>
                                </CommandItemTemplate>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_PT_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_PeriodTypeDetails" runat="server" Text="Details" meta:resourcekey="lbl_PeriodTypeDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PeriodTypeID" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_PeriodTypeCode" runat="server" Text="Name" meta:resourcekey="lbl_PeriodTypeCode"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_PeriodTypeCode" runat="server"  Skin="WebBlue" 
                                        MaxLength="30" >
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_PeriodTypeCode" runat="server" ControlToValidate="rtxt_PeriodTypeCode"
                                        ErrorMessage="Please give a valid Period Type" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NoofDays" runat="server" Text="No. of Days" meta:resourcekey="lbl_NoofDays"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rtxt_noofdays" runat="server" DataType="System.Int32"
                                        MaxValue="90" MinValue="1" MaxLength="2">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_noofdays" runat="server" ControlToValidate="rtxt_noofdays"
                                        ErrorMessage="Please give a Valid Value" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" Width="60px" CausesValidation="False" />
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="vs_PeriodTypes" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
