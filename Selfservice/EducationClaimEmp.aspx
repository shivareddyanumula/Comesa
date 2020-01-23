﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EducationClaimEmp.aspx.cs" Inherits="Selfservice_EducationClaimEmp" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .eWidth {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_EducationDetHeader" runat="server" Font-Bold="true" Text="Educational Claim"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Education_page" runat="server" SelectedIndex="0" Width="990px" Height="480px">
                    <telerik:RadPageView ID="Rp_Education_ViewMain" runat="server" meta:resourcekey="Rp_Education_ViewMain"
                        Selected="True">
                        <table align="center" width="80%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Educationdet" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_Educationdet_NeedDataSource" PageSize="10" Skin="WebBlue"
                                        ClientSettings-Scrolling-AllowScroll="true"
                                        ClientSettings-Scrolling-UseStaticHeaders="true" Width="900px" Height="355px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EDU_ID" UniqueName="EDU_ID" HeaderText="Edu id"
                                                    meta:resourcekey="EDU_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_FNAME" HeaderText="Employee Name"
                                                    UniqueName="EMP_FNAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BENIFICIARY"
                                                    HeaderText="Beneficiary Name" UniqueName="BENIFICIARY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EDU_EXPEN_NAME" HeaderText="Expenditure"
                                                    meta:resourcekey="EDU_EXPEN_NAME" UniqueName="EDU_EXPEN_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CLAIM_AMNT" HeaderText="Amount"
                                                    meta:resourcekey="CLAIM_AMNT" UniqueName="CLAIM_AMNT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INVOICE" HeaderText="Invoice ID"
                                                    meta:resourcekey="INVOICE" UniqueName="INVOICE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RULE_AMNT" HeaderText="Amount as per Rule"
                                                    meta:resourcekey="RULE_AMNT" UniqueName="RULE_AMNT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status"
                                                    UniqueName="STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Receipt and Documents " AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <a id="D2" runat="server" target="_blank" href='<%#Eval("EDU_UPLOAD_RECPTDOC") %>'>Download/View</a>
                                                        <asp:Label ID="lbl_BioData" Text='<%#Eval("EDU_UPLOAD_RECPTDOC") %>' Visible="false" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Attendance Certificate " AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <a id="D2" runat="server" target="_blank" href='<%#Eval("EDU_UPLOAD_ATTDCERT") %>'>Download/View</a>
                                                        <asp:Label ID="lbl_BioData" Text='<%#Eval("EDU_UPLOAD_ATTDCERT") %>' Visible="false" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColView">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_View" runat="server"
                                                            CommandArgument='<%# Eval("EDU_ID") %>' meta:resourcekey="lnk_View"
                                                            OnCommand="lnk_View_Command" Text="View"></asp:LinkButton>
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
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_Loans" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
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
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" MaxHeight="300px"
                                                MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="rcmb_Employee"
                                                ErrorMessage="Please select Employee"
                                                InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True"
                                                MarkFirstMatch="true" MaxHeight="300px" Enabled="false" Filter="Contains"
                                                OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Skin="WebBlue">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Department" runat="server" AutoPostBack="True"
                                                MarkFirstMatch="true" MaxHeight="300px" Enabled="false" Filter="Contains"
                                                OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged" Skin="WebBlue">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFinPeriod" runat="server" Text="Financial Period"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbFinPeriod" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                Skin="WebBlue" MaxHeight="300px" AutoPostBack="true" OnSelectedIndexChanged="rcbFinPeriod_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvFinPeriod" runat="server" ControlToValidate="rcbFinPeriod"
                                                ErrorMessage="Please select Financial Period"
                                                InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Scale" runat="server" Text="Grade"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbScale" runat="server" Enabled="false"
                                                Skin="WebBlue" MaxHeight="300px" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvScale" runat="server" ControlToValidate="rcbScale"
                                                ErrorMessage="Please select Grade"
                                                InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_EduAllScale" runat="server" Text="Allowance as per Grade"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntbEduAllScale" runat="server" Skin="WebBlue" MaxHeight="300px" Enabled="false">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DependentName" runat="server" Text="Dependent Name"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbDependentName" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                Skin="WebBlue" MaxHeight="300px" AutoPostBack="true" OnSelectedIndexChanged="rcbDependentName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvDependentName" runat="server" ControlToValidate="rcbDependentName"
                                                ErrorMessage="Please select Dependent Name"
                                                InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BalAval" runat="server" Text="Balance Available"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntb_bal" runat="server" Width="125px" Enabled="false"
                                                MaxLength="9">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Expenditure" runat="server" Text="Expenditure"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_Expenditure" runat="server"
                                                Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                Width="125px" MaxLength="100">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Expenditure" runat="server"
                                                ControlToValidate="rtxt_Expenditure" ErrorMessage="Please Enter Expenditure For"
                                                meta:resourcekey="rtxt_Expenditure" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ClaimAmt" runat="server" Text="Claim Amount"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rad_ClaimAmount" runat="server"
                                                Culture="English (United States)" MaxLength="9" AutoPostBack="true"
                                                MinValue="0" Skin="WebBlue" OnTextChanged="rad_ClaimAmount_TextChanged">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rad_ClaimAmount" runat="server" ControlToValidate="rad_ClaimAmount"
                                                ErrorMessage="Please Enter Claim Amount"
                                                meta:resourcekey="rad_ClaimAmount" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRule75" runat="server" Text="Final Amount as per Rule 75%"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntbRule75" runat="server"
                                                Culture="English (United States)" MaxLength="9"
                                                MinValue="0" Skin="WebBlue" Enabled="false">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ReceiptNo" runat="server" Text="Receipt No.."></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox runat="server" ID="rntbReceiptNo" Skin="WebBlue" Width="125px">
                                                <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_ReceiptNo" runat="server"
                                                ControlToValidate="rntbReceiptNo" ErrorMessage="Please Enter Receipt No"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ReceiptDate" runat="server" Text="Receipt Date"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdpt_ReceiptDate" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" Width="135px">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdpt_ReceiptDate" runat="server"
                                                ControlToValidate="rdpt_ReceiptDate" ErrorMessage="Please Pick Receipt Date"
                                                meta:resourcekey="rdpt_ReceiptDate" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Documents" runat="server" Text="Upload Receipt and Documents "></asp:Label></td>
                                        <td>:
                                        </td>

                                        <td>
                                            <asp:FileUpload ID="FBrowse" runat="server" />
                                        </td>
                                        <%--<td colspan="4" align="center">
                                            <asp:LinkButton ID="lnk_Download" runat="server" Visible="true">Click Here to View</asp:LinkButton>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Certificate" runat="server" Text="Attendance Certificate"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fu_Browse" runat="server" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <%-- <tr>
                                        <td colspan="4" align="center">
                                            <asp:LinkButton ID="lnk_Download" runat="server" Visible="true">Click Here to View</asp:LinkButton>
                                        </td>
                                    </tr>--%>

                                    <tr>
                                        <td colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="btn_Submit" runat="server" Text="Submit" ValidationGroup="Controls" OnClick="btn_Submit_Click" />
                                            <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" OnClick="btn_Submit_Click" Visible="false" />
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="btn_Finalize" runat="server" Text="Finalize the Claim" ValidationGroup="Controls" OnClick="btn_Submit_Click" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:ValidationSummary ID="vg_Master" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" meta:resourcekey="vg_Master" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Submit" />
                                <asp:PostBackTrigger ControlID="btn_Update" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>