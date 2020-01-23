<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_MainPage.aspx.cs" Inherits="frm_MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table>
        <tr>
            <td>&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="lbl_Birthday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="lbl_Reminders" runat="server" Text="HAPPY BIRTHDAY TO"></asp:Label>
                &nbsp;&nbsp; <u>
                    <telerik:RadTicker ID="RTicker" runat="server" AutoStart="true" Loop="true" TickSpeed="50">
                        <Items>
                            <telerik:RadTickerItem Text='<%# Eval("EMPNAME")%>'></telerik:RadTickerItem>
                        </Items>
                    </telerik:RadTicker>
                </u>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_SelfService" runat="server" Width="990px" Height="480px"
                    SelectedIndex="0">
                    <telerik:RadPageView ID="RPW_SelfService" runat="server">
                        <table align="left">
                            <tr>
                                <td rowspan="7" style="width: 125px">
                                    <asp:Image ID="Img_EmpSelfSerive" runat="server" Height="148px" Width="147px" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_EmpCode" runat="server" meta:resourcekey="lbl_EmpCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblEmpCode" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EmpName" runat="server" meta:resourcekey="lbl_EmpName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_DOB" runat="server" meta:resourcekey="lbl_DOB"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblBusinessUnit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Designation" runat="server" meta:resourcekey="lbl_Designation"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Grade" runat="server" meta:resourcekey="lbl_Grade"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblGrade" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" meta:resourcekey="lbl_Status"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>