<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmRatingScale.aspx.cs" Inherits="PMS_frmRatingScale" %>

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
        <center> <b>Rating Scale</b></center>
        <table align="center">
            <tr>
                <td align="center">
                    <telerik:RadGrid ID="RG_RatingScale" runat="server" AutoGenerateColumns="False" AllowSorting="false"
                        AllowMultiRowSelection="False" Skin="WebBlue" GridLines="None" Width="500px">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="ID" DataField="RATING_SCALE_ID" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Category" DataField="RATING_SCALE_CATEGORY">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="VP%, if any" DataField="RATING_SCALE_VP%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
