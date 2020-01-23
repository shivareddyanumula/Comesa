<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_UserLog.aspx.cs" Inherits="Security_frm_UserLog" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadMultiPage ID="rmp_Userlog" runat="server" Height="26px" SelectedIndex="0">
        <telerik:RadPageView ID="rpv_Userlog" runat="server" Selected="true">
            <table align="center" width="80%" style="vertical-align: top;">
                <tr>
                    <td align="center">
                        <br />
                        <asp:Label ID="lbl_UserLog" runat="server" Text="User Log"
                            Font-Bold="True" meta:resourcekey="lbl_UserLog"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadGrid ID="rgUserlog" runat="server" AutoGenerateColumns="False" AllowFilteringByColumn="True"
                            AllowPaging="True" AllowSorting="True" GridLines="None" Skin="Sunset" OnNeedDataSource="rgUserlog_NeedDataSource"
                            PageSize="5" Width="94.5%">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="USERLOG_ID" HeaderText="USERLOG_ID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <%-- <telerik:GridBoundColumn DataField="APPLICANT_FULLNAME" HeaderText="Name">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="USER_GROUP" HeaderText="User Group">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="USERLOG_IP" HeaderText="IP Address">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="USERLOG_LOGSTART" HeaderText="Start Time">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="USERLOG_LOGEND" HeaderText="End Time">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DURATION" HeaderText="Duration">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>
