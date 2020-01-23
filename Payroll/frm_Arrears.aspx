<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Arrears.aspx.cs" Inherits="Payroll_Arrears" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <telerik:RadAjaxPanel ID="RAP_Arrears" runat="server" Height="613px" Width="990px"
                    LoadingPanelID="RALP_Arrears">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadMultiPage ID="rm_Arrears" runat="server" SelectedIndex="0">
                                    <telerik:RadPageView ID="Rp_ArrearsMain" runat="server" Selected="True">
                                        <table align="center" width="100%">
                                            <tr>
                                                <td>
                                                    <telerik:RadGrid ID="Rg_Arrears" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                        Skin="WebBlue" AllowPaging="True" OnNeedDataSource="Rg_Arrears_NeedDataSource"
                                                        Width="100%" AllowFilteringByColumn="True">
                                                        <MasterTableView CommandItemDisplay="Top">
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                                    HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME" HeaderText="Period"
                                                                    meta:resourcekey="SMHR_ARR_PERIOD">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="FROMNAME" UniqueName="FROMNAME" HeaderText="Period Element"
                                                                    meta:resourcekey="SMHR_ARR_FROM_PERIODELEMENT">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="TONAME" UniqueName="TONAME" HeaderText="Effective Element"
                                                                    meta:resourcekey="SMHR_ARR_TO_PERIODELEMENT">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="STATUS" UniqueName="STATUS" HeaderText="Status"
                                                                    meta:resourcekey="STATUS">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_ARR_ID") %>'
                                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
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
                                    <telerik:RadPageView ID="rp_Arrears" runat="server">
                                        <table align="center">
                                            <tr>
                                                <td colspan="8" align="center">
                                                    <asp:Label ID="lbl_Arrears_Header" runat="server" Text="Employee Arrears" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <br />
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Businessunit" runat="server" Text="BusinessUnit"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_BusinessUnit" runat="server" Text="*" Display="Dynamic"
                                                        ErrorMessage="Please Select Business Unit" ControlToValidate="ddl_BusinessUnit"
                                                        InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: left">
                                                    <asp:Label ID="lbl_PPeriod" runat="server" Text="PresentPeriod" Font-Underline="true"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Period" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Period_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_Period" runat="server" Text="*" Display="Dynamic"
                                                        ErrorMessage="Please Select Present Period" ControlToValidate="ddl_Period" InitialValue="Select"
                                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PeriodElements" runat="server" Text="PeriodElements"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_PeriodElements" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_PeridElements" runat="server" ControlToValidate="ddl_PeriodElements"
                                                        Display="Dynamic" ErrorMessage="Please Select Present Period Elements" InitialValue="Select"
                                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: left">
                                                    <asp:Label ID="Label3" runat="server" Text="EffectivePeriod" Font-Underline="true"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_EPeriod" runat="server" Text="Period"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_EPeriod" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddl_EPeriod_SelectedIndexChanged" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_EPeriod" runat="server" Text="*" Display="Dynamic"
                                                        ErrorMessage="Please Select Effective Period" ControlToValidate="ddl_EPeriod"
                                                        InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_EPeriodElements" runat="server" Text="PeriodElements"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_EPeriodElements" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_EPeriodElements" runat="server" ControlToValidate="ddl_EPeriodElements"
                                                        Display="Dynamic" ErrorMessage="Please Select Effective Period Elements" InitialValue="Select"
                                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4"></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" align="center">
                                                    <asp:Button ID="btn_GetDet" runat="server" Text="Get Details" ValidationGroup="Controls"
                                                        OnClick="btn_GetDet_Click" />
                                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table align="center">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GRV_Arrears" runat="server" GridLines="Both" BorderColor="#67839a"
                                                        AutoGenerateColumns="false" HorizontalAlign="Left" BorderStyle="Solid" AllowPaging="True">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <%-- employee id--%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Emp_ID" runat="server" Text='<%# Eval("EMP_ID") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="Left">
                                                                <%-- employee name --%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Emp_Name" runat="server" Text='<%# Eval("EMPLOYEE_NAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date of Join">
                                                                <%-- employee date of join --%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Emp_DOJ" runat="server" Text='<%# Eval("DATE_OF_JOIN") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Present Gross Salary">
                                                                <%-- present gross salary--%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Emp_Gross" runat="server" Text='<%# Eval("GROSS_SALARY") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Select Type">
                                                                <%-- arrears select --%>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddl_Type" runat="server">
                                                                        <asp:ListItem Value="1" Text="%Age" Selected="True" />
                                                                        <asp:ListItem Value="2" Text="Direct" />
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Value">
                                                                <%-- arrears value --%>
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="txt_Value" runat="server" MinValue="0" MaxValue="1000000">
                                                                    </telerik:RadNumericTextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="New Gross Salary">
                                                                <%-- new gross salary --%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Emp_New_Gross" runat="server" Text='<%# Eval("NEW_GROSS") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Arrears">
                                                                <%-- Arrears --%>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Emp_Arrears" runat="server" Text="Not Processed"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table align="center">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btn_Process" runat="server" Text="Process Arrears" Visible="false"
                                                        ValidationGroup="Controls" OnClick="btn_Process_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="btn_Finalize" runat="server" Text="Finalize Arrears" Visible="false"
                                                        OnClick="btn_Finalize_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>
                                </telerik:RadMultiPage>
                            </td>
                        </tr>
                    </table>
                </telerik:RadAjaxPanel>
                <telerik:RadAjaxLoadingPanel ID="RALP_Arrears" runat="server" Skin="Default">
                </telerik:RadAjaxLoadingPanel>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="VS_Arrears" runat="server" ValidationGroup="Controls"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>