<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="FrmEmployeeRating.aspx.cs" Inherits="PMS_FrmEmployeeRating" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">

        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_Employeertg" runat="server">
                    <telerik:RadPageView ID="RP_Employeertg" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_idrtg" runat="server" Text="My Final Rating Details" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_appcycle" runat="server" Text="Appraisal&nbsp;Cycle"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_appcycle" runat="server" MarkFirstMatch="true"
                                            MaxHeight="120px" AutoPostBack="True" Filter="Contains"
                                            OnSelectedIndexChanged="rcmb_appcycle_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>

                                </tr>
                            </table>
                            <table align="center">
                                <tr>
                                    <td colspan="3" align="center">
                                        <telerik:RadGrid ID="RG_Employeertg" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                            Skin="WebBlue" PageSize="10" AllowFilteringByColumn="True"
                                            OnNeedDataSource="RG_Employeertg_NeedDataSource" GridLines="None" Width="500px">
                                            <MasterTableView CommandItemDisplay="None">
                                                <Columns>

                                                    <%-- <telerik:GridBoundColumn HeaderText="Goal Avg Rtg" DataField="APPRAISAL_GOAL_AVGRTG" 
                                                    UniqueName="APPRAISAL_GOAL_AVGRTG">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Kra Avg Rtg" DataField="APPRAISAL_KRA_AVGRTG" 
                                                    UniqueName="APPRAISAL_KRA_AVGRTG">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Final Rtg" DataField="APP_FINALRTG">
                                                </telerik:GridBoundColumn>--%>
                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Competency Avg Rating">
                                                        <ItemTemplate>
                                                            <telerik:RadRating ID="lbl_rating1" runat="server" Value='<%# Convert.ToDecimal(Eval("APPRAISAL_GOAL_AVGRTG")) %>'
                                                                ReadOnly="true" Precision="Exact" ItemCount="5" Font-Size="X-Large" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="KRA Avg Rating">
                                                        <ItemTemplate>
                                                            <telerik:RadRating ID="lbl_rating2" runat="server" Value='<%# Convert.ToDecimal(Eval("APPRAISAL_KRA_AVGRTG")) %>'
                                                                ReadOnly="true" Precision="Exact" ItemCount="5" Font-Size="X-Large" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Value Avg Rating">
                                                        <ItemTemplate>
                                                            <telerik:RadRating ID="lbl_rating4" runat="server" Value='<%# Convert.ToDecimal(Eval("APPRAISAL_IDP_AVGRTG")) %>'
                                                                ReadOnly="true" Precision="Exact" ItemCount="5" Font-Size="X-Large" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Final Rating">
                                                        <ItemTemplate>
                                                            <telerik:RadRating ID="lbl_rating3" runat="server" Value='<%# Convert.ToDecimal(Eval("APP_FINALRTG")) %>'
                                                                ReadOnly="true" Precision="Exact" ItemCount="5" Font-Size="X-Large" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>

                                                    <%-- <telerik:GridBoundColumn HeaderText="Potential Rtg" DataField="APP_POTENTIALRTG">
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Buainess Rtg" DataField="APP_BUSINEESRTG">
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Over All Rtg" DataField="APP_OVERALLRTG">
                                                </telerik:GridBoundColumn>--%>
                                                </Columns>

                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </table>
                    </telerik:RadPageView>

                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>