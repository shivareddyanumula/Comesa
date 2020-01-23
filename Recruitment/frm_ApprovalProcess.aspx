<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_ApprovalProcess.aspx.cs" Inherits="Recruitment_frm_ApprovalProcess" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript">
        function OnClientItemsRequesting(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["FilterString"] = eventArgs.get_text();
        }


    </script>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Approval Process" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_ApproverProcess_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    meta:resourcekey="Rm_ApproverProcess_PAGE">
                    <telerik:RadPageView ID="Rp_ApproverProcess_VIEWMAIN" runat="server" Selected="True" meta:resourcekey="Rp_ApproverProcess_VIEWMAIN">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_ApproverProcess" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="false"
                                        Skin="WebBlue" PageSize="5" meta:resourcekey="Rg_ApproverProcess" OnNeedDataSource="rgap_needsource">
                                        <MasterTableView CommandItemDisplay="None">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="APPRO_ID" UniqueName="APPRO_ID" HeaderText="APPRO_ID"
                                                    meta:resourcekey="APPRO_ID" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="APPRO_BU_ID" UniqueName="APPRO_BU_ID" HeaderText="Business Unit" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" 
                                                    HeaderText="Employee" meta:resourcekey="GridBoundColumnResource1">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="APPRO_APPROVER3_ID" UniqueName="APPRO_APPROVER3_ID" Visible="false" HeaderText="APPRO_APPROVER3_ID" />
                                                <telerik:GridBoundColumn DataField="APPRO_APPROVER1_ID" UniqueName="APPRO_APPROVER1_ID" Visible="false" HeaderText="1 LeveAPPRO_APPROVER1_ID" />
                                                <telerik:GridBoundColumn DataField="APPRO_APPROVER2_ID" UniqueName="APPRO_APPROVER2_ID" Visible="false" HeaderText="APPRO_APPROVER2_ID" />

                                                <telerik:GridBoundColumn DataField="APPRO_APPROVER1" UniqueName="APPRO_APPROVER1" HeaderText="1 Level">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="APPRO_APPROVER2" UniqueName="APPRO_APPROVER2"
                                                    HeaderText="2 Level">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="APPRO_APPROVER3 " UniqueName="APPRO_APPROVER3" HeaderText="3 Level">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="coledit" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_edit" runat="server" Text="Edit" CommandArgument='<%# Eval("APPRO_ID") %>'
                                                                OnCommand="lnk_edit_Command"></asp:LinkButton>
                                                        </div>
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
                    <telerik:RadPageView ID="Rp_ApprvalPrecess_VIEWDETAILS" runat="server" meta:resourcekey="Rp_ApprvalPrecess_VIEWDETAILS">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:Label ID="lbl_Header2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AP_Id" runat="server" Visible="False" meta:resourcekey="lbl_AP_Id"></asp:Label>
                                    <%--<asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit" meta:resourcekey="lbl_BusinessUnitName"></asp:Label>--%>
                                </td>
                            </tr>
                            <%--  <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True"
                                        Width="200px"  OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" 
                                        meta:resourcekey="rcmb_BusinessUnitType" MarkFirstMatch="true"  MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                         <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType"
                                        runat="server" ValidationGroup="Controls"  InitialValue="Select" 
                                        ErrorMessage="Please Select BusinessUnit">*</asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_1Level" runat="server" meta:resourcekey="lbl_1Level"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <%--<telerik:RadComboBox ID="rcmb_1Level" runat="server" Width="200px"
                                        OnSelectedIndexChanged="rcmb_1Level_SelectedIndexChanged" meta:resourcekey="rcmb_1Level"
                                        MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                    <telerik:RadComboBox ID="rcmb_1Level" Width="200px" runat="server" Skin="WebBlue" HighlightTemplatedItems="True"
                                        EmptyMessage="Enter Level 1 Employee Name" MaxHeight="120px" Filter="Contains"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_1Level_SelectedIndexChanged" OnClientItemsRequesting="OnClientItemsRequesting">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ApprovalProcess.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_1Level" ControlToValidate="rcmb_1Level"
                                        runat="server" ValidationGroup="Controls"
                                        ErrorMessage="Please Select 1 Level">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%-- <asp:CompareValidator ID="cmpv_rcmb_1Level" runat="server" ErrorMessage="1 Level should not be equal to 3 Level" ControlToValidate="rcmb_1Level" ControlToCompare="rcmb_3Level" Operator="NotEqual" ValueToCompare="Select"></asp:CompareValidator>                                    --%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_2Level" runat="server" meta:resourcekey="lbl_2Level"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <%-- <telerik:RadComboBox ID="rcmb_2Level" runat="server" Width="200px" meta:resourcekey="rcmb_2Level"
                                        AutoPostBack="True" OnSelectedIndexChanged="rcmb_2Level_SelectedIndexChanged" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                    <telerik:RadComboBox ID="rcmb_2Level" Width="200px" runat="server" Skin="WebBlue" HighlightTemplatedItems="True"
                                        EmptyMessage="Enter Level 2 Employee Name" MaxHeight="120px" Filter="Contains"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_2Level_SelectedIndexChanged" OnClientItemsRequesting="OnClientItemsRequesting">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ApprovalProcess.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_2Level" ControlToValidate="rcmb_2Level"
                                        runat="server" ValidationGroup="Controls"
                                        ErrorMessage="Please Select 2 Level">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%-- <asp:CompareValidator ID="cmpv_rcmb_2Level" runat="server" ErrorMessage="2 Level should not be equal to 1 Level" ControlToValidate="rcmb_2Level" ControlToCompare="rcmb_1Level" Operator="NotEqual" ValueToCompare="Select"></asp:CompareValidator>                                    --%>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_3Level" runat="server" meta:resourcekey="lbl_3Level"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <%--<telerik:RadComboBox ID="rcmb_3Level" runat="server" Width="200px" meta:resourcekey="rcmb_3Level"
                                        AutoPostBack="True" OnSelectedIndexChanged="rcmb_3Level_SelectedIndexChanged" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                    <telerik:RadComboBox ID="rcmb_3Level" Width="200px" runat="server" Skin="WebBlue" HighlightTemplatedItems="True"
                                        EmptyMessage="Enter Level 3 Employee Name" MaxHeight="120px" Filter="Contains"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_3Level_SelectedIndexChanged" OnClientItemsRequesting="OnClientItemsRequesting">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ApprovalProcess.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_3Level" ControlToValidate="rcmb_3Level"
                                        runat="server" ValidationGroup="Controls"
                                        ErrorMessage="Please Select 3 Level">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%-- <asp:CompareValidator ID="cmpv_rcmb_3Level" runat="server" ErrorMessage="3 Level should not be equal to 2 Level" ControlToValidate="rcmb_3Level" ControlToCompare="rcmb_2Level" Operator="NotEqual" ValueToCompare="Select" ></asp:CompareValidator>--%>
                                   
                                </td>
                                <td>
                                    <%--   <asp:CheckBox ID ="chk_Approver2" runat="server" meta:resourcekey="chk_Approver2" />--%>
                                </td>
                                <%--<td> <asp:Label ID ="lbl_man" runat ="server" meta:resourcekey="lbl_man"></asp:Label></td>--%>
                            </tr>
                            <%-- <tr>
                                <td>
                                    <asp:Label ID="lbl_HR" runat="server" meta:resourcekey="lbl_HR"></asp:Label >
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_HR" runat="server" Width="200px" meta:resourcekey="rcmb_HR"
                                        AutoPostBack="True">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_HR" ControlToValidate="rcmb_HR"
                                        runat="server" ValidationGroup="Controls"   InitialValue="Select"
                                        ErrorMessage="Please Select HR">*</asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" Text="Save"
                                        ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_update" runat="server" Text="Update"
                                        ValidationGroup="Controls" OnClick="btn_update_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click1"
                                        Text="Cancel" />

                                    <asp:ValidationSummary ID="vs_AP" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>

                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>