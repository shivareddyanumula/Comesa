<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_applicantgrade.aspx.cs" Inherits="Recruitment_frm_applicantgrade" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ApplicantGradeHeader" runat="server" Text="Applicant Grade" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_ApplicantGrade" runat="server" SelectedIndex="0" Height="490px"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="RP_ApplicantGrade" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_ApplicantGrade" runat="server"
                                        AutoGenerateColumns="false" OnNeedDataSource="RG_ApplicantGrade_NeedDataSource"
                                        AllowPaging="true" AllowFilteringByColumn="True" PageSize="5">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="APPLGRADEID" DataField="APPLGRADE_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Type" DataField="APPGRADE_SETID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Interview Rounds" DataField="HR_MASTER_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Interview Name" DataField="APPGRADE_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="APPLGRADE_DESCRIPTION">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%#Eval("APPLGRADE_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_ApplicantDetails" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_GradeId" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_Type" runat="server" Text="Interview Rounds"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCMB_Type" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Type" runat="server" ErrorMessage="Please Select Interview Rounds"
                                        ControlToValidate="RCMB_Type" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_Name" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_Name" runat="server" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Name" runat="server" ErrorMessage="Please Enter Name"
                                        ControlToValidate="txt_Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_Description" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_Description" runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="Submit"
                                        ValidationGroup="Controls" Visible="false" />
                                    <asp:Button ID="btn_Update" runat="server" OnClick="btn_Submit_Click" Text="Update"
                                        ValidationGroup="Controls" Visible="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                                </td>
                            </tr>
                            <tr>
                                <asp:ValidationSummary ID="vs_ApplicantGrade" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="Controls" />
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>