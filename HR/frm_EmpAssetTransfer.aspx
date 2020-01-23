<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_EmpAssetTransfer.aspx.cs" Inherits="HR_frm_EmpAssetTransfer" %>

<asp:Content ID="cphAssetTransfer" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <telerik:RadWindowManager ID="RWM_EMPASSETTRANSFER" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManagerProxy ID="RAM_EMPASSETTRANSFER" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_EmpAssetTransfer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lbl_EMPASSETTRANSFERHeader" runat="server" Text="Employee Assets Transfer" Font-Bold="True"
                    meta:resourcekey="lbl_EMPASSETTRANSFERHeader"></asp:Label>
                <br />
                <br />
            </td>
            <td></td>
        </tr>

        <tr align="center">
            <td align="right">
                <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true" AutoPostBack="True" MaxHeight="120px"
                    Skin="WebBlue" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="RFV_ddl_BusinessUnit" runat="server" ControlToValidate="ddl_BusinessUnit"
                    ErrorMessage="Please Select Business Unit" meta:resourcekey="RFV_ddl_BusinessUnit"
                    Text="*" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblEmployee" runat="server" Text="From Employee"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="ddl_Employee" runat="server" AutoPostBack="True" Skin="WebBlue"
                    OnSelectedIndexChanged="ddl_Employee_SelectedIndexChanged" MaxHeight="120px"
                    MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="RFV_Employee" runat="server" ControlToValidate="ddl_Employee"
                    meta:resourcekey="RFV_Employee" Text="*" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red"> </asp:RequiredFieldValidator>

            </td>
        </tr>


    </table>
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <br />
                <br />
                <telerik:RadGrid ID="Rg_EmpAssetTransfer" runat="server" AutoGenerateColumns="False" GridLines="None"
                    AllowPaging="True" AllowFilteringByColumn="false" Skin="WebBlue" OnNeedDataSource="Rg_EmpAssetTransfer_NeedDataSource" Visible="false">
                    <MasterTableView CommandItemDisplay="None">
                        <Columns>
                          
                            <telerik:GridBoundColumn DataField="ASSET_ID" UniqueName="ASSET_ID" HeaderText="EMPASSETDOC ID"
                                meta:resourcekey="ASSET_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ASSET_DEPARTMENT_ID" UniqueName="ASSET_DEPARTMENT_ID" HeaderText="Dept ID"
                                meta:resourcekey="ASSET_DEPARTMENT_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="ColCheck" meta:resourcekey="ColCheck" HeaderText="Select" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="ASSET_NAME" UniqueName="ASSET_NAME"
                                AllowFiltering="false" HeaderText="Asset Name " meta:resourcekey="ASSET_NAME" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="ColToEmp" HeaderText="To Employee" meta:resourcekey="ColToEmp" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcmbToEmployee" runat="server" AppendDataBoundItems="true" Filter="Contains"
                                        DataTextField="Empname" DataValueField="EMP_ID" DataSource='<%#LoadGridEmployees() %>'>
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="ColToIssuedDate" HeaderText="Date of Transfer" meta:resourcekey="ColToIssuedDate" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <telerik:RadDatePicker ID="rdpIssuedDate" MinDate='<%#Eval("EMP_DOJ") %>' MaxDate='<%#DateTime.Now %>' runat="server" SelectedDate='<%#DateTime.Now %>' >
                                        <DateInput MinDate='<%#Eval("EMP_DOJ") %>' ID="dateinput1" runat="server">                                   
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle AlwaysVisible="true" />
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <br />
                <asp:Button ID="btn_Transfer" runat="server" Text="Transfer" meta:resourcekey="btn_Transfer" OnClick="btn_Transfer_Click" Visible="false" />
                <asp:Button ID="btn_Cancel" Text="Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>

