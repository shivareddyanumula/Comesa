<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_AssessmentType.aspx.cs" Inherits="Recruitment_frm_AssessmentType" Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Assessment Master's" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_AssessmentType" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_AssessmentType" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_AssessmentType" runat="server" GridLines="None" AutoGenerateColumns="false" Skin="WebBlue" AllowFilteringByColumn="true"
                                        AllowPaging="true" OnNeedDataSource="rg_AssessmentType_NeedDataSource" Width="700px" PagerStyle-AlwaysVisible="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="ASSESSMENT_ID" UniqueName="ASSESSMENT_ID" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_ID" UniqueName="HR_MASTER_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Assessment Type">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ASSESSMENT_DESC" UniqueName="ASSESSMENT_DESC" HeaderText="Description">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="ASSESSMENT_APPLICABLEFOR" UniqueName="ASSESSMENT_APPLICABLEFOR" HeaderText="Applicable For" >
              <HeaderStyle HorizontalAlign="Center" />
            </telerik:GridBoundColumn>  --%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ASSESSMENT_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_add" runat="server" Text="Add" OnCommand="lnk_Add_Command"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_AssessmentTypeDetails" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Type" runat="server" Text="Assessment Type"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Type" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Type" runat="server" ControlToValidate="rcmb_Type"
                                        InitialValue="Select" Text="*" ErrorMessage="Please Select Type" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Name" runat="server" Text="Name"></asp:Label>
                                    <asp:Label ID="lbl_ID" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Name" runat="server"></telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Name" runat="server" ControlToValidate="rtxt_Name"
                                        Text="*" ErrorMessage="Please Enter Name" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Desc" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Desc" runat="server"></telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <%--      <tr>
       <td>
        <asp:Label ID="lbl_applicablefor"  runat="server" Text="Applicable For"></asp:Label>
       </td>
       <td>
        <b>:</b>
       </td>
       <td>
        <telerik:RadComboBox ID="rcmb_ApplicableFor" runat="server" MarkFirstMatch="true" MaxHeight="120px">
         <Items>
         <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
          <telerik:RadComboBoxItem runat="server" Text="Fresher" Value="Fresher" />
          <telerik:RadComboBoxItem runat="server" Text="Experience" Value="Experience" />
          <telerik:RadComboBoxItem runat="server" Text="Both" Value="Both" />
           </Items>
        </telerik:RadComboBox>
       </td>
       <td>
        <asp:RequiredFieldValidator ID="rfv_rcmb_ApplicableFor" runat="server" ControlToValidate="rcmb_ApplicableFor"
           InitialValue="Select"  Text="*" ErrorMessage="Please Select Applicable For" ValidationGroup="Controls" >
        </asp:RequiredFieldValidator>
       </td>
      </tr>--%>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
                                    <asp:ValidationSummary ID="VS_Assessments" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>