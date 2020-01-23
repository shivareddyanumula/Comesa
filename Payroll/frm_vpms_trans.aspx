<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_vpms_trans.aspx.cs" Inherits="Payroll_frm_vpms_trans" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" LoadingPanelID="RALP_Apptschd">--%>
    <table style="width: 100%;">
        <tr>
            <td style="width: 5px"></td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <span><strong>Performance Bonus</strong> </span>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table>
                                <tr>
                                    <td width="120px"></td>
                                    <td width="120px" align="left">
                                        <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                    </td>
                                    <td width="5px">
                                        <strong>:</strong>
                                    </td>
                                    <td width="180px" align="left">
                                        <telerik:RadComboBox ID="rcbBusinessUnit" MarkFirstMatch="true" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="rcbBusinessUnit_SelectedIndexChanged" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td width="120px"></td>

                                </tr>
                                <tr>
                                    <td width="120px"></td>
                                    <td width="120px" align="left">
                                        <asp:Label ID="lblFinancialPeriod" Text="Financial Period" runat="server"></asp:Label>
                                    </td>
                                    <td width="5px"><strong>:</strong></td>
                                    <td width="180px" align="left">
                                        <telerik:RadComboBox ID="rcbFinancialPeriod" runat="server" Filter="Contains"
                                            MarkFirstMatch="true" OnSelectedIndexChanged="rcbFinancialPeriod_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>

                                    </td>
                                    <td width="120px"></td>
                                </tr>
                                <tr>
                                    <td width="120px"></td>
                                    <td width="120px" align="left">
                                        <asp:Label ID="lblPeriodID" runat="server" Text="Period ID"></asp:Label>
                                    </td>
                                    <td width="5px"><strong>:</strong></td>
                                    <td width="180px" align="left">
                                        <telerik:RadComboBox ID="rcbPeriodID" runat="server" AutoPostBack="true" MarkFirstMatch="true" OnSelectedIndexChanged="rcbPeriodID_SelectedIndexChanged" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td width="120px"></td>
                                </tr>
                                <tr>
                                    <td colspan="5">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="right">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <telerik:RadGrid ID="RG_Vpay" runat="server" AllowFilteringByColumn="False"
                                            AllowPaging="false" AutoGenerateColumns="False" GridLines="None">
                                            <%--Skin="Office2007" >--%>
                                            <ClientSettings>
                                                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                                            </ClientSettings>
                                            <MasterTableView>
                                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                <Columns>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" UniqueName="Check">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true"
                                                                Text="Check All" OnCheckedChanged="chk_selectall_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                            <asp:Label ID="lbl_emp_id" runat="server" Visible="false" Text='<%#Eval("EMP_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_empname" runat="server" Text='<%#Eval("EMP_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <%--<telerik:GridTemplateColumn HeaderText="Variable Allowance">
                                                    <ItemTemplate>
                                                       <telerik:RadNumericTextBox ID="rtxt_variableallowance" runat="server" ReadOnly="true" Value='<%#Eval("AMOUNT") %>'>
                                                       </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>--%>
                                                    <telerik:GridBoundColumn HeaderText="Varialble Allowance" DataField="AMOUNT">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Component Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Component" runat="server" Text='<%#Eval("COMPONENT") %>'></asp:Label>
                                                            <asp:Label ID="lbl_Componentid" runat="server" Text='<%#Eval("SMHR_EMPCOMP_COMPID") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" Visible="true" HeaderText="Component Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Amt" runat="server" Text='<%#Eval("PERCENTAGE AMT") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Percentage">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="rtxt_percentage" runat="server">
                                                                <%--AutoPostBack="true" OnTextChanged="rtxt_percentage_TextChanged"--%>
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="rtxt_amount" runat="server" MinValue="0" Enabled="false">
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Payment Period">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Periodid" runat="server" Visible="false" Text='<%#Eval("PRDDTL_ID") %>'></asp:Label>
                                                            <asp:Label ID="lbl_Periodname" runat="server" Visible="true" Text='<%#Eval("FOR_PERIOD") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <asp:UpdatePanel ID="upd_Panel_Upload" runat="server">
                                    <ContentTemplate>

                                        <tr>
                                            <td colspan="5" align="center">
                                                <asp:Button ID="btn_Calculate" runat="server" OnClick="btn_Calculate_Click"
                                                    Text="Calculate" />
                                                &nbsp;&nbsp;
                                      <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Visible="false"
                                          Width="60px" />
                                                &nbsp;&nbsp;
                                 <asp:Button ID="btnFinalise" runat="server" Width="60px" Text="Finalise"
                                     OnClick="btnFinalise_Click" />
                                                &nbsp;&nbsp;
                                 <asp:Button ID="btnCancel" runat="server" Width="60px" Text="Cancel"
                                     OnClick="btnCancel_Click" />

                                            </td>
                                        </tr>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_Calculate" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;"></td>
                    </tr>
                </table>
            </td>
            <td style="width: 5px"></td>
        </tr>
    </table>
    <%--</telerik:RadAjaxPanel>--%>
</asp:Content>