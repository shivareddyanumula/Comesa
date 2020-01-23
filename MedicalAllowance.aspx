<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="MedicalAllowance.aspx.cs" Inherits="MedicalAllowance" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_MedicalDetHeader" runat="server" Font-Bold="true" Text="Medical Claim"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Medical_page" runat="server" SelectedIndex="0" Width="990px" Height="480px" ScrollBars="Auto" Style="z-index: 10">
                    <telerik:RadPageView ID="Rp_Medical_ViewMain" runat="server" meta:resourcekey="Rp_Medical_ViewMain"
                        Selected="True">

                        <table align="center" width="80%">
                            <tr>

                                <td>

                                    <telerik:RadGrid ID="Rg_Medicaldet" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_Medicaldet_NeedDataSource" PageSize="10" Skin="WebBlue" ClientSettings-Scrolling-AllowScroll="true"
                                        ClientSettings-Scrolling-UseStaticHeaders="true" Width="900px" Height="355px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMP_ID" HeaderText="Employee Name"
                                                    meta:resourcekey="EMP_ID" UniqueName="EMP_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BF_NAME"
                                                    HeaderText="Beneficiary Name" meta:resourcekey="BF_NAME"
                                                    UniqueName="BF_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EXP_NAME" HeaderText="Expenditure Type"
                                                    meta:resourcekey="EXP_NAME" UniqueName="EXP_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AMT" HeaderText="Amount"
                                                    meta:resourcekey="AMT" UniqueName="AMT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INV_ID" HeaderText="Invoice ID"
                                                    meta:resourcekey="INV_ID" UniqueName="INV_ID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="STA_ID" HeaderText="Status"
                                                    meta:resourcekey="STA_ID" UniqueName="STA_ID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColView">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_View" runat="server"
                                                            CommandArgument='<%# Eval("CLAIMID") %>' meta:resourcekey="lnk_View"
                                                            OnCommand="lnk_View_Command" Text="View"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>

                    <telerik:RadPageView ID="RPV_Loans" runat="server">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Employee" runat="server" AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label></td>
                                <td>:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Scale" runat="server" Text="Scale"></asp:Label></td>
                                <td>:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_MdcAllScale" runat="server" Text="Medical Allowance as per Scale"></asp:Label></td>
                                <td>:
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BalAval" runat="server" Text="Balance Available"></asp:Label></td>
                                <td>:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_DependentName" runat="server" Text="Dependent Name"></asp:Label></td>
                                <td>:
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ClaimType" runat="server" Text="Claim Type"></asp:Label></td>
                                <td>:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Expenditure" runat="server" Text="Expenditure Type"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Expenditure" runat="server" AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Expenditure_SelectedIndexChanged" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Expenditure" runat="server"
                                        ControlToValidate="rcmb_Expenditure" ErrorMessage="Please Select Expenditure Type"
                                        meta:resourcekey="rcmb_Expenditure" Text="*" InitialValue="Select"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ClaimAmt" runat="server" Text="Claim Amount"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rad_ClaimAmount" runat="server"
                                        Culture="English (United States)" MaxLength="13"
                                        MinValue="0" Skin="WebBlue">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rad_ClaimAmount" runat="server" ControlToValidate="rad_ClaimAmount" ErrorMessage="Please Enter Claim Amount"
                                        meta:resourcekey="rad_ClaimAmount" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InvoiceNo" runat="server" Text="Invoice No.."></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_InvoiceNo" runat="server"
                                        Skin="WebBlue" DisabledStyle-BackColor="Window"
                                        Width="125px">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_InvoiceNo" runat="server"
                                        ControlToValidate="rtxt_InvoiceNo" ErrorMessage="Please Enter Invoice No"
                                        meta:resourcekey="rtxt_InvoiceNo" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InvoiceDate" runat="server" Text="Invoice Date"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdpt_InvoiceDate" runat="server" Culture="English (United States)" Skin="WebBlue" Width="135px"></telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdpt_InvoiceDate" runat="server"
                                        ControlToValidate="rdpt_InvoiceDate" ErrorMessage="Please Pick Invoice Date"
                                        meta:resourcekey="rdpt_InvoiceDate" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Documents" runat="server" Text="Upload Invoice and Documents "></asp:Label></td>
                                <td>:
                                </td>

                                <td>
                                    <asp:FileUpload ID="FBrowse" runat="server" />
                                    <asp:RegularExpressionValidator ID="rev_FBrowse" ControlToValidate="FBrowse"
                                        runat="Server" ErrorMessage="Document type should be Jpeg/Pdf/word" ValidationGroup="Controls"
                                        Text="*" ValidationExpression="^.+\.((pdf))" />
                                    <asp:RequiredFieldValidator ID="rfv_FBrowse" runat="server" Text="*"
                                        ControlToValidate="FBrowse" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Select file to upload"></asp:RequiredFieldValidator>
                                </td>

                            </tr>

                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" ValidationGroup="Controls" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center"></td>
                                <asp:Button ID="btn_Finalize" runat="server" Text="Finalize the Claim" ValidationGroup="Controls" OnClick="btn_Finalize_Click" />
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vg_Master" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vg_Master" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>