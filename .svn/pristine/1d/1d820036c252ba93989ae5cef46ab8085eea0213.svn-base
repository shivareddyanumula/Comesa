<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_EmpTransfer.aspx.cs" Inherits="frm_EmpTransfer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            height: 47px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbl_Transfer" runat="server" Text="Employee Transfer"
                                Style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table align="center">
                                <tr>
                                    <td align="center">
                                        <telerik:RadMultiPage ID="RM_Transfer" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="RPV_All" runat="server">
                                                <telerik:RadGrid ID="rg_Emptransfer" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    Skin="WebBlue" OnNeedDataSource="rg_Emptransfer_NeedDataSource" AllowFilteringByColumn="true">
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="S.No" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <%#Container.DataSetIndex+1 %>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn HeaderText="Emp_id" DataField="EMP_ID" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Date of Joining" DataField="DOJ" DataFormatString="{0:dd/MM/yyyy}">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Designation" DataField="DESIGNATION">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="From Businessunit" DataField="FROMBUSINESSUNIT">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="To Businessunit" DataField="TOBUSINESSUNIT">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Date of Transfer" DataField="DATEOFTRASFER" DataFormatString="{0:dd/MM/yyyy}">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EMP_GRADE" UniqueName="EMP_GRADE" HeaderText="Employee Grade">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Details" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtn_View" runat="server" ToolTip="View Employee Details" CausesValidation="false"
                                                                        OnCommand="lnkbtn_View_Click" CommandArgument='<%#Eval("TRAFER_ID")%>'>View</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Actions" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtn_Rollback" runat="server" ToolTip="Rollback Transfer" CausesValidation="false"
                                                                        OnCommand="lnkbtn_Roolback_Click" OnClientClick="return confirm('Are You Sure Do You Want Rollback ?')"
                                                                        CommandArgument='<%#Eval("TRAFER_ID")%>'>Rollback</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                        <CommandItemTemplate>
                                                            <div align="right">
                                                                <asp:LinkButton ID="lnkbtn_Add" Visible="true" runat="server" ToolTip="Transfer An Employee"
                                                                    CausesValidation="false" OnCommand="lnkbtn_Add_Click">Add</asp:LinkButton>
                                                            </div>
                                                        </CommandItemTemplate>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="RPV_Add" runat="server" Width="941px">
                                                <table>
                                                    <tr>
                                                        <td style="width: 2%"></td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lbl_Bu" runat="server" Text="Businessunit"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%"></td>
                                                        <td style="width: 25%"></td>
                                                        <td style="width: 25%"></td>
                                                        <td style="width: 25%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%"></td>
                                                        <td style="width: 25%">
                                                            <telerik:RadComboBox ID="rcmb_Bu" runat="server" AutoPostBack="True" CausesValidation="False"
                                                                OnSelectedIndexChanged="rcmb_Bu_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td style="width: 1%"></td>
                                                        <td style="width: 25%"></td>
                                                        <td style="width: 25%"></td>
                                                        <td style="width: 25%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%"></td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lbl_Employee" runat="server" Text="Employee"> </asp:Label>
                                                        </td>
                                                        <td style="width: 1%"></td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lbl_DOJ" runat="server" Text="Date of joining"></asp:Label>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lbl_DOC" runat="server" Text="Date of confirmation"></asp:Label>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lbl_LOS" runat="server" Text="Length of service"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Employees" runat="server" AutoPostBack="True" CausesValidation="False" Filter="Contains"
                                                                MaxHeight="120px" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Employees_SelectedIndexChanged">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="rdtp_DOJ" runat="server">
                                                                <Calendar ID="Calendar1" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                                    ViewSelectorText="x">
                                                                </Calendar>
                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                <DateInput ID="DateInput1" runat="server" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                                                </DateInput>
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="rdtp_DOC" runat="server">
                                                                <Calendar ID="Calendar2" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                                    ViewSelectorText="x">
                                                                </Calendar>
                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                <DateInput ID="DateInput2" runat="server" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                                                </DateInput>
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_LOS" runat="server">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_From" runat="server" Font-Underline="True" Text="From"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_To" runat="server" Font-Underline="True" Text="To"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <%--                                                    <tr>
                                                        <td align="right">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_check" runat="server" Text="Generate New Employee Code"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chk_empcode" runat="server" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_empcode" runat="server" visible="false">
                                                        <td align="right">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_empcode" runat="server" Text="Employee&nbsp;Code"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_old_empcode" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Code" runat="server" meta:resourcekey="lbl_Code" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_empcode" runat="server" Enabled="false">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_empcode" runat="server" ControlToValidate="rtxt_empcode"
                                                                ErrorMessage="Please Enter Employee Code" Text="*" ValidationGroup="TRANSFER">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Businessunit" runat="server" Text="Business Unit"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Businessunitdesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Businessunitid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="True" CausesValidation="False"
                                                                OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_Businessunit"
                                                                ErrorMessage="Please select Business Unit" Text="*" ValidationGroup="TRANSFER">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_DirectorateDesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Directorate_ID" runat="server" Visible="False"></asp:Label>
                                                            <%--<asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>--%>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Directorate" runat="server" AutoPostBack="True" CausesValidation="False"
                                                                MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ControlToValidate="rcmb_Directorate"
                                                                ErrorMessage="Please select Directorate" Text="*" ValidationGroup="TRANSFER">
                                                            </asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Department" runat="server" Text="Department"> </asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Departmentdesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Departmentid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Department" runat="server" AutoPostBack="false" CausesValidation="False"
                                                                MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="rcmb_Department"
                                                                ErrorMessage="Please select Department" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Shift" runat="server" Text="Shift"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Shiftdesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Shiftid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Shifts" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rcmb_Shifts"
                                                                ErrorMessage="Please select Shift" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Salarystructure" runat="server" Text="Salary Structure"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Salstructuredesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Salarystructid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Salstruct" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rcmb_Salstruct"
                                                                ErrorMessage="Please select Salary Structure" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Leavestructure" runat="server" Text="Leave Structure"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Leavestructuredesc" runat="server">
                                                            </asp:Label>
                                                            <asp:Label ID="lbl_Leavestructid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Leavestruct" runat="server" AutoPostBack="True" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="rcmb_Leavestruct"
                                                                ErrorMessage="Please select Leave Structure" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                            <telerik:RadGrid ID="RG_Leaves" runat="server" AutoGenerateColumns="true">
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="right"></td>
                                                        <td align="right"></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkbtn_Check" runat="server" CausesValidation="False" OnClick="lnkbtn_Check_Click"
                                                                ToolTip="To Check The Remained Balances in The Previous Business unit">Check Balance</asp:LinkButton>
                                                        </td>
                                                        <td align="left">
                                                            <asp:LinkButton ID="lnkbtn_Cancel" runat="server" CausesValidation="False" OnClick=" lnkbtn_Cancel_Click"
                                                                ToolTip="Will Clear The Remained Leaves" Visible="False">Cancel</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="right"></td>
                                                        <td align="right"></td>
                                                        <td>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rbtnlst_Coform" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtnlst_Coform_SelectedIndexChanged"
                                                                RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="1">Update</asp:ListItem>
                                                                <asp:ListItem Value="0">Cancel</asp:ListItem>
                                                            </asp:RadioButtonList>

                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rbtnlst_Coform"
                                                                ErrorMessage="Select update or cancel for updating previous leaves" ValidationGroup="TRANSFER">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="lbl_Conform" runat="server" Font-Bold="True" Text="Note: Update will add previous leaves to selected  businessunit Cancel will flush previous leaves"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Currency" runat="server" Text="Currency"> </asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Currencydesc" runat="server">
                                                            </asp:Label>
                                                            <asp:Label ID="lbl_Currencyid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_Currency" runat="server" Visible="False">
                                                            </telerik:RadTextBox>
                                                            <telerik:RadComboBox ID="rcmb_Currencytype" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="rcmb_Currencytype"
                                                                ErrorMessage="Please select Currency" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lblJob" runat="server" Text="Job" meta:resourcekey="lblJob"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblJobFrom" runat="server"></asp:Label>
                                                            <asp:Label ID="lblJobID" runat="server" meta:resourcekey="lblJobID" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Job" runat="server" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Job_SelectedIndexChanged"
                                                                MarkFirstMatch="true" meta:resourcekey="rcmb_Job" EnableVirtualScrolling="true" MaxHeight="150px" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="rfv_rcmb_Job" runat="server" ControlToValidate="rcmb_Job"
                                                                ErrorMessage="Please select Job" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>



                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Position" runat="server" Text="Position"> </asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Positiondesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Positionid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Position" runat="server" AutoPostBack="True" MaxHeight="200px" MarkFirstMatch="true"
                                                                OnSelectedIndexChanged="rcmb_Position_SelectedIndexChanged" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rcmb_Position"
                                                                ErrorMessage="Please select Position" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right"></td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_period" runat="server" Text="Financial Period"> </asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_FinancialPeriod" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_financialperiod_id" runat="server" meta:resourcekey="lbl_financialperiod_id_from" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_period" runat="server" AutoPostBack="True" MaxHeight="200px" MarkFirstMatch="true"
                                                                OnSelectedIndexChanged="rcmb_period_SelectedIndexChanged" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="rfv_rcmb_period" runat="server" ControlToValidate="rcmb_period"
                                                                ErrorMessage="Please select Financial Period" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                </tr>

                                <tr>
                                    <td align="right"></td>

                                    <td class="style8">
                                        <asp:Label ID="lbl_Grade" runat="server" Text="Grade"></asp:Label>
                                    </td>
                                    <td class="style6">:
                                    </td>
                                    <td class="style7">
                                        <asp:Label ID="lbl_Grade_from" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_Grade_ID" runat="server" meta:resourcekey="lbl_Grade_from" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style5">
                                        <telerik:RadComboBox ID="rcmb_Grade" runat="server" Skin="WebBlue" Filter="Contains"
                                            MarkFirstMatch="true" meta:resourcekey="rcmb_Grade" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Grade_SelectedIndexChanged">
                                        </telerik:RadComboBox>

                                    </td>
                                    <td class="style5">
                                        <asp:RequiredFieldValidator ID="rfv_Grade" runat="server" ControlToValidate="rcmb_Grade"
                                            ErrorMessage="Please Select Grade" ValidationGroup="TRANSFER">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"></td>
                                    <td>
                                        <asp:Label ID="lbl_Slab" runat="server" Text="Salary Slab" meta:resourcekey="lbl_Slab"></asp:Label>
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_Slab_From" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_Slab_ID" runat="server" meta:resourcekey="lbl_Scale_ID" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_Slabs" runat="server" Skin="WebBlue" Filter="Contains"
                                            MarkFirstMatch="true" meta:resourcekey="rcmb_Slabs" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Slabs_SelectedIndexChanged">
                                        </telerik:RadComboBox>

                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_Slabs" runat="server" ControlToValidate="rcmb_Slabs"
                                            ErrorMessage="Please Select Salary Slab" ValidationGroup="TRANSFER">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <%-- <tr>--%>

                                <%-- <td align="right">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Gross" runat="server" Text="Gross"></asp:Label>
                                                            <asp:Label ID="lbl_AnnualGross" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Grossdesc" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rntxt_Gross" runat="server" Enabled="false" >
                                                            </telerik:RadNumericTextBox>
                                                        </td>--%>
                                <%-- <td align="left">
                                                            <asp:RequiredFieldValidator ID="rfv_Gross" runat="server" ControlToValidate="rntxt_Gross"
                                                                ErrorMessage="Please Select Salary Slab" ValidationGroup="TRANSFER">*</asp:RequiredFieldValidator>
                                                        </td>--%>
                                <%-- </tr>--%>
                                <tr>
                                    <td align="right"></td>
                                    <td align="left">
                                        <asp:Label ID="lbl_Basic" runat="server" Text="Basic"></asp:Label>
                                        <asp:Label ID="lbl_AnnualBasic" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_Basicdesc" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rtxt_Basic" runat="server" ReadOnly="True" Enabled="False">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr id="Category" runat="server" visible="false">
                                    <td align="right"></td>
                                    <td align="left">
                                        <asp:Label ID="lbl_category" runat="server" Text="Employee&nbsp;Category"></asp:Label>
                                        <asp:Label ID="lbl_category_id" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_category_from" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmbCategory" runat="server" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmbCategory" runat="server" ControlToValidate="rcmbCategory" InitialValue="Select"
                                            ErrorMessage="Please select Employee Category" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <%-- <tr>
                                                        <td align="right">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lbl_Position" runat="server" Text="Position"> </asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Positiondesc" runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_Positionid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_Position" runat="server" AutoPostBack="True" MarkFirstMatch="true">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rcmb_Position"
                                                                ErrorMessage="please select position" Text="*" ValidationGroup="TRANSFER"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                <tr>
                                    <td align="right"></td>
                                    <td align="left" rowspan="2">
                                        <asp:Label ID="lbl_Reportingemp" runat="server" Text="Reporting Employee"></asp:Label>
                                    </td>
                                    <td align="right" rowspan="2">&#160;<b>:</b>
                                    </td>
                                    <td rowspan="2">
                                        <asp:Label ID="lbl_Reportingempdesc" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_Reportingempid" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_BusinessunitReportingemp" runat="server" AutoPostBack="true" Filter="Contains"
                                            MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BusinessunitReportingemp_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="right">&#160;
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_Reportingemp" runat="server" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"></td>
                                    <td align="left">
                                        <asp:Label ID="lbl_ReportingEndDate" runat="server" Text="Reporting EndDate"></asp:Label>
                                    </td>
                                    <td align="right"><b>:</b></td>
                                    <td>
                                        <telerik:RadDatePicker ID="rdtp_Reportingdate" runat="server">
                                            <Calendar ID="Calendar3" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rdtp_Reportingdate"
                                                                ErrorMessage="Reporting date is mandatory" ValidationGroup="TRANSFER">*</asp:RequiredFieldValidator>--%>
                                                           
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="rdtp_Executiondate"
                                            ControlToValidate="rdtp_Reportingdate" ErrorMessage="Execution Date Should Be Less Than The Reporting Date"
                                            Operator="GreaterThanEqual" ValidationGroup="TRANSFER">*</asp:CompareValidator>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="right"></td>
                                    <td align="left">
                                        <asp:Label ID="lbl_Executiondate" runat="server" Text="Execution Date"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="rdtp_Executiondate" runat="server" AutoPostBack="true" OnSelectedDateChanged="rdtp_Executiondate_SelectedDateChanged">
                                            <Calendar ID="Calendar4" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                            </DateInput>
                                        </telerik:RadDatePicker>

                                    </td>
                                    <td align="left">&#160;
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rdtp_Executiondate"
                                                                 ErrorMessage="Execution date is mandatory" ValidationGroup="TRANSFER">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td>&#160;
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right"></td>
                                    <td align="right"></td>
                                    <td align="right"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td align="right">
                                        <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Style="font-weight: 700"
                                            Text="Transfer" ToolTip="Selected Employee Will Be Transferred To New Businessunit"
                                            UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'TRANSFER')" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btn_Cancel" runat="server" CausesValidation="False" OnClick="btn_Cancel_Click"
                                            Style="font-weight: 700" Text="Cancel" ToolTip="Will Redirect To All Transferred Employee Information" />
                                        <asp:Label ID="lbl_Grossdesc" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <asp:ValidationSummary ID="vs_TRANSFER" runat="server" ShowMessageBox="True" ShowSummary="False"
                                    ValidationGroup="TRANSFER" />
                            </table>
                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
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
</asp:Content>