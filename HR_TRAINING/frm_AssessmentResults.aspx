<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_AssessmentResults.aspx.cs" Inherits="HR_TRAINING_frm_AssessmentResults" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Results" runat="server" Text="Assessment Results" meta:resourcekey="lblExamType" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div>
                    <table align="center" width="350px">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblExamType" runat="server" Text="Exam Type" meta:resourcekey="lblExamType"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdExamType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdExamType_SelectedIndexChanged">
                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                    <asp:ListItem Text="Offline" Value="Offline"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <telerik:RadGrid ID="RG_Assessments" runat="server" AutoGenerateColumns="False" GridLines="None" Visible="false"
                                    Skin="WebBlue">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="ID" UniqueName="ID" HeaderText="ID"
                                                meta:resourcekey="ID" Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME"
                                                HeaderText="Assessment Name" meta:resourcekey="ASSESSMENT_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <%--   <telerik:GridBoundColumn DataField="Result" UniqueName="Result"
                                                                                HeaderText="Results" meta:resourcekey="Result">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="Marks" UniqueName="Marks"
                                                HeaderText="Marks" meta:resourcekey="Marks">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Result" UniqueName="Result"
                                                HeaderText="Result" meta:resourcekey="Result">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                           <%-- <telerik:GridTemplateColumn HeaderText="Result">
                                                <ItemTemplate>
                                                    <%# Convert.ToBoolean(Eval("Result")) ? "Pass" : "Fail" %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>--%>
                                        </Columns>
                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="True" />
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

