<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Importresult.aspx.cs" Inherits="Masters_Importresult" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import Process Errors</title>
</head>

<body>
    <form id="form1" runat="server">

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadScriptBlock ID="radscript1" runat="server">

            <script language="javascript" type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog         
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)         
                    return oWindow;
                }

                function Close() {
                    GetRadWindow().Close();
                }
            </script>

        </telerik:RadScriptBlock>

        <div>

            <table align="center">
                <tr>
                    <td align="center" colspan="5">
                        <asp:Label ID="lbl_ImportProcess" runat="server" Text="Import Process"
                            Style="font-weight: 700; text-decoration: underline"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <img alt="Row Indication" src="../Payroll/green.png" style="width: 14px; height: 13px" /><strong> Row Indication </strong>
                    </td>


                    <td>
                        <img alt="Successfull Row" src="../Payroll/white.png" style="width: 14px; height: 13px" /><strong>
                        Successful Row</strong></td>

                    <td>
                        <img alt="Failure Column" src="../Payroll/red.png" style="width: 14px; height: 13px" /><strong>
                        Failure Column </strong>
                    </td>


                    <td></td>
                </tr>

                <tr>

                    <td align="center" colspan="5">
                        <asp:GridView ID="RG_Import" runat="server" AutoGenerateColumns="true" Visible="true" Font-Name="sans-serif" BorderStyle="Solid"
                            Width="500px" Font-Size="11px" HeaderStyle-BackColor="#5CB3FF"
                            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#b1d1e8" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                            </Columns>
                        </asp:GridView>
                    </td>

                </tr>
            </table>
        </div>

    </form>
</body>
</html>