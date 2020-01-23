<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ViewInterviewAssesmentnew.aspx.cs" Inherits="Recruitment_frm_ViewInterviewAssesmentnew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RD_ScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>
            <telerik:RadMultiPage ID="RMP_InterviewAssesment" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RPV_InterviewAssesmentHeader" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_HeaderText" runat="server" Font-Bold="True" Font-Underline="true"
                                    Text="Interview Assesment Form"></asp:Label>
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
                                            <asp:Label ID="lbl_PhaseID" runat="server" Text="Phase"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="Rcb_PhaseID" runat="server" MaxHeight="120px" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="Rcb_PhaseID_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Rcb_PhaseID" runat="server" ControlToValidate="Rcb_PhaseID"
                                                ErrorMessage="Please Select Phase" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>&nbsp;
                                        </td>
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
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RPV_Fesher" runat="server">
                    <br />
                    <br />

                    <table style="width: 100%;" align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_Header" runat="server" Text="Applicant Details">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <telerik:RadTabStrip ID="RTS_Fresher" runat="server" Skin="WebBlue" MultiPageID="RMP_Fresher_1"
                                    SelectedIndex="0" Align="Center">
                                    <Tabs>

                                        <telerik:RadTab runat="server" Text="General Assessment" PageViewID="GeneralAssessment"
                                            Value="0" Selected="true">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" Text="Skills" PageViewID="FactorsExp" Value="1">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" Text="Attributes" PageViewID="SkillsAttributes"
                                            Value="2">
                                        </telerik:RadTab>

                                    </Tabs>
                                </telerik:RadTabStrip>
                                <telerik:RadMultiPage ID="RMP_Fresher_1" runat="server" Width="100%" SelectedIndex="0"
                                    ScrollBars="Auto">





                                    <telerik:RadPageView ID="GeneralAssessment" runat="server" Selected="true">
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadGrid ID="rg_GeneralAssessment" runat="server" GridLines="None" AutoGenerateColumns="false" Enabled="false"
                                                        Skin="WebBlue" Width="500px">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="ASSESSMENT_ID" UniqueName="ASSESSMENT_ID" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME"
                                                                    HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ASSESSMENT_DESC" UniqueName="ASSESSMENT_DESC"
                                                                    HeaderText="Description">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rating(0-10)" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <telerik:RadNumericTextBox ID="rnt_Value" runat="server" Width="60px" text='<%#Eval("IAF_RATING_RATING") %>'
                                                                            SkinID="1" Skin="WebBlue" MinValue="0" MaxValue="10">
                                                                            <NumberFormat DecimalDigits="2" />
                                                                        </telerik:RadNumericTextBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                        <GroupingSettings CaseSensitive="false" />
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>

                                    <telerik:RadPageView ID="FactorsExp" runat="server">
                                        <br />
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <telerik:RadGrid ID="rg_FactorsExp" runat="server" GridLines="None" AutoGenerateColumns="false" Enabled="false"
                                                        Skin="WebBlue" AllowFilteringByColumn="false" Width="550px">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="SKILLCAT_ID" UniqueName="SKILLCAT_ID" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="SKILLCAT_SKILLID" UniqueName="SKILLCAT_SKILLID"
                                                                    Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="SKILLCAT_NAME" UniqueName="SKILLCAT_NAME" HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="SKILLCAT_DESCRIPTION" UniqueName="SKILLCAT_DESCRIPTION"
                                                                    HeaderText="Description">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <%--<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rating" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <telerik:RadComboBox ID="rcmb_rating" runat="server" Width="60px" SkinID="1" Skin="WebBlue" >
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>--%>
                                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Remarks" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <telerik:RadTextBox ID="rtxt_remarks_Exp" SkinID="1" runat="server" TextMode="MultiLine" Text='<%#Eval("IAF_RATING_REMARKS") %>'
                                                                            MaxLength="200" Width="180px">
                                                                        </telerik:RadTextBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                        <GroupingSettings CaseSensitive="false" />
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="SkillsAttributes" runat="server">
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadGrid ID="rg_SkillAttributes" runat="server" GridLines="None" AutoGenerateColumns="false" Enabled="false"
                                                        Skin="WebBlue" Width="480px">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="ASSESSMENT_ID" UniqueName="ASSESSMENT_ID" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME"
                                                                    HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ASSESSMENT_DESC" UniqueName="ASSESSMENT_DESC"
                                                                    HeaderText="Description">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Remarks" HeaderStyle-Width="120px">
                                                                    <ItemTemplate>
                                                                        <telerik:RadTextBox ID="rtxt_remarks_Exp_Skill" runat="server" TextMode="MultiLine" Text='<%#Eval("IAF_RATING_REMARKS") %>'
                                                                            MaxLength="400">
                                                                        </telerik:RadTextBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                        <GroupingSettings CaseSensitive="false" />
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_AddComments_Exp" runat="server" Text="Additional Comments" Font-Bold="true"
                                                        Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_comments_Exp" runat="server" MaxLength="400" SkinID="1"
                                                        TextMode="MultiLine" Width="200px" Height="70px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>

                                </telerik:RadMultiPage>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" />
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </form>
</body>
</html>