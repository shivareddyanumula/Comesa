<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Emptax.aspx.cs" Inherits="HR_frm_Emptax" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
<table align="center">
    <%--<tr>
        <td colspan="5">
        </td>
    </tr>--%>
    
    <tr>
        <td colspan="5" align="center">
            <asp:Label ID="lbl_Header" runat="server" Text="Employee Tax Savings" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    
    <tr>
        <td colspan="5">
        </td>
    </tr>
    
    <tr>
        <td></td>
        <td align="right">
            <asp:Label ID="lbl_Businessunit" runat="server" Text="Business Unit">
            </asp:Label>
        </td>
        <td><b>:</b></td>
        <td align="left">
            <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="true" 
                MarkFirstMatch="true" Filter="Contains"
                onselectedindexchanged="rcmb_Businessunit_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
        <td></td>
    </tr>
    
    <tr>
        <td></td>
        <td align="right">
            <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period">
            </asp:Label>
        </td>
        <td><b>:</b></td>
        <td align="left">
            <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" 
                AutoPostBack="true" MarkFirstMatch="true" Filter="Contains"
                onselectedindexchanged="rcmb_Financialperiod_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
        <td></td>
    </tr>
    
    <tr>
        <td></td>
        <td align="right">
            <asp:Label ID="lbl_Taxelement" runat="server" Text="Element Name">
            </asp:Label>
        </td>
        <td><b>:</b></td>
        <td align="left">
            <telerik:RadComboBox ID="rcmb_Taxelement" runat="server" AutoPostBack="true" 
                MarkFirstMatch="true" Filter="Contains"
                onselectedindexchanged="rcmb_Taxelement_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
        <td></td>
    </tr>
    <tr>
    <td colspan="5"></td>
    </tr>
    
    <tr>
    <td></td>
    <td align="center" colspan="3">
        <telerik:RadGrid ID="rg_Taxinfo" runat="server" AutoGenerateColumns="false" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
            <MasterTableView CommandItemDisplay="None">
                <Columns>
                
                    <telerik:GridTemplateColumn HeaderText="Check All">
                            <HeaderTemplate>
                               <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged" Text="Check All" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Empid" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Empid" runat="server" Text='<%#Eval("EMP_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridTemplateColumn HeaderText="Amount">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="rtxt_Amount" runat="server" MinValue="0" ></telerik:RadNumericTextBox><%--Text='<%#Eval("AMOUNT") %>'--%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>                    
                    <telerik:GridTemplateColumn HeaderText="Maximum Limit">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Maxlimit" runat="server" Text='<%#Eval("MAXLIMIT") %>'></asp:Label>
                    </ItemTemplate>
                    </telerik:GridTemplateColumn>                   
                    
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </td>
    <td></td>
    
    </tr>
    
    <tr>
        <td colspan="5"></td>
    </tr>
    <tr>
    
        <td></td>
        <td colspan="3" align="center">
            <asp:Button ID="btn_Save" runat="server" Text="Save" onclick="btn_Save_Click" />
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" 
                onclick="btn_Cancel_Click" />
        </td>
        <td></td>
    </tr>
    
</table>
</asp:Content>

