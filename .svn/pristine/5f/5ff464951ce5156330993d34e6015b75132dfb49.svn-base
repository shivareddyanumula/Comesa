<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="DOWNLOADESI.aspx.cs" Inherits="Payroll_DOWNLOADESI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ESI1" runat="server" Text="ESI CALCULATION"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_ESI_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_ESI_VIEWMAIN" runat="server" Selected="True" Width="493px">
                        <table align="center" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_ESI" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" Skin="WebBlue" OnNeedDataSource="Rg_ESI_NeedDataSource" PageSize="5"
                                        AllowFilteringByColumn="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_ESI_MASTER_ID" UniqueName="SMHR_ESI_MASTER_ID"
                                                    HeaderText="ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="bucode" UniqueName="bucode" HeaderText="Business Unit">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" UniqueName="EMPLOYEE_NAME" HeaderText="Employee">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_ESI_MASTER_IPNO" UniqueName="SMHR_ESI_MASTER_IPNO"
                                                    HeaderText="IP NUMBER">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_ESI_MASTER_IPNAME" UniqueName="SMHR_ESI_MASTER_IPNAME"
                                                    HeaderText="IP NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_ESI_MASTER_ID") %>'
                                                            OnCommand="lnk_edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_ESI_VIEWDETAILS" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_ESI" runat="server" Text="ESI DETAILS"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BUI_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Please select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ESIDUMMYID" runat="server" Visible="False"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lbl_EMPLOYEE" runat="server" Text="Employee"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_employee" runat="server" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcm_employee_SelectedIndexChanged"
                                        AutoPostBack="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_RCM_EMPLOYEE" runat="server" ControlToValidate="rcm_employee"
                                        ErrorMessage="Please select Employee" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IPNUMBER" runat="server" Text="IP Number"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RNT_IPNUMBER" runat="server" MaxLength="10">
                                    </telerik:RadTextBox>
                                    <%--  <telerik:RadNumericTextBox ID="RNT_IPNUMBER" runat="server" />--%>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_RNT_IPNUMBER" runat="server" ControlToValidate="RNT_IPNUMBER"
                                        ErrorMessage="Please Enter IP NUMBER" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IPName" runat="server" Text="IP&nbsp;Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_IPName" runat="server" MaxLength="40">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_IPName" runat="server" ControlToValidate="rtxt_IPName"
                                        ErrorMessage="Please Enter IP Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <%--<asp:CheckBox ID="chk_Status" runat="server" />--%>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server"
                                        AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>

                                    </telerik:RadComboBox>
                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" Visible="False"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_update" runat="server" Text="Update" ValidationGroup="Controls"
                                        Visible="False" OnClick="btn_update_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_PROJECT" runat="server" ShowMessageBox="True" ShowSummary="False"
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