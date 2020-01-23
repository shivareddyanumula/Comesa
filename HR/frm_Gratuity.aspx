<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Gratuity.aspx.cs" Inherits="Payroll_frm_Gratuity" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function Gratuity_History() {
                var win = window.radopen('../payroll/frm_Previousdtls.aspx', "RW_GratuityHistory");
                win.center();
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Gratuity" runat="server" Style="font-weight: 700" Text="Gratuity Information"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td class="style1">
                            <telerik:RadComboBox ID="rcmb_Businessunit" Runat="server" AutoPostBack="True" Filter="Contains"
                            onselectedindexchanged="rcmb_Businessunit_SelectedIndexChanged" MarkFirstMatch="true">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_Businessunit0" runat="server" Text="Maximum Amount"></asp:Label>
                            <asp:Label ID="lbl_Mandatory" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LBL_SYMBOL2" runat="server" Text=":" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td >
                            <telerik:RadNumericTextBox ID="rntxt_Maximun" Runat="server"  MaxLength="12" MinValue="0" 
                                 AutoPostBack="true" ontextchanged="rntxt_Maximun_TextChanged">
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_Payitems" runat="server" Text="Payitems"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LBL_SYMBOL1" runat="server" Text=":" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td >
                            <asp:RadioButtonList ID="rlist_Payitems" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rlist_Payitems_SelectedIndexChanged"
                                RepeatDirection="Horizontal" CausesValidation="true" ValidationGroup="Max">
                                <asp:ListItem Text="Gross"></asp:ListItem>
                                <asp:ListItem Text="Payitems"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr id="payitems" runat="server" visible="false">
                        <td align="right">
                        </td>
                        <td>
                        </td>
                        <td rowspan="4" valign="top">
                            <asp:Panel ID="pnl_CheckBoxList" runat="server" ScrollBars="Auto" Width="200px" Height="100px">
                                <asp:CheckBoxList ID="chklst_Payitems" runat="server">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btn_Calculate" runat="server" OnClick="btn_Calculate_Click" 
                                Text="Calculate" CausesValidation="true" />
                        </td>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" CausesValidation="false"/>
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="False" OnClick="btn_Cancel_Click" />
                            <asp:LinkButton ID="lnkbtn_History" runat="server" OnClick="lnkbtn_History_Click">View History</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="right">
                        </td>
                        <td align="left" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <telerik:RadGrid ID="rg_Gratuity" runat="server" Skin="WebBlue" Width="762px" AutoGenerateColumns="false" >
                                <mastertableview>                            
                            <Columns>
                            <telerik:GridTemplateColumn HeaderText="">
                            <HeaderTemplate>
                                <asp:CheckBox ID="Chk_All"  Text="Check All" runat="server" OnCheckedChanged="Chk_All_CheckedChanged"  AutoPostBack="true"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                 <asp:CheckBox ID="Chk_Check"  runat="server" />
                            </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            
                            <telerik:GridBoundColumn HeaderText="Employee Id" DataField="EMP_ID" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Date of Joining" DataField="EMP_DOJ">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Department" DataField="DEPARTMENT">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>                           
                            <telerik:GridBoundColumn HeaderText="Designation" DataField="DESIGNATION">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                           <telerik:GridTemplateColumn HeaderText="Calculated Amount">
                            <ItemTemplate>
                            <asp:Label ID="lbl_Currency" runat="server" Text='<%#Eval("CURR_SYMBOL") %>'></asp:Label>
                             <asp:Label ID="lbl_Amount" runat="server" Text='<%#Eval("AMOUNT") %>'></asp:Label>                           
                             </ItemTemplate>
                             <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Maximum Elegable Amount" >
                            <ItemTemplate>
                            <asp:Label ID="lbl_Maxamt" Text='0' runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Payable">
                            <ItemTemplate>
                            <asp:Label ID="lbl_Payable" Text='0' runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>                            
                            <telerik:GridBoundColumn HeaderText="Nominee If Any" DataField="NOMINEE">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Years Of Service" DataField="EXPERIENCE">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Status" DataField="TYPE" >
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            
                            </Columns>
                            </mastertableview>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
