<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Esiexport.aspx.cs" Inherits="Payroll_frm_Esiexport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function ShowESIInfo(Businessunit, Period, Periodelement) {
                var win = window.radopen('../Payroll/frm_Downloadesi.aspx?BID=' + Businessunit + '&PID=' + Period + '&PDTLID=' + Periodelement, "RW_SalDetails");
                win.center();
                win.set_modal(true);
            }

        </script>

    </telerik:RadScriptBlock>

    <table align="center">
        <tr>
            <td colspan="5" align="center"></td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Heading" runat="server" Text="Esi Information" Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td colspan="5">
                <telerik:RadMultiPage ID="rmp_Esiexport" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="rpv_Esiinfoofall" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="rg_Esiparent" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        OnNeedDataSource="rg_Esiparent_NeedDataSource" PageSize="10" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Businessunit"
                                                    AllowFiltering="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Financial Period" AllowFiltering="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PRDDTL_NAME" HeaderText="Period Element" AllowFiltering="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="DownLoad Details" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Download" runat="server" CommandArgument='<%#Eval("ESIIMPORT_PERIDEMLEMENTID") %>'
                                                            OnCommand="lnk_Download_Command" Text="View And Download">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpv_Details" runat="server">
                        <table align="center">
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Busniessunit" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Busniessunit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Businessunit" runat="server" ControlToValidate="rcmb_Busniessunit" InitialValue="Select"
                                        Display="Dynamic" ErrorMessage="Please Select Businessunit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Financialperiod" Text="Financial Period" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_Financialperiod_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Financialperiod" runat="server" ControlToValidate="rcmb_Financialperiod" InitialValue="Select"
                                        Display="Dynamic" ErrorMessage="Please Select Financial Period" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Periodelement" runat="server" Text="Period Element">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Perioddtls" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Perioddtls_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Perioddtls" runat="server" ControlToValidate="rcmb_Perioddtls" InitialValue="Select"
                                        Display="Dynamic" ErrorMessage="Please Select Period Element" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <%--  <asp:GridView ID="gv_Child" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField HeaderText="Employee Code" DataField="EMPLOYEE_NAME" />
                                            <asp:BoundField HeaderText="Employee Name" DataField="NAME" />
                                            
                                             <asp:TemplateField HeaderText="Empid">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Empid" runat="server" Text='<%# Eval("SMHR_ESI_MASTER_EMPID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Ip Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ipnumber" runat="server" Text='<%# Eval("IMPORTCHILD_IPNUMBER") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Ip Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ipname" runat="server" Text='<%# Eval("IMPORTCHILD_IPNAME") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Present Days">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Presentdays" runat="server" Text='<%# Eval("IMPORTCHILD_presentdays") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Total" runat="server" Text='<%# Eval("IMPORTCHILD_TOTALAMOUNT") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Reason Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Reasoncode" runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>--%>
                                    <telerik:RadGrid ID="rg_Child" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        AllowSorting="true" OnNeedDataSource="rg_Child_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="None" AllowFilteringByColumn="true">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Employee Code" DataField="EMPLOYEE_NAME" AllowFiltering="false" />
                                                <telerik:GridTemplateColumn HeaderText="Employee Name" AllowFiltering="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Empname" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Empid" AllowFiltering="false" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Empid" runat="server" Text='<%# Eval("SMHR_ESI_MASTER_EMPID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Ip Number" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Ipnumber" runat="server" Text='<%# Eval("IMPORTCHILD_IPNUMBER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Ip Name" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Ipname" runat="server" Text='<%# Eval("IMPORTCHILD_IPNAME") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Present Days" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Presentdays" runat="server" Text='<%# Eval("IMPORTCHILD_presentdays") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Total Amount" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Total" runat="server" Text='<%# Eval("IMPORTCHILD_TOTALAMOUNT") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Reason Code" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Reasoncode" runat="server">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Finalise" runat="server" Text="Finalise" OnClick="btn_Finalise_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_summary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>