<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Clearance.aspx.cs" Inherits="HR_frm_Clearance" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="cphClearanceCertificate" ContentPlaceHolderID="cphDefault" runat="Server">
    
        <table align="center">
            <tr>

                <td align="center" colspan="3" class="auto-style1">
                    <asp:Label ID="lbl_ClearanceCertificateHeader" runat="server" Font-Bold="True" Text="Clearance Certificate"></asp:Label>
                    <br />
                    <br />
                </td>
                <td class="auto-style1"></td>
            </tr>
        </table>
        <table align="center">
             <tr align="left">
                <td align="left">
                    <asp:Label ID="lblBU" runat="server" Text="Business Unit"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="radBU" AutoPostBack="true" OnSelectedIndexChanged="radBU_SelectedIndexChanged" runat="server" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radBU" InitialValue="Select"
                        ErrorMessage="Please Select Business Unit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="left">
                <td align="left">
                    <asp:Label ID="lbl_SelectEmployee" runat="server" meta:resourcekey="lbl_SelectEmployee"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="rad_Employees" AutoPostBack="true" OnSelectedIndexChanged="rad_Employees_SelectedIndexChanged" runat="server" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_EmployeeName" runat="server" ControlToValidate="rad_Employees" InitialValue="Select"
                        ErrorMessage="Please Select Employee" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_DepartmentName" Text="Department" Font-Bold="true" Font-Size="X-Large" runat="server"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="Rad_Department" AutoPostBack="true" OnSelectedIndexChanged="Rad_Department_SelectedIndexChanged" runat="server" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
    <br />

        <%--<table>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
        </table>--%>
        <table align="center" id="tr_EmpDetails" runat="server">
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_EmployeeName" runat="server" meta:resourcekey="lbl_EmployeeName"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txt_EmployeeName" runat="server" EmptyMessage="Auto Generated Code"
                        Skin="WebBlue" ReadOnly="True" TabIndex="0">
                    </telerik:RadTextBox>
                </td>


                <td align="left">
                    <asp:Label ID="lbl_EmployeeCode" runat="server" meta:resourcekey="lbl_EmployeeCode"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txt_EmployeeCode" runat="server" EmptyMessage="Auto Generated Code"
                        Skin="WebBlue" ReadOnly="True" TabIndex="0">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_Department" runat="server" meta:resourcekey="lbl_Department"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txt_Department" runat="server" EmptyMessage="Auto Generated Code"
                        Skin="WebBlue" ReadOnly="True" TabIndex="0">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_DateOfRetirement" runat="server" meta:resourcekey="lbl_DateOfRetirement"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <%--    <asp:TextBox ID="txt_DateOfRetirement" runat="server">
                </asp:TextBox>--%>
                    <telerik:RadDatePicker ID="rdp_DateOfRetirement" runat="server" TabIndex="1">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                        <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy"
                            TabIndex="8">
                        </DateInput>
                    </telerik:RadDatePicker>

                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_Address" runat="server" meta:resourcekey="lbl_Address"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="txt_Address" runat="server" EmptyMessage="Address"
                        Skin="WebBlue" TabIndex="0">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_Telephone" runat="server" meta:resourcekey="lbl_Telephone"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadMaskedTextBox ID="txt_Telephone" DisplayMask="##########" Mask="##########" runat="server" Skin="WebBlue" TabIndex="0">
                    </telerik:RadMaskedTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <hr style="color: black" />
                    <asp:Label ID="lbl_Department_Name" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table id="table_AssetDetails" align="center" runat="server">


            <tr>
                <td align="center" colspan="8">
                    <telerik:RadGrid ID="Rg_DepartmentswithAssets" runat="server" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="True" AllowFilteringByColumn="false" Skin="WebBlue" OnItemDataBound="Rg_DepartmentswithAssets_OnItemDataBound">
                        <MasterTableView CommandItemDisplay="None" EnableNoRecordsTemplate="true">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Sl.No" UniqueName="SlNo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChoose" runat="server" />
                                        <asp:Label ID="lbl_Asset_Id" runat="server" Text='<%# Eval("ASSET_ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblSn" Text="<%# (Container.ItemIndex+1).ToString() %>" runat="server" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="ASSET_NAME" UniqueName="ASSET_NAME"
                                    AllowFiltering="false" HeaderText="ASSET NAME" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="ReceivedPayable" HeaderText="Received/Amount Payable" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>


                                        <table width="100%" border="0">
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <telerik:RadComboBox ID="radReceivedPayable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radReceivedPayable_SelectedIndexChanged">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Received" Value="Received" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Amount Payable" Value="Amount Payable" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Amount" runat="server" Text="Amount" Visible="false">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rad_Amount" runat="server" Skin="WebBlue" Width="125px" Visible="false"
                                                        NumberFormat-DecimalDigits="0" MinValue="0" MaxLength="7">
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="rfv_Amount" runat="server" ControlToValidate="rad_Amount"
                                                        ErrorMessage="Please Specify Amount" Text="*" ValidationGroup="Controls">*</asp:RequiredFieldValidator>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Reason" runat="server" TextMode="MultiLine" Text="Reason/Remarks" Visible="false">
                                                    </asp:Label>
                                                </td>
                                                <td>

                                                    <telerik:RadTextBox ID="rad_Reason" MaxLength="400" TextMode="MultiLine" runat="server" Width="125px" Visible="false">
                                                    </telerik:RadTextBox>

                                                    <asp:RequiredFieldValidator ID="rfv_Reason" runat="server" ControlToValidate="rad_Reason"
                                                        ErrorMessage="Please Specify Remarks/Comments" Text="*" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--<telerik:GridTemplateColumn UniqueName="NameSignature"  HeaderText="Name And Signature" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <telerik:RadTextBox ID="radNameSignature" runat="server">                                        
                                    </telerik:RadTextBox>                                 
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>  --%>
                                <telerik:GridTemplateColumn UniqueName="Date" HeaderText="Date" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <telerik:RadDatePicker ID="rad_ReceivedDate" runat="server" TabIndex="1">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy"
                                                TabIndex="8">
                                            </DateInput>
                                        </telerik:RadDatePicker>

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

            <tr align="left">
                <td align="left">
                    <asp:Label ID="lbl_HeadOfDeptRemarks" runat="server" Text="Head of Department remarks:"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="rad_DeptHeadRemarks" TextMode="MultiLine" runat="server" EmptyMessage="DEPARTMENT HEAD REMARKS"
                        Skin="WebBlue" TabIndex="0">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <table align="center">
            <tr>
                <td>
                    <asp:Button ID="btn_Submit" runat="server" ValidationGroup="Controls" OnClick="btn_Submit_Click" Text="Submit" />
                </td>
                <td>
                    <asp:Button ID="btn_Cancel" OnClick="btn_Cancel_Click" runat="server" Text="Cancel" />
                </td>

            </tr>
            <tr><td> <asp:ValidationSummary ID="vs_Jobs" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Controls" /></td></tr>

        </table>
</asp:Content>
