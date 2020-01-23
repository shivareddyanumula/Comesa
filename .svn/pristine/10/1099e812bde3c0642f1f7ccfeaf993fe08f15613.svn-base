<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_SalDetails.aspx.cs" Inherits="Payroll_frm_SalDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 4px;
        }
        .style3
        {
            width: 143px;
        }
        .style4
        {
            color: #FFFFFF;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <br />
        <br />
        <table style="width: 70%; height: 60;"  align="center">
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_Header" runat="server" Text="Employee Salary Details"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" class="style3">
                                <asp:Label ID="lblCode" runat="server" Text="Employee Code"></asp:Label>
                            </td>
                            <td align="left" class="style2">
                                <b>:</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbl_Code" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                <asp:Label ID="lblName" runat="server" Text="Employee Name"></asp:Label>
                            </td>
                            <td align="left" class="style2">
                                <b>:</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbl_Name" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                <asp:Label ID="lblDOJ" runat="server" Text="Date of Join"></asp:Label>
                            </td>
                            <td align="left" class="style2">
                                <b>:</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbl_DOJ" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
                            </td>
                            <td align="left" class="style2">
                                <b>:</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbl_Position" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                <asp:Label ID="lblBusUnit" runat="server" Text="Business Unit"></asp:Label>
                            </td>
                            <td align="left" class="style2">
                                <b>:</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbl_BusUnit" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style1" colspan="3">
                                <hr />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Income" runat="server">
                <td align="left">
                    <asp:Label ID="lbl_Income" runat="server" Text="Incomes:" Font-Underline="true" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="Incomegrid" runat="server">
                <td align="left" style="width: 100%">
                    <%-- <telerik:RadGrid  ID="RG_SalDetails" runat="server" Skin="WebBlue"
                        GridLines="None" AutoGenerateColumns="False">
                        <HeaderContextMenu Skin="WebBlue">
                        </HeaderContextMenu>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" UniqueName="PAYITEM_PAYITEMNAME"
                                    HeaderText="PAYITEM NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EMPSALDTLS_AMOUNT" UniqueName="EMPSALDTLS_AMOUNT"
                                    HeaderText="AMOUNT">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu Skin="WebBlue">
                        </FilterMenu>
                    </telerik:RadGrid>--%>
                    <asp:GridView ID="RG_SalDetails" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        CellSpacing="3" GridLines="None" ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="PAYITEM_PAYITEMNAME" HeaderText="PAYITEM NAME" ItemStyle-Width="48%" />
                            <asp:TemplateField ItemStyle-Width="2%">
                                <ItemTemplate>
                                    <b>:</b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMPSALDTLS_AMOUNT" HeaderText="AMOUNT" ItemStyle-Width="48%">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
            <td></td>
            </tr>
            <tr id="Deductions" runat="server">
                <td align="left" style="width: 100%">
                     <asp:Label ID="lbl_Deductions" runat="server" Text="Deductions:" Font-Underline="true" Font-Bold="true"></asp:Label>           
                </td>
            </tr>
            
            <tr id="Deductionsgrid" runat="server">
                <td >
                         <asp:GridView ID="Rg_Deductions" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        CellSpacing="3" GridLines="None" ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="PAYITEM_PAYITEMNAME" HeaderText="PAYITEM NAME" ItemStyle-Width="48%" />
                            <asp:TemplateField ItemStyle-Width="2%">
                                <ItemTemplate>
                                    <b>:</b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMPSALDTLS_AMOUNT" HeaderText="AMOUNT" ItemStyle-Width="48%">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            
            <tr>
                <td align="right" style="width: 100%" class="style4">
                    ---------------------------------
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100%">
                    <asp:Label ID="lbl_BU_Amount" runat="server" Style="font-weight: 700" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100%">
                    <asp:Label ID="lbl_Amount" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
            </tr>
             
            <%--<tr>
            <td align="right" style="width: 100%" class="style4">
                    ---------------------------------
                </td>
           </tr>--%>
            <tr id="Benefitable" runat="server">
                <td align="left" style="width: 100%">
                     <asp:Label ID="Label1" runat="server" Text="Benefitable:" Font-Underline="true" Font-Bold="true"></asp:Label>           
                </td>
            </tr>
           
           
            
            <tr id="Benefitablegrid" runat="server">
                <td >
                         <asp:GridView ID="Rg_Benefitable" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        CellSpacing="3" GridLines="None" ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="PAYITEM_PAYITEMNAME" HeaderText="PAYITEM NAME" ItemStyle-Width="48%" />
                            <asp:TemplateField ItemStyle-Width="2%">
                                <ItemTemplate>
                                    <b>:</b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMPSALDTLS_AMOUNT" HeaderText="AMOUNT" ItemStyle-Width="48%">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
