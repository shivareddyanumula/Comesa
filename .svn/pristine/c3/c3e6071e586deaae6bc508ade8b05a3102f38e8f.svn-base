<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_EmployeeIDP.aspx.cs" Inherits="PMS_frm_EmployeeIDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">

        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_Idpform" runat="server">
                    <telerik:RadPageView ID="RP_Idpform" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_idpid" runat="server" Text="IDP Details" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Idpform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        Skin="WebBlue" PageSize="5" AllowFilteringByColumn="True"
                                        OnNeedDataSource="RG_Idpform_NeedDataSource1" GridLines="None">
                                        <MasterTableView CommandItemDisplay="None">
                                            <Columns>

                                                <telerik:GridBoundColumn HeaderText="IDP" DataField="IDP_NAME"
                                                    UniqueName="IDP_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="IDP_DESCRIPTION"
                                                    UniqueName="IDP_DESCRIPTION">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Date" DataField="IDP_STARTDATE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="IDP_STATUS">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="IDP_APPRAISALCYCLE" UniqueName="IDP_APPRAISALCYCLE" HeaderText="Appraisal Cycle"
                                                    >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                            </Columns>

                                        </MasterTableView>
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