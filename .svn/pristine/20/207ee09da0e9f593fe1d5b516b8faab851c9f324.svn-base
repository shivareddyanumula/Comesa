<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_esiimport.aspx.cs" Inherits="" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_esiimport.aspx.cs" Inherits="Payroll_frm_esiimport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_esiimport" runat="server" Text="Import ESI"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_ESIIMPORT_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_ESIIMPORT_VIEWMAIN" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>

                                    <telerik:RadGrid ID="Rg_ESIIMPORT" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" Skin="WebBlue" OnNeedDataSource="Rg_ESIIMPORT_NeedDataSource"
                                        PageSize="5" AllowFilteringByColumn="True">

                                        <MasterTableView CommandItemDisplay="Top">

                                            <Columns>
                                                <telerik:GridBoundColumn DataField="ESIIMPORT_ID" UniqueName="ESIIMPORT_ID" HeaderText="ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    HeaderText="Business Unit">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME" HeaderText="Financial Period">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PRDDTL_NAME" UniqueName="PRDDTL_NAME" HeaderText="Period Element">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ESIIMPORT_EMPNAME" UniqueName="ESIIMPORT_EMPNAME"
                                                    HeaderText="Employee">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ESIIMPORT_IPNO" UniqueName="ESIIMPORT_IPNO" HeaderText="IP Number">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ESIIMPORT_IPNAME" UniqueName="ESIIMPORT_IPNAME"
                                                    HeaderText="IP Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ESIIMPORT_PRESENTDAYS" UniqueName="ESIIMPORT_PRESENTDAYS"
                                                    HeaderText="Present Days">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ESIIMPORT_TOTALAMOUNT" UniqueName="ESIIMPORT_TOTALAMOUNT"
                                                    HeaderText="Total Amount">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_DOWNLOAD" runat="server" CommandArgument='<%# Eval("ESIIMPORT_ID") %>'
                                                            OnCommand="lnk_DOWNLOAD_Command">DOWNLOAD</asp:LinkButton>
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
                    <telerik:RadPageView ID="RP_ESIIMPORT_VIEWDETAILS" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_det" runat="server" Text="IMPORT DETAILS"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" MarkFirstMatch="true" runat="server" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Please select Business Unit" ValidationGroup="Controls" InitialValue="Select"  >*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ESIIMPORT_FINANCIALPERIOD" runat="server" Text="Financial&nbsp;Period"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCM_FINANCIALPERIOD" runat="server" AutoPostBack="true" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="RCM_FINANCIALPERIOD_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_RCM_FINANCIALPERIOD" runat="server" ControlToValidate="RCM_FINANCIALPERIOD"
                                        ErrorMessage="Please Select Financial Period" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr id="finelem_id" runat="server">
                                <td>
                                    <asp:Label ID="lbl_financialperiodelements" runat="server" Text="Period Elements"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_fin_elem" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcm_fin_elem_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_RCM_FINANCIALPERIOD" runat="server" ControlToValidate="RCM_FINANCIALPERIOD"
                                        ErrorMessage="Please Select Financial Period" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td></td>
                                <td>
                                    <telerik:RadGrid ID="rg_importchild" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AutoGenerateColumns="False" OnNeedDataSource="rg_importchild_NeedDataSource"
                                        GridLines="None" OnExcelMLExportRowCreated="RadGrid1_ExcelMLExportRowCreated" OnExcelMLExportStylesCreated="RadGrid1_ExcelMLExportStyles">
                                        <ExportSettings FileName="SMHR_ESIIMPORT_DETAILS" />

                                        <MasterTableView TableLayout="Fixed">
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Employee">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_EMPLOYEE_NAME" runat="server" Text='<%# Eval("EMPLOYEE_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" HeaderText="EMPLOYEE_NAME ID"
                                                    UniqueName="EMPLOYEE_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="IP Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_IMPORTCHILD_IPNUMBER" runat="server" Text='<%# Eval("IMPORTCHILD_IPNUMBER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="IP Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_IMPORTCHILD_IPNAME" runat="server" Text='<%# Eval("IMPORTCHILD_IPNAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Present Days">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_IMPORTCHILD_presentdays" runat="server" Text='<%# Eval("IMPORTCHILD_presentdays") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_IMPORTCHILD_TOTALAMOUNT" runat="server" Text='<%# Eval("IMPORTCHILD_TOTALAMOUNT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Reason Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_IMPORTCHILD_reasoncode" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="BTN_DOWNLOAD" runat="server" Text="Download" ValidationGroup="Controls"
                                        OnClick="BTN_DOWNLOAD_Click" />
                                    <asp:ValidationSummary ID="vs_IMPORT_ESI" runat="server" ShowMessageBox="True" ShowSummary="False"
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