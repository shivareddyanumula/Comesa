<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_PensionContribution.aspx.cs" Inherits="Pension_frm_PensionContribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <%--    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Heading" runat="server" Text="Pension Contributions" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>--%>

    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Provident Fund Contribution" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_PensionContribution" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_PensionContribution_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="PENSION_CONTRIBUTION_ID" UniqueName="PENSION_CONTRIBUTION_ID" HeaderText="PENSION_CONTRIBUTION_ID"
                                                            meta:resourcekey="PENSION_CONTRIBUTION_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PENSION_EMPTYPE" UniqueName="PENSION_EMPTYPE" HeaderText="Employee Type"
                                                            meta:resourcekey="PENSION_EMPTYPE" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridNumericColumn DataField="PENSION_EMPLOYEE_VALUE" UniqueName="PENSION_EMPLOYEE_VALUE" HeaderText="Employee Contribution"
                                                            meta:resourcekey="PENSION_EMPLOYEE_VALUE" DataType="System.Decimal" DataFormatString="{0:.00}" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridNumericColumn DataField="PENSION_EMPLOYER_VALUE" UniqueName="PENSION_EMPLOYER_VALUE" HeaderText="Employer Contribution"
                                                            meta:resourcekey="PENSION_EMPLOYER_VALUE" DataType="System.Decimal" DataFormatString="{0:.00}" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <%--<telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PENSION_CONTRIBUTION_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>--%>
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
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblEmployeeType" runat="server" Text="Employee Type"></asp:Label>
                                            <asp:HiddenField ID="hdnPensionCntID" runat="server" />
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"></telerik:RadComboBox>
                                            <%--<telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" MaxHeight="120px" AutoPostBack="True"
                                                        MarkFirstMatch="true" >
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Permanent and Pensionable" Value="Permanent and Pensionable" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Contract" Value="Contract" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Probation" Value="Probation" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Secondment" Value="Secondment" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Members of Parliament" Value="Members of Parliament" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Members of Senate" Value="Members of Senate" />
                                                        </Items>
                                                    </telerik:RadComboBox>--%>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" runat="server" Text="*"
                                                ControlToValidate="rcmb_EmployeeType" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Select Employee Type" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblEmployeeContribution" runat="server" Text="Employee Contribution"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_EmployeeValue" runat="server" Skin="WebBlue" Type="Percent" MaxValue="100" MinValue="0"
                                                NumberFormat-DecimalDigits="1" NumberFormat-GroupSeparator="">
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeValue" runat="server" Text="*"
                                                ControlToValidate="rtxt_EmployeeValue" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter Min Value of Employee Contribution"></asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                            <telerik:RadNumericTextBox ID="rtxt_EmployeeMaxValue" runat="server" Skin="WebBlue" MaxLength="7" MinValue="0"
                                                NumberFormat-DecimalDigits="1" NumberFormat-GroupSeparator="">
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeMaxValue" runat="server" Text="*"
                                                ControlToValidate="rtxt_EmployeeMaxValue" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter Max Value of Employee Contribution"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>

                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblEmployerContribution" runat="server" Text="Employer Contribution"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_EmployerValue" runat="server" Skin="WebBlue" Type="Percent" MaxValue="100" MinValue="0"
                                                NumberFormat-DecimalDigits="1" NumberFormat-GroupSeparator="">
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_EmployerValue" runat="server" Text="*"
                                                ControlToValidate="rtxt_EmployerValue" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter Min Value of Employer Contribution"></asp:RequiredFieldValidator>
                                        </td>
                                        <%-- <td>
                                            <telerik:RadNumericTextBox ID="rtxt_EmployerMaxValue" runat="server" Skin="WebBlue" MaxLength="7" MinValue="0"
                                                NumberFormat-DecimalDigits="1" NumberFormat-GroupSeparator="">
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_EmployerMaxValue" runat="server" Text="*"
                                                ControlToValidate="rtxt_EmployerMaxValue" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter Max Value of Employer Contribution"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>

                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />
                                <asp:PostBackTrigger ControlID="btn_Update" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>