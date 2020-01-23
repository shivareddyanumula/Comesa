<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="LoanManagerApproval.aspx.cs" Inherits="Masters_LoanManagerApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function disableButton(sender) {

            sender.disabled = "disabled";
        }

        function ShowPop(LRID) {
            var win = window.radopen('../Reportss/LoanVoucherReport.aspx?LRID=' + LRID, "RW_LoanVoucher");
            win.center();
            win.set_modal(true);
            //win.set_title("Leave Allowances Paid Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">&nbsp;
               <b>Loan Manager Approval</b></td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Manager_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="690px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Mamager" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnItemCreated="Rg_Mamager_ItemCreated" ClientSettings-Scrolling-AllowScroll="true"
                                        OnNeedDataSource="Rg_Mamager_NeedDataSource" AllowPaging="True" PageSize="5" ClientSettings-Scrolling-UseStaticHeaders="true"
                                        Width="900px" Height="300px" OnDataBinding="Rg_Mamager_DataBinding" AllowFilteringByColumn="true"
                                        OnItemDataBound="Rg_Mamager_ItemDataBound">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("LOANREQUESTID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%-- <telerik:GridTemplateColumn HeaderText="Select " AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkOpen" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn HeaderText="Select All" AllowFiltering="false">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_CheckedChanged"
                                                            Text="Select All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                                        <asp:Label ID="lblIsEnabled" runat="server" Visible="false" Text='<%# Eval("IsEnabled") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" UniqueName="EmployeeName"
                                                    ItemStyle-HorizontalAlign="Left" FilterControlWidth="150px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Approved Date">
                                                    <ItemTemplate>
                                                        <%-- <telerik:RadDatePicker ID="txt_StartDate" runat="server" Skin="WebBlue">
                                                            <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                                ViewSelectorText="x">
                                                            </Calendar>
                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                                            </DateInput>
                                                        </telerik:RadDatePicker>--%>
                                                        <asp:Label ID="lbl_DPname" Text='<%# Eval("APPROVEDATE") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="payitem_payitemname" HeaderText="Type Of Loan" UniqueName="payitem_payitemname">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NOOFINSTALLMENTS" HeaderText="No Of Installments" UniqueName="NOOFINSTALLMENTS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Status" ItemStyle-HorizontalAlign="Left" FilterControlWidth="150px" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="1" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Approved" Value="2" />
                                                                <%-- <telerik:RadComboBoxItem runat="server" Text="Declined" Value="3" />--%>
                                                                <telerik:RadComboBoxItem runat="server" Text="Cancelled" Value="3" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn  HeaderText="Voucher" >
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkVoucher" runat="server" Enabled='<%# Convert.ToBoolean(Eval("ViewVoucher")) %>' Text="View Voucher" OnCommand="lnkVoucher_OnCommand"
                                                            CommandArgument='<%#Eval("LOANREQUESTID") %>' ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" meta:resourcekey="btn_Save"
                                        OnClick="btn_Save_Click" OnClientClick="disableButtoneve(this);" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" meta:resourcekey="btn_Cancel"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>