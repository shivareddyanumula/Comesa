<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="Payroll_Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head> 
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="smResult"></asp:ScriptManager>
            <asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="~/Images/xl.jpg"
                OnClick="imgBtnExcel_Click" Text="Export to Excel" />
            <telerik:RadGrid runat="server" ID="rgResult" Width="100%"
                OnNeedDataSource="rgResult_NeedDataSource">
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>