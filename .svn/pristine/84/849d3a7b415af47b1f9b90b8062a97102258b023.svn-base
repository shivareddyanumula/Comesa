<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_GlobalConfig.aspx.cs" Inherits="Security_frm_GlobalConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    ;<asp:UpdatePanel ID="updEmployee" runat="server">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="RMP_GlobalConfig" runat="server" SelectedIndex="0" Width="480px">
                            <telerik:RadPageView ID="RPV_GlobalConfig" runat="server" BorderColor="Black" BorderStyle="Solid"
                                BorderWidth="1">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <table style="width: 480px" align="center">
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:Label ID="lbl_Header" runat="server" meta:resourcekey="lbl_Header" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_Info1" runat="server" Font-Bold="True" Font-Underline="True" Text="Applicant Numbering"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_AppNo" runat="server" meta:resourcekey="lbl_AppNo"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_AppNo" runat="server" MinValue="0" MaxLength="12">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rntxt_AppNo_Validate1" runat="server" ControlToValidate="rntxt_AppNo"
                                                            Display="Dynamic" meta:resourcekey="rntxt_AppNo_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" width="190px">
                                                        <asp:Label ID="lbl_AppPrefix" runat="server" meta:resourcekey="lbl_AppPrefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_AppPrefix" runat="server" MaxLength="20">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rtxt_AppPrefix_Validate" runat="server" ControlToValidate="rtxt_AppPrefix"
                                                            Display="Dynamic" meta:resourcekey="rtxt_AppPrefix_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <%--  <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_Info" runat="server" Font-Bold="True" Font-Underline="true" Text="Employee Numbering"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_EmpNo" runat="server">Permanent</asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_EmpNo" runat="server" MaxLength="12" MinValue="0">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rntxt_EmpNo_Validate0" runat="server" ControlToValidate="rntxt_EmpNo"
                                                            Display="Dynamic" meta:resourcekey="rntxt_EmpNo_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_TempEmp" runat="server">Contract</asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_EmpPart" runat="server" MaxLength="12" MinValue="0">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rntxt_EmpPart_Validate" runat="server" ControlToValidate="rntxt_EmpPart"
                                                            Display="Dynamic" ErrorMessage="Enter Contract/Temporary Employee Numbering"
                                                            Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_Trainee" runat="server">Consultant</asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_EmpTrainee" runat="server" MaxLength="12" MinValue="0">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rntxt_EmpTrainee_Validate" runat="server" ControlToValidate="rntxt_EmpTrainee"
                                                            Display="Dynamic" ErrorMessage="Enter Trainee Employee Numbering" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_EmpPrefix" runat="server" meta:resourcekey="lbl_EmpPrefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_EmpPrefix" runat="server" MaxLength="20">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rtxt_EmpPrefix_Validate" runat="server" ControlToValidate="rtxt_EmpPrefix"
                                                            Display="Dynamic" meta:resourcekey="rtxt_EmpPrefix_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_CotractPrefix" runat="server" meta:resourcekey="lbl_CotractPrefix"
                                                            Text="Contract&nbsp;Employee&nbsp;Prefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_ContractPrefix" runat="server" MaxLength="20">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rtxt_ContractPrefix_Validate" runat="server" ControlToValidate="rtxt_ContractPrefix"
                                                            Display="Dynamic" meta:resourcekey="rtxt_ContractPrefix_Validate" Text="*" ValidationGroup="Controls"
                                                            ErrorMessage="Please Enter Contract Employee Prefix" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_ConsultPrefix" runat="server" meta:resourcekey="lbl_ConsultPrefix"
                                                            Text="Consultant&nbsp;Employee&nbsp;Prefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_ConsultantPrefix" runat="server" MaxLength="20">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rtxt_ConsultantPrefix_Validate" runat="server" ControlToValidate="rtxt_ConsultantPrefix"
                                                            Display="Dynamic" meta:resourcekey="rtxt_ContractPrefix_Validate" Text="*" ValidationGroup="Controls"
                                                            ErrorMessage="Please Enter Consultant Employee Prefix" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_Info_1" runat="server" Font-Bold="True" Font-Underline="True"
                                                            Text="Prefix and Numbering"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_IncidentID" runat="server" meta:resourcekey="lbl_IncidentID"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_IncidentID" runat="server" MinValue="0" MaxLength="12">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_IncidentID" runat="server" ControlToValidate="rntxt_IncidentID"
                                                            Display="Dynamic" ErrorMessage="Please Enter Complaint Number" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_IncidentPrefix" runat="server" meta:resourcekey="lbl_IncidentPrefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_IncidentPrefix" runat="server" MaxLength="50" meta:resourcekey="rtxt_IncidentPrefix">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_IncidentPrefix" runat="server" ControlToValidate="rtxt_IncidentPrefix"
                                                            Display="Dynamic" meta:resourcekey="rfv_IncidentPrefix" ErrorMessage="Please Enter Complaint Prefix" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="disa" runat="server" visible="false">
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_Discipline" runat="server" meta:resourcekey="lbl_Discipline"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_DisciplineID" runat="server" MinValue="0" MaxLength="12">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_DisciplineID" runat="server" ControlToValidate="rntxt_DisciplineID"
                                                            Display="Dynamic" ErrorMessage="Please Enter Disciplinary Action Number" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="disp" runat="server" visible="false">
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_DisciplinePrefix" runat="server" meta:resourcekey="lbl_DisciplinePrefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_DisciplinePrefix" runat="server" MaxLength="50" meta:resourcekey="rtxt_DisciplinePrefix">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_DisciplinePrefix" runat="server" ControlToValidate="rtxt_DisciplinePrefix"
                                                            Display="Dynamic" meta:resourcekey="rfv_DisciplinePrefix" ErrorMessage="Please Enter Disciplinary Action Prefix" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_LoanID" runat="server" meta:resourcekey="lbl_LoanID"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_LoanID" runat="server" MinValue="0" MaxLength="12">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rntxt_LoanID_Validate" runat="server" ControlToValidate="rntxt_LoanID"
                                                            Display="Dynamic" meta:resourcekey="rntxt_LoanID_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_LoanPrefix" runat="server" meta:resourcekey="lbl_LoanPrefix"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_LoanPrefix" runat="server" MaxLength="50" meta:resourcekey="rntxt_LoanPrefix">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rtxt_LoanPrefix_Validate" runat="server" ControlToValidate="rtxt_LoanPrefix"
                                                            Display="Dynamic" meta:resourcekey="rtxt_LoanPrefix_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_Info2" runat="server" Font-Bold="True" Font-Underline="True" Text="Payroll Transaction Numbering"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Supermoduleid" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_JobReq_Code" runat="server" meta:resourcekey="lbl_JobReq_Code"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_JobReq_Code" runat="server" MaxLength="12" MinValue="0">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rntxt_PeriodCode_Validate" runat="server" ControlToValidate="rntxt_JobReq_Code"
                                                            Display="Dynamic" meta:resourcekey="rntxt_PeriodCode_Validate" Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_Recruitment" runat="server" Font-Bold="True" Font-Underline="True"
                                                            Text="Recruitment"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_JobRequisition_Code" runat="server" meta:resourcekey="lbl_JobRequisition_Code"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_JobReqcode" runat="server" MaxLength="100">
                                                        </telerik:RadTextBox>
                                                        <%-- <asp:RequiredFieldValidator ID="rfv_JobReq_Validates" runat="server" ControlToValidate="rtxt_JobReqcode"
                                                            Display="Dynamic" meta:resourcekey="rfv_JobReq_Validates" Text="*" ValidationGroup="Controls" />--%>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>




                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblPension" runat="server" Font-Bold="True" Font-Underline="True"
                                                            Text="Pension"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lblPensionRegdAmt" runat="server" meta:resourcekey="lblPensionRegdAmt"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PensionRegdAmt" runat="server" MaxLength="7" MinValue="0" NumberFormat-DecimalDigits="0">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>




                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_insurance" runat="server" Font-Bold="True" Font-Underline="True"
                                                            Text="Insurance"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_tax" runat="server" meta:resourcekey="lbl_tax"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_InsuranceTaxRelief" runat="server" MaxLength="8" MinValue="0" NumberFormat-DecimalDigits="0">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>








                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbl_Info3" runat="server" Font-Bold="True" Font-Underline="True" meta:resourcekey="lbl_Info3"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <hr />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_DateFormat" runat="server" meta:resourcekey="lbl_DateFormat"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_DateFormat" runat="server" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_DateFormat" runat="server" ControlToValidate="rcmb_DateFormat"
                                                            Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_rcmb_DateFormat"
                                                            Text="*" ValidationGroup="Controls" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_Theme" runat="server" meta:resourcekey="lbl_Theme"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_Theme" runat="server" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lbl_Age" runat="server" meta:resourcekey="lbl_Age"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_MinAge" runat="server" MaxLength="2" Width="50px"
                                                            MinValue="18" MaxValue="70">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        -
                                                        <telerik:RadNumericTextBox ID="rntxt_MaxAge" runat="server" MaxLength="2" Width="50px"
                                                            MinValue="18" MaxValue="99">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_rntxt_MinAge" runat="server" ControlToValidate="rntxt_MinAge"
                                                            Display="Dynamic" meta:resourcekey="rfv_rntxt_MinAge" Text="*" ValidationGroup="Controls" />
                                                        <asp:RequiredFieldValidator ID="rfv_rntxt_MaxAge" runat="server" ControlToValidate="rntxt_MaxAge"
                                                            Display="Dynamic" meta:resourcekey="rfv_rntxt_MaxAge" Text="*" ValidationGroup="Controls" />
                                                        <asp:CompareValidator ID="rcv_rntxt_Compare" runat="server" ControlToCompare="rntxt_MinAge"
                                                            ControlToValidate="rntxt_MaxAge" Display="Dynamic" meta:resourcekey="rcv_rntxt_Compare"
                                                            Operator="GreaterThan" Text="*" ValidationGroup="Controls"></asp:CompareValidator>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_AppliedDates" runat="server" meta:resourcekey="lbl_AppliedDates"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chk_AppliedDates" runat="server" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_LeaveTranFlag" runat="server" meta:resourcekey="lbl_LeaveTranFlag"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chk_LeaveTranFlag" runat="server" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_CompanyLogo" runat="server" meta:resourcekey="lbl_CompanyLogo"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="FUpload" runat="server" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lbl_LogoPath" runat="server" meta:resourcekey="lbl_LogoPath"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_CompanyLogoWidth" runat="server" meta:resourcekey="lbl_CompanyLogoWidth"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_Width" runat="server" MaxLength="5" MinValue="0">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Width_Validate" runat="server" ControlToValidate="rntxt_Width"
                                                            Display="Dynamic" Text="*" ValidationGroup="Controls" ErrorMessage="Enter Logo Width" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_CompanyLogoHeight" runat="server" meta:resourcekey="lbl_CompanyLogoHeight"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntxt_Height" runat="server" MaxLength="5" MinValue="0">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Height_Validate" runat="server" ControlToValidate="rcmb_DateFormat"
                                                            Display="Dynamic" Text="*" ValidationGroup="Controls" ErrorMessage="Enter Logo Height" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lbl_PayrollFooterMessage" runat="server" meta:resourcekey="lbl_PayrollFooterMessage"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_Payrollfootermsg" runat="server" LabelCssClass=""
                                                            MaxLength="100" meta:resourcekey="rtxt_Payrollfootermsg" Skin="WebBlue" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="text-align: center">
                                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                            UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="text-align: center">
                                                        <asp:ValidationSummary ID="smhr_GlobalConfig_Summary" runat="server" DisplayMode="BulletList"
                                                            ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Save" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>