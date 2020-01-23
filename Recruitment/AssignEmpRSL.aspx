<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="AssignEmpRSL.aspx.cs" Inherits="Recruitment_AssignEmpRSL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Assign Employee to Resume ShortListing" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_AssignEmpRSL" runat="server" SelectedIndex="0" meta:resourcekey="RMP_AssignEmpRSL">
                    <telerik:RadPageView ID="RPV_AssignEmpRSL" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_AssignEmpRSL" runat="server" AllowFilteringByColumn="true" AutoGenerateColumns="false"
                                        AllowPaging="true" GridLines="None" Skin="WebBlue" PageSize="10" meta:resourcekey="RG_AssignEmpRSL"
                                        OnNeedDataSource="RG_AssignEmpRSL_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="ASSIGNEMP_ID" UniqueName="ASSIGNEMP_ID" HeaderText="ASSIGNEMP_ID"
                                                    meta:resourcekey="ASSIGNEMP_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" HeaderText="EMP_ID"
                                                    meta:resourcekey="EMP_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE" HeaderText="Business&nbsp:Name"
                                                    meta:resourcekey="BUSINESSUNIT_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" UniqueName="EMPNAME" HeaderText="Employee&nbsp;Name"
                                                    meta:resourcekey="EMPNAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" UniqueName="DEPARTMENT_NAME" HeaderText="Department"
                                                    meta:resourcekey="DEPARTMENT_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBREQ_REQCODE" UniqueName="JOBREQ_REQCODE" HeaderText="Job&nbsp;Requisition"
                                                    meta:resourcekey="JOBREQ_REQCODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ASSIGNEMP_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_add" runat="server" Text="Add" OnCommand="lnk_Add_Command"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>

                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_AssignEmpRSLDetials" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_id" runat="server" Visible="false" meta:resourcekey="lbl_BU"></asp:Label>
                                    <asp:Label ID="lbl_BU" runat="server" Text="Business&nbsp;Name" meta:resourcekey="lbl_BU"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        meta:resourcekey="rcmb_BU" AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BU" runat="server" ControlToValidate="rcmb_BU" meta:resourcekey="rfv_rcmb_BU"
                                        InitialValue="Select" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit" Text="*">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Job" runat="server" Text="Job&nbsp;Requisition" meta:resourcekey="lbl_Job"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_JobReq" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        meta:resourcekey="rcmb_JobReq" AutoPostBack="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_JobReq" runat="server" ControlToValidate="rcmb_JobReq" meta:resourcekey="rfv_rcmb_JobReq"
                                        InitialValue="Select" ValidationGroup="Controls" ErrorMessage="Please Select Job Requisition" Text="*">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Dept" runat="server" Text="Department" meta:resourcekey="lbl_Dept"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Dept" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        meta:resourcekey="rcmb_Dept" AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Dept_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Dept" runat="server" ControlToValidate="rcmb_Dept" meta:resourcekey="rfv_rcmb_Dept"
                                        InitialValue="Select" ValidationGroup="Controls" ErrorMessage="Please Select Department" Text="*">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EMP" runat="server" Text="Employee" meta:resourcekey="lbl_EMP"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_EMP" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        meta:resourcekey="rcmb_EMP" AutoPostBack="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EMP" runat="server" ControlToValidate="rcmb_EMP" meta:resourcekey="rfv_rcmb_EMP"
                                        InitialValue="Select" ValidationGroup="Controls" ErrorMessage="Please Select Employee" Text="*">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" meta:resourcekey="btn_Save" ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" meta:resourcekey="btn_Update" ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                                        meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="VS_AssgnEMP" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>