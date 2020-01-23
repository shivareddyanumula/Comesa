<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_PastInspections.aspx.cs" Inherits="Approval_frm_PastInspections" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="rsmPastData" runat="server"></telerik:RadScriptManager>
        </div>
        <table>
            <tr><td colspan="3"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Date" runat="server" Text="From Date"></asp:Label>
                </td>
                <td><b>:</b>
                </td>
                <td>
                    <telerik:RadDatePicker ID="rdtp_FromDate" runat="server"
                        Skin="WebBlue">
                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                            ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr><td colspan="3"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_To" runat="server" Text="To Date"></asp:Label>
                </td>
                <td><b>:</b>
                </td>
                <td>
                    <telerik:RadDatePicker ID="rdtp_ToDate" runat="server"
                        Skin="WebBlue" Enabled="false">
                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                            ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                </td>
            </tr>            
            <tr><td colspan="3"></td></tr>
            <tr><td colspan="3"></td></tr>
            <tr><td colspan="3"></td></tr>
            <tr>
                <%--<td></td>--%>
                <td colspan="3">
                    <asp:Button ID="btn_Generate" runat="server" OnClick="btn_Generate_Click" Text="Generate" ValidationGroup="Controls" />
                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                    <asp:ValidationSummary ID="vsPastInspections" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                </td>
                <%--<td></td>--%>
            </tr>
            <tr>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="Rg_Areas_To_Inspected" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    AllowPaging="True" AllowFilteringByColumn="false" Skin="WebBlue" Visible="false" OnNeedDataSource="Rg_Areas_To_Inspected_NeedDataSource"
                                     OnItemDataBound="Rg_Areas_To_Inspected_ItemDataBound">
                                    <MasterTableView CommandItemDisplay="None" EnableNoRecordsTemplate="true">
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Sl.No" UniqueName="Sl_No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSn" Text="<%# (Container.ItemIndex+1).ToString() %>" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="IsCompliant" UniqueName="IsCompliant" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_IsCompliant" Text='<%# Eval("INSPECTION_AREA_ISCOMPLIANT") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Choose">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Area Name" UniqueName="Area_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Area_Id" runat="server" Text='<%# Eval("AREA_ID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lbl_AreaName" runat="Server" Text='<%#Eval("AREA_NAME") %>'></asp:Label>
                                                    <asp:RadioButtonList ID="rbl_IsCompliant" RepeatDirection="Horizontal" RepeatColumns="2" runat="server">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="rfv_IsCompliant" runat="server" ControlToValidate="rbl_IsCompliant" ErrorMessage="Please select Area Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="Is_Compliant" HeaderText="Is Compliant" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Comments" runat="Server" Text="Comments"></asp:Label>
                                                    <asp:Label ID="lbl_ItemComments" runat="Server" Text='<%# Eval("INSPECTION_AREA_COMMENTS") %>' Visible="false"></asp:Label>
                                                    <telerik:RadTextBox ID="Comments" runat="server" Width="10px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="rfv_Comments" runat="server" ControlToValidate="Comments" ErrorMessage="Please Enter Comments" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            <div>
                                                There are no records to display
                                            </div>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="true" />
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>