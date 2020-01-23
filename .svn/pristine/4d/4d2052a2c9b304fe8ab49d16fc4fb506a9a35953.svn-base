<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ViewKRA.aspx.cs" Inherits="PMS_frm_ViewKRA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

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
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
            meta:resourcekey="RadFormDecorator1Resource1" />
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        
         <center > <b>KRA Details </b></center>
          <table align="center">
           <tr>
           <td align="center">
           <telerik:RadGrid ID="RG_ViewKRA" runat="server" AutoGenerateColumns="False"
                           AllowSorting="false" AllowMultiRowSelection="False" Skin="WebBlue" AllowFilteringByColumn="true"
                   GridLines="None" onneeddatasource="RG_ViewKRA_NeedDataSource"  Width="500px" AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="true">
           <MasterTableView>
           <Columns>
          <telerik:GridBoundColumn HeaderText="Name" DataField="KRA_NAME" >
          <HeaderStyle HorizontalAlign="Center" />
          </telerik:GridBoundColumn>
           <telerik:GridBoundColumn HeaderText="Description" DataField="KRA_DESCRIPTION">
           <HeaderStyle HorizontalAlign="Center" />
          </telerik:GridBoundColumn>
          <telerik:GridBoundColumn HeaderText="Type" DataField="TYPE">
          <HeaderStyle HorizontalAlign="Center" />
          </telerik:GridBoundColumn>
          <%--<telerik:GridBoundColumn HeaderText="Measure" DataField="KRA_MEASURE">
          <HeaderStyle HorizontalAlign="Center" />
          </telerik:GridBoundColumn>--%>
           </Columns>
           </MasterTableView>
           <GroupingSettings CaseSensitive="false" />
           </telerik:RadGrid>
           </td>
           </tr>
        </table>
    </div>
    </form>
</body>
</html>
