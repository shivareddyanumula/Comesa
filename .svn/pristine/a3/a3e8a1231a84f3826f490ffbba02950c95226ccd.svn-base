<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Variableamtmaster.aspx.cs" Inherits="Masters_frm_Variableamtmaster" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <telerik:RadScriptBlock ID="rsbScripts" runat="server">

                <script language="javascript" type="text/javascript">
                    function confirmationSave() {
                        if (confirm("Do you want to finalize the Attendance?")) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                </script>

            </telerik:RadScriptBlock>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--<br />--%>

    <%-- <telerik:RadAjaxPanel ID="RAPNL_Variblemaster" runat="server" LoadingPanelID="ralp_variablemaster">--%>
    <table align="center">
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Variableamt" runat="server" Font-Bold="true"
                    Text="Variable Amount">
                </asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="5" align="center">&nbsp;</td>
        </tr>

        <tr>
            <td colspan="5"></td>
        </tr>

        <tr>
            <td></td>
            <td align="right">
                <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" MarkFirstMatch="true" TabIndex="1" Filter="Contains">
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
                <telerik:RadComboBox ID="rcmb_FinancialPeriod" runat="server" MarkFirstMatch="true" TabIndex="2"
                    AutoPostBack="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_FinancialPeriod_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>

        <tr>
            <td colspan="5"></td>
        </tr>

        <tr>
            <td></td>
            <td align="center" colspan="3" style="width: 90%">
                <telerik:RadGrid ID="RG_Variableallowance" runat="server" AutoGenerateColumns="false"
                    AllowFilteringByColumn="false" OnNeedDataSource="RG_Variableallowance_NeedDataSource">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>

                            <telerik:GridTemplateColumn HeaderText="S.No" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SNO" runat="server" AllowFiltering="false" Text=' <%#Container.DataSetIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn HeaderText="Empid" DataField="EMP_ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn HeaderText="Employee" DataField="EMP_NAME" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn HeaderText="Payable Periods" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:CheckBoxList ID="chk_Periods" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="chk_Periods_SelectedIndexChanged"
                                        RepeatColumns="4" AutoPostBack="true">
                                        <%--<asp:ListItem Text="Jan" Value="1" ></asp:ListItem>
                                            <asp:ListItem Text="Feb" Value="2" ></asp:ListItem>
                                            <asp:ListItem Text="Mar" Value="3" ></asp:ListItem>
                                            <asp:ListItem Text="Apr" Value="4" ></asp:ListItem>
                                            <asp:ListItem Text="May" Value="5" ></asp:ListItem>
                                            <asp:ListItem Text="Jun" Value="6" ></asp:ListItem>
                                            <asp:ListItem Text="Jul" Value="7" ></asp:ListItem>
                                            <asp:ListItem Text="Aug" Value="8" ></asp:ListItem>
                                            <asp:ListItem Text="Sep" Value="9" ></asp:ListItem>
                                            <asp:ListItem Text="Oct" Value="10" ></asp:ListItem>
                                            <asp:ListItem Text="Nov" Value="11" ></asp:ListItem>
                                            <asp:ListItem Text="Dec" Value="12" ></asp:ListItem>--%>
                                    </asp:CheckBoxList>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="No. Of Time Payable" DataField="EMP_COUNT_VARIABLEAMOUNT" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Count" Text='<%#Eval("EMP_COUNT_VARIABLEAMOUNT") %>' runat="server"></asp:Label>
                                    <%--<telerik:RadNumericTextBox ID="rntxt_Count" runat="server" MinValue="0" MaxValue="12" Value="'<%#Eval("EMP_COUNT_VARIABLEAMOUNT") %>
                                        </telerik:RadNumericTextBox>--%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Checked Periods" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Vary" runat="server" Visible="false" BackColor="Red" ToolTip="Differed">
                                    </asp:Label>
                                    <asp:Label ID="lbl_Same" runat="server" Visible="false" ToolTip="Same" BackColor="Green">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Amount For Each Period" DataField="EMP_VARIABLEAMOUNT" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%--<telerik:RadNumericTextBox ID="rntxt_Amount" runat="server" MinValue="0">
                                        </telerik:RadNumericTextBox>--%>
                                    <asp:Label ID="lbl_Amount" Text='<%#Eval("EMP_VARIABLEAMOUNT") %>' runat="server"></asp:Label>
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
            <td align="right">&nbsp;</td>
            <td></td>
            <td align="left">
                <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" TabIndex="3"
                    Text="Save" />
                <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update" TabIndex="3" />
                <asp:Button ID="btn_Cancel" Text="Cancel" runat="server" OnClick="btn_Cancel_Click" TabIndex="4" />
            </td>
            <td></td>
        </tr>

        <tr>
            <td colspan="5"></td>
        </tr>
    </table>
    <%--</telerik:RadAjaxPanel>--%>
</asp:Content>