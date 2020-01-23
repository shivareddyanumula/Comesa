<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Tds_Params.aspx.cs" Inherits="Masters_frm_Tds_Params" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="PAYE Params - Add/Edit Existing Values" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_Main" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="rpv_Grid" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Main" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        GridLines="None" OnNeedDataSource="rg_Main_NeedDataSource" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TDS_NAME" HeaderText="Name" UniqueName="TDS_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TDS_SLAB_NAME" HeaderText="Slab Name" UniqueName="TDS_SLAB_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Period" UniqueName="PERIOD_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="TDS_PARAMS_FROMVAL" HeaderText="From Value" FilterControlWidth="100px"
                                                    UniqueName="TDS_PARAMS_FROMVAL" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridNumericColumn DataField="TDS_PARAMS_TOVAL" HeaderText="To Value" UniqueName="TDS_PARAMS_TOVAL" ItemStyle-HorizontalAlign="Left" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridNumericColumn DataField="TDS_PARAMS_VALUE" HeaderText="Params Value" FilterControlWidth="100px"
                                                    UniqueName="TDS_PARAMS_VALUE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridNumericColumn DataField="TDS_PARAMS_PERCENT" HeaderText="Params Percent" FilterControlWidth="100px"
                                                    UniqueName="TDS_PARAMS_PERCENT" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <%--<telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="" UniqueName="">
                                                </telerik:GridBoundColumn--%>
                                                <telerik:GridTemplateColumn UniqueName="EDIT" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TDS_PARAMS_ID") %>'
                                                            OnCommand="lnk_Edit_Command" Text="Edit">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Commnad" Text="Add">
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
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" ErrorMessage="Select a Business Unit">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Period">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Period" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Period" runat="server" Text="*" InitialValue="Select"
                                        ControlToValidate="rcmb_Period" ValidationGroup="Controls" ErrorMessage="Please Select Period">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_tdsname" runat="server" Text="Name">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_tdsname" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" TabIndex="2"
                                        OnSelectedIndexChanged="rcmb_tdsname_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_tdsname" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="rcmb_tdsname" ValidationGroup="Controls" ErrorMessage="Please Select Name">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Slab" runat="server" Text="Slab Name">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Slab" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Slab" runat="server" InitialValue="Select" Text="*"
                                        ControlToValidate="rcmb_Slab" ValidationGroup="Controls" ErrorMessage="Please Select Slab Name">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsFromVal" runat="server" Text="From Value"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_TdsFromVal" runat="server" MinValue="0.00" TabIndex="4"
                                        MaxLength="20">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_TdsFromVal" runat="server" Text="*" ControlToValidate="rntxt_TdsFromVal"
                                        ValidationGroup="Controls" ErrorMessage="Please Specify From Value">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsToVal" runat="server" Text="To Value">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_TdsToVal" runat="server" MaxLength="20" TabIndex="5"
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_TdsToVal" runat="server" Text="*" ControlToValidate="rntxt_TdsToVal"
                                        ValidationGroup="Controls" ErrorMessage="Please Specify To Value">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsVal" runat="server" Text="Value">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_TdsVal" runat="server" MaxLength="7" TabIndex="6"
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_TdsVal" runat="server" Text="*" ControlToValidate="rntxt_TdsVal"
                                        ValidationGroup="Controls" ErrorMessage="Enter Tds Value">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsPercent" runat="server" Text="Percent">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_TdsPercent" runat="server" MaxLength="3" TabIndex="7"
                                        MaxValue="100" MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_TdsPercent" runat="server" Text="*" ControlToValidate="rntxt_TdsPercent"
                                        ValidationGroup="Controls" ErrorMessage="Enter Tds Percent">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>

                        </table>
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" OnClick="btn_Save_Click" TabIndex="8" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" TabIndex="8"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" TabIndex="9" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Tds_Params" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>