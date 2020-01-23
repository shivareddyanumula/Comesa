<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_AppraisalStatus.aspx.cs" Inherits="PMS_frm_AppraisalStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    &nbsp;<table align="center">
        <tr>
            <td>
                <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All" />
                <telerik:RadMultiPage ID="RM_AppraisalStatus" runat="server">
                    <telerik:RadPageView ID="RP_AppraisalStatus" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <b>Appraisal Status </b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="false"></asp:Label>
                                                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="RCB_BusinessUnit" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RCB_BusinessUnit_SelectedIndexChanged"
                                                    MarkFirstMatch="true" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_AppraisalCycle" runat="server" Text="AppraisalCycle"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="RCB_AppraisalCycle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RCB_AppraisalCycle_SelectedIndexChanged"
                                                    MarkFirstMatch="true" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr id="tr_status" runat="server">
                                            <td>
                                                <asp:Label ID="lbl_status" runat="server" Text="Status"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_status" AutoPostBack="true" runat="server" OnSelectedIndexChanged="rcmb_status_SelectedIndexChanged"
                                                    MarkFirstMatch="true">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Value="0" Text="Select" runat="server" />
                                                        <telerik:RadComboBoxItem Value="1" Text="Completed" runat="server" />
                                                        <telerik:RadComboBoxItem Value="2" Text="NotCompleted" runat="server" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table align="center">
                                        <tr>
                                            <td align="center">
                                                <telerik:RadGrid ID="RG_AppraisalStatus" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                    GridLines="None" AllowFilteringByColumn="false" ClientSettings-Scrolling-AllowScroll="true"
                                                    ClientSettings-Scrolling-UseStaticHeaders="true" Width="900px">
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk" runat="server" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("EMPID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn HeaderText="appraisalid" DataField="APPRAISAL_ID" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Serial No" DataField="SI_NO" Visible="false"
                                                                AllowFiltering="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME" AllowFiltering="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Staus" DataField="Appraisal_status" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Staus" DataField="REPORTINGMANAGER" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Staus" DataField="APPROVALMANAGER" Visible="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Self Appraisal" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IB_Reight1" runat="server" ImageUrl="../Images/RIGHTimg1.gif"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="IB_Reight11" runat="server" ImageUrl="../Images/RONGimg2.gif"
                                                                        Visible="false" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Manager Appraisal" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IB_Reight2" runat="server" ImageUrl="../Images/RIGHTimg1.gif"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="IB_Reight22" runat="server" ImageUrl="../Images/RONGimg2.gif"
                                                                        Visible="false" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Group Manager Appraisal" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IB_Reight3" runat="server" ImageUrl="../Images/RIGHTimg1.gif"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="IB_Reight33" runat="server" ImageUrl="../Images/RONGimg2.gif"
                                                                        Visible="false" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Appraisal Discussion" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IB_Reight4" runat="server" ImageUrl="../Images/RIGHTimg1.gif"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="IB_Reight44" runat="server" ImageUrl="../Images/RONGimg2.gif"
                                                                        Visible="false" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <%--<telerik:GridTemplateColumn HeaderText="Final Rating" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadRating ID="rdrtg_final" runat="server" ItemCount="5" ReadOnly="true" Precision="Exact"
                                                                       EnableEmbeddedSkins  = "false" Value='<%# Convert.ToDouble(Eval("FINAL_RATING")) %>'    />
                                                                     
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>--%>
                                                            <telerik:GridBoundColumn HeaderText="Competency Rating (%)" DataField="GOAL_RATING">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="KRA Rating (%)" DataField="KRA_RATING">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Value Rating (%)" DataField="IDP_RATING">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Final Rating (%)" DataField="FINAL_RATING">
                                                            </telerik:GridBoundColumn>
                                                            <%--<telerik:GridTemplateColumn HeaderText="Potential Rating" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="rdrtg_potential" runat="server" MaxLength="4" MaxValue="5"
                                                                        MinValue="0" SkinID="1" Width="50px">
                                                                    </telerik:RadNumericTextBox>
                                                                    <%--<telerik:RadRating ID="rdrtg_potential" runat="server" AutoPostBack="false" ItemCount="5"
                                                                        Precision="Exact" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Business Rating" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <%--<telerik:RadRating ID="rdrtg_business" runat="server" ItemCount="5" Precision="Exact" />
                                                                    <telerik:RadNumericTextBox ID="rdrtg_business" runat="server" MaxLength="4" MaxValue="5"
                                                                        MinValue="0" SkinID="1" Width="50px">
                                                                        </telerik:RadNumericTextBox>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn HeaderText="Comments" DataField="COMMENTS" AllowFiltering="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Overall Rating" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btn_generat" runat="server" Text="Generate Grade" CommandArgument='<%# Eval("SI_NO") %>'
                                                                        OnCommand="btn_genrate_command" />
                                                                    <asp:Label ID="lbl_grade" runat="server" Text="a" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>--%>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                                                &nbsp; &nbsp;&nbsp;
                                                <asp:Button ID="btn_finalise" runat="server" Text="Finalize" OnClick="btn_finalise_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>