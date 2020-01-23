<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Employee_Tds.aspx.cs" Inherits="HR_Employee_Tds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">


.RadGrid_Default
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Default
{
    border:1px solid #828282;
    background:#fff;
    color:#333;
}

.RadGrid_Default .rgMasterTable
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid .rgMasterTable
{
    border-collapse:separate;
}

.RadGrid_Default .rgCommandRow
{
	background:#c5c5c5 0 -2099px repeat-x url('mvwres://Telerik.Web.UI, Version=2010.2.713.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
	color:#000;
}

.RadGrid_Default .rgCommandCell
{
	border:1px solid;
	border-color:#999 #f2f2f2;
	border-top-width:0;
	padding:0;
}

.RadGrid_Default .rgHeader
{
    color:#333;
}

.RadGrid_Default .rgHeader
{
	border:0;
	border-bottom:1px solid #828282;
	background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2010.2.713.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
}

.RadGrid .rgHeader
{
	padding-top:5px;
	padding-bottom:4px;
	text-align:left;
	font-weight:normal;
}

.RadGrid .rgHeader
{
	padding-left:7px;
	padding-right:7px;
}

.RadGrid .rgHeader
{
	cursor:default;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Past Gross & TDS Info">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="rmp_Main" runat="server" SelectedIndex="0" Width="990px"
                    Height="490px">
                    <telerik:RadPageView ID="rpv_Main" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td align="center">
                    <telerik:RadGrid ID="rg_Tds" runat="server" AllowPaging="true" 
                        AutoGenerateColumns="false" GridLines="None" 
                        onneeddatasource="rg_Tds_NeedDataSource" AllowFilteringByColumn="true" >
                                        <mastertableview commanditemdisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" 
                                                    HeaderText="Business&nbsp;Unit" ItemStyle-HorizontalAlign="Left" 
                                                    UniqueName="EMP_TDS_BUID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" 
                                                    ItemStyle-HorizontalAlign="Left" UniqueName="EMP_TDS_EMPID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Period" 
                                                    ItemStyle-HorizontalAlign="Left" UniqueName="EMP_TDS_PERIOD">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_TDS_PREV_GROSS_AMOUNT" 
                                                    HeaderText="Gross Amount" ItemStyle-HorizontalAlign="Left" 
                                                    UniqueName="EMP_GROSS_AMOUNT">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_TDS_PREV_TDS_AMOUNT" 
                                                    HeaderText="TDS Amount" ItemStyle-HorizontalAlign="Left" 
                                                    UniqueName="EMP_TDS_AMOUNT">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Tds_Edit" runat="server" 
                                                            CommandArgument='<%# Eval("EMP_TDS_ID") %>' OnCommand="lnk_Edit_Command" 
                                                            Text="Edit">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                    
                                            <commanditemtemplate>
                                                <div align="right" id="tds_add" runat="server">
                                                    <asp:LinkButton ID="lnk_Tds_Add" runat="server" OnCommand="lnk_Add_Command" 
                                                        Text="Add">
                                                    </asp:LinkButton>
                                                </div>
                                            </commanditemtemplate>
                                        </mastertableview>
                                    </telerik:RadGrid>
                    
                                    </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpv_Details" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_Tds" runat="server" Text="TDS">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Tds_Buid" runat="server" Text="BusinessUnit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Tds_Buid" runat="server" AutoPostBack="true" MarkFirstMatch="true" 
                                        OnSelectedIndexChanged="rcmb_Tds_Buid_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Tds_Buid" runat="server" 
                                        ControlToValidate="rcmb_Tds_Buid" ErrorMessage="Select BusinessUnit" 
                                        InitialValue="Select" Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Tds_EmpId" runat="server" Text="Employee">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Tds_EmpId" runat="server" AutoPostBack="true" MarkFirstMatch="true" 
                                        MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Tds_EmpId" runat="server" 
                                        ControlToValidate="rcmb_Tds_EmpId" ErrorMessage="Select Employee" 
                                        InitialValue="Select" Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Financial Period">
                            </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Period" runat="server" AutoPostBack="true" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Tds_Period" runat="server" 
                                        ControlToValidate="rcmb_Period" ErrorMessage="Select Period" 
                                        InitialValue="Select" Text="*" ValidationGroup="Controls">
                             </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Prev_Gross_Amount" runat="server" 
                                        Text="Previous Gross Amount"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_Prev_Gross_Amount" runat="server" 
                                        MaxLength="12" MinValue="0.0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rntxt_Prev_Gross_Amount" runat="server" 
                                        ControlToValidate="rntxt_Prev_Gross_Amount" 
                                        ErrorMessage="Enter Previous Gross Amount" Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_prev_tds_amount" runat="server" Text="Previous TDS Amount">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_prev_tds_amount" runat="server" 
                                        MaxLength="12" MinValue="0.0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rntxt_prev_tds_amount" runat="server" 
                                        ControlToValidate="rntxt_prev_tds_amount" 
                                        ErrorMessage="Enter Previous TDS Amount" Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Save" runat="server" onclick="btn_Save_Click" Text="Save" 
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" OnClick="btn_Save_Click" 
                                        Text="Update" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" onclick="btn_Cancel_Click" 
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EmployeeTds" runat="server" ShowMessageBox="true" ShowSummary="false"
     ValidationGroup="Controls" />
</asp:Content>
