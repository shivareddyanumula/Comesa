<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_EmpPay.aspx.cs" Inherits="HR_frm_EmpPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .eColor {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Pay Item Wise Employee Information"
                    Font-Bold="true"></asp:Label>

            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="updPanel1" runat="server">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="left">
                        <asp:Label ID="lbl_BusUnit" runat="server" Text="Business Unit"></asp:Label>
                    </td>
                    <td>
                        <b>: </b>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="rcb_BussinessUnit" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                            MaxHeight="200px" OnSelectedIndexChanged="rcb_BussinessUnit_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="rcb_BussinessUnit"
                            InitialValue="Select" ErrorMessage="Please Choose BusinessUnit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td align="left">
                        <asp:Label ID="lblGrade" runat="server" Text="Grade"></asp:Label>
                    </td>
                    <td>
                        <b>: </b>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="rcbGrade" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                            MaxHeight="200px" OnSelectedIndexChanged="rcbGrade_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ControlToValidate="rcbGrade"
                            InitialValue="Select" ErrorMessage="Please Choose Grade" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td align="left">
                        <asp:Label ID="lbl_Payitem" runat="server" Text="Pay Item"></asp:Label>
                    </td>
                    <td>
                        <b>: </b>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="rcmb_Payitem" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                            MaxHeight="200px" OnSelectedIndexChanged="rcmb_Payitem_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        <asp:RequiredFieldValidator ID="rfv_Payitem" runat="server" ControlToValidate="rcmb_Payitem"
                            InitialValue="Select" ErrorMessage="Please Choose PayItem" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr runat="server" id="trImport" visible="false">
                    <td>
                        <a id="A1" runat="server" href="~/HR/PayItem.xlsx">Download PayItem Template</a>
                    </td>
                    <td></td>
                    <td>
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btn_Imp_payitem" runat="server" OnClick="Btn_Imp_payitem_click" Enabled="false"
                            Text="Import" />
                    </td>
                </tr>
                <%--<tr>
            <td align="left" colspan="4" style="text-align: center">
                <asp:Button ID="btn_Save" runat="server" Text="Submit" ValidationGroup="Controls"
                    Width="63px" OnClick="btn_Save_Click" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Width="63px" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:ValidationSummary ID="vs_Salary" runat="server" meta:resourcekey="vs_Salary"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
            </td>
        </tr>--%>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Imp_payitem" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <br />
    <table align="center">
        <tr align="right">
            <td runat="server" id="td_lnk" visible="false">
                <div style="float: left;">
                    <asp:Label ID="lblVal" runat="server" Text="Value : "></asp:Label>
                    <telerik:RadNumericTextBox ID="txt_Value" runat="server" Width="80px" MaxLength="10" Style="text-align: right;" CssClass="rfdRoundedCorners rfdDecorated"></telerik:RadNumericTextBox>
                    <asp:RegularExpressionValidator ID="rfv_txt_Value" runat="server" ControlToValidate="txt_Value"
                        ErrorMessage="Only Numerical Values" Text="*" ValidationExpression="^[0-9]*\.?[0-9]+$"
                        ValidationGroup="Controls1"></asp:RegularExpressionValidator>
                    <asp:LinkButton ID="lnkApplyAll" runat="server" Text="Apply All" OnClick="lnkApplyAll_Click" ValidationGroup="Controls1"></asp:LinkButton>
                </div>
                <asp:LinkButton ID="lnk_clear" runat="server" Text="Clear All" OnClick="lnk_clear_Click"
                    OnClientClick="return confirm('Are you sure you want to Clear the data..?')"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <%-- <asp:Panel ID="pnlGrid" runat="server" ScrollBars="Auto" Height="450px">--%>
                <telerik:RadGrid ID="RG_PayElements" runat="server" AutoGenerateColumns="false" Visible="false"
                    Width="800px" OnItemDataBound="RG_PayElements_ItemDataBound">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Check All">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                        Text="Check All" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                    <asp:Label ID="lblIsEnabled" runat="server" Visible="false" Text='<%# Eval("IsEnabled") %>'></asp:Label>
                                    <asp:Label ID="lblEmpPayItemID" runat="server" Visible="false" Text='<%# Eval("SMHR_EMP_PAYITEMS_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Code">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpName" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Desgn" runat="server" Text='<%# Eval("POSITIONS_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="PRCS_TYPE" HeaderText="Process Type" UniqueName="PRCS_TYPE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Value">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Value" runat="server" Text='<%# Eval("VALUE") %>' Width="80px"
                                        MaxLength="10" Style="text-align: right;">
                                    </asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rfv_Number" runat="server" ControlToValidate="txt_Value"
                                        ErrorMessage="Only Numerical Values" Text="*" ValidationExpression="^[0-9]*\.?[0-9]+$"
                                        ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                    <%--^[-+]?[0-9]*\.?[0-9]+$"--%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Scale" UniqueName="HR_MASTER_CODE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <FilterMenu>
                    </FilterMenu>
                </telerik:RadGrid>
                <%-- </asp:Panel>--%>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table align="center">
        <tr>
            <td align="left" colspan="4" style="text-align: center">
                <asp:Button ID="btn_Save" runat="server" Text="Submit" ValidationGroup="Controls"
                    Width="63px" OnClick="btn_Save_Click" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Width="63px" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:ValidationSummary ID="vs_Salary" runat="server" meta:resourcekey="vs_Salary"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>