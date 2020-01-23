<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="DepartmentHeads.aspx.cs" Inherits="HR_DepartmentHeads" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cphDepartmentHeadMapping" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <telerik:radwindowmanager id="RWM_DepartmentHeadsMapping" runat="server" style="z-index: 8000">
    </telerik:radwindowmanager>
    <telerik:radajaxmanagerproxy id="RAM_DepartmentHeadsMapping" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_DepartmentHeadsMapping">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanagerproxy>
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lbl_DepartmentHeadsMappingHeader" runat="server" Font-Bold="True"
                    meta:resourcekey="lbl_DepartmentHeadsMappingHeader"></asp:Label>
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
              <%--  <asp:RequiredFieldValidator ID="RFV_ddl_BusinessUnit" runat="server" ControlToValidate="ddl_BusinessUnit"
                    ErrorMessage="Please Select Business Unit" meta:resourcekey="RFV_ddl_BusinessUnit"
                    Text="*" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red"> </asp:RequiredFieldValidator>--%>
            </td>
        </tr>

          <tr align="center">
            <td align="right">
                <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:radcombobox id="rad_Directorate" runat="server" markfirstmatch="true" autopostback="True" MaxHeight="120px"
                    skin="WebBlue" onselectedindexchanged="rad_Directorate_SelectedIndexChanged" Filter="Contains">
                </telerik:radcombobox>             
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <br />
                <br />
                <telerik:radgrid id="Rg_DepartmentHeadsMapping" runat="server" autogeneratecolumns="False" gridlines="None"
                    allowpaging="True" allowfilteringbycolumn="false" skin="WebBlue" onneeddatasource="Rg_DepartmentHeadsMapping_NeedDataSource" visible="false">
                    <MasterTableView CommandItemDisplay="None" EnableNoRecordsTemplate="true" >
                        <Columns>
                               <telerik:GridTemplateColumn HeaderText="Check All" HeaderStyle-ForeColor="White" >
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                        Text="Check All" ForeColor="White" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             
                             <telerik:GridTemplateColumn HeaderText="Department_ID" Visible="false">
                                  <ItemTemplate>
                                          <asp:Label ID="Department_ID" runat="server" Text='<%# Eval("Department_ID") %>'></asp:Label>
                                  </ItemTemplate>
                             </telerik:GridTemplateColumn>                      
                             
                           <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" UniqueName="DEPARTMENT_NAME"
                                AllowFiltering="false" HeaderText="DEPARTMENT NAME" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn> 
                           
                            <telerik:GridTemplateColumn UniqueName="ColToEmp" HeaderText="DEPARTMENT HEAD" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcmbEmployee" runat="server" Filter="Contains"
                                        AppendDataBoundItems="true" DataTextField="Empname" DataValueField="EMP_ID" DataSource='<%#LoadGridEmployees() %>'>
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                  <%--     <asp:RequiredFieldValidator ID="RFV_Employee" runat="server" ControlToValidate="rcmbEmployee"
                                      meta:resourcekey="RFV_Employee" Text="*" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red"> </asp:RequiredFieldValidator>--%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn> 
                             
                            <telerik:GridTemplateColumn UniqueName="ColToEmp" HeaderText="DEPARTMENT SUB HEAD" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcmbSubHead" runat="server" AppendDataBoundItems="true" Filter="Contains" 
                                        DataTextField="Empname" DataValueField="EMP_ID" DataSource='<%#LoadGridEmployees() %>'>
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                  <%--     <asp:RequiredFieldValidator ID="RFV_Employee" runat="server" ControlToValidate="rcmbEmployee"
                                      meta:resourcekey="RFV_Employee" Text="*" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red"> </asp:RequiredFieldValidator>--%>
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
                </telerik:radgrid>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <br />
                <asp:Button ID="btn_submit" runat="server" meta:resourcekey="btn_submit" ValidationGroup="Controls"  OnClick="btn_submit_Click" Visible="false" />
                <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
