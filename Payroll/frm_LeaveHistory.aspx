<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_LeaveHistory.aspx.cs" Inherits="frm_LeaveHistory" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">

                <tr>
                    <td>
                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        </telerik:RadScriptManager>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Label ID="lblHeading" runat="server"
                            Text="Leave History Details " Style="font-weight: 700"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Business Unit</td>
                    <td colspan="3">: </td>
                    <td>
                        <asp:Label ID="lblBusinessUnit" runat="server" meta:resourcekey="lblBusinessUnit" Text='<%# Eval("BUSINESSUNIT_CODE")%>'></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>From Period </td>
                    <td colspan="3">: </td>
                    <td>
                        <asp:Label ID="lblFromPeriod" runat="server" meta:resourcekey="lblFromPeriod" Text='<%# Eval("FROM_PERIOD")%>'></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>To Period </td>
                    <td colspan="3">: </td>
                    <td>
                        <asp:Label ID="lblToPeriod" runat="server" meta:resourcekey="lblToPeriod" Text='<%# Eval("TO_PERIOD")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Pay Elements </td>
                    <td colspan="3">: </td>
                    <td>
                        <asp:Label ID="lblPayElements" runat="server" meta:resourcekey="lblPayElements" Text='<%# Eval("PAYITEM_PAYITEMNAME")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Executed Date </td>
                    <td colspan="3">: </td>
                    <td>
                        <asp:Label ID="lblExecutedDate" runat="server" meta:resourcekey="lblExecutedDate" Text='<%# Eval("SMHR_LP_CREATED_DATE")%>'></asp:Label></td>
                </tr>
                <tr>
                    <td>Created By </td>
                    <td colspan="3">: </td>
                    <td>
                        <asp:Label ID="lblCreatedBy" runat="server" meta:resourcekey="lblCreatedBy" Text='<%# Eval("SMHR_LP_CREATED_BY")%>'></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>

                <%-- <tr>
                        <td class="style1">
                            Period Element
                        </td>
                        <td>
                            :
                        </td>
                            <td>
                                <telerik:RadComboBox ID="rcmb_periodelement" runat="server" AutoPostBack="True" 
                                   Skin="WebBlue" 
                                    onselectedindexchanged="rcmb_periodelement_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                      </tr>--%>
            </table>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadGrid ID="RG_ViewHistory" runat="server" AutoGenerateColumns="False"
                            GridLines="None" Skin="WebBlue">
                            <%-- AllowPaging="True"--%>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataSetIndex+1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Emp Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmp_id" runat="server" Text='<%# Eval("LP_EMP_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEMPLOYEENAME" runat="server" Text='<%# Eval("EMPLOYEENAME")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Period">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToPeriod" runat="server" Text='<%# Eval("PERIOD_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%-- <telerik:GridTemplateColumn HeaderText="Period Element">
                                                     
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPeriodElement" runat="server" Text='<%# Eval("PRDDTL_NAME")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridTemplateColumn HeaderText="Total CarryForward Leaves">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTOTAL_CF" runat="server" Text='<%# Eval("LP_CF_LEAVES")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Total Encash Leaves">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTOTAL_ENCASH" runat="server" Text='<%# Eval("LP_ENC_LEAVES")%>'
                                                meta:resourcekey="TOTAL_ENCASH"></asp:Label>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Encashed Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("LP_ENC_AMOUNT")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                </Columns>

                            </MasterTableView>
                            <PagerStyle AlwaysVisible="true" />
                        </telerik:RadGrid>
                    </td>
                </tr>

            </table>
        </div>

    </form>
</body>
</html>