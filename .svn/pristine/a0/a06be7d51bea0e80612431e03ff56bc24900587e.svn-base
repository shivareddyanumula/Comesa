<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_AttendanceImportProcess.aspx.cs"
    Inherits="PMS_frm_AttendanceImportProcess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <td align="center">
                    <b>
                        <asp:Label ID="lblimportprocess" runat="server" Font-Bold="True" Font-Size="Large"
                            Text=" Import Process"></asp:Label></b>
                    <hr style="width: 170px" />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;&nbsp;<img alt="Row Indication" src="green.png" style="width: 14px;
                        height: 13px" /><strong> Row Indication </strong>&nbsp;&nbsp;
                    <img alt="Failure Column" src="red.png" style="width: 14px; height: 13px" /><strong>
                        Failure Column </strong>&nbsp;&nbsp;
                    <img alt="Successfull Row" src="white.png" style="width: 14px; height: 13px" /><strong>
                        Successful Row </strong>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grvExcelData" runat="server" Font-Name="sans-serif" BorderStyle="Solid"
                        Width="1000px" Font-Size="11px" CellPadding="4" HeaderStyle-BackColor="#5CB3FF"
                        HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#b1d1e8">
                    </asp:GridView>
                    <%--  <telerik:RadGrid ID="grvExcelData1" runat="server"  AllowPaging="false" 
                                AutoGenerateColumns="true" GridLines="None" 
                               >      
                                </telerik:RadGrid>--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
