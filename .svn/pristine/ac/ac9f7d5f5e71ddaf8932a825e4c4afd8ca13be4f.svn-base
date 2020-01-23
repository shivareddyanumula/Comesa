<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Empcomponents.aspx.cs" Inherits="Masters_frm_Empcomponents" Title="Untitled Page" %>

<script runat="server">

 

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Heading" runat="server" Text="Employee Components" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged"
                MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" AutoPostBack="true" MarkFirstMatch="true" TabIndex="2"
                    OnSelectedIndexChanged="rcmb_Financialperiod_SelectedIndexChanged" Visible="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>
        
        <tr>
            <td></td>
            <td align="left">
                <asp:Label ID="lbl_CheckPrevious" runat="server" Text="Check Previous Financial Period Data"></asp:Label>
            </td>
            <td><b>:</b></td>
            <td align="left">
                <asp:CheckBox ID="chk_Previous" runat="server" AutoPostBack="true" TabIndex="3" 
                    oncheckedchanged="chk_Previous_CheckedChanged" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="5">            
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="center" colspan="3">
                <telerik:RadGrid ID="rg_Empcomponents" runat="server" AutoGenerateColumns="false"
                    AllowPaging="false" >
                    <%--OnPageIndexChanged ="rg_Empcomponents_PageIndexChanged" OnNeedDataSource="rg_Empcomponents_NeedDataSource"--%>
                    
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    
                    <MasterTableView>                        
                        <Columns>                         
                            <telerik:GridTemplateColumn HeaderText="Row No" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%#Container.DataSetIndex+1%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        
                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chk_All" runat="server" OnCheckedChanged="chk_All_CheckedChanged"
                                        AutoPostBack="true" Text="Check All" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Row" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="Empid" DataField="EMP_ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="VariablePayComponents" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:CheckBoxList ID="chklst_Components" runat="server" RepeatDirection="Vertical"
                                        AutoPostBack="true" OnSelectedIndexChanged="chklst_Components_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                    <div align="right">
                                        <asp:Label ID="lbl_Total" runat="server" Text="Total :"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Percentage" ItemStyle-HorizontalAlign="Left"
                                UniqueName="Percentage">
                                <ItemTemplate>
                                    <asp:DataList ID="dlTxtBox" runat="server">
                                        <ItemTemplate>
                                          <telerik:RadNumericTextBox ID="rntxt"  runat="server" AutoPostBack="true" Enabled="false" 
                                            MinValue='<%#Eval("SMHR_VPCOMP_MIN") %>' MaxValue='<%#Eval("SMHR_VPCOMP_MAX") %>' MaxLength="3"
                                            ontextchanged="rntxt_TextChanged">
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                           <asp:TextBox ID="txtTotal" runat="server" Enabled="false"></asp:TextBox>
                                            <%--<asp:Label ID="lbl_Sum" runat="server"></asp:Label>--%>
                                        </FooterTemplate>    
                                    </asp:DataList>                              
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td colspan="3">
                <asp:Button ID="btn_Save" runat="server" Text="Save" onclick="btn_Save_Click" TabIndex="4" />
                <asp:Button ID="btn_Update" runat="server" Text="Update" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" TabIndex="5" 
                    onclick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
