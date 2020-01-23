<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XML.aspx.cs" Inherits="Payroll_XML" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <br />
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_Header" runat="server" Text="Past AX Posted Files"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadGrid ID="RG_Files" runat="server" AutoGenerateColumns="False"
                            GridLines="None">
                            <HeaderContextMenu>
                            </HeaderContextMenu>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Filename">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Download" runat="server" Text='<%# Eval("FILENAME") %>' CommandArgument='<%# Eval("PATH") %>'
                                                OnCommand="lnk_Download_onCommand" CommandName='<%# Eval("FILENAME") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Created Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%# Eval("CDATE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                        UpdateImageUrl="Update.gif">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu>
                            </FilterMenu>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>