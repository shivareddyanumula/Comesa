<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="ManagerViewLoanStatus.aspx.cs" Inherits="Masters_ManagerViewLoanStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" width="50%">
        <tr>
            <td>
                <telerik:RadGrid ID="Rg_MamagerLoanStatus" runat="server" AutoGenerateColumns="False"
                    GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_MamagerLoanStatus_NeedDataSource"
                    AllowPaging="True" Width="50%">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("LOANTRANDTL_ID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_LOANNO" HeaderText="Loan No"
                                UniqueName="LOANTRANDTL_LOANNO" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_EMIPAYMENTDUEDATE" HeaderText="Emi Payment Due Date"
                                UniqueName="LOANTRANDTL_EMIPAYMENTDUEDATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_EMIAMOUNT" HeaderText="Amount" UniqueName="LOANTRANDTL_EMIAMOUNT">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_EMISTATUS" HeaderText="Status"
                                UniqueName="LOANTRANDTL_EMISTATUS">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_CURRENTBALANCEAMOUNT" HeaderText="Current Balance Amount"
                                UniqueName="LOANTRANDTL_CURRENTBALANCEAMOUNT">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_CURRENTLOANAMOUNt" HeaderText="Current Loan Amount"
                                UniqueName="LOANTRANDTL_CURRENTLOANAMOUNt">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOANTRANDTL_CURR_EMINO" HeaderText="Current Emi No"
                                UniqueName="LOANTRANDTL_CURR_EMINO">
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
    </table>
</asp:Content>