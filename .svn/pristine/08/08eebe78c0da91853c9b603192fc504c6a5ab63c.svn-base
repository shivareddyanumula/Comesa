<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_InterviewAssesment.aspx.cs" Inherits="Recruitment_frm_InterviewAssesment" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="111%" Width="100%">
        <br />
        <br />
        <telerik:RadMultiPage ID="RMP_InterviewAssesment" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="RPV_InterviewAssesmentHeader" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbl_HeaderText" runat="server" Font-Bold="True" Font-Underline="true"
                                Font-Names="Arial" Font-Size="11pt" Text="Interview Assesment Form"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="2" cellspacing="2" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_JobReq" runat="server" Text="Job Request"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="Rcb_JobReq" runat="server" AutoPostBack="true" Filter="Contains"
                                            OnSelectedIndexChanged="Rcb_JobReq_SelectedIndexChanged" MarkFirstMatch="true">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RFV_Rcb_JobReq" runat="server" ControlToValidate="Rcb_JobReq"
                                            ErrorMessage="Select Job Request" InitialValue="Select" ValidationGroup="ControlsHeader">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_ApplicantID" runat="server" Text="Select Applicant"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="Rcb_ApplicantID" runat="server" Filter="Contains"
                                            AutoPostBack="True" OnSelectedIndexChanged="Rcb_ApplicantID_SelectedIndexChanged" MarkFirstMatch="true">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RFV_Rcb_ApplicantID" runat="server" ControlToValidate="Rcb_ApplicantID"
                                            ValidationGroup="ControlsHeader" ErrorMessage="Select the Applicant" InitialValue="Select">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_PhaseID" runat="server" Text="Phase"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="Rcb_PhaseID" runat="server" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RFV_Rcb_PhaseID" runat="server" ControlToValidate="Rcb_PhaseID"
                                            ErrorMessage="Select Phase" InitialValue="Select" ValidationGroup="ControlsHeader">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_Next" runat="server" Text="Next" OnClick="btn_Submit_Click" ValidationGroup="ControlsHeader" />
                                        <asp:Button ID="btn_Clear" runat="server" Text="Cancel" OnClick="btn_Clear_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="VS_InterviewAssesmentHeader" runat="server" ShowMessageBox="true"
                                            ShowSummary="false" ValidationGroup="ControlsHeader" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RPV_InterviewAssesmentDetails" runat="server" Selected="false">
                <table style="width: 100%">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbl_Caption" runat="server" Font-Bold="True" Font-Underline="true"
                                Font-Names="Arial" Font-Size="11pt" Text="Interview Assesment Form"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="2" cellspacing="2" align="center">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lbl_ContactInformation" Text="Candidate's Contact Information" runat="server"
                                            Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        <asp:Label ID="lbl_Skill" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl_JobReqId" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_RefferedBy" Text="Reffered By" runat="server" Font-Bold="true"
                                            Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_RefferedBy" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_FullName" runat="server" Text="Full name"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_FullName" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_DateOfInterview" runat="server" Text="Date of Interview"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_DateofInterview" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_ContactNumber" runat="server" Text="Contact Number"></asp:Label>
                                    </td>
                                    <td>
                                        <%--<telerik:RadNumericTextBox ID="rntxt_ContactNumber" runat="server" NumberFormat-DecimalDigits="0"
                                            NumberFormat-AllowRounding="false"  Enabled="false">
                                        </telerik:RadNumericTextBox>--%>
                                        <telerik:RadMaskedTextBox ID="rntxt_ContactNumber" runat="server"
                                            DisplayMask="###-###-####" Skin="WebBlue" Mask="(###) ###-####" TextWithLiterals="() -"
                                            Enabled="false">
                                        </telerik:RadMaskedTextBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_PositionAppliedFor" runat="server" Text="Position Applied for"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_PositionAppliedFor" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_ToatlExp" runat="server" Text="Total Exp"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_TotalExp" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_Qualification" runat="server" Text="Qualification"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_Qualification" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_RelevantExp" runat="server" Text="Relevant Exp"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_RelevantExp" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_Company" runat="server" Text="Current Company"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_Company" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Certifications" runat="server" Text="Certifications (if any)"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_Certifications" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_ValidPassport" runat="server" Text="Valid Passport (Y/N)"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_ValidPassport" runat="server"
                                            Enabled="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lbl_FirstRound" runat="server" Text="" Font-Bold="true" Font-Names="Arial"
                                            Font-Size="10pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <telerik:RadGrid ID="RG_Skills1" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            Width="620px" Skin="Office2007">
                                            <HeaderContextMenu>
                                            </HeaderContextMenu>
                                            <MasterTableView>
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="SkillCat_ID" HeaderText="ID" UniqueName="Skills_ID"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Skill" HeaderText="Skills" UniqueName="Skills">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn UniqueName="Column1">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lbl_Column1" runat="server" Text="Assesment"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <telerik:RadComboBox ID="Rcb_Assesment" runat="server" MarkFirstMatch="true"
                                                                    OnDataBinding="Rcb_Assesment_DataBinding" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <FilterMenu>
                                            </FilterMenu>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lbl_AdditionalComments" runat="server" Text="Additional Comments"
                                            Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="4">
                                        <telerik:RadTextBox ID="rtxt_AdditionalComments1" runat="server" Rows="3" TextMode="MultiLine"
                                            Width="622px">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Name" runat="server" Text="Name" Font-Bold="true" Font-Names="Arial"
                                            Font-Size="10pt" Visible="false"></asp:Label>
                                        <telerik:RadTextBox ID="rtxt_Name" runat="server" Width="160px"
                                            Visible="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Signature" runat="server" Text="Signature" Font-Bold="true" Font-Names="Arial"
                                            Font-Size="10pt" Visible="false"></asp:Label>
                                        <telerik:RadTextBox ID="rtxt_Signature" runat="server"
                                            Visible="false">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_Submit" runat="server" Text="Shortlisted" OnClick="btn_Submit_Click" />
                                        <asp:Button ID="btn_Rejected" runat="server" Text="Rejected" OnClick="btn_Submit_Click" />
                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Clear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </telerik:RadAjaxPanel>
</asp:Content>