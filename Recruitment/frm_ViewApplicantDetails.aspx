<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ViewApplicantDetails.aspx.cs" Inherits="Recruitment_frm_ViewApplicantDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
        </telerik:RadAjaxManagerProxy>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <telerik:RadScriptManager ID="RD_ScriptManager1" runat="server"></telerik:RadScriptManager>
        <div style="text-align: center;">
            <table align="center" style="vertical-align: top;">
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_BU_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                            Width="990px" Height="490px" ScrollBars="Auto">
                            <telerik:RadPageView ID="Rp_BU_ViewMain" runat="server">
                                <br />
                                <br />
                                <asp:UpdatePanel ID="updApplicant" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 80%;" align="center">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lbl_Header" runat="server" Text="Applicant Details">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <telerik:RadTabStrip ID="RTS_Applicant" runat="server" Skin="WebBlue" MultiPageID="RMP_Applicant_1" AutoPostBack="true" CausesValidation="false"
                                                        SelectedIndex="0" Align="Center" Width="100%">
                                                        <Tabs>
                                                            <telerik:RadTab runat="server" Text="Personal" PageViewID="Personal">
                                                            </telerik:RadTab>
                                                            <telerik:RadTab runat="server" Text="Qualification" PageViewID="Qualification">
                                                            </telerik:RadTab>
                                                            <telerik:RadTab runat="server" Text="Skills" PageViewID="AppSkill">
                                                            </telerik:RadTab>
                                                            <telerik:RadTab runat="server" Text="Experience" PageViewID="Experience">
                                                            </telerik:RadTab>
                                                            <telerik:RadTab runat="server" Text="Contact" PageViewID="Contact">
                                                            </telerik:RadTab>
                                                            <telerik:RadTab runat="server" Text="Language" PageViewID="Language">
                                                            </telerik:RadTab>
                                                            <telerik:RadTab runat="server" Text="Reference" PageViewID="Reference">
                                                            </telerik:RadTab>
                                                            <%-- <telerik:RadTab runat="server" Text="Resume Upload" PageViewID="Upload">
                                                    </telerik:RadTab>--%>
                                                        </Tabs>
                                                    </telerik:RadTabStrip>
                                                    <telerik:RadMultiPage ID="RMP_Applicant_1" runat="server" Width="90%" SelectedIndex="0">
                                                        <telerik:RadPageView ID="Personal" runat="server">
                                                            <br />
                                                            <table align="center">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblCode" runat="server" meta:resourcekey="lblCode" Text="Applicant Code"></asp:Label>
                                                                        <asp:HiddenField ID="HF_APID" runat="server" />
                                                                        <asp:HiddenField ID="HF_ID" runat="server" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="txt_AppCode" runat="server" EmptyMessage="Auto Generated Code"
                                                                            Skin="WebBlue" ReadOnly="True" TabIndex="0">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblBloodGroup" runat="server" meta:resourcekey="lblBloodGroup" Text="Blood Group"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox Enabled="false" ID="ddl_BloodGroup" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                                                            TabIndex="7" Filter="Contains">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="O+" Value="O+" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="O-" Value="O-" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="B+" Value="B+" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="B-" Value="B-" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="AB+" Value="AB+" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="AB-" Value="AB-" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="A-" Value="A-" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="A+" Value="A+" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td align="left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lbltitle" runat="server" meta:resourcekey="lbltitle" Text="Title"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox Enabled="false" ID="ddl_Title" runat="server" Skin="WebBlue" OnClientSelectedIndexChanged="onGenderCheck"
                                                                            TabIndex="1" MarkFirstMatch="true">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Mr." Value="Mr." />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Ms." Value="Ms." />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Mrs." Value="Mrs." />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%-- <asp:RequiredFieldValidator ID="rfv_title" runat="server" ControlToValidate="ddl_Title"
                                                                    ErrorMessage="Choose Title" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblReligion" runat="server" meta:resourcekey="lblReligion" Text="Religion"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox ID="ddl_Religion" Enabled="false" runat="server" Skin="WebBlue" TabIndex="8"
                                                                            MarkFirstMatch="true" Filter="Contains">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%--  <asp:RequiredFieldValidator ID="rfvb_religion" runat="server" ControlToValidate="ddl_Religion"
                                                                    ErrorMessage="Choose Religion" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFirstName" runat="server" meta:resourcekey="lblFirstName" Text="First Name"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="txt_FirstName" runat="server" AutoCompleteType="Disabled"
                                                                            Skin="WebBlue" TabIndex="2" MaxLength="50" />
                                                                        </radtextbox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%-- <asp:RequiredFieldValidator runat="server" ID="rfv_firstname" ControlToValidate="txt_FirstName"
                                                                    ErrorMessage="Enter First Name" Text="*" ValidationGroup="Controls">
                                                                </asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblNationality" runat="server" meta:resourcekey="lblNationality" Text="Nationality"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox Enabled="false" ID="ddl_Nationality" runat="server" TabIndex="9" Skin="WebBlue"
                                                                            MarkFirstMatch="true" Filter="Contains">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%-- <asp:RequiredFieldValidator ID="rfv_Nationality" runat="server" ControlToValidate="ddl_Nationality"
                                                                    ErrorMessage="Choose Nationality" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblMiddleName" runat="server" meta:resourcekey="lblMiddleName" Text="Middle Name"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="txt_AppMiddleName" runat="server" AutoCompleteType="Disabled"
                                                                            Skin="WebBlue" TabIndex="3" MaxLength="50">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblStatus" runat="server" meta:resourcekey="lblStatus" Text="Status"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox Enabled="false" ID="ddl_Status" runat="server" Skin="WebBlue" TabIndex="10"
                                                                            MarkFirstMatch="true">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Applied" Value="Applied" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Selected" Value="Selected" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Rejected" Value="Rejected" />
                                                                                <%--<telerik:RadComboBoxItem runat="server" Text="On Hold" Value="On Hold" />--%>
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%-- <asp:RequiredFieldValidator ID="rfv_Status" runat="server" ControlToValidate="ddl_Status"
                                                                    ErrorMessage="Choose Status" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblLastName" runat="server" meta:resourcekey="lblLastName" Text="Last Name"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="txt_AppLastName" runat="server" AutoCompleteType="Disabled"
                                                                            Skin="WebBlue" TabIndex="4" MaxLength="50">
                                                                            <EmptyMessageStyle Font-Italic="True" />
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%-- <asp:RequiredFieldValidator runat="server" ID="rfv_lastname" ControlToValidate="txt_AppLastName"
                                                                    ErrorMessage="Enter Last Name" Text="*" ValidationGroup="Controls">
                                                                </asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblMaritalStatus" runat="server" meta:resourcekey="lblMaritalStatus" Text="Marital Status"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox Enabled="false" ID="ddl_MaritalStatus" runat="server" Skin="WebBlue" TabIndex="11"
                                                                            MarkFirstMatch="true">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Single" Value="Single" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Married" Value="Married" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Divorced" Value="Divorced" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Now Married" Value="Now Married" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        <%--  <asp:RequiredFieldValidator ID="rfv_maritalstatus" runat="server" ControlToValidate="ddl_MaritalStatus"
                                                                    ErrorMessage="Choose Marital Status" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDOB" runat="server" meta:resourcekey="lblDOB" Text="Date of Birth"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left" colspan="3">
                                                                        <telerik:RadDatePicker ID="txt_DOB" Enabled="false" runat="server" AutoPostBack="true" Skin="WebBlue"
                                                                            MinDate="1900-01-01" TabIndex="5">
                                                                        </telerik:RadDatePicker>
                                                                        <%--<asp:RequiredFieldValidator ID="rfv_dob" runat="server" ControlToValidate="txt_DOB"
                                                                    ErrorMessage="Enter Valid Date" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                    ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                        <asp:Label ID="lblAge" runat="server" Style="font-weight: 700"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblAddress" runat="server" meta:resourcekey="lblAddress" Text="Address"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="txt_Address" runat="server" AutoCompleteType="Disabled" Skin="WebBlue"
                                                                            TabIndex="12" MaxLength="5000">
                                                                            <EmptyMessageStyle Font-Italic="True" />
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td align="left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGender" Text="Gender"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadComboBox Enabled="false" ID="ddl_Gender" runat="server" Skin="WebBlue" TabIndex="6" MarkFirstMatch="true">
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Male" Value="Male" />
                                                                                <telerik:RadComboBoxItem runat="server" Text="Female" Value="Female" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                    <td>
                                                                        <%--<asp:RequiredFieldValidator ID="rfv_Gender" runat="server" ControlToValidate="ddl_Gender"
                                                                    ErrorMessage="Choose Gender" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblRemarks" runat="server" meta:resourcekey="lblRemarks" Text="Remarks"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="txt_Remarks" runat="server" AutoCompleteType="Disabled" Skin="WebBlue"
                                                                            TabIndex="13" MaxLength="5000">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td align="left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lbl_Email" runat="server" Text="Email" meta:resourcekey="lbl_Email"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadTextBox Enabled="false" ID="rtxt_Email" runat="server" Skin="WebBlue" TabIndex="13" MaxLength="50">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td>
                                                                        <%--<asp:RequiredFieldValidator ID="RFV_rtxt_Email" runat="server" ControlToValidate="rtxt_Email"
                                                                    ErrorMessage="Please Enter Email" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RFV_rtxt_Email_Cmp" runat="server" ControlToValidate="rtxt_Email"
                                                                    Text="Please Enter Valid Email ID" Display="Dynamic" ValidationGroup="Controls"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                                                                    </td>
                                                                    <td></td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                                                                        <%--Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rmtxt_MobileNo"
                                                                    ErrorMessage="Please Enter Mobile" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td align="left"><b>:</b>
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadMaskedTextBox Enabled="false" ID="rmtxt_MobileNo" runat="server" DisplayMask="##########"
                                                                            Mask="##########">
                                                                        </telerik:RadMaskedTextBox>
                                                                        <%--<asp:RegularExpressionValidator ID="rev_MobileNo" runat="server" ControlToValidate="rmtxt_MobileNo"
                                                                Display="Dynamic" Text="Enter 10 digits for mobile  number" ValidationExpression="\d{10}"
                                                                ValidationGroup="Controls"></asp:RegularExpressionValidator>--%>
                                                                 
                                                                    </td>
                                                                    <td align="left"></td>
                                                                </tr>
                                                            </table>

                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="Qualification" runat="server">
                                                            <br />
                                                            <%--<table align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Category" runat="server" meta:resourcekey="lbl_Category"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddl_Category" runat="server" MaxHeight="120px" Skin="WebBlue"
                                                                    MarkFirstMatch="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfv_Category" runat="server" Text="*" InitialValue="Select"
                                                                    ValidationGroup="Qual" ControlToValidate="ddl_Category" meta:resourcekey="rfv_Category"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Institute" runat="server" Text="Institute/University" meta:resourcekey="lbl_Institute"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_Institute" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="150" Skin="WebBlue">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfv_Institute" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="txt_Institute" meta:resourcekey="rfv_Institute"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_YearPass" runat="server" meta:resourcekey="lbl_YearPass"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadNumericTextBox ID="txt_YearofPass" runat="server" DataType="System.Int32"
                                                                    MaxLength="4" Skin="WebBlue" MaxValue="5000" MinValue="1900">
                                                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfv_yearofpass" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="txt_YearofPass" meta:resourcekey="rfv_yearofpass"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Percentage" runat="server" meta:resourcekey="lbl_Percentage"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadNumericTextBox ID="txt_Percentage" runat="server" Skin="WebBlue" MaxLength="5"
                                                                    MaxValue="100" MinValue="35">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td align="left">
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Grade" runat="server" meta:resourcekey="lbl_Grade"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddl_Grade" runat="server" meta:resourcekey="ddl_Grade" Skin="WebBlue"
                                                                    MarkFirstMatch="true">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="Select" Value="Select" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="A" Value="A" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="B" Value="B" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="C" Value="C" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="D" Value="D" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td align="left">
                                                               
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="5">
                                                                <asp:Button ID="btn_Qual_Add" ValidationGroup="Qual" runat="server" Text="Add"  />
                                                                <asp:Button ID="btn_Qual_Correct" ValidationGroup="Qual" runat="server" Text="Correct"
                                                                     />
                                                                <asp:Button ID="btn_Qual_Cancel" runat="server" Text="Cancel"  />
                                                            </td>
                                                            <td align="center">
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                            <br />
                                                            <table align="center" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <telerik:RadGrid ID="RG_Qualification" runat="server" Skin="WebBlue" GridLines="None"
                                                                            Width="100%" AutoGenerateColumns="False">
                                                                            <ClientSettings>
                                                                                <Selecting AllowRowSelect="True" />
                                                                            </ClientSettings>
                                                                            <MasterTableView>
                                                                                <Columns>
                                                                                    <%-- <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                                                <ItemStyle Width="80px" />
                                                                            </telerik:GridButtonColumn>--%>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPQFN_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPQFN_QUALIFICATION_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Qualification" UniqueName="Qualification">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_AppQual" runat="server" Text='<%# Eval("APPQFN_QUALIFICATION_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Institute" UniqueName="Institute">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_AppInstitute" runat="server" Text='<%# Eval("APPQFN_INSTITUTE") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Year&nbsp;Pass" UniqueName="YearPass">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_AppYearPass" runat="server" Text='<%# Eval("APPQFN_PASSEDYEAR") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Percentage" UniqueName="Percentage">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_AppPercentage" runat="server" Text='<%# Eval("APPQFN_PERCENTAGE") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Grade" UniqueName="Grade">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_AppGrade" runat="server" Text='<%# Eval("APPQFN_GRADE") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                </Columns>
                                                                            </MasterTableView>
                                                                            <FilterMenu Skin="WebBlue">
                                                                            </FilterMenu>
                                                                            <HeaderContextMenu Skin="WebBlue">
                                                                            </HeaderContextMenu>
                                                                        </telerik:RadGrid>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadPageView>

                                                        <telerik:RadPageView ID="AppSkill" runat="server">
                                                            <br />
                                                            <%--<table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Skill" runat="server" Text="Skill&nbsp;Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcb_Skill" runat="server" Skin="WebBlue" MarkFirstMatch="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_SkillName" runat="server" Text="*" InitialValue="Select"
                                                                    ControlToValidate="rcb_Skill" ValidationGroup="Skills" Display="Dynamic" ErrorMessage="Choose Skill"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                                                                              <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ExpertLevel" runat="server" Text="Expertise"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcb_ExpertLevel" runat="server" Skin="WebBlue" MarkFirstMatch="true">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                                        <telerik:RadComboBoxItem Text="Beginner" Value="1" />
                                                                        <telerik:RadComboBoxItem Text="Intermediate" Value="2" />
                                                                        <telerik:RadComboBoxItem Text="Expert" Value="3" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Expertise" runat="server" ErrorMessage="Choose Skill Expertise"
                                                                    Text="*" ValidationGroup="Skills" ControlToValidate="rcb_ExpertLevel" InitialValue="Select"
                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Button ID="btn_Skill_Add" runat="server" ValidationGroup="Skills" Text="Add"
                                                                     />
                                                                <asp:Button ID="btn_Skill_Correct" runat="server" ValidationGroup="Skills" Text="Correct"
                                                                     />
                                                               
                                                                <asp:Button ID="btn_Skill_Cancel" runat="server" Text="Cancel"  />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                            <br />
                                                            <table align="center">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadGrid ID="RG_Skills" runat="server" Skin="WebBlue" GridLines="None" Width="100%"
                                                                            AutoGenerateColumns="False">
                                                                            <ClientSettings>
                                                                                <Selecting AllowRowSelect="True" />
                                                                            </ClientSettings>
                                                                            <MasterTableView>
                                                                                <Columns>
                                                                                    <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                                            </telerik:GridButtonColumn>--%>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPSKL_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_SKILL_ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Skill_ID" runat="server" Text='<%# Eval("APPSKL_SKILL_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Skill" UniqueName="APPSKL_SKILL_NAME">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Skill_Name" runat="server" Text='<%# Eval("APPSKL_SKILL_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Last&nbsp;Used" UniqueName="APPSKL_LASTUSED" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Skill_LastUsed" runat="server" Text='<%# Eval("APPSKL_LASTUSED") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_EXPERT_ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Skill_Exp_ID" runat="server" Text='<%# Eval("APPSKL_EXPERT") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Expertise" UniqueName="APPSKL_EXPERT">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Skill_Expertise" runat="server" Text='<%# Eval("APPSKL_EXPERT_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                </Columns>
                                                                            </MasterTableView>
                                                                            <FilterMenu Skin="WebBlue">
                                                                            </FilterMenu>
                                                                            <HeaderContextMenu Skin="WebBlue">
                                                                            </HeaderContextMenu>
                                                                        </telerik:RadGrid>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="Experience" runat="server">
                                                            <br />
                                                            <%--<table align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Serial" runat="server" meta:resourcekey="lbl_Serial"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_Serial" runat="server" Enabled="False" Skin="WebBlue">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Serial_E" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Serial_E" ControlToValidate="txt_Serial"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblReason" runat="server" meta:resourcekey="lblReason"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_ReasonRelieve" runat="server" Skin="WebBlue" MaxLength="100"
                                                                    TabIndex="5">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_ReasonRelieve" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_ReasonRelieve" ControlToValidate="txt_ReasonRelieve"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblCompanyName" runat="server" meta:resourcekey="lblCompanyName"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_CompanyName" runat="server" Skin="WebBlue" MaxLength="50"
                                                                    TabIndex="1">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_CompanyName" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_CompanyName" ControlToValidate="txt_CompanyName"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblRelieveDate" runat="server" meta:resourcekey="lblRelieveDate"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadDatePicker ID="txt_RelieveDate" runat="server" Culture="English (United States)"
                                                                    Skin="WebBlue" TabIndex="6">
                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DateInput LabelCssClass="" TabIndex="6" Width="">
                                                                    </DateInput>
                                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" TabIndex="6" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_RelieveDate" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_RelieveDate" ControlToValidate="txt_RelieveDate"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblJoinDate" runat="server" meta:resourcekey="lblJoinDate"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadDatePicker ID="txt_JoinDate" runat="server" Culture="English (United States)"
                                                                    Skin="WebBlue" TabIndex="2">
                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DateInput LabelCssClass="" TabIndex="2" Width="">
                                                                    </DateInput>
                                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" TabIndex="2" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_JoinDate" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_JoinDate" ControlToValidate="txt_JoinDate"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblRelSalary" runat="server" meta:resourcekey="lblRelSalary"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadNumericTextBox ID="txt_RelSalary" runat="server" Skin="WebBlue" MinValue="0"
                                                                    MaxLength="12" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                                    IncrementSettings-Step="0" TabIndex="7">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_RelSalary" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_RelSalary" ControlToValidate="txt_RelSalary"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblJoinSalary" runat="server" meta:resourcekey="lblJoinSalary"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadNumericTextBox ID="txt_JoinSalary" runat="server" Culture="English (United States)"
                                                                    MaxLength="12" MinValue="0" Skin="WebBlue" IncrementSettings-InterceptArrowKeys="true"
                                                                    IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" TabIndex="3">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                              
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblRelDesc" runat="server" meta:resourcekey="lblRelDesc"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_RelDesc" runat="server" Skin="WebBlue" TabIndex="8" MaxLength="500">
                                                                    <EmptyMessageStyle Font-Italic="True" />
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_RelDesc" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_RelDesc" ControlToValidate="txt_RelDesc"> </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblJoinDesc" runat="server" meta:resourcekey="lblJoinDesc"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_JoinDesc" runat="server" Skin="WebBlue" MaxLength="50"
                                                                    TabIndex="4">
                                                                    <EmptyMessageStyle Font-Italic="True" />
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                            
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btn_Exp_Add" runat="server" ValidationGroup="Exp" 
                                                                    Text="Add" />
                                                                <asp:Button ID="btn_Exp_Correct" runat="server" ValidationGroup="Exp" 
                                                                    Text="Correct" />
                                                                <asp:Button ID="btn_Exp_Cancel" runat="server"  Text="Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                            <br />
                                                            <table align="center" style="width: 100%">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadGrid ID="RG_Experience" Skin="WebBlue" runat="server" GridLines="None"
                                                                            Width="100%" AutoGenerateColumns="False">
                                                                            <MasterTableView>
                                                                                <Columns>
                                                                                    <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit&nbsp;Record" UniqueName="column">
                                                                            </telerik:GridButtonColumn>--%>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPEXP_ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPEXP_ID") %>' Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Serial" UniqueName="APPEXP_SERIAL">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_Serial" runat="server" Text='<%# Eval("APPEXP_SERIAL") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Company&nbsp;Name" UniqueName="APPEXP_COMPANY">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_CompName" runat="server" Text='<%# Eval("APPEXP_COMPANY") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Join&nbsp;Date" UniqueName="APPEXP_JOINDATE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_JoinDate" runat="server" Text='<%# Eval("APPEXP_JOINDATE") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Join&nbsp;Salary" UniqueName="APPEXP_JOINSAL">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_JoinSal" runat="server" Text='<%# Eval("APPEXP_JOINSAL") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Join&nbsp;Designation" UniqueName="APPEXP_JOINDESC">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_JoinDesc" runat="server" Text='<%# Eval("APPEXP_JOINDESC") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Reason&nbsp;For&nbsp;Relieving" UniqueName="APPEXP_REASONREL">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_RelReason" runat="server" Text='<%# Eval("APPEXP_REASONREL") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Relieving&nbsp;Date" UniqueName="APPEXP_RELDATE"
                                                                                        Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_RelDate" runat="server" Text='<%# Eval("APPEXP_RELDATE") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Relieving&nbsp;Salary" UniqueName="APPEXP_RELSAL"
                                                                                        Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_RelSalary" runat="server" Text='<%# Eval("APPEXP_RELSAL") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Relieving&nbsp;Description" UniqueName="APPEXP_REASONDESC"
                                                                                        Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Exp_RelDesc" runat="server" Text='<%# Eval("APPEXP_REASONDESC") %>'
                                                                                                Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                </Columns>
                                                                            </MasterTableView>
                                                                        </telerik:RadGrid>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="Contact" runat="server">
                                                            <br />
                                                            <%--<table align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_conserial" runat="server" meta:resourcekey="lbl_conserial"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_Serail_C" runat="server" Skin="WebBlue" ReadOnly="True">
                                                                    <EmptyMessageStyle Font-Italic="True" />
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Serail_C" runat="server" ControlToValidate="txt_Serail_C"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Serail_C" Text="*" ValidationGroup="Contact">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblConCompany" runat="server" meta:resourcekey="lblConCompany"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_Company_C" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="50" Skin="WebBlue">
                                                                    <EmptyMessageStyle Font-Italic="True" />
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Company_C" runat="server" ControlToValidate="txt_Company_C"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Company_C" Text="*" ValidationGroup="Contact">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblContactPerson" runat="server" meta:resourcekey="lblContactPerson"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_ContactName" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="100" Skin="WebBlue">
                                                                    <EmptyMessageStyle Font-Italic="True" />
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_ContactName" runat="server" ControlToValidate="txt_ContactName"
                                                                    Display="Dynamic" meta:resourcekey="rfv_ContactName" Text="*" ValidationGroup="Contact">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblPhoneNumber" runat="server" meta:resourcekey="lblPhoneNumber"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadMaskedTextBox ID="txt_PhoneNumber" runat="server" DisplayMask="###-###-####"
                                                                    Skin="WebBlue" Mask="(###) ###-####" TextWithLiterals="() -">
                                                                </telerik:RadMaskedTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_PhoneNumber" runat="server" ControlToValidate="txt_PhoneNumber"
                                                                    Display="Dynamic" meta:resourcekey="rfv_PhoneNumber" Text="*" ValidationGroup="Contact">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Address" runat="server" meta:resourcekey="lbl_Address"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>: </b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txt_Address_C" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="100" CausesValidation="True" Skin="WebBlue" LabelCssClass="" Rows="3">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Address_C" runat="server" ControlToValidate="txt_Address_C"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Address_C" Text="*" ValidationGroup="Contact">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Contact_Add" runat="server" Text="Add" ValidationGroup="Contact"
                                                                     />
                                                                <asp:Button ID="btn_Contact_Correct" runat="server" Text="Correct" ValidationGroup="Contact"
                                                                     />
                                                                <asp:Button ID="btn_Contact_Cancel" runat="server" Text="Cancel"  />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                            <br />
                                                            <table style="width: 100%" align="center">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadGrid ID="RG_Contact" runat="server" GridLines="None" Height="100%" Width="98%"
                                                                            AutoGenerateColumns="False" Skin="WebBlue">
                                                                            <MasterTableView>
                                                                                <Columns>
                                                                                    <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit&amp;nbsp Record" UniqueName="column">
                                                                            </telerik:GridButtonColumn>--%>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPCONT_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Serial" UniqueName="Serial">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Con_Serial" runat="server" Text='<%# Eval("APPCONT_SERIAL") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Company&amp;nbsp;Name" UniqueName="CompanyName">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ConName" runat="server" Text='<%# Eval("APPCONT_COMPANY") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Contact&amp;nbsp;Person" UniqueName="ContactPerson">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ConPerson" runat="server" Text='<%# Eval("APPCONT_CONTACT") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Phone&amp;nbsp;Number" UniqueName="Phonenumber">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ConPhoneNumber" runat="server" Text='<%# Eval("APPCONT_PHONE") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Address" UniqueName="Address">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ConAddress" runat="server" Text='<%# Eval("APPCONT_ADDRESS") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                </Columns>
                                                                            </MasterTableView>
                                                                        </telerik:RadGrid>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="Language" runat="server">
                                                            <br />
                                                            <%--<table align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblLanguage" runat="server" meta:resourcekey="lblLanguage"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddl_Language" runat="server" Skin="WebBlue" MarkFirstMatch="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Language" runat="server" ControlToValidate="ddl_Language"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Language" Text="*"
                                                                    ValidationGroup="Lang">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Read" runat="server" meta:resourcekey="lbl_Read"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chk_Read" runat="server" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Write" runat="server" meta:resourcekey="lbl_Write"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chk_Write" runat="server" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Speak" runat="server" meta:resourcekey="lbl_Speak"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chk_Speak" runat="server" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Understand" runat="server" meta:resourcekey="lbl_Understand"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chk_Understand" runat="server" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Lang_Add" runat="server" ValidationGroup="Lang" Text="Add"  />
                                                                <asp:Button ID="btn_Lang_Correct" runat="server" ValidationGroup="Lang" Text="Correct"
                                                                     />
                                                                <asp:Button ID="btn_Lang_Cancel" runat="server" Text="Cancel"  />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                            <br />
                                                            <table style="width: 100%" align="center">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadGrid ID="RG_Language" runat="server" GridLines="None" Height="100%" Width="98%"
                                                                            AutoGenerateColumns="False" Skin="WebBlue">
                                                                            <MasterTableView>
                                                                                <Columns>
                                                                                    <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit&amp;nbsp Record" UniqueName="column">
                                                                            </telerik:GridButtonColumn>--%>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPLAN_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPLAN_LANGUAGE_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Name" UniqueName="Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Lang_Name" runat="server" Text='<%# Eval("APPLAN_LANGUAGE_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Read" UniqueName="Read">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chk_Lang_Read" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_READ")) %>'
                                                                                                Enabled="false"></asp:CheckBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Write" UniqueName="write">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chk_Lang_Write" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_WRITE")) %>'
                                                                                                Enabled="false"></asp:CheckBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Speak" UniqueName="Speak">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chk_Lang_Speak" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_SPEAK")) %>'
                                                                                                Enabled="false"></asp:CheckBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Understand" UniqueName="Understand">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chk_Lang_Understand" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_UNDERSTAND")) %>'
                                                                                                Enabled="false"></asp:CheckBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                </Columns>
                                                                            </MasterTableView>
                                                                        </telerik:RadGrid>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="Reference" runat="server">
                                                            <br />
                                                            <%--<table align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_BU" runat="server" Text="Business Unit" meta:resourcekey="lbl_BU"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddl_BU" runat="server" Skin="WebBlue" AutoPostBack="true"
                                                                    MarkFirstMatch="true" >
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_BU" runat="server" ControlToValidate="ddl_BU"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_BU" Text="*" ValidationGroup="Referred">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee Code" meta:resourcekey="lbl_Employee"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddl_Employee" runat="server" Skin="WebBlue" MarkFirstMatch="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="ddl_Employee"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Employee" Text="*"
                                                                    ValidationGroup="Referred">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_Relationship" runat="server" Text="Relationship" meta:resourcekey="lbl_Relationship"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddl_Relationship" runat="server" Skin="WebBlue" MarkFirstMatch="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Relationship" runat="server" ControlToValidate="ddl_Relationship"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Relationship" Text="*"
                                                                    ValidationGroup="Referred">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblReferred" runat="server" Text="Referred" meta:resourcekey="lblReferred"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chk_Referred" runat="server" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Ref_Add" runat="server" ValidationGroup="Referred" Text="Add"
                                                                     />
                                                                <asp:Button ID="btn_Ref_Correct" runat="server" ValidationGroup="Referred" Text="Correct"
                                                                     />
                                                                <asp:Button ID="btn_Ref_Cancel" runat="server" Text="Cancel"  />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                            <br />
                                                            <table style="width: 100%" align="center">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadGrid ID="RG_Reference" Skin="WebBlue" runat="server" GridLines="None"
                                                                            Height="100%" AutoGenerateColumns="False">
                                                                            <MasterTableView>
                                                                                <Columns>
                                                                                    <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit&amp;nbsp Record" UniqueName="column">
                                                                            </telerik:GridButtonColumn>--%>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPREF_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPREF_REFFERED_EMP_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Name" UniqueName="Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_Ref_Name" runat="server" Text='<%# Eval("APPREF_REFFERED_EMP_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="RElID" UniqueName="RELID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_RelID" runat="server" Text='<%# Eval("APPREF_RELATIONSHIP") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Relationship" UniqueName="Relationship">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_relationship" runat="server" Text='<%# Eval("APPREF_RELATIONSHIP_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                    <telerik:GridTemplateColumn HeaderText="Referred" UniqueName="Referred">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkReferred" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPREF_REFERRED")) %>'
                                                                                                Enabled="false" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </telerik:GridTemplateColumn>
                                                                                </Columns>
                                                                            </MasterTableView>
                                                                        </telerik:RadGrid>
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
                                    </Triggers>
                                </asp:UpdatePanel>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>