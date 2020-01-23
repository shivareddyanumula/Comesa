<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Family.aspx.cs" Inherits="Selfservice_Family" %>

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
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                            <br />
                            <br />
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_FamilyDetails" runat="server" Text="Employee Family Details" Style="font-weight: 700; color: #000000; font-size: medium;"></asp:Label>
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
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table align="center">
                                                </table>
                                                <br />
                                                <table align="center">


                                                    <tr>
                                                        <td>

                                                            <telerik:RadGrid ID="RG_Family" runat="server" AutoGenerateColumns="False" GridLines="None">
                                                                <MasterTableView>
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn UniqueName="ID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("EMPFMDTL_EMPREL_ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Serial" UniqueName="serial">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Serial" runat="server" Text='<%# Eval("EMPFMDTL_SERIAL") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="ID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("EMPFMDTL_ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Relation" UniqueName="Relation">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Relation" runat="server" Text='<%# Eval("EMPFMDTL_EMPREL_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>

                                                                        <telerik:GridTemplateColumn HeaderText="Name" UniqueName="Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("EMPFMDTL_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Spouse ID" UniqueName="WifeIDNumber" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Surname" runat="server" Text='<%# Eval("EMPFMDTL_SURNAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="DOB" UniqueName="DOB">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_DOB" runat="server" Text='<%# Eval("EMPFMDTL_RELDOB") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Emergency&nbsp;Contact" UniqueName="EMPFMDTL_RELEMERGENCY">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chk_Emergency" runat="server" Checked='<%# Convert.ToBoolean(Eval("EMPFMDTL_RELEMERGENCY")) %>' Enabled="False" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>

                                                                        <telerik:GridTemplateColumn HeaderText="Photo">
                                                                            <ItemTemplate>
                                                                                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("EMPFMDTL_PHOTO") %>' Width="100px" />
                                                                                <asp:Label ID="lbl_Photo" runat="server" Text='<%#Eval("EMPFMDTL_PHOTO") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Bio Data">
                                                                            <ItemTemplate>
                                                                                <a id="D2" runat="server" href='<%#Eval("EMPFMDTL_BIODATA") %>' target="_blank">Download Bio Data</a>
                                                                                <asp:Label ID="lbl_BioData" runat="server" Text='<%#Eval("EMPFMDTL_BIODATA") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>

                                                                    </Columns>
                                                                </MasterTableView>
                                                                <ClientSettings>
                                                                    <Selecting AllowRowSelect="True" />
                                                                </ClientSettings>
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </telerik:RadAjaxPanel>
                    </td>
                </tr>
            </table>
        </div>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    </form>
</body>
</html>