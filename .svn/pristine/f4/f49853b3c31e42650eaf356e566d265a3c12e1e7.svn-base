<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Qualification.aspx.cs" Inherits="Selfservice_Qualification" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">


        function fnJSOnFormSubmit(sender, group) {
            var isGrpOneValid = Page_ClientValidate(group);
            var i;
            for (i = 0; i < Page_Validators.length; i++) {
                ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
            }
            for (i = 0; i < Page_ValidationSummaries.length; i++) {
                summary = Page_ValidationSummaries[i];
                if (isGrpOneValid) {
                    sender.disabled = "disabled";
                    return true;
                }

                if (fnJSDisplaySummary(summary.validationGroup)) {
                    summary.style.display = "";
                }
            }







        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_QualificationDetails" runat="server" Text="Employee Qualification Details"
                                            Style="font-weight: 700; font-size: medium; color: #000000;"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table align="center">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Category" runat="server" Text="Qualification"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Category" runat="server"
                                                        MaxHeight="120px" Skin="WebBlue" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Category" runat="server" Text="*" ValidationGroup="Qual"
                                                        ControlToValidate="ddl_Category" InitialValue="Select" ErrorMessage="Choose Qualification"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Institute" runat="server" Text="Institute"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_Institute" runat="server"
                                                        AutoCompleteType="Disabled" Skin="WebBlue">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Institute" runat="server" Text="*" ValidationGroup="Qual"
                                                        ControlToValidate="txt_Institute" ErrorMessage="Enter Institute"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_YearPass" runat="server" Text="Year of Pass"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txt_YearofPass" runat="server"
                                                        DataType="System.Int32" MaxLength="4" Skin="WebBlue">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_yearofpass" runat="server" Text="*" ValidationGroup="Qual"
                                                        ControlToValidate="txt_YearofPass" ErrorMessage="Enter Year of Pass"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Percentage" runat="server" Text="Percentage(%)"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txt_Percentage" runat="server"
                                                        MinValue="35" MaxLength="5" MaxValue="100" Skin="WebBlue">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_percentage" runat="server" Text="*" ValidationGroup="Qual"
                                                        ControlToValidate="txt_Percentage" ErrorMessage="Enter Percentage"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl__Grade" runat="server" Text="Grade"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl__Grade" runat="server" Skin="WebBlue">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Select" Value="Select" />
                                                            <telerik:RadComboBoxItem runat="server" Text="A" Value="A" />
                                                            <telerik:RadComboBoxItem runat="server" Text="B" Value="B" />
                                                            <telerik:RadComboBoxItem runat="server" Text="C" Value="C" />
                                                            <telerik:RadComboBoxItem runat="server" Text="D" Value="D" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_grade" runat="server" Text="*" ValidationGroup="Qual"
                                                        ControlToValidate="ddl__Grade" InitialValue="Select" ErrorMessage="Choose Grade"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:Button ID="btn_Qual_Add" runat="server" OnClick="btn_Qual_Add_Click" Text="Add Qualification" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Qual')" />
                                                    &nbsp;<asp:Button ID="btn_Qual_Correct" runat="server" OnClick="btn_Qual_Correct_Click"
                                                        UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Qual')" Text="Correct Qualification" />
                                                    &nbsp;<asp:Button ID="btn_Qual_Cancel" runat="server" OnClick="btn_Qual_Cancel_Click"
                                                        Text="Cancel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:ValidationSummary ID="vs_Qual" runat="server" ShowSummary="true" ValidationGroup="Qual" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table align="center" width="100%">
                                            <tr>
                                                <td>
                                                    <telerik:RadGrid ID="RG_Qualification" runat="server"
                                                        AutoGenerateColumns="False" Skin="WebBlue" GridLines="None" OnItemCommand="RG_Qualification_ItemCommand"
                                                        Width="100%" meta:resourcekey="RG_Qualification">
                                                        <ClientSettings>
                                                            <Selecting AllowRowSelect="True" />
                                                        </ClientSettings>
                                                        <MasterTableView>
                                                            <Columns>
                                                                <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                                <ItemStyle Width="80px" />
                                                            </telerik:GridButtonColumn>--%>
                                                                <telerik:GridTemplateColumn UniqueName="ID" Visible="False" HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPQFN_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn UniqueName="ID" Visible="False" HeaderText="QualID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPQFN_QUALIFICATION_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn UniqueName="Qualification" HeaderText="Qualification">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_AppQual" runat="server" Text='<%# Eval("APPQFN_QUALIFICATION_NAME") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn UniqueName="Institute" HeaderText="Institute">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_AppInstitute" runat="server" Text='<%# Eval("APPQFN_INSTITUTE") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn UniqueName="YearPass" HeaderText="Year&nbsp;of&nbsp;Pass">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_AppYearPass" runat="server" Text='<%# Eval("APPQFN_PASSEDYEAR") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn UniqueName="Percentage" HeaderText="Percentage(%)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_AppPercentage" runat="server" Text='<%# Eval("APPQFN_PERCENTAGE") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn UniqueName="Grade" HeaderText="Grade">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_AppGrade" runat="server" Text='<%# Eval("APPQFN_GRADE") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                                    <ItemStyle Width="80px" />
                                                                </telerik:GridButtonColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadAjaxPanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>