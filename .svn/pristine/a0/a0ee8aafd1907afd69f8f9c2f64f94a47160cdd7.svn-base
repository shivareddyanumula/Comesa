<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Employeecomp.aspx.cs" Inherits="Masters_frm_Employeecomp" Title="Untitled Page" %>

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
            <td colspan="5"></td>
        </tr>

        <tr>
            <td align="right">
                <asp:Label ID="lbl_Businesssunit" runat="server" Text="Businessunit">
                </asp:Label>
            </td>
            <td align="center"><b>:</b></td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                    OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>

        <tr>
            <td align="right">
                <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period">
                </asp:Label>
            </td>
            <td align="center"><b>:</b></td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                    OnSelectedIndexChanged="rcmb_Financialperiod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>

        <tr>
            <td align="right">
                <asp:Label ID="lbl_CheckPrevious" runat="server" Text="Check Previous Financial Period Data">
                </asp:Label>
            </td>
            <td align="center"><b>:</b></td>
            <td align="left">
                <asp:CheckBox ID="chk_Previous" runat="server" AutoPostBack="true" />
            </td>
            <td></td>
        </tr>

        <tr>
            <td colspan="5"></td>
        </tr>

        <tr>
            <td colspan="5" align="center">
                <asp:GridView ID="rg_Empcomponents" AutoGenerateColumns="false" runat="server"
                    AllowPaging="True" PageSize="5"
                    OnPageIndexChanging="rg_Empcomponents_PageIndexChanging">

                    <%-- <PagerTemplate>
                    <table align="center" width="100%">
                        <tr id="Page" runat="server">
                            <td align="center">
                                <asp:PlaceHolder ID="plc_Pages" runat="server">
                                </asp:PlaceHolder>
                            </td>
                        </tr>
                    </table>
                </PagerTemplate>
                    --%>
                    <Columns>
                        <asp:TemplateField HeaderText="Empid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Empid" runat="server" Text='<%#Eval("EMP_ID") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chk_All" runat="server" Text="Check All"
                                    AutoPostBack="true" OnCheckedChanged="chk_All_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Row" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Row No" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />

                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Employee Name" DataField="EMP_NAME" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Center" />

                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Components" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:CheckBoxList ID="chklst_Components" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chklst_Components_SelectedIndexChanged">
                                </asp:CheckBoxList>
                                <asp:Label ID="lbl_Total" runat="server" Text="Sum of Checked Componenets Percnetage :" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />

                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Percentage" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:DataList ID="dlst_Percentages" runat="server">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="txt_Percentage" runat="server" AutoPostBack="true" Enabled="false"
                                            MinValue='<%#Eval("SMHR_VPCOMP_MIN") %>' MaxValue='<%#Eval("SMHR_VPCOMP_MAX") %>' MaxLength="3" OnTextChanged="txt_Percentage_TextChanged">
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Total" runat="server" Enabled="false">
                                        </asp:TextBox>
                                    </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:DataList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />

                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

        <tr>
            <td colspan="5"></td>
        </tr>

        <tr>
            <td></td>
            <td align="right">
                <asp:Button ID="btn_Save" runat="server" Text="Save" />
            </td>
            <td align="left">
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" />
            </td>
            <td></td>
            <td></td>
        </tr>

    </table>
</asp:Content>