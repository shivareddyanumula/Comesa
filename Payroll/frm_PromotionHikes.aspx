<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PromotionHikes.aspx.cs" Inherits="Payroll_frm_PromotionHikes" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--<telerik:RadAjaxManagerProxy ID="RAM_EMPPH" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rg_Promotion">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Submit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>--%>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Emppro" runat="server" Font-Bold="True" meta:resourcekey="lbl_Emppro"
                    Text="Salary Progressions"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_PROMOTIONS" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_GRID" runat="server">
                        <telerik:RadGrid ID="rg_Promotion" runat="server" AutoGenerateColumns="False"
                            Skin="WebBlue" AllowPaging="true" AllowFilteringByColumn="True" AllowSorting="True"
                            OnNeedDataSource="rg_Promotion_NeedDataSource">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="EMPPRO_ID" HeaderText="ID" meta:resourcekey="EMPPRO_ID"
                                        UniqueName="EMPPRO_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EMP_EMPCODE" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Code" meta:resourcekey="EMP_EMPCODE" UniqueName="EMP_EMPCODE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EmpName" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Name" meta:resourcekey="EmpName" UniqueName="EmpName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DATEOFJOIN" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Date of Join" meta:resourcekey="DATEOFJOIN" UniqueName="DATEOFJOIN">
                                    </telerik:GridBoundColumn>
                                    <%-- <telerik:GridBoundColumn DataField="DATEOFCONFIRMATION" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Date of Confirmation" meta:resourcekey="DATEOFCONFIRMATION" UniqueName="DATEOFCONFIRMATION">31.5.2016
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="EMPPRO_DESIGNATION_ID" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="From Position" meta:resourcekey="EMPPRO_DESIGNATION_ID" UniqueName="EMPPRO_DESIGNATION_ID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EMPPRO_DESIGNATION_IDN" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="To Position" meta:resourcekey="EMPPRO_DESIGNATION_IDN" UniqueName="EMPPRO_DESIGNATION_IDN">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DATEOFPROMOTION" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Date of Promotion" meta:resourcekey="DATEOFPROMOTION" UniqueName="DATEOFPROMOTION">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EMP_GRADE" UniqueName="EMP_GRADE" HeaderText="Scale">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="View" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Convert.ToInt32(Eval("EMPPRO_ID")) %>'
                                                meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                            </MasterTableView>
                            <PagerStyle AlwaysVisible="true" />
                            <GroupingSettings CaseSensitive="false" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_Details" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <%--<div style="height: 490px; width: 1014px; overflow: auto;">--%>
                                    <%-- <div style="height: 520px; width: 1014px; ">--%>
                                    <table align="center" class="style1">


                                        <tr>
                                            <td colspan="5" align="center">
                                                <hr />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Businessunit" runat="server" Text="Business unit"></asp:Label>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="true" Filter="Contains"
                                                    MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style6">
                                                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="rcmb_Businessunit" InitialValue="Select"
                                                    ErrorMessage="Please Select a BusinessUnit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee" meta:resourcekey="lbl_Employee"></asp:Label>
                                            </td>
                                            <td class="style6">
                                                <asp:RequiredFieldValidator ID="rfv_rdtp_Employee" runat="server" ControlToValidate="rcmb_Employee" InitialValue="Select"
                                                    ErrorMessage="Please Select a Employee" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_DOJ" runat="server" Text="Date of Joining" meta:resourcekey="lbl_DOJ"></asp:Label>
                                            </td>
                                            <%--<td class="style5"> 31.5.2016
                                                <asp:Label ID="lbl_DOC" runat="server" Text="Date of Confirmation" meta:resourcekey="lbl_DOC"></asp:Label>
                                            </td>--%>
                                            <td class="style5">
                                                <asp:Label ID="lbl_lengthofservice" runat="server" Text="Length of Service"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <telerik:RadComboBox ID="rcmb_Employee" runat="server" Filter="Contains"
                                                    MarkFirstMatch="true" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged"
                                                    MaxHeight="120px" Skin="WebBlue" meta:resourcekey="rcmb_Employee">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style7">
                                                <telerik:RadDatePicker ID="rdtp_DOJ" runat="server" Enabled="False"
                                                    Skin="WebBlue" meta:resourcekey="rdtp_DOJ">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <%--<td class="style5">31.5.2016
                                                <telerik:RadDatePicker ID="rdtp_DOC" runat="server" Enabled="False"
                                                    Skin="WebBlue" meta:resourcekey="rdtp_DOC">
                                                </telerik:RadDatePicker>
                                            </td>--%>
                                            <td class="style5">
                                                <telerik:RadTextBox ID="rtxt_lS" runat="server" Enabled="False"
                                                    Skin="WebBlue">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8"></td>
                                            <td class="style6"></td>
                                            <td align="center" class="style7">
                                                <asp:Label ID="lbl_From" runat="server" Text="From" meta:resourcekey="lbl_From" Style="text-decoration: underline"></asp:Label>
                                            </td>
                                            <td align="center" class="style5">
                                                <asp:Label ID="lbl_To" runat="server" Text="To" meta:resourcekey="lbl_To" Style="text-decoration: underline"></asp:Label>
                                            </td>
                                            <td align="center" class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_emptype" runat="server" Text="Employee&nbsp;Type" meta:resourcekey="lbl_emptype"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_emptype_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_emptype_ID" runat="server" meta:resourcekey="lbl_emptype_from" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_emptype" runat="server" Skin="WebBlue"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_emptype" Filter="Contains">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Regular General Service - Established" Value="Regular General Service - Established" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Project Professional - Non Established" Value="Project Professional - Non Established" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Project General Service -" Value="Project General Service -" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Consultancy" Value="Consultancy" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Short-Term" Value="Short-Term" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Internship" Value="Internship" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Extension on Retirement" Value="Extension on Retirement" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Executive" Value="Executive" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Regular Professional - Established" Value="Regular Professional - Established" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <%--                                        <tr id="tr_empcode" runat="server">
                                            <td class="style8">
                                                <asp:Label ID="lbl_empcode" runat="server" Text="Employee&nbsp;Code" meta:resourcekey="lbl_empcode"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_empcode_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_Code" runat="server" meta:resourcekey="lbl_Code" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadTextBox ID="rtxt_empcode" runat="server" Skin="WebBlue"
                                                    MarkFirstMatch="true" meta:resourcekey="rtxt_empcode">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td class="style5">
                                                <asp:RequiredFieldValidator ID="rtxt_empcode_Validate" runat="server" ControlToValidate="rtxt_empcode"
                                                    Display="Dynamic" meta:resourcekey="rtxt_empcode_Validate" Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter Employee Code" />

                                            </td>

                                        </tr>--%>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_FinancialPeriod" runat="server" Text="Financial Period"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lblFinPeriodFrom" runat="server"></asp:Label>
                                                <asp:Label ID="lblFinPeriod" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_FinancialPeriod" runat="server" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_FinancialPeriod_SelectedIndexChanged"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_FinancialPeriod" EnableVirtualScrolling="true" Height="80px" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <%--<tr>
                                             <td class="style8">
                                                <asp:Label ID="lbl_PeriodDtls" runat="server" Text="Period Details" ></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lblPerioddtlFrom" runat="server"></asp:Label>
                                                <asp:Label ID="lblPerioddtl" runat="server"  Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_Perioddtls" runat="server" Skin="WebBlue" AutoPostBack="True" 
                                                    MarkFirstMatch="true"  EnableVirtualScrolling="true" Height="150px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblJob" runat="server" Text="Job" meta:resourcekey="lblJob"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lblJobFrom" runat="server"></asp:Label>
                                                <asp:Label ID="lblJobID" runat="server" meta:resourcekey="lblJobID" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_Job" runat="server" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Job_SelectedIndexChanged"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_Job" EnableVirtualScrolling="true" Height="150px" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>

                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_Desg" runat="server" Text="Designation" meta:resourcekey="lbl_Desg"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_Desg_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_Desg_ID" runat="server" meta:resourcekey="lbl_Desg_from" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_Desg" runat="server" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Desg_SelectedIndexChanged"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_Desg" EnableVirtualScrolling="true" Height="60px" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
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
                                                <telerik:RadComboBox ID="rcmb_Grade" runat="server" Skin="WebBlue" OnSelectedIndexChanged="rcmb_Grade_SelectedIndexChanged" Filter="Contains"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_Grade" AutoPostBack="true" EnableVirtualScrolling="true" MaxHeight="150px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_Slab" runat="server" Text="Salary Slab" meta:resourcekey="lbl_Slab"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_Scale_From" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_Slab_ID" runat="server" meta:resourcekey="lbl_Scale_ID" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_Slabs" runat="server" Skin="WebBlue" Filter="Contains"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_Slabs" OnSelectedIndexChanged="rcmb_Slabs_SelectedIndexChanged"
                                                    AutoPostBack="true" EnableVirtualScrolling="true" MaxHeight="150px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_Shift" runat="server" Text="Shift" meta:resourcekey="lbl_Shift"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_Shifts_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_Shift_ID" runat="server" meta:resourcekey="lbl_Grade_from" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_Shift" runat="server" Skin="WebBlue" Filter="Contains"
                                                    MarkFirstMatch="true" meta:resourcekey="rcmb_Shift" EnableVirtualScrolling="true" Height="80px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_SalStruct" runat="server" Text="Salary Structure" meta:resourcekey="lbl_SalStruct"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_SalStruct_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_SS_ID" runat="server" meta:resourcekey="lbl_Grade_from" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_SalStruct" runat="server" Filter="Contains"
                                                    MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="rcmb_SalStruct" EnableVirtualScrolling="true" Height="80px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_LeaveStruct" runat="server" Text="Leave Structure" meta:resourcekey="lbl_LeaveStruct"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_LeaveStruct_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_LS_ID" runat="server" meta:resourcekey="lbl_Grade_from" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_LeaveStruct" runat="server" Filter="Contains"
                                                    MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="rcmb_LeaveStruct" EnableVirtualScrolling="true" Height="80px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <%--<td class="style8">
                                                <asp:Label ID="lbl_GrossSalary" runat="server" Text="Gross Salary" meta:resourcekey="lbl_GrossSalary"></asp:Label>
                                                <asp:Label ID="lbl_AnnualGross" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_GrossSalary_from" runat="server"></asp:Label>

                                            </td>
                                            <td class="style5">
                                                <telerik:RadNumericTextBox ID="rtxt_GrossSalary" runat="server"
                                                    Skin="WebBlue" meta:resourcekey="rtxt_GrossSalary" Enabled="false" Width="125px">
                                                </telerik:RadNumericTextBox>
                                            </td>--%>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_GSCurrency" runat="server" Filter="Contains"
                                                    MarkFirstMatch="true" Visible="False" Skin="WebBlue" meta:resourcekey="rcmb_GSCurrency">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_Basic" runat="server" Text="Basic" meta:resourcekey="lbl_Basic"></asp:Label>
                                                <asp:Label ID="lbl_AnnualBasic" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_Basic_from" runat="server"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadNumericTextBox ID="rtxt_Basic" runat="server"
                                                    Skin="WebBlue" Enabled="false" meta:resourcekey="rtxt_Basic" Width="125px">
                                                </telerik:RadNumericTextBox>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadNumericTextBox ID="rtxt_BasicCurrency" Enabled="False"
                                                    runat="server" Visible="False" Skin="WebBlue" meta:resourcekey="rtxt_BasicCurrency"
                                                    Width="125px">
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_ReportingEmployee" runat="server" Text="Reporting Employee" meta:resourcekey="lbl_ReportingEmployee"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lbl_ReportingEmployee_from" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_PR" runat="server" meta:resourcekey="lbl_Grade_from" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                <telerik:RadComboBox ID="rcmb_RepEmployee" runat="server" MaxHeight="120px" Filter="Contains"
                                                    MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="rcmb_RepEmployee" EnableVirtualScrolling="true" Height="150px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td class="style5">
                                                <%--<telerik:RadDatePicker  ID="rdtp_RMEndDate" runat="server"
                                                        Skin="WebBlue" ToolTip="New Reporting Employee Active Date" meta:resourcekey="rdtp_RMEndDate">
                                                    </telerik:RadDatePicker>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>31.5.2016
                                            <td class="style8">
                                                <asp:Label ID="lbl_rependdate" runat="server" Text="Reporting EndDate" meta:resourcekey="lbl_rependdate"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <telerik:RadDatePicker ID="rdtp_RMEndDate" runat="server"
                                                    Skin="WebBlue" ToolTip="New Reporting Employee Active Date" meta:resourcekey="rdtp_RMEndDate">
                                                </telerik:RadDatePicker>
                                            </td>

                                            <td class="style5"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_DateofExecution" runat="server" Text="Execution Date" meta:resourcekey="lbl_DateofExecution"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <telerik:RadDatePicker ID="rdtp_DateofExecution" runat="server" MinDate='<%# System.DateTime.Now %>' OnSelectedDateChanged="rdtp_DateofExecution_SelectedDateChanged"
                                                    Skin="WebBlue" meta:resourcekey="rdtp_DateofExecutionResource1" AutoPostBack="true">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td class="style5">
                                                <asp:RequiredFieldValidator ID="rfv_rdtp_DateofExecution" runat="server" ControlToValidate="rdtp_DateofExecution"
                                                    ErrorMessage="Please Enter Date of Execution" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="ctl_rdtp_DateofExecution" runat="server" ControlToCompare="rdtp_DOJ"
                                                    ControlToValidate="rdtp_DateofExecution" ErrorMessage="Promotion Date cannot be ahead of Joining Date"
                                                    Operator="GreaterThanEqual" Text="*" ValidationGroup="Controls" Type="Date"></asp:CompareValidator>
                                            </td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_IncrementDate" runat="server" Text="Next Increment Date"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <telerik:RadDatePicker ID="rdp_IncrementDate" runat="server"
                                                    Skin="WebBlue" AutoPostBack="true">
                                                    <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy" ReadOnly="true" autocomplete="off">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_Contract_Start" runat="server" Text="Contract Start Date"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <telerik:RadDatePicker ID="rdp_ContractStart" runat="server" OnSelectedDateChanged="rdp_ContractStart_SelectedDateChanged"
                                                    Skin="WebBlue" AutoPostBack="true">
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lbl_Contract_End" runat="server" Text="Contract End Date"></asp:Label>
                                            </td>
                                            <td class="style6">:
                                            </td>
                                            <td class="style7">
                                                <telerik:RadDatePicker ID="rdp_ContractEnd" runat="server" OnSelectedDateChanged="rdp_ContractEnd_SelectedDateChanged"
                                                    Skin="WebBlue" AutoPostBack="true">
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <%--   <tr> 31.5.2016
                                            <td>
                                                <asp:Label ID="lbl_IncrementType" runat="server" Text="Salary Progression By"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>--%>
                                        <%--<asp:Label ID="lbl_IncrementTypeFrom" runat="server"></asp:Label>--%>
                                        <%-- <telerik:RadComboBox ID="rcmb_IncrementTypeFrom" runat="server" Enabled="false"> 31.5.2016
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_IncrementType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_IncrementType_SelectedIndexChanged" MarkFirstMatch="true">--%>
                                        <%--<Items>
                                                        <telerik:RadComboBoxItem Text="Revision" Value="0" />
                                                        <telerik:RadComboBoxItem Text="Promotion" Value="1" />
                                                    </Items>--%>
                                        <%-- </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_IncrementType" runat="server" InitialValue="Select" ControlToValidate="rcmb_IncrementType"
                                                    ErrorMessage="Please Select Salary Progression By" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                            </td>
                                       31.5.2016 </tr>--%>
                                        <%--   <tr> 31.5.2016 divya
                                            <td>
                                                <asp:Label ID="lbl_IncrementMonth" runat="server" Text="Increment Month"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_IncrementMonthFrom" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_IncrementMonth" runat="server" MarkFirstMatch="true">--%>
                                        <%-- <Items>
                                                        <telerik:RadComboBoxItem Text="Select" Value="0" />
                                                        <telerik:RadComboBoxItem Text="January" Value="1" />
                                                        <telerik:RadComboBoxItem Text="April" Value="2" />
                                                        <telerik:RadComboBoxItem Text="July" Value="3" />
                                                        <telerik:RadComboBoxItem Text="October" Value="4" />
                                                    </Items>--%>
                                        <%-- </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_IncrementMonth" runat="server" InitialValue="Select" ControlToValidate="rcmb_IncrementMonth"
                                                    ErrorMessage="Please Select Increment Month" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                            </td>31.5.2016
                                        </tr>--%>
                                        <tr>
                                            <td class="style2"></td>
                                            <td class="style6"></td>
                                            <td class="style7"></td>
                                            <td class="style5"></td>
                                            <td class="style5"></td>
                                        </tr>
                                        <tr>
                                            <td class="style2">&nbsp;</td>
                                            <td class="style6">&nbsp;</td>
                                            <td class="style7">&nbsp;</td>
                                            <td class="style5">&nbsp;</td>
                                            <td class="style5">&nbsp;</td>
                                        </tr>
                                        <%--  <tr>
                                                <td class="style2">
                                                    &nbsp;</td>
                                                <td class="style6">
                                                    &nbsp;</td>
                                                <td class="style7">
                                                    &nbsp;</td>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td class="style5">
                                                    &nbsp;</td>
                                            </tr>--%>
                                        <tr>
                                            <td class="style2" colspan="5">
                                                <asp:Button ID="btn_Submit" runat="server" meta:resourcekey="btn_Submit"
                                                    OnClick="btn_Submit_Click" Text="Submit" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                                &nbsp;<asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel"
                                                    OnClick="btn_Cancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:ValidationSummary ID="vs_PRHK" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                    ValidationGroup="Controls" />
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- </div>--%>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_Choose" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <div style="height: 490px; width: 1014px; overflow: auto;">
                                        <table align="center" class="style1">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblchoose" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:RadioButtonList ID="rdb_choose" runat="server" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdb_choose_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">Individual</asp:ListItem>
                                                        <%-- <asp:ListItem Value="1">Groupwise</asp:ListItem>--%>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_GroupDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <div>
                                        <table align="center">

                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_bu" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_BU_group" runat="server" AutoPostBack="True"
                                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                                        OnSelectedIndexChanged="rcmb_BU_group_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BU_group" runat="server"
                                                        ControlToValidate="rcmb_BU_group"
                                                        ErrorMessage="Please Select BusinessUnit" InitialValue="Select"
                                                        ValidationGroup="ControlsGroup">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_grade_group" runat="server" Text="Scale"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_grade_group" runat="server" AutoPostBack="True"
                                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                                        OnSelectedIndexChanged="rcmb_grade_group_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rcmb_grade_group" runat="server"
                                                        ControlToValidate="rcmb_grade_group"
                                                        ErrorMessage="Please Select Grade " InitialValue="Select"
                                                        ValidationGroup="ControlsGroup">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_leavestruct_group" runat="server" Text="Leave&nbsp;Structure"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_levestruct_group" runat="server" MaxHeight="120px"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                    <asp:Label ID="lbl_annualgross_group" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rcmb_levestruct_group" runat="server"
                                                        ControlToValidate="rcmb_levestruct_group"
                                                        ErrorMessage="Please Select Leave Structure" InitialValue="Select"
                                                        ValidationGroup="ControlsGroup">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_salstruct_group" runat="server" Text="Salary&nbsp;Structure"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_salstruct_group" runat="server" MaxHeight="120px"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                    <asp:Label ID="lbl_annualbasic_group" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rcmb_salstruct_group" runat="server"
                                                        ControlToValidate="rcmb_salstruct_group"
                                                        ErrorMessage="Please Select Leave Structure" InitialValue="Select"
                                                        ValidationGroup="ControlsGroup">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_reportingemp_group" runat="server" Text="Reporting&nbsp;Employee"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_reportemp_group" runat="server" MaxHeight="120px"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <%--<asp:RequiredFieldValidator ID="rfv_rcmb_reportemp_group" runat="server"
                                                        ControlToValidate="rcmb_reportemp_group"
                                                        ErrorMessage="Please Select Reporting Employee" InitialValue="Select"
                                                        ValidationGroup="ControlsGroup">*</asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_rependdate_group" runat="server" Text="Reporting&nbsp;Employee&nbsp;Enddate"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdtp_reptenddate_group" runat="server"
                                                        Skin="WebBlue" ToolTip="New Reporting Employee Active Date" meta:resourcekey="rdtp_reptenddate_group">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr align="center">
                                                <td align="left">
                                                    <asp:Label ID="lbl_execdate_group" runat="server" Text="Execution&nbsp;Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdtp_execdate_group" runat="server"
                                                        Skin="WebBlue" meta:resourcekey="rdtp_execdate_group" AutoPostBack="true" MinDate='<%#System.DateTime.Now %>' OnSelectedDateChanged="rdtp_execdate_group_SelectedDateChanged">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rdtp_execdate_group" runat="server"
                                                        ControlToValidate="rdtp_execdate_group"
                                                        ErrorMessage="Please&nbsp;Enter&nbsp;Execution&nbsp;Date"
                                                        ValidationGroup="ControlsGroup">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <%--<tr> 31.5.2016
                                            <td>
                                                <asp:Label ID="lbl_IncrementType_Group" runat="server" Text="Salary Progression By"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_IncrementType_Group" runat="server" Enabled="false">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_IncrementType_Group" runat="server" InitialValue="Select" ControlToValidate="rcmb_IncrementType_Group"
                                                    ErrorMessage="Please Select Salary Progression By" Text="*" ValidationGroup="ControlsGroup"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                            <tr>
                                            <td>
                                                <asp:Label ID="lbl_IncrementMonthGroup" runat="server" Text="Increment Month"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_IncrementMonth_group" runat="server">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_IncrementMonth_group" runat="server" InitialValue="Select" ControlToValidate="rcmb_IncrementMonth_group"
                                                    ErrorMessage="Please Select Increment Month" Text="*" ValidationGroup="ControlsGroup"></asp:RequiredFieldValidator>
                                            </td>
                                           
                                        </tr>--%>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td colspan="4">
                                    <telerik:RadGrid ID="rg_employees_group" runat="server" AllowFilteringByColumn="False"
                                        AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False" GridLines="None"
                                        Skin="Office2007" Visible="False" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                            Text="Check All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                        <asp:Label ID="lbl_emp_id" runat="server" Text='<%#Eval("EMP_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Employee Name" meta:resourcekey="EmpName" UniqueName="EmpName">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Salary Slabs">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmb_GridSlabs" runat="server" Skin="WebBlue" Filter="Contains"
                                                            AppendDataBoundItems="true" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_GridSlabs_SelectedIndexChanged" meta:resourcekey="rcmb_GridSlabs"
                                                            DataValueField="EMPLOYEEGRADE_SLAB_ID" DataTextField="EMPLOYEEGRADE_SLAB_AMOUNT" DataSource='<%#LoadGridSalarySlabs() %>' SelectedValue='<%# Eval("EMPLOYEEGRADE_SLAB_ID") %>'>
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="Select" Value="0" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                        <asp:Label ID="lblEmpSlabID" runat="server" Text='<%#Eval("EMPLOYEEGRADE_SLAB_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Gross Value" Display="false">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_gross_group" Value='<%#Eval("EMP_BASIC") %>' runat="server" MinValue="0.00"
                                                            MaxLength="15" Enabled="false">
                                                        </telerik:RadNumericTextBox>
                                                        <telerik:RadNumericTextBox ID="rtxt_annualgross" runat="server" Visible="false">
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Basic Value">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_basic_group" runat="server" Value='<%#Eval("EMP_BASIC") %>' MinValue="0.00" Enabled="false"
                                                            MaxLength="15">
                                                        </telerik:RadNumericTextBox>
                                                        <telerik:RadNumericTextBox ID="rtxt_annualbasic" runat="server" Visible="false">
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btn_submit_group" runat="server" Text="Submit" ValidationGroup="ControlsGroup"
                                        Visible="false" OnClick="btn_submit_group_Click" />
                                    <asp:Button ID="btn_cancel_group" runat="server" Text="Cancel"
                                        Visible="true" OnClick="btn_cancel_group_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:ValidationSummary ID="vs_group" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="ControlsGroup" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1 {
            width: 769px;
        }

        .style2 {
            text-align: center;
        }

        .style5 {
            width: 167px;
        }

        .style6 {
            width: 10px;
        }

        .style7 {
            width: 253px;
        }

        .style8 {
            text-align: left;
        }
    </style>
</asp:Content>