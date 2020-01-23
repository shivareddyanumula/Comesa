<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="HrManagerLoan.aspx.cs" Inherits="Masters_HrManagerLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">&nbsp;
                                <asp:Label ID="Label2" runat="server"
                                    Text="HR Manager Loan Sanction"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Manager_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <telerik:RadGrid ID="Rg_HrMamager" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_HrMamager_NeedDataSource" AllowPaging="True"
                                        Width="900px" OnItemDataBound="Rg_HrMamager_ItemDataBound1">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("LOANREQUESTID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Select" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkOpen" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" UniqueName="EmployeeName"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="payitem_payitemname" HeaderText="Type Of Loan" UniqueName="payitem_payitemname" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NOOFINSTALLMENTS" HeaderText="No Of Installments" UniqueName="NOOFINSTALLMENTS" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Loan Mode" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Loan Type" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmb_Loan" runat="server" MarkFirstMatch="true">
                                                            <Items>
                                                                <%--<telerik:RadComboBoxItem Text="Equated Monthly Installment" Value="1" /> --%>
                                                                <telerik:RadComboBoxItem Text="Reducing Balance" Value="2" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
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
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" meta:resourcekey="btn_Save"
                                        OnClick="btn_Save_Click" OnClientClick="disableButtoneve(this);" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Proceed" meta:resourcekey="btn_Cancel"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                                <td align="center">&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>