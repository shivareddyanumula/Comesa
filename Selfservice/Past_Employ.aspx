<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Past_Employ.aspx.cs" Inherits="Selfservice_Past_Employ" %>

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
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <table align="center">
            <tr>
                <td>
                    <asp:Label ID="lbl_ExperienceDetails" runat="server" Text="Employee Past Employment Details"
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
                    <br />
                    <table align="center">
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_Experience" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    meta:resourcekey="RG_Experience" Skin="WebBlue">
                                    <HeaderContextMenu>
                                    </HeaderContextMenu>
                                    <MasterTableView>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_ID" Visible="False" HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPEXP_ID") %>' Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_SERIAL" HeaderText="Serial">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_Serial" runat="server" Text='<%# Eval("APPEXP_SERIAL") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_COMPANY" HeaderText="Company&nbsp;Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_CompName" runat="server" Text='<%# Eval("APPEXP_COMPANY") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_JOINDATE" HeaderText="Join&nbsp;Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_JoinDate" runat="server" Text='<%# Eval("APPEXP_JOINDATE") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_JOINSAL" HeaderText="Join&nbsp;Salary">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_JoinSal" runat="server" Text='<%# Eval("APPEXP_JOINSAL") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_JOINDESC" HeaderText="Join&nbsp;Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_JoinDesc" runat="server" Text='<%# Eval("APPEXP_JOINDESC") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_REASONREL" HeaderText="Relieving&nbsp;Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_RelReason" runat="server" Text='<%# Eval("APPEXP_REASONREL") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_RELDATE" Visible="False" HeaderText="Relieving Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_RelDate" runat="server" Text='<%# Eval("APPEXP_RELDATE") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_RELSAL" Visible="False" HeaderText="Relieving Salary">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_RelSalary" runat="server" Text='<%# Eval("APPEXP_RELSAL") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="APPEXP_REASONDESC" Visible="False" HeaderText="Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Exp_RelDesc" runat="server" Text='<%# Eval("APPEXP_REASONDESC") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                                CancelImageUrl="Cancel.gif">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu>
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
