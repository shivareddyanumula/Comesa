<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="LeaveEncashment_New.aspx.cs" Inherits="LeaveEncashment_New" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            width: 272px;
        }

        .style2 {
            width: 296px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function LeaveEncash_History() {
                var win = window.radopen('frm_LeaveHistory.aspx', "RW_LeaveEncash");
                win.center();
                win.height = 10;
                win.title = "Leave Encash Histroy";
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr align="center">
            <td></td>
            <td></td>
            <td align="left">
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Label ID="lbl_LeaveAppDetails" runat="server" Text="Leave Encashment" meta:resourcekey="lbl_LeaveAppDetails"
                                        Style="font-weight: 700"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="font-weight: bold;">&nbsp;
                                </td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                    <asp:Label ID="lblBU" runat="server" Text="Business Unit">
                                    </asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">Financial Period
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_FinancialPeriod" runat="server" AutoPostBack="True" Filter="Contains"
                                        Skin="WebBlue" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_FinancialPeriod_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">Period Element
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_periodelement" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">From Period
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_FromPeriod" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">To Period
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_toperiod" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">PayItem Head
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Payitems" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">Select Effected PayItems
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadListBox ID="RL_Payitem" runat="server" AutoPostBack="True" CheckBoxes="true"
                                        Height="100" Skin="WebBlue" Width="200">
                                    </telerik:RadListBox>
                                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:LinkButton ID="lnkbtn_History" runat="server" Font-Bold="true" Font-Size="Small"
                                        OnClick="lnkbtn_History_Click">View 
                                    History</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Process" runat="server" OnClick="btn_Process_Click" Text="Process"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <%--<tr>
                                <td></td>
                                 <td>
                                    <asp:CheckBox ID="chk_Encash" runat="server" Font-Bold="true" Text ="Set 0 For Encash" 
                                         Visible="true" oncheckedchanged="chk_Encash_CheckedChanged" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CF" runat="server" Font-Bold="true" Text ="Set 0 For CF" 
                                         Visible="true" />
                               </td>
                               <td>
                                    <asp:CheckBox ID="chk_All" runat="server" Font-Bold="true" Text ="Select Total Value" 
                                         Visible="true" />
                               </td>
                              
                            </tr>--%>
                        </table>
                        <%--<tr>
                                <td colspan="4">--%>
                        <table align="center" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Details" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_Details_NeedDataSource" Skin="WebBlue">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                            Text="Check All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Emp Id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmp_id" runat="server" Text='<%# Eval("EMP_ID")%>'></asp:Label>
                                                        <%--OnCommand="lblEmp_id_Edit_Command" --%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLeaveTypeId" runat="server" Text='<%# Eval("LT_LEAVETYPEID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEMP_LEAVESTRUCT_ID" runat="server" Text='<%# Eval("EMP_LEAVESTRUCT_ID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEMPLOYEENAME" runat="server" Text='<%# Eval("EMPLOYEENAME")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Type of Leaves">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLeaveMasterCode" runat="server" Text='<%# Eval("LEAVEMASTER_CODE")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Current Balance">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCurrentBalance" runat="server" Text='<%# Eval("LT_CURRENTBALANCE")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Carry Forward">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtTotalCF" runat="server" AutoPostBack="true" Enabled="true"
                                                            OnTextChanged="txtTotalCF_TextChanged" MinValue="0" MaxLength="12" Text='<%# Eval("LT_CFAVAILABLE")%>'>
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RangeValidator ID="rgv_txtTotalCF" runat="server" ErrorMessage="Value Exceeds the Maximum Limit."
                                                            Text="*" Type="Double" ValidationGroup="Controls" MinimumValue="0" MaximumValue='<%#Eval("LT_CFAVAILABLE_MAX") %>'
                                                            ControlToValidate="txtTotalCF">
                                                        </asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Carry Forward" Visible="false">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtTotalCF_dis" runat="server" MinValue="0" MaxLength="12"
                                                            Text='<%# Eval("LT_CFAVAILABLE_MAX")%>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Encash">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtEncash" runat="server" AutoPostBack="True" Enabled="true"
                                                            OnTextChanged="txtEncash_TextChanged" MinValue="0" MaxLength="12" Text='<%# Eval("LT_ENCASHMENTAVAILBLE")%>'>
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RangeValidator ID="rgv_txtEncash" runat="server" ErrorMessage="Value Exceeds the Maximum Limit."
                                                            Text="*" Type="Double" ValidationGroup="Controls" MinimumValue="0" MaximumValue='<%#Eval("LT_ENCASHMENTAVAILBLE_MAX") %>'
                                                            ControlToValidate="txtEncash">
                                                        </asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Encash_dis" Visible="false">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtEncash_dis" runat="server" AutoPostBack="True"
                                                            MinValue="0" MaxLength="12" Text='<%# Eval("LT_ENCASHMENTAVAILBLE_MAX")%>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtTotalAmount" runat="server" Enabled="false" Text='<%# Eval("TotalAmount")%>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="DefaultsalaryId" Visible="false">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtDefaultValue" runat="server" Enabled="false" Text='<%# Eval("Defaultsalary")%>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerStyle AlwaysVisible="True" />
                                        </MasterTableView>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="true" />
                                        <FilterMenu>
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <%--   </td>
                            </tr>--%>
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Style="margin-left: 0px"
                                        Text="Submit" ValidationGroup="Controls" Width="69px" />
                                    <asp:Button ID="Btn_Finalise" runat="server" OnClick="Btn_Submit_Click" Style="margin-left: 0px"
                                        Text="Finalise" ValidationGroup="Controls" Width="69px" />
                                    <asp:Button ID="Btn_Clear" runat="server" meta:resourcekey="btn_Process" OnClick="Btn_Submit_Click"
                                        Text="Clear" ValidationGroup="Controls" Visible="True" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vs_LeaveApp" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>