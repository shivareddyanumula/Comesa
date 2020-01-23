<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmployeeLoanStatus.aspx.cs" Inherits="Masters_EmployeeLoanStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                &nbsp;
                    <asp:Label ID="Label2" runat="server" 
                    Text="Employee Loan Status" Font-Bold="true"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Manager_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                            <td>
                                &nbsp;</td>
                                <td>
                                    <telerik:RadGrid ID="Rg_HrMamager" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_HrMamager_NeedDataSource"
                                        Width="700px" AllowFilteringByColumn="true">
                                      <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("LOANREQUESTID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="SI_NO" UniqueName="SI_NO" HeaderText="S.No" meta:resourcekey="SI_NO" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                              <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" UniqueName="EmployeeName"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn DataField="payitem_payitemname" HeaderText="Type of Loan" UniqueName="payitem_payitemname" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridNumericColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                 <telerik:GridNumericColumn DataField="NOOFINSTALLMENTS" HeaderText="No of Installments" UniqueName="NOOFINSTALLMENTS" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                  <telerik:GridBoundColumn DataField="status" HeaderText=" Loan Status" UniqueName="status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
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
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                  </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

