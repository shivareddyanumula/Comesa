<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Applicanterror.aspx.cs" Inherits="Recruitment_Applicanterror" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        
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

    
    </div>
    
        <table>
    
     <tr>
                <td align="left">
                    &nbsp;&nbsp;<img alt="Row Indication" src="../Payroll/green.png" style="width: 14px;
                        height: 13px" /><strong> Row Indication </strong>&nbsp;&nbsp;
                    <img alt="Failure Column" src="../Payroll/red.png" style="width: 14px; height: 13px" /><strong>
                        Failure Column </strong>&nbsp;&nbsp;
                    <img alt="Successfull Row" src="../Payroll/white.png" style="width: 14px; height: 13px" /><strong>
                        Successful Row </strong>&nbsp;&nbsp;
                </td>
            </tr>
                        <tr>
                <td>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="1" 
        OnTabClick="RadTabStrip1_TabClick">
    
                        <Tabs>
                        <telerik:RadTab runat="server" TabIndex='0' Text="Personal" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" TabIndex='1'  Text="Qualification" >
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" TabIndex='2' Text="Skills">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" TabIndex='3' Text="Experience">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" TabIndex='4' Text="Contact">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" TabIndex='5' Text="Language">
                        </telerik:RadTab>
                          
                    </Tabs>
    </telerik:RadTabStrip>
    
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

    </form>
</body>
</html>
