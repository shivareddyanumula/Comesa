<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_payrejection.aspx.cs" Inherits="Payroll_frm_payrejection" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function ShowPopForm(url, ID) {
                var win = window.radopen('../Payroll/frm_PayRejectHist.aspx?ID=' + url, "RW_PayTranRejectDetails");
                win.center();
                win.set_modal(true);
            }

        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_Reject" runat="server" Width="1004px" Height="430px"
                    SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_Reject" runat="server">
                        <table align="center" width="60%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_header" runat="server" meta:resourcekey="lbl_header" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid  ID="RG_Transactions" runat="server"  Skin="WebBlue" 
                                        AutoGenerateColumns="false" OnNeedDataSource="RG_Transactions_NeedDataSource"
                                        AllowPaging="True" AllowFilteringByColumn="true">
                                        <HeaderContextMenu  Skin="WebBlue" >
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="True" Mode="NextPrevAndNumeric" />
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn UniqueName="PAYTRAN_ID" DataField="PAYTRAN_ID" HeaderText="ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="PAYTRAN_NAME" DataField="PAYTRAN_NAME" HeaderText="Transaction&nbsp;Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="PRDDTL_NAME" DataField="PRDDTL_NAME" HeaderText="Period&nbsp;Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="PAYTRAN_STATUS" DataField="PAYTRAN_STATUS" HeaderText="Transaction&nbsp;Status">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="PAYTRAN_DAYS" DataField="PAYTRAN_DAYS" HeaderText="Days">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_ViewDetails" runat="server" CommandArgument='<%# Eval("PAYTRAN_ID") %>'
                                                            Text="View&nbsp;Details" OnCommand="lnk_ViewDetails_Command">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                                    CancelImageUrl="Cancel.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FilterMenu  Skin="WebBlue" >
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
