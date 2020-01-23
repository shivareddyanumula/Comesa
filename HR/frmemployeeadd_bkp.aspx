<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmemployeeadd.aspx.cs" Inherits="HR_frmemployeeadd" Culture="auto"
    EnableEventValidation="true" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%--<meta http-equiv="X-UA-Compatible" content="IE=8" />--%>

<script runat="server">


</script>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>--%>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <style type="text/css">
        div.RadGrid .rgPager .rgAdvPart {
            display: none;
        }
    </style>
    <%-- <asp:RegularExpressionValidator ID="rev_Height" runat="server" ControlToValidate="rtxt_Height"
                                                                Text="Only&nbsp;numberes&nbsp;allowed" Display="Dynamic" ValidationGroup="Physical"
                                                                ValidationExpression="^\d+$">
                                                            </asp:RegularExpressionValidator>--%><telerik:RadScriptBlock ID="RSB_Employee" runat="server">

                                                                <script type="text/javascript">
                                                                    function fnJSOnFormSubmit(sender, group) {
                                                                        var isGrpOneValid = Page_ClientValidate(group);
                                                                        var i;
                                                                        for (i = 0; i < Page_Validators.length; i++) {
                                                                            ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
                                                                        }
                                                                        for (i = 0; i < Page_ValidationSummaries.length; i++) {
                                                                            summary = Page_ValidationSummaries[i];
                                                                            if (isGrpOneValid) {
                                                                                sender.disabled = "disabled";
                                                                                return true;
                                                                            }

                                                                            if (fnJSDisplaySummary(summary.validationGroup)) {
                                                                                summary.style.display = "";
                                                                            }
                                                                        }
                                                                    }

                                                                    function onGenderCheck(sender, eventArgs) {
                                                                        var item = eventArgs.get_item();
                                                                        if (item.get_text().toUpperCase() == "HON. MR.") {
                                                                            var Maritalstatus = $find("<%= ddl_Gender.ClientID %>");
                                                                            Maritalstatus.set_text("Male");
                                                                        }
                                                                        else if (item.get_text().toUpperCase() == "HON. MS.") {
                                                                            var Maritalstatus = $find("<%= ddl_Gender.ClientID %>");
                                                                            Maritalstatus.set_text("Female");
                                                                            return;
                                                                        }
                                                                        else if (item.get_text().toUpperCase() == "HON. MRS.") {
                                                                            var Maritalstatus = $find("<%= ddl_Gender.ClientID %>");
                                                                            Maritalstatus.set_text("Female");
                                                                            return;
                                                                        }
                                                                        else if (item.get_text().toUpperCase() == "MR.") {
                                                                            var Maritalstatus = $find("<%= ddl_Gender.ClientID %>");
                                                                            Maritalstatus.set_text("Male");
                                                                        }
                                                                        else if (item.get_text().toUpperCase() == "MS.") {
                                                                            var Maritalstatus = $find("<%= ddl_Gender.ClientID %>");
                                                                            Maritalstatus.set_text("Female");
                                                                            return;
                                                                        }
                                                                        else if (item.get_text().toUpperCase() == "MRS.") {
                                                                            var Maritalstatus = $find("<%= ddl_Gender.ClientID %>");
                                                                                Maritalstatus.set_text("Female");
                                                                                return;
                                                                            }
                                                    }
                                                    function Rehire() {
                                                        debugger;
                                                        var btn = document.getElementById("btn_Update");
                                                        confirm("Are you sure.It Updates with the same data.");
                                                        return true;
                                                        //                if (confirm("Are you sure.It Updates with the same data.") == true) {
                                                        //                    return true;
                                                        //                }
                                                        //                else {
                                                        //                    return false;
                                                        //                }

                                                    }

                                                    function ConfirmOnDelete() {
                                                        if (document.getElementById('ctl00_cphDefault_lbl_Code').value != null) {
                                                            if (confirm("Are you sure. You want to change the status. It Updates the Employee Number?") == true)
                                                                return true;
                                                            else
                                                                return false;
                                                        }
                                                    }

                                                    // for loading the uploaded image
                                                    //            function LoadImage(path, img) {
                                                    //                //imgPrev = document.images[img];
                                                    //                document.getElementById('img').src = path;
                                                    //                //imgPrev.src = path;
                                                    //            }
                                                    function LoadImage(path) {
                                                        //imgPrev = document.images[img];
                                                        //document.getElementById('RBI_Employee_Image').src = path.value/;
                                                        //imgPrev.src = path;
                                                        CallServer(path.value, '');
                                                    }


                                                                </script>

                                                            </telerik:RadScriptBlock>

    <script type="text/javascript" src="../maintainScrollPosition_IE.js"></script>

    <table align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div>
                    <br />
                    <br />
                    <center>
                        <asp:Label ID="lblEmployee" runat="server" Font-Bold="True" meta:resourcekey="lblEmployee"></asp:Label>
                    </center>
                    <br />
                    <br />
                    <table align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <telerik:RadTabStrip ID="RTS_Employee" runat="server" MultiPageID="RMP_EmployeePage"
                                    SelectedIndex="0" Orientation="VerticalLeft">
                                    <Tabs>
                                        <telerik:RadTab runat="server" PageViewID="Personal" Text="Personal" meta:resourcekey="Personal"
                                            Selected="True">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Qualification" meta:resourcekey="Qual">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Skills" meta:resourcekey="Skills">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Experience" meta:resourcekey="Experience">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Contact" meta:resourcekey="Contact" Visible="false">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Language" meta:resourcekey="Lang">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Reference" meta:resourcekey="Reference"
                                            Visible="false">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Family" meta:resourcekey="Family">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Swipe" meta:resourcekey="SwipeCard" Visible="false">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="OT" meta:resourcekey="Overtime" Visible="false">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Weeklyoff" meta:resourcekey="WeeklyOff">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Picture" meta:resourcekey="Picture">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Other_Details" Text="Other Details">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Physical_Details" Text="Physical Details">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="SELF_LOGIN_DETAILS" Text="Self Login Details">
                                        </telerik:RadTab>
                                        <%-- <telerik:RadTab runat="server" PageViewID="OnSite_Details" Text="OnSite Details">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" PageViewID="Shift_Details" Text="Shift Details">
                                        </telerik:RadTab>--%>
                                        <telerik:RadTab runat="server" PageViewID="Important_Dates" Text="Important Dates & Docs">
                                        </telerik:RadTab>
                                        <%-- <telerik:RadTab runat="server" PageViewID="EMP_TDS" Text="Employee Tds">
                                                </telerik:RadTab>--%>
                                    </Tabs>
                                </telerik:RadTabStrip>
                            </td>
                            <td>
                                <telerik:RadMultiPage ID="RMP_EmployeePage" runat="server" meta:resourcekey="RMP_EmployeePage"
                                    SelectedIndex="0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                                    <telerik:RadPageView ID="Personal" runat="server" Selected="True" meta:resourcekey="Personal"
                                        Width="800px">
                                        <br />
                                        <table align="center">
                                            <tr>
                                                <td colspan="8">
                                                    <asp:Label ID="lbl_Personal" runat="server" Text="Employee Personal Information"
                                                        Font-Underline="True" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" align="right">
                                                    <%--<telerik:RadTextBox     ID="txt_AppCode" runat="server" ReadOnly="True" 
                                                                  TabIndex="1">
                                                            </telerik:RadTextBox>--%>
                                                    <asp:HiddenField ID="HF_APID" runat="server" />
                                                    <asp:HiddenField ID="HF_EMPID" runat="server" />
                                                    <asp:Label ID="lbl_Code" runat="server" Style="font-weight: 700; font-size: 14pt"></asp:Label>
                                                </td>
                                                <td align="right">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">&nbsp;<asp:Label ID="lbl_Rand" runat="server" Text="Random Number" Visible="False"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Applicant" runat="server" meta:resourcekey="lbl_Applicant"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Applicant" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                        OnSelectedIndexChanged="ddl_Applicant_SelectedIndexChanged" MaxHeight="120px"
                                                        TabIndex="1" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_title" runat="server" Text="Title" meta:resourcekey="lbl_title"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Title" runat="server" MaxHeight="120px" OnClientSelectedIndexChanged="onGenderCheck"
                                                        TabIndex="2" MarkFirstMatch="true" Filter="Contains">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Select" Value="Select" />
                                                            <telerik:RadComboBoxItem runat="server" Text="HON. Mr." Value="HON. Mr." />
                                                            <telerik:RadComboBoxItem runat="server" Text="HON. Ms." Value="HON. Ms." />
                                                            <telerik:RadComboBoxItem runat="server" Text="HON. Mrs." Value="HON. Mrs." />
                                                            <telerik:RadComboBoxItem runat="server" Text="Mr." Value="Mr." />
                                                            <telerik:RadComboBoxItem runat="server" Text="Ms." Value="Ms." />
                                                            <telerik:RadComboBoxItem runat="server" Text="Mrs." Value="Mrs." />
                                                            <telerik:RadComboBoxItem runat="server" Text="Hon." Value="Hon." />
                                                            <telerik:RadComboBoxItem runat="server" Text="Dr." Value="Dr." />
                                                            <telerik:RadComboBoxItem runat="server" Text="Prof." Value="Prof." />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_title" runat="server" ControlToValidate="ddl_Title"
                                                        Text="*" InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_title"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_FirstName" runat="server" meta:resourcekey="lbl_FirstName"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_FirstName" runat="server" AutoCompleteType="Disabled"
                                                        TabIndex="3" MaxLength="50">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_FirstName" runat="server" ControlToValidate="txt_FirstName"
                                                        Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_FirstName"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_MiddleName" runat="server" meta:resourcekey="lbl_MiddleName"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_AppMiddleName" runat="server" AutoCompleteType="Disabled"
                                                        TabIndex="4" MaxLength="50">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_LastName" runat="server" meta:resourcekey="lbl_LastName"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_AppLastName" runat="server" AutoCompleteType="Disabled"
                                                        TabIndex="5" MaxLength="50">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_lastname" runat="server" ErrorMessage="Please Enter Last Name"
                                                        Enabled="false" Text="*" ValidationGroup="Controls" ControlToValidate="txt_AppLastName"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Hobbies" runat="server" Text="Hobbies"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_Hobbies" runat="server" AutoCompleteType="Disabled"
                                                        MaxLength="500" TabIndex="6">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Gender" runat="server" meta:resourcekey="lbl_Gender"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Gender" runat="server" TabIndex="7" MarkFirstMatch="true" MaxHeight="120px">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Select" Value="Select" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Male" Value="Male" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Female" Value="Female" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Gender" runat="server" ControlToValidate="ddl_Gender"
                                                        InitialValue="Select" meta:resourcekey="rfv_Gender" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_DOB" runat="server" meta:resourcekey="lbl_DOB"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_DOB" runat="server" AutoPostBack="true" OnSelectedDateChanged="txt_DOB_SelectedDateChanged"
                                                        TabIndex="8">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="8" />
                                                        <DateInput AutoPostBack="True" DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy"
                                                            TabIndex="8">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_dob" runat="server" ControlToValidate="txt_DOB"
                                                        meta:resourcekey="rfv_dob" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_BloodGroup" runat="server" meta:resourcekey="lbl_BloodGroup"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_BloodGroup" runat="server" TabIndex="9" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" meta:resourcekey="RadComboBoxItem" Selected="True"
                                                                Text="Select" Value="Select" />
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
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAge" runat="server" meta:resourcekey="lblAge"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="lbl_Age" runat="server"></asp:Label>
                                                    </b>
                                                    <asp:Label ID="lbl_Max" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_MaritalStatus" runat="server" meta:resourcekey="lbl_MaritalStatus"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_MaritalStatus" runat="server" TabIndex="10" MarkFirstMatch="true" MaxHeight="120px">
                                                        <Items>
                                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Single" Value="Single" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Divorced" Value="Divorced" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Separated" Value="Separated" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Widowed" Value="Widowed" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Married" Value="Married" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_maritalstatus" runat="server" ControlToValidate="ddl_MaritalStatus"
                                                        InitialValue="Select" meta:resourcekey="rfv_maritalstatus" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Tribe" runat="server" meta:resourcekey="lbl_Tribe"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Tribe" runat="server" TabIndex="11" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Religion" runat="server" meta:resourcekey="lbl_Religion"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Religion" runat="server" MaxHeight="120px" TabIndex="12"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Religion" runat="server" ControlToValidate="ddl_Religion"
                                                        InitialValue="Select" meta:resourcekey="rfv_Religion" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Nationality" runat="server" meta:resourcekey="lbl_Nationality"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Nationality" runat="server" TabIndex="13" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Nationality" runat="server" ControlToValidate="ddl_Nationality"
                                                        InitialValue="Select" meta:resourcekey="rfv_Nationality" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCounty" runat="server" Text="District"></asp:Label>
                                                </td>
                                                <td><b>:</b></td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_County" runat="server" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td colspan="8">
                                                    <asp:Label ID="lbl_title1" runat="server" Text="Assignment Information" Font-Bold="true"
                                                        Font-Underline="True"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_DOJ" runat="server" meta:resourcekey="lbl_DOJ"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_DOJ" runat="server" AutoPostBack="True" MinDate="1900-01-01"
                                                        OnSelectedDateChanged="txt_DOJ_SelectedDateChanged" TabIndex="14">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="14" />
                                                        <DateInput AutoPostBack="True" DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy"
                                                            TabIndex="14">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:CompareValidator ID="cv_DOJ" runat="server" ControlToCompare="txt_DOB" ControlToValidate="txt_DOJ"
                                                        Display="Dynamic" meta:resourcekey="cv_DOJ" Operator="GreaterThan" Text="*" Type="Date"
                                                        ValidationGroup="Controls"></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="rfv_DOJ" runat="server" ControlToValidate="txt_DOJ"
                                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_DOC" runat="server" meta:resourcekey="lbl_DOC"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <b>
                                                        <telerik:RadDatePicker ID="txt_DOC" runat="server" meta:resourcekey="txt_DOC" MinDate="1900-01-01"
                                                            TabIndex="15">
                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                            </Calendar>
                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="15" />
                                                            <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" TabIndex="15">
                                                            </DateInput>
                                                        </telerik:RadDatePicker>
                                                    </b>
                                                </td>
                                                <td>
                                                    <asp:CompareValidator ID="cv_DOC" runat="server" ControlToCompare="txt_DOJ" ControlToValidate="txt_DOC"
                                                        Display="Dynamic" meta:resourcekey="cv_DOC" Operator="GreaterThanEqual" Text="*"
                                                        Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" AutoPostBack="true" MaxHeight="120px"
                                                        MarkFirstMatch="true" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"
                                                        TabIndex="16" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="ddl_BusinessUnit"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_BusinessUnit"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_Directorate" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Filter="Contains"
                                                        runat="server" AutoPostBack="True" CausesValidation="False" MarkFirstMatch="true" MaxHeight="120px" TabIndex="17">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                     <asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ControlToValidate="rcmb_Directorate"
                                                        InitialValue="Select" meta:resourcekey="rfv_Directorate" ErrorMessage="Please Select Directorate" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Department" runat="server" meta:resourcekey="lbl_Department"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Department" runat="server" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="120px"
                                                        OnSelectedIndexChanged="ddl_Department_SelectedIndexChanged" TabIndex="18" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_Department" runat="server" ControlToValidate="ddl_Department"
                                                        InitialValue="Select" meta:resourcekey="RFV_Department" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <!--modified the below label "function" to "sub department" -->
                                                    <asp:Label ID="lbl_Devision" runat="server" Text="Sub Department"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_Devision" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                                        AutoPostBack="true" TabIndex="19" OnSelectedIndexChanged="rcmb_Devision_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <%--<asp:RequiredFieldValidator ID="rfv_rcmb_Devision" runat="server" ControlToValidate="rcmb_Devision" ErrorMessage="Please Select Function"
                                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_Devision" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>

                                                <%--    <td>
                                    <asp:Label ID="lbl_DPCode" runat="server" meta:resourcekey="lbl_DPCode" Text="Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DCode" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="4" Enabled="false"> 
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>--%>

                                                <td>
                                                    <asp:Label ID="lbl_Status" runat="server" meta:resourcekey="lbl_Status"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Mode" runat="server" MaxHeight="120px" TabIndex="20"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Mode" runat="server" ControlToValidate="ddl_Mode"
                                                        InitialValue="Select" meta:resourcekey="rfv_Mode" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="visibility: hidden;">
                                                    <asp:Label ID="lbl_SubDivision" runat="server" Text="Sub Function"></asp:Label>
                                                </td>
                                                <td style="visibility: hidden;">
                                                    <b>:</b>
                                                </td>
                                                <td style="visibility: hidden;">
                                                    <telerik:RadComboBox ID="rcmb_SubDivision" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:Label ID="lbl_JobInfo" runat="server" Text="Job Information" Font-Underline="True"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_job" runat="server" meta:resourcekey="lbl_job"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <%--<asp:Label ID="lbl_jobName" runat="server"></asp:Label>--%>
                                                    <telerik:RadComboBox ID="ddl_Jobs" runat="server" AutoPostBack="True" MaxHeight="120px"
                                                        MarkFirstMatch="true" OnSelectedIndexChanged="ddl_Jobs_SelectedIndexChanged"
                                                        TabIndex="21" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Jobs" runat="server" ControlToValidate="ddl_Jobs"
                                                        InitialValue="Select" Text="*" ForeColor="Red" ValidationGroup="Controls" ErrorMessage="Please Select Job"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Designation" runat="server" meta:resourcekey="lbl_Designation"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Designation" runat="server" MaxHeight="120px" MarkFirstMatch="true"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_Designation_SelectedIndexChanged"
                                                        TabIndex="22" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                    <asp:HiddenField ID="hdnDesignation" runat="server" />
                                                    <%--<telerik:RadComboBox ID="ddl_Designation" runat="server" AutoPostBack="True" MaxHeight="120px"
                                                        MarkFirstMatch="true" OnSelectedIndexChanged="ddl_Designation_SelectedIndexChanged"
                                                        TabIndex="20">
                                                    </telerik:RadComboBox>--%>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Designation" runat="server" ControlToValidate="ddl_Designation"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_Designation"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Sup_BusinessUnit" runat="server" Text="Supervisor Business Unit"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Sup_BusinessUnit" runat="server" AutoPostBack="true" Filter="Contains"
                                                        TabIndex="23" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="ddl_Sup_BusinessUnit_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_Supervisor" runat="server" meta:resourcekey="lbl_Supervisor"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Supervisor" runat="server" AutoPostBack="True" MaxHeight="120px"
                                                        MarkFirstMatch="true" OnSelectedIndexChanged="ddl_Supervisor_SelectedIndexChanged"
                                                        TabIndex="24" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_StartDate" runat="server" meta:resourcekey="lbl_StartDate"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_startDate" runat="server" MinDate="1900-01-01" Enabled="False">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:CompareValidator ID="cv_StartDate" runat="server" ControlToCompare="txt_DOJ"
                                                        ControlToValidate="txt_startDate" Display="Dynamic" meta:resourcekey="cv_StartDate"
                                                        Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                </td>


                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server" Text="Employee&nbsp;Category"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmbCategory" runat="server" MarkFirstMatch="true" TabIndex="29" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rcmbCategory" runat="server" ControlToValidate="rcmbCategory"
                                                        ErrorMessage="Please Select Employee Category" ValidationGroup="Controls" InitialValue="Select"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>


                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_EmpStatus" runat="server" meta:resourcekey="lbl_EmpStatus"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_EmpStatus" runat="server" MaxHeight="120px" AutoPostBack="True"
                                                        MarkFirstMatch="true" OnSelectedIndexChanged="ddl_EmpStatus_SelectedIndexChanged"
                                                        onChange="ConfirmOnDelete();" TabIndex="25" Filter="Contains">
                                                        <%--<Items>
                                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Permanent and Pensionable" Value="Permanent and Pensionable" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Contract" Value="Contract" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Probation" Value="Probation" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Secondment" Value="Secondment" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Members of Parliament" Value="Members of Parliament" />
                                                            <telerik:RadComboBoxItem runat="server" Text="Members of Senate" Value="Members of Senate" />
                                                        </Items>--%>
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_EmpStatus" runat="server" ControlToValidate="ddl_EmpStatus"
                                                        InitialValue="Select" meta:resourcekey="rfv_EmpStatus" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_EndDate" runat="server" meta:resourcekey="lbl_EndDate"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_endDate" runat="server" MinDate="1900-01-01" Enabled="true">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:CompareValidator ID="cv_endDate" runat="server" ControlToCompare="txt_startDate"
                                                        ControlToValidate="txt_endDate" Display="Dynamic" meta:resourcekey="cv_endDate"
                                                        Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_SalaryStruct" runat="server" meta:resourcekey="lbl_SalaryStruct"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_SalaryStructure" runat="server" TabIndex="26" meta:resourcekey="ddl_SalaryStructure"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_SalaryStructure" runat="server" ControlToValidate="ddl_SalaryStructure"
                                                        Text="*" InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_SalaryStructure"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Currency" runat="server" meta:resourcekey="lbl_Currency"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Currency" runat="server" MarkFirstMatch="true" TabIndex="27" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Currency" runat="server" ControlToValidate="ddl_Currency"
                                                        InitialValue="Select" meta:resourcekey="rfv_Currency" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_LeaveStruct" runat="server" meta:resourcekey="lbl_LeaveStruct"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_LeaveStructure" runat="server" MaxHeight="120px" TabIndex="28"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_LeaveStructure" runat="server" ControlToValidate="ddl_LeaveStructure"
                                                        Text="*" InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_LeaveStructure"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Shift" runat="server" meta:resourcekey="lbl_Shift"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Shift" runat="server" MaxHeight="120px" TabIndex="29"
                                                        MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Shift" runat="server" ControlToValidate="ddl_Shift"
                                                        Text="*" InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_Shift"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btn_Shift_refresh" runat="server" ImageUrl="~/Images/refreshIcon.png"
                                                        OnClick="btn_Shift_refresh_Click" />
                                                </td>
                                            </tr>
                                            <%--                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server" Text="Employee&nbsp;Category"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmbCategory" runat="server" MarkFirstMatch="true" TabIndex="29">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_rcmbCategory" runat="server" ControlToValidate="rcmbCategory"
                                                        ErrorMessage="Please Select Employee Category" ValidationGroup="Controls" InitialValue="Select"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_baseloc" Text="Base Location" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <b></b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_baseloc" runat="server" MaxHeight="120px" TabIndex="30" Visible="false"
                                                        MarkFirstMatch="true">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>--%>
                                            <%--<asp:RequiredFieldValidator ID="rfv_ddl_baseloc" runat="server" ControlToValidate="ddl_baseloc"
                                                        ErrorMessage="Please Select Base Location" ValidationGroup="Controls" InitialValue="Select"
                                                        Text="*"></asp:RequiredFieldValidator>--%>
                                            <%--</td>
                                                <td>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_CurrentProject" runat="server" Text="Current&nbsp;Project" Visible="false"></asp:Label>
                                                </td>
                                                <td style="visibility: hidden">
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_CurrentProject" runat="server" AutoCompleteType="Disabled"
                                                        MaxLength="200" Visible="false">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_ReasonForSeperation" Text="Reason&nbsp;For&nbsp;Seperation" Visible="false"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Seperator" Text=":" Visible="false" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_ReasonForSeperation" runat="server" Visible="false" MaxHeight="120px"
                                                        MarkFirstMatch="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:Label ID="lbl_title3" runat="server" Text="Salary Information" Font-Bold="true"
                                                        Font-Underline="True"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_period" runat="server" Text="Financial Period"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_Period" runat="server" TabIndex="30" MarkFirstMatch="true"
                                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_EmpPeriod" runat="server" Text="*" InitialValue="Select"
                                                        ControlToValidate="rcmb_Period" ErrorMessage="Please Select Period" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Grade" runat="server" Text="Grade"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Grade" runat="server" TabIndex="31" MarkFirstMatch="true"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_Grade_SelectedIndexChanged" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_EmpGrade" runat="server" Text="*" InitialValue="Select"
                                                        ControlToValidate="ddl_Grade" ErrorMessage="Please Select Grade" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <%-- <td>
                                                    <asp:Label ID="lbl_GrossSal" runat="server" meta:resourcekey="lbl_GrossSal"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txt_GrossSalary" runat="server" IncrementSettings-InterceptArrowKeys="true"
                                                        IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" 
                                                        Culture="English (United States)" OnTextChanged="txt_GrossSalary_TextChanged"
                                                        AutoPostBack="True" MinValue="0" MaxLength="12" Enabled="false">
                                                        <IncrementSettings Step="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td id="td_MonthlySalary" runat="server">
                                                    <asp:RequiredFieldValidator ID="rfv_GrossSalary" runat="server" ControlToValidate="txt_GrossSalary"
                                                        Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_GrossSalary"></asp:RequiredFieldValidator>
                                                </td>
                                                <td id="td_Empty" runat="server">
                                                </td>--%>
                                                <td>
                                                    <asp:Label ID="lbl_Slab" runat="server" Text="Salary Slab" meta:resourcekey="lbl_Slab"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Slabs" runat="server" TabIndex="32" MarkFirstMatch="true"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_Slabs_SelectedIndexChanged" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_Slabs" runat="server" Text="*" InitialValue="Select"
                                                        ControlToValidate="ddl_Slabs" ErrorMessage="Please Select Slab" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="tr_AnnualSalary" runat="server">
                                                <td>
                                                    <asp:Label ID="lbl_AnnualGrossSal" runat="server" Text="Annual Gross Salary"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txt_AnnualGrossSalary" runat="server" IncrementSettings-InterceptArrowKeys="true"
                                                        IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" Culture="English (United States)"
                                                        AutoPostBack="True" MinValue="0" OnTextChanged="txt_AnnualGrossSalary_TextChanged">
                                                        <IncrementSettings Step="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_AnnualGrossSalary" runat="server" ControlToValidate="txt_AnnualGrossSalary"
                                                        Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter Annual Gross Salary"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_AnnualBasicPay" runat="server" Text="Annual&nbsp;Basic&nbsp;Salary"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txt_AnnualBasicSalary" runat="server" Culture="English (United States)"
                                                        IncrementSettings-InterceptArrowKeys="True" IncrementSettings-InterceptMouseWheel="True"
                                                        IncrementSettings-Step="0" Enabled="false">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td></td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Address" runat="server" meta:resourcekey="lbl_Address"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_Address" runat="server" AutoCompleteType="Disabled" MaxLength="5000"
                                                        TabIndex="33">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_BasicPay" runat="server" meta:resourcekey="lbl_BasicPay"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txt_BasicPay" runat="server" Culture="English (United States)"
                                                        IncrementSettings-InterceptArrowKeys="True" IncrementSettings-InterceptMouseWheel="True"
                                                        IncrementSettings-Step="0">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td></td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Previouspromotion" runat="server" meta:resourcekey="lbl_Previouspromotion"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_previousProm" runat="server" MinDate="" TabIndex="34">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="34" />
                                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" TabIndex="34">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Remarks" runat="server" meta:resourcekey="lbl_Remarks"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txt_Remarks" runat="server" AutoCompleteType="Disabled" MaxLength="5000"
                                                        TabIndex="33">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:Label ID="lbl_NotficPeriod" runat="server" meta:resourcekey="lbl_NotficPeriod"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxt_NoticePeriod" runat="server" MinValue="0" MaxLength="2"
                                                        TabIndex="35">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>Days
                                                </td>
                                                <td>&nbsp;
                                                </td>

                                                <td>
                                                    <asp:Label ID="lblEmpStatus" runat="server" meta:resourcekey="lblEmpStatus"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddl_Employee_Status" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_Employee_Status" runat="server" ErrorMessage="Please Select Employee Status"
                                                        ValidationGroup="Controls" InitialValue="Select" ControlToValidate="ddl_Employee_Status"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_ProbDate" runat="server" meta:resourcekey="lbl_ProbDate"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_probDate" runat="server" MinDate="1900-01-01" TabIndex="36">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="36" />
                                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" TabIndex="36">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:CompareValidator ID="cv_probDate" runat="server" Text="*" ValidationGroup="Controls"
                                                        ControlToCompare="txt_DOC" ControlToValidate="txt_probDate" Display="Dynamic"
                                                        Type="Date" Operator="GreaterThanEqual" meta:resourcekey="cv_probDate"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cv_probDate_1" runat="server" Text="*" ValidationGroup="Controls"
                                                        ControlToCompare="txt_DOJ" ControlToValidate="txt_probDate" Display="Dynamic"
                                                        Type="Date" Operator="GreaterThanEqual" meta:resourcekey="cv_probDate_1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <%-- <tr runat="server" id="contract">31.5.2016
                                                <td>
                                                    <asp:Label ID="lbl_Contract_Date" runat="server" meta:resourcekey="lbl_Contract_Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txt_Contract_Date" runat="server" TabIndex="37">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="37" />
                                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" TabIndex="37">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RFV_Contract_Date" runat="server" ErrorMessage="Please Enter Contract End Date"
                                                        ValidationGroup="Controls" ControlToValidate="txt_Contract_Date" Text="*"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_startDate"
                                                        ControlToValidate="txt_Contract_Date" ErrorMessage="Contract end date should be greater than date of join"
                                                        Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>
                                                </td>

                                            </tr>--%>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Contract_Start" runat="server" Text="Contract Start Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdp_contract_start" runat="server" TabIndex="37"
                                                        OnSelectedDateChanged="rdp_contract_start_SelectedDateChanged" AutoPostBack="true">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="37" />
                                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" TabIndex="37">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                    <%--<asp:RequiredFieldValidator ID="rfv_ContractStart" ErrorMessage="Please Enter Contract Start Date" runat="server" 
                                                        SetFocusOnError="true" Text="*" ControlToValidate="rdp_contract_start" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td>&nbsp
                                                </td>

                                                <td>
                                                    <asp:Label ID="lbl_Contract_End" runat="server" Text="Contract End Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdp_contract_end" runat="server" TabIndex="38" OnSelectedDateChanged="rdp_contract_end_SelectedDateChanged" AutoPostBack="true">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="38" />
                                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" TabIndex="38">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>

                                                </td>

                                            </tr>

                                            <%-- <tr>   divya31.5.2016
                                                <td>
                                                    <asp:Label ID="lbl_IncrementMonth" runat="server" meta:resourcekey="lbl_IncrementMonth" Text="Increment Month"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_IncrementMonth" runat="server" MarkFirstMatch="true" Enabled="false">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                                            <telerik:RadComboBoxItem Text="January" Value="1" />
                                                            <telerik:RadComboBoxItem Text="April" Value="2" />
                                                            <telerik:RadComboBoxItem Text="July" Value="3" />
                                                           divya31.5.2016    <telerik:RadComboBoxItem Text="October" Value="4" />--%>

                                            <%--<telerik:RadComboBoxItem Text="January" Value="0101" />
                                                            <telerik:RadComboBoxItem Text="April" Value="0401" />
                                                            <telerik:RadComboBoxItem Text="July" Value="0701" />
                                                            <telerik:RadComboBoxItem Text="October" Value="1001" />--%>
                                            <%--   </Items>
                                                    </telerik:RadComboBox>
                                              31.5.2016  </td>--%>
                                            <%--<td></td>--%>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_IncrementDate" runat="server" meta:resourcekey="lbl_IncrementDate" Text="Increment Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker runat="server" ID="txt_IncrementDate" AutoPostBack="true">
                                                        <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy" ReadOnly="true" autocomplete="off">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_IsManual" runat="server" Text="Is Manual Entry"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chk_IsManual" runat="server" AutoPostBack="true" Checked="false"
                                                        TabIndex="38" OnCheckedChanged="chk_IsManual_CheckedChanged" />
                                                </td>
                                                <td></td>
                                                <td id="td_lbl_empcode" runat="server" visible="false">
                                                    <asp:Label ID="lbl_empcode" runat="server" Text="Enter Employee Code"></asp:Label>
                                                </td>
                                                <td id="td_colon_empcode" runat="server" visible="false">
                                                    <b>:</b>
                                                </td>
                                                <td id="td_rtxt_empcode" runat="server" visible="false">
                                                    <telerik:RadTextBox ID="rtxt_empcode" runat="server" MaxLength="50">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td id="td_rfv_empcode" runat="server" visible="false">
                                                    <asp:RequiredFieldValidator ID="RFV_rtxt_empcode" runat="server" ErrorMessage="Please Enter Employee Code"
                                                        ValidationGroup="Controls" ControlToValidate="rtxt_empcode" Text="*" Enabled="false"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Supismandatory" runat="server" meta:resourcekey="lbl_Supismandatory"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chk_Mandatory" runat="server" Checked="false" Visible="true" TabIndex="39" />
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <%-- <asp:Label ID="lbl_Isvariablepay" runat="server" Text="Is VariablePay" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td id="text" runat="server" visible="false">
                                                    <%--<b>:</b>--%>
                                                </td>
                                                <td>
                                                    <%--<asp:CheckBox ID="chk_Isvariablepay" runat="server" AutoPostBack="true" OnCheckedChanged="chk_Isvariablepay_CheckedChanged"
                                                        Visible="false" TabIndex="41" />--%>
                                                </td>
                                            </tr>
                                            <tr id="VariablePay" runat="server" visible="false">
                                                <td>
                                                    <asp:Label ID="lbl_Count" runat="server" Text="No. Of Times Payable"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxt_Count" MinValue="0" MaxValue="50" runat="server"
                                                        AllowOutOfRangeAutoCorrect="true" DataType="System.Int32" TabIndex="43">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_Amount" runat="server" Text="Variable Amount"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxt_Amount" runat="server" MinValue="0" MaxLength="12"
                                                        TabIndex="44">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table align="right">
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update"
                                                        meta:resourcekey="btn_Update" ValidationGroup="Controls" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" UseSubmitBehavior="false" ValidationGroup="Controls"
                                                        OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel"
                                                        meta:resourcekey="btn_Cancel" />
                                                </td>
                                                <td>
                                                    <%--<asp:ConfirmButtonExtender ID="cnfrmbtnextn" runat="server" ConfirmText="Are you sure..?It updates with the same data."
                                                        TargetControlID="btn_Update" ConfirmOnFormSubmit="false">
                                                    </asp:ConfirmButtonExtender>--%>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Qualification" runat="server" meta:resourcekey="Qualification"
                                        Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Category" runat="server" meta:resourcekey="lbl_Category"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddl_Category" runat="server" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Category" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="ddl_Category" InitialValue="Select" meta:resourcekey="rfv_Category"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Institute" runat="server" Text="Institute" meta:resourcekey="lbl_Institute"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_Institute" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="60">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_Institute" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="txt_Institute" meta:resourcekey="rfv_Institute"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_YearPass" runat="server" meta:resourcekey="lbl_YearPass"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="txt_YearofPass" runat="server" DataType="System.Int32"
                                                                    MinValue="1900" MaxValue="9999" MaxLength="4">
                                                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_yearofpass" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="txt_YearofPass" meta:resourcekey="rfv_yearofpass"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Percentage" runat="server" meta:resourcekey="lbl_Percentage"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="txt_Percentage" runat="server" MinValue="35" MaxValue="100"
                                                                    MaxLength="5">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_percentage" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="txt_Percentage" meta:resourcekey="rfv_percentage"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl__Grade" runat="server" meta:resourcekey="lbl__Grade"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddl__Grade" runat="server" meta:resourcekey="ddl__Grade"
                                                                    MarkFirstMatch="true">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="Select" Value="0" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="A" Value="A" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="B" Value="B" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="C" Value="C" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="D" Value="D" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_grade" runat="server" Text="*" ValidationGroup="Qual"
                                                                    ControlToValidate="ddl__Grade" InitialValue="Select" meta:resourcekey="rfv_grade"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Qual_Add" runat="server" OnClick="btn_Qual_Add_Click" Text="Add"
                                                                    meta:resourcekey="btn_Qual_Add" UseSubmitBehavior="false" ValidationGroup="Qual" OnClientClick="fnJSOnFormSubmit(this,'Qual')" />
                                                                <asp:Button ID="btn_Qual_Correct" runat="server" OnClick="btn_Qual_Correct_Click"
                                                                    ValidationGroup="Qual" Text="Correct" meta:resourcekey="btn_Qual_Correct" UseSubmitBehavior="false"
                                                                    OnClientClick="fnJSOnFormSubmit(this,'Qual')"/>
                                                                <asp:Button ID="btn_Qual_Cancel" runat="server" OnClick="btn_Qual_Cancel_Click" Text="Cancel"
                                                                    meta:resourcekey="btn_Qual_Cancel" />
                                                            </td>
                                                            <td align="center"></td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center" width="70%">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_Qualification" runat="server" AutoGenerateColumns="False"
                                                                    GridLines="None" OnItemCommand="RG_Qualification_ItemCommand" Width="100%" meta:resourcekey="RG_Qualification">
                                                                    <ClientSettings>
                                                                        <Selecting AllowRowSelect="True" />
                                                                    </ClientSettings>
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column"
                                                                                meta:resourcekey="GridButtonColumn">
                                                                                <ItemStyle Width="80px" />
                                                                            </telerik:GridButtonColumn>--%>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="ID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPQFN_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="QualID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPQFN_QUALIFICATION_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Qualification" meta:resourcekey="Qualification">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_AppQual" runat="server" Text='<%# Eval("APPQFN_QUALIFICATION_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Institute" meta:resourcekey="Institute">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_AppInstitute" runat="server" Text='<%# Eval("APPQFN_INSTITUTE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="YearPass" meta:resourcekey="YearPass">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_AppYearPass" runat="server" Text='<%# Eval("APPQFN_PASSEDYEAR") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Percentage" meta:resourcekey="Percentage">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_AppPercentage" runat="server" Text='<%# Eval("APPQFN_PERCENTAGE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Grade" meta:resourcekey="Grade">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_AppGrade" runat="server" Text='<%# Eval("APPQFN_GRADE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column"
                                                                                meta:resourcekey="GridButtonColumn">
                                                                                <ItemStyle Width="80px" />
                                                                            </telerik:GridButtonColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Skills" runat="server" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Skill" runat="server" Text="Skill&nbsp;Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcb_Skill" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_SkillName" runat="server" Text="*" InitialValue="Select"
                                                                    ControlToValidate="rcb_Skill" ValidationGroup="Skills" Display="Dynamic" ErrorMessage="Please Select Skill Name"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_YearLastUsed" runat="server" Text="Last&nbsp;Used"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcb_YearLastUsed" runat="server" MarkFirstMatch="true" MaxHeight="120px">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                                        <telerik:RadComboBoxItem Text="Beginner" Value="1" />
                                                                        <telerik:RadComboBoxItem Text="Intermediate" Value="2" />
                                                                        <telerik:RadComboBoxItem Text="Expert" Value="3" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_YearLastUsed" runat="server" ControlToValidate="rcb_YearLastUsed"
                                                                    Text="*" ValidationGroup="Skills" Display="Dynamic" ErrorMessage="Please Select Year Last Used"
                                                                    InitialValue="Select"></asp:RequiredFieldValidator>
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
                                                                <telerik:RadComboBox ID="rcb_ExpertLevel" runat="server" MarkFirstMatch="true">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                                        <telerik:RadComboBoxItem Text="Beginner" Value="1" />
                                                                        <telerik:RadComboBoxItem Text="Intermediate" Value="2" />
                                                                        <telerik:RadComboBoxItem Text="Expert" Value="3" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Expertise" runat="server" ErrorMessage="Please Select Expertise"
                                                                    Text="*" ValidationGroup="Skills" ControlToValidate="rcb_ExpertLevel" InitialValue="Select"
                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Button ID="btn_Skill_Add" runat="server" Text="Add" OnClick="btn_Skill_Add_Click"
                                                                    UseSubmitBehavior="false" ValidationGroup="Skills" OnClientClick="fnJSOnFormSubmit(this,'Skills')" />
                                                                <asp:Button ID="btn_Skill_Correct" runat="server" Text="Correct" UseSubmitBehavior="false"
                                                                  ValidationGroup="Skills"  OnClientClick="fnJSOnFormSubmit(this,'Skills')" OnClick="btn_Skill_Correct_Click" />
                                                                <%-- --%><asp:Button ID="btn_Skill_Cancel" runat="server" Text="Cancel" OnClick="btn_Skill_Cancel_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_Skills" runat="server" GridLines="None" Width="100%" AutoGenerateColumns="False"
                                                                    OnItemCommand="RG_Skills_ItemCommand">
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
                                                                            <telerik:GridTemplateColumn HeaderText="Last&nbsp;Used" UniqueName="APPSKL_LASTUSED">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Skill_LastUsed" runat="server" Text='<%# Eval("APPSKL_LASTUSED") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_EXPERT_ID" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Skill_Exp_ID" runat="server" Text='<%# Eval("APPSKL_EXPERT") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="Expertise" UniqueName="APPSKL_EXPERT">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Skill_Expertise" runat="server" Text='<%# Eval("APPSKL_EXPERT_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                                            </telerik:GridButtonColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <FilterMenu>
                                                                    </FilterMenu>
                                                                    <HeaderContextMenu>
                                                                    </HeaderContextMenu>
                                                                </telerik:RadGrid>
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Experience" runat="server" meta:resourcekey="Experience"
                                        Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Serial" runat="server" meta:resourcekey="lbl_Serial"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_Serial" runat="server" Enabled="False">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_Reason" runat="server" meta:resourcekey="lbl_Reason"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_ReasonRelieve" runat="server" TabIndex="5" MaxLength="100">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_ReasonRelieve" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_ReasonRelieve" ControlToValidate="txt_ReasonRelieve"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_CompanyName" runat="server" meta:resourcekey="lbl_CompanyName"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_CompanyName" runat="server" TabIndex="1" MaxLength="50">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_CompanyName" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_CompanyName" ControlToValidate="txt_CompanyName"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_RelieveDate" runat="server" meta:resourcekey="lbl_RelieveDate"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="txt_RelieveDate" runat="server" TabIndex="6">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_RelieveDate" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_RelieveDate" ControlToValidate="txt_RelieveDate"></asp:RequiredFieldValidator>--%>
                                                                <asp:CompareValidator ID="cv_RelieveDate" runat="server" ControlToCompare="txt_JoinDate"
                                                                    ControlToValidate="txt_RelieveDate" Display="Dynamic" meta:resourcekey="cv_RelieveDate"
                                                                    Operator="GreaterThan" Text="*" Type="Date" ValidationGroup="Exp"></asp:CompareValidator>
                                                                <asp:CompareValidator ID="cv_RelJoinDate" runat="server" ControlToCompare="txt_DOJ"
                                                                    ControlToValidate="txt_RelieveDate" Display="Dynamic" meta:resourcekey="cv_RelJoinDate"
                                                                    Operator="LessThan" Text="*" Type="Date" ValidationGroup="Exp" ErrorMessage="Experience Relieving Date Should be Less Than Date Of Join"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_JoinDate" runat="server" meta:resourcekey="lbl_JoinDate"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="txt_JoinDate" runat="server" TabIndex="2">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:RequiredFieldValidator ID="rfv_JoinDate" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_JoinDate" ControlToValidate="txt_JoinDate"></asp:RequiredFieldValidator>--%>
                                                                <asp:CompareValidator ID="cv_joindate" runat="server" ControlToCompare="txt_DOJ"
                                                                    ControlToValidate="txt_JoinDate" Display="Dynamic" meta:resourcekey="cv_joindate"
                                                                    Operator="LessThan" Text="*" Type="Date" ValidationGroup="Exp"></asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_RelSalary" runat="server" meta:resourcekey="lbl_RelSalary"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="txt_RelSalary" runat="server" IncrementSettings-InterceptArrowKeys="true"
                                                                    IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" TabIndex="7"
                                                                    MinValue="0" MaxLength="12">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_RelSalary" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_RelSalary" ControlToValidate="txt_RelSalary"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_JoinSalary" runat="server" meta:resourcekey="lbl_JoinSalary"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="txt_JoinSalary" runat="server" TabIndex="3" IncrementSettings-InterceptArrowKeys="true"
                                                                    IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" MinValue="0"
                                                                    MaxLength="12">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:RequiredFieldValidator ID="rfv_JoinSalary" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_JoinSalary" ControlToValidate="txt_JoinSalary"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_RelDesc" runat="server" meta:resourcekey="lbl_RelDesc"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_RelDesc" runat="server" TabIndex="8" MaxLength="500">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_RelDesc" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_RelDesc" ControlToValidate="txt_RelDesc"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_JoinDesc" runat="server" meta:resourcekey="lbl_JoinDesc"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_JoinDesc" runat="server" TabIndex="4" MaxLength="50">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_JoinDesc" runat="server" Text="*" ValidationGroup="Exp"
                                                                    Display="Dynamic" meta:resourcekey="rfv_JoinDesc" ControlToValidate="txt_JoinDesc"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td></td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td></td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Exp_Add" runat="server" OnClick="btn_Exp_Add_Click" Text="Add"
                                                                    TabIndex="9" meta:resourcekey="btn_Exp_Add" UseSubmitBehavior="false" ValidationGroup="Exp" OnClientClick="fnJSOnFormSubmit(this,'Exp')" />
                                                                <asp:Button ID="btn_Exp_Correct" runat="server" OnClick="btn_Exp_Correct_Click" Text="Correct"
                                                                    TabIndex="9" meta:resourcekey="btn_Exp_Correct" UseSubmitBehavior="false" ValidationGroup="Exp" OnClientClick="fnJSOnFormSubmit(this,'Exp')" />
                                                                <asp:Button ID="btn_Exp_Cancel" runat="server" OnClick="btn_Exp_Cancel_Click" Text="Cancel"
                                                                    TabIndex="11" meta:resourcekey="btn_Exp_Cancel" />
                                                            </td>
                                                            <td align="center">&nbsp;
                                                            </td>
                                                            <td></td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_Experience" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                    OnItemCommand="RG_Experience_ItemCommand" Width="100%" meta:resourcekey="RG_Experience">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <%--<telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column" meta:resourcekey="Edit_Rec_Exp">
                                                                            </telerik:GridButtonColumn>--%>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_ID" Visible="False" meta:resourcekey="ExpID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPEXP_ID") %>' Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_SERIAL" meta:resourcekey="ExpSerial">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_Serial" runat="server" Text='<%# Eval("APPEXP_SERIAL") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_COMPANY" meta:resourcekey="CompName">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_CompName" runat="server" Text='<%# Eval("APPEXP_COMPANY") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_JOINDATE" meta:resourcekey="joinDate">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_JoinDate" runat="server" Text='<%# Eval("APPEXP_JOINDATE") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_JOINSAL" meta:resourcekey="joinsalary">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_JoinSal" runat="server" Text='<%# Eval("APPEXP_JOINSAL") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_JOINDESC" meta:resourcekey="joindesc">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_JoinDesc" runat="server" Text='<%# Eval("APPEXP_JOINDESC") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_REASONREL" meta:resourcekey="reasonrel">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_RelReason" runat="server" Text='<%# Eval("APPEXP_REASONREL") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_RELDATE" Visible="False" meta:resourcekey="relievedate">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_RelDate" runat="server" Text='<%# Eval("APPEXP_RELDATE") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_RELSAL" Visible="False" meta:resourcekey="relievesal">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_RelSalary" runat="server" Text='<%# Eval("APPEXP_RELSAL") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="APPEXP_REASONDESC" Visible="False" meta:resourcekey="relievedesc">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Exp_RelDesc" runat="server" Text='<%# Eval("APPEXP_REASONDESC") %>'
                                                                                        Width="100%"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column" meta:resourcekey="Edit_Rec_Exp">
                                                                            </telerik:GridButtonColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                </telerik:RadGrid>
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Contact" runat="server" meta:resourcekey="Contact" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_conserial" runat="server" meta:resourcekey="lbl_conserial"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_Serail_C" runat="server" ReadOnly="True">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Serail_C" runat="server" ControlToValidate="txt_Serail_C"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Serail_C" Text="*" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ConCompany" runat="server" meta:resourcekey="lbl_ConCompany"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_Company_C" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="50">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Company_C" runat="server" ControlToValidate="txt_Company_C"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Company_C" Text="*" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ContactPerson" runat="server" meta:resourcekey="lbl_ContactPerson"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_ContactName" runat="server" AutoCompleteType="Disabled"
                                                                    MaxLength="100">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_ContactName" runat="server" ControlToValidate="txt_ContactName"
                                                                    Display="Dynamic" meta:resourcekey="rfv_ContactName" Text="*" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_PhoneNumber" runat="server" meta:resourcekey="lbl_PhoneNumber"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadMaskedTextBox ID="txt_PhoneNumber" runat="server" DisplayMask="###-###-####"
                                                                    Mask="(###) ###-####" TextWithLiterals="() -">
                                                                </telerik:RadMaskedTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_PhoneNumber" runat="server" ControlToValidate="txt_PhoneNumber"
                                                                    Display="Dynamic" meta:resourcekey="rfv_PhoneNumber" Text="*" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl__Address" runat="server" meta:resourcekey="lbl__Address"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_Address_C" runat="server" AutoCompleteType="Disabled"
                                                                    CausesValidation="True" Rows="3" MaxLength="100">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Address_C" runat="server" ControlToValidate="txt_Address_C"
                                                                    Display="Dynamic" meta:resourcekey="rfv_Address_C" Text="*" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Con_Add" runat="server" OnClick="btn_Con_Add_Click" Text="Add"
                                                                    meta:resourcekey="btn_Con_Add" UseSubmitBehavior="false" ValidationGroup="Contact" OnClientClick="fnJSOnFormSubmit(this,'Contact')" />
                                                                <asp:Button ID="btn_Con_Correct" runat="server" OnClick="btn_Con_Correct_Click" Text="Correct"
                                                                    meta:resourcekey="btn_Con_Correct" UseSubmitBehavior="false" ValidationGroup="Contact" OnClientClick="fnJSOnFormSubmit(this,'Contact')" />
                                                                <asp:Button ID="btn_Con_Cancel" runat="server" OnClick="btn_Con_Cancel_Click" Text="Cancel"
                                                                    meta:resourcekey="btn_Con_Cancel" />
                                                            </td>
                                                            <td align="center">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_Contact" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                    Height="100%" OnItemCommand="RG_Contact_ItemCommand" Width="98%" meta:resourcekey="RG_Contact">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column"
                                                                                meta:resourcekey="Edit_Rec_Con">
                                                                            </telerik:GridButtonColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="ConID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPCONT_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Serial" meta:resourcekey="ConSerial">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Con_Serial" runat="server" Text='<%# Eval("APPCONT_SERIAL") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="CompanyName" meta:resourcekey="CompanyName">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ConName" runat="server" Text='<%# Eval("APPCONT_COMPANY") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ContactPerson" meta:resourcekey="ContactPerson">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ConPerson" runat="server" Text='<%# Eval("APPCONT_CONTACT") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Phonenumber" meta:resourcekey="Phonenumber">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ConPhoneNumber" runat="server" Text='<%# Eval("APPCONT_PHONE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Address" meta:resourcekey="Address">
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
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Language" runat="server" meta:resourcekey="Language" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Language" runat="server" meta:resourcekey="lbl_Language"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddl_Language" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Language" runat="server" ControlToValidate="ddl_Language"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Language" Text="*"
                                                                    ValidationGroup="Lang"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Read" runat="server" meta:resourcekey="lbl_Read"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Read" runat="server" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Write" runat="server" meta:resourcekey="lbl_Write"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Write" runat="server" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Speak" runat="server" meta:resourcekey="lbl_Speak"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Speak" runat="server" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Understand" runat="server" meta:resourcekey="lbl_Understand"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Understand" runat="server" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Lang_Add" runat="server" OnClick="btn_Lang_Add_Click" Text="Add"
                                                                    meta:resourcekey="btn_Lang_Add" UseSubmitBehavior="false" />
                                                                <asp:Button ID="btn_Lang_Correct" runat="server" OnClick="btn_Lang_Correct_Click" Text="Correct"
                                                                    meta:resourcekey="btn_Lang_Correct" UseSubmitBehavior="false" ValidationGroup="Lang" OnClientClick="fnJSOnFormSubmit(this,'Lang')" />
                                                                <asp:Button ID="btn_Lang_Cancel" runat="server" OnClick="btn_Lang_Cancel_Click" Text="Cancel"
                                                                    meta:resourcekey="btn_Lang_Cancel" />
                                                            </td>
                                                            <td align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_Language" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                    Height="100%" OnItemCommand="RG_Language_ItemCommand" Width="98%" meta:resourcekey="RG_Language">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column"
                                                                                meta:resourcekey="Edit_Rec_Lang">
                                                                            </telerik:GridButtonColumn>--%>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="LangID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPLAN_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="Lang_ID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPLAN_LANGUAGE_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Name" meta:resourcekey="LangName">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Lang_Name" runat="server" Text='<%# Eval("APPLAN_LANGUAGE_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Read" meta:resourcekey="Read">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk_Lang_Read" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_READ")) %>'
                                                                                        Enabled="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="write" meta:resourcekey="write">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk_Lang_Write" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_WRITE")) %>'
                                                                                        Enabled="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Speak" meta:resourcekey="Speak">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk_Lang_Speak" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_SPEAK")) %>'
                                                                                        Enabled="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Understand" meta:resourcekey="Understand">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk_Lang_Understand" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPLAN_UNDERSTAND")) %>'
                                                                                        Enabled="false"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column"
                                                                                meta:resourcekey="Edit_Rec_Lang">
                                                                            </telerik:GridButtonColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                </telerik:RadGrid>
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Reference" runat="server" meta:resourcekey="Reference" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl__Employee" runat="server" meta:resourcekey="lbl__Employee"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddl_Employee" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="ddl_Employee"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Employee" Text="*"
                                                                    ValidationGroup="Referred"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Relationship" runat="server" meta:resourcekey="lbl_Relationship"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddl_Relationship" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Relationship" runat="server" ControlToValidate="ddl_Relationship"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Relationship" Text="*"
                                                                    ValidationGroup="Referred"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Referred" runat="server" meta:resourcekey="lbl_Referred"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Referred" runat="server" />
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_Ref_Add" runat="server" OnClick="btn_Ref_Add_Click" Text="Add"
                                                                    meta:resourcekey="btn_Ref_Add" UseSubmitBehavior="false" ValidationGroup="Referred" />
                                                                <asp:Button ID="btn_Ref_Correct" runat="server" OnClick="btn_Ref_Correct_Click" Text="Correct"
                                                                    meta:resourcekey="btn_Ref_Correct" UseSubmitBehavior="false" ValidationGroup="Referred" OnClientClick="fnJSOnFormSubmit(this,'Referred')" />
                                                                <asp:Button ID="btn_Ref_Cancel" runat="server" OnClick="btn_Ref_Cancel_Click" Text="Cancel"
                                                                    meta:resourcekey="btn_Ref_Cancel" />
                                                            </td>
                                                            <td align="center">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center" style="width: 40%">
                                                        <tr>
                                                            <td align="left">
                                                                <telerik:RadGrid ID="RG_Reference" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                    Height="100%" OnItemCommand="RG_Reference_ItemCommand" Width="98%" meta:resourcekey="RG_Reference">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column" meta:resourcekey="Edit_Rec_ref">
                                                                            </telerik:GridButtonColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="RefID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPREF_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="RefEmpID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("APPREF_REFFERED_EMP_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Name" meta:resourcekey="RefName">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Ref_Name" runat="server" Text='<%# Eval("APPREF_REFFERED_EMP_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="RELID" Visible="False" meta:resourcekey="RElID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_RelID" runat="server" Text='<%# Eval("APPREF_RELATIONSHIP") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Relationship" meta:resourcekey="Relationship">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_relationship" runat="server" Text='<%# Eval("APPREF_RELATIONSHIP_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Referred" meta:resourcekey="Referred">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkReferred" runat="server" Checked='<%# Convert.ToBoolean(Eval("APPREF_REFERRED")) %>'
                                                                                        Enabled="False" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                </telerik:RadGrid>
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Family" runat="server" meta:resourcekey="Family" Width="800px">
                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table style="width: 800px">
                                                    <tr>
                                                        <td>
                                                            <table align="center">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_FSerial" runat="server" meta:resourcekey="lbl_FSerial"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox ID="txt_FSerial" runat="server" ReadOnly="True" TabIndex="1">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_FRelType" runat="server" Text="Relation&nbsp;Type" meta:resourcekey="lbl_FRelType"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadComboBox ID="ddlRelation" runat="server" TabIndex="2" MarkFirstMatch="true" MaxHeight="300"
                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlRelation_SelectedIndexChanged" Filter="Contains">
                                                                        </telerik:RadComboBox>
                                                                        <asp:RequiredFieldValidator ID="rfv_Relation" runat="server" Text="*" ControlToValidate="ddlRelation"
                                                                            Display="Dynamic" InitialValue="Select" ValidationGroup="Family" meta:resourcekey="rfv_Relation"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSurName" runat="server" Text="Surname" meta:resourcekey="lblSurName"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox ID="radSurName" runat="server" TabIndex="3">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_FName" runat="server" meta:resourcekey="lbl_FName"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox ID="txt_Name" runat="server" TabIndex="3" MaxLength="50">
                                                                        </telerik:RadTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <%-- <asp:Label ID="lblFIDNumber" runat="server" Text="ID Number" meta:resourcekey="lblIDNumber"></asp:Label>--%>
                                                                        <asp:Label ID="lbl_FDOB" runat="server" meta:resourcekey="lbl_FDOB" Text="DOB :"></asp:Label>
                                                                    </td>
                                                                    <td></td>
                                                                    <td>
                                                                        <%-- <telerik:RadTextBox ID="radFIDNumber" runat="server" TabIndex="3" MaxLength="50">
                                                                        </telerik:RadTextBox>--%>
                                                                        <telerik:RadDatePicker ID="txt_FDOB" runat="server" MinDate="1900-01-01" TabIndex="4"
                                                                            MaxDate='<%#DateTime.Now %>'>
                                                                        </telerik:RadDatePicker>
                                                                        <asp:CheckBox ID="chk_EmergencyCont" runat="server" Text="Emergency&nbsp;Contact" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FBrowsePhoto" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="FBrowsePhoto"
                                                                            runat="Server" ErrorMessage="Only .jpg files are allowed" Text="*" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg))$" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblBioData" runat="server" Text="Bio Data"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FBioData" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="FBioData"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only doc files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblBioMetricData" runat="server" Text="Bio Metric Data"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FBioMetricData" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="FBioMetricData"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only jpeg files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg))$" />
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                            <table align="center">
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkDeptAlwnce" AutoPostBack="true"
                                                                            OnCheckedChanged="chkAlwnce_CheckedChanged"></asp:CheckBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDeptAlwnce" runat="server" Text="Is Dependent Allowance Eligible"
                                                                            Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkEduAlwnce" AutoPostBack="true"
                                                                            OnCheckedChanged="chkAlwnce_CheckedChanged" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblEduAlwnce" runat="server" Text="Is Education Allowance Eligible"
                                                                            Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkMedAlwnce" AutoPostBack="true"></asp:CheckBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblMedAlwnce" runat="server" Text="Is Medical Allowance Eligible"
                                                                            Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table align="center">
                                                                <tr>
                                                                    <td align="right" colspan="6">
                                                                        <asp:Button ID="btn_Fam_Add" runat="server" OnClick="btn_Fam_Add_Click" Text="Add"
                                                                            TabIndex="5" meta:resourcekey="btn_Fam_Add" UseSubmitBehavior="false"
                                                                            OnClientClick="fnJSOnFormSubmit(this,'Family')" ValidationGroup="Family" />
                                                                        <asp:Button ID="btn_Fam_Correct" runat="server" OnClick="btn_Fam_Correct_Click" Text="Correct"
                                                                            TabIndex="5" meta:resourcekey="btn_Fam_Correct" UseSubmitBehavior="false"
                                                                            OnClientClick="fnJSOnFormSubmit(this,'Family')" />
                                                                        <asp:Button ID="btn_Fam_Cancel" runat="server" OnClick="btn_Fam_Cancel_Click" Text="Cancel"
                                                                            meta:resourcekey="btn_Fam_Cancel" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table align="center">
                                                    <tr>
                                                        <td>
                                                            <telerik:RadGrid ID="RG_Family" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                meta:resourcekey="RG_Family" Width="20px">
                                                                <%--OnItemCommand="RG_Family_ItemCommand" --%>
                                                                <MasterTableView>
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="FamID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("EMPFMDTL_ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="serial" meta:resourcekey="FamSerial">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Serial" runat="server" Text='<%# Eval("EMPFMDTL_SERIAL") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="Rel_ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("EMPFMDTL_EMPREL_ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="Relation" meta:resourcekey="FamRelName">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Relation" runat="server" Text='<%# Eval("EMPFMDTL_EMPREL_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="Surname" meta:resourcekey="FamSurname" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Surname" runat="server" Text='<%# Eval("EMPFMDTL_SURNAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="Name" meta:resourcekey="FamName">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("EMPFMDTL_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="DOB" HeaderText="Date of Birth">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_DOB" runat="server" Text='<%# Eval("EMPFMDTL_RELDOB")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="EMPFMDTL_RELEMERGENCY" HeaderText="Emergency Contact">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chk_Emergency" runat="server" Checked='<%# Convert.ToBoolean(Eval("EMPFMDTL_RELEMERGENCY")) %>'
                                                                                    Enabled="False" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Photo">
                                                                            <ItemTemplate>
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("EMPFMDTL_PHOTO") %>' Width="80px"
                                                                                    Height="100px"></asp:Image>
                                                                                <asp:Label ID="lbl_Photo" Text='<%#Eval("EMPFMDTL_PHOTO") %>' runat="server" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Bio Data">
                                                                            <ItemTemplate>
                                                                                <a id="D2" runat="server" target="_blank" href='<%#Eval("EMPFMDTL_BIODATA") %>'>Download
                                                                                                Bio Data</a>
                                                                                <asp:Label ID="lbl_BioData" Text='<%#Eval("EMPFMDTL_BIODATA") %>' Visible="false"
                                                                                    runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Dependent Allowance" AllowFiltering="false" HeaderStyle-Width="50px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="chkDepAlwnce" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("EMPFMDTL_IS_DEP")) %>'></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Education Allowance" AllowFiltering="false" HeaderStyle-Width="50px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="chkEduAlwnce" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("EMPFMDTL_IS_EDU")) %>'></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Medical Allowance" AllowFiltering="false" HeaderStyle-Width="50px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="chkMedAlwnce" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("EMPFMDTL_IS_MED")) %>'></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="lnkBtnFmlyEdit" CommandArgument='<%# Eval("EMPFMDTL_ID") %>'
                                                                                    OnCommand="lnkBtnFmlyEdit_Command">Edit</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column"
                                                                            meta:resourcekey="Edit_Rec_Family" Visible="false">
                                                                            <ItemStyle Width="80px" />
                                                                        </telerik:GridButtonColumn>
                                                                    </Columns>
                                                                </MasterTableView>
                                                                <ClientSettings>
                                                                    <Selecting AllowRowSelect="True" />
                                                                </ClientSettings>
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="RG_Family" />
                                                <asp:PostBackTrigger ControlID="btn_Fam_Add" />
                                                <asp:PostBackTrigger ControlID="btn_Fam_Correct" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Swipe" runat="server" meta:resourcekey="Swipe" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Serial_S" runat="server" meta:resourcekey="lbl_Serial_S"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_SSerial" runat="server" ReadOnly="True">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_CardCode" runat="server" meta:resourcekey="lbl_CardCode"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_CardCode" runat="server" MaxLength="50">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="cv_CardCode" runat="server" Text="*" ControlToValidate="txt_CardCode"
                                                                    Display="Dynamic" ValidationGroup="Swipe"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_IssueDate" runat="server" meta:resourcekey="lbl_IssueDate"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="txt_IssueDate" runat="server">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="cv_IssueDate" runat="server" Text="*" ControlToValidate="txt_IssueDate"
                                                                    Display="Dynamic" ValidationGroup="Swipe" meta:resourcekey="cv_IssueDate"></asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvIssueDate" runat="server" ControlToCompare="txt_DOJ"
                                                                    ControlToValidate="txt_IssueDate" Display="Dynamic" meta:resourcekey="cvIssueDate"
                                                                    Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                                <asp:CompareValidator ID="cv_DOBIssueDate" runat="server" ControlToCompare="txt_DOB"
                                                                    ControlToValidate="txt_IssueDate" Display="Dynamic" meta:resourcekey="cv_DOBIssueDate"
                                                                    Operator="GreaterThan" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ExpiryDate" runat="server" meta:resourcekey="lbl_ExpiryDate"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="txt_ExpiryDate" runat="server">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_Expirydate" runat="server" Text="*" ControlToValidate="txt_ExpiryDate"
                                                                    Display="Dynamic" ValidationGroup="Swipe" meta:resourcekey="rfv_Expirydate"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblRemarks" runat="server" meta:resourcekey="lblRemarks"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="txt_SwpRemarks" runat="server" MaxLength="100">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_swp_Add" runat="server" OnClick="btn_swp_Add_Click" Text="Add"
                                                                    meta:resourcekey="btn_swp_Add" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Swipe')" />
                                                                <asp:Button ID="btn_swp_Correct" runat="server" OnClick="btn_swp_Correct_Click" Text="Correct"
                                                                    meta:resourcekey="btn_swp_Correct" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Swipe')" />
                                                                <asp:Button ID="btn_swp_Cancel" runat="server" OnClick="btn_swp_Cancel_Click" Text="Cancel"
                                                                    meta:resourcekey="btn_swp_Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_Swipe" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                    OnItemCommand="RG_Swipe_ItemCommand" meta:resourcekey="RG_Swipe">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column" meta:resourcekey="Edit_Rec_swp">
                                                                                <ItemStyle Width="80px" />
                                                                            </telerik:GridButtonColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="SwpID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("EMPSWM_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="serial" meta:resourcekey="swpSerial">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_swpSerial" runat="server" Text='<%# Eval("EMPSWM_SERIAL") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="code" meta:resourcekey="cardcode">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_swpCardCode" runat="server" Text='<%# Eval("EMPSWM_CARDCODE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="cardIssue" meta:resourcekey="cardIssue">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_swpCardIssue" runat="server" Text='<%# Eval("EMPSWM_CARDISSUE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Expiry" meta:resourcekey="cardExpiry">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_swpCardexpiry" runat="server" Text='<%# Eval("EMPSWM_CARDEXPIRY") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="Remarks" meta:resourcekey="cardRemarks">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_swpRemarks" runat="server" Text='<%# Eval("EMPSWM_REMARKS") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <ClientSettings>
                                                                        <Selecting AllowRowSelect="True" />
                                                                    </ClientSettings>
                                                                </telerik:RadGrid>
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="OT" runat="server" meta:resourcekey="OT" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_OTType" runat="server" meta:resourcekey="lbl_OTType"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="ddl_OTType" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_OT" runat="server" ControlToValidate="ddl_OTType"
                                                                    Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_OT" Text="*" ValidationGroup="OT"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_OTValue" runat="server" meta:resourcekey="lbl_OTValue"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="txt_Value" runat="server" MinValue="0" MaxLength="12">
                                                                </telerik:RadNumericTextBox>
                                                                <asp:Label ID="lbl_Hours" runat="server" Text="Per&nbsp;Hour"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_OTValue" runat="server" ControlToValidate="txt_Value"
                                                                    Display="Dynamic" meta:resourcekey="rfv_OTValue" Text="*" ValidationGroup="OT"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_OT_Add" runat="server" OnClick="btn_OT_Add_Click" Text="Add"
                                                                    meta:resourcekey="btn_OT_Add" ValidationGroup="OT" />
                                                                <asp:Button ID="btn_OT_Correct" runat="server" OnClick="btn_OT_Correct_Click" Text="Correct"
                                                                    meta:resourcekey="btn_OT_Correct" ValidationGroup="OT" />
                                                                <asp:Button ID="btn_OT_Cancel" runat="server" Text="Cancel" OnClick="btn_OT_Cancel_Click"
                                                                    meta:resourcekey="btn_OT_Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="RG_OTRate" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                                    OnItemCommand="RG_OTRate_ItemCommand" meta:resourcekey="RG_OTRate">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column" meta:resourcekey="Edit_Rec_OT">
                                                                                <ItemStyle Width="80px" />
                                                                            </telerik:GridButtonColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="OTID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("EMPOTR_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="OTTypeID" Visible="False" meta:resourcekey="OTTypeID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_OTTypeID" runat="server" Text='<%# Eval("EMPOTR_OTTYPE_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="OTType" meta:resourcekey="OTType">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_OTTypeName" runat="server" Text='<%# Eval("EMPOTR_OTTYPE_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="OTRate" meta:resourcekey="OTRate">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_OtRate" runat="server" Text='<%# Eval("EMPOTR_OTRATE") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <ClientSettings>
                                                                        <Selecting AllowRowSelect="True" />
                                                                    </ClientSettings>
                                                                </telerik:RadGrid>
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Weeklyoff" runat="server" meta:resourcekey="Weeklyoff" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_offDate" runat="server" meta:resourcekey="lbl_offDate"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="rdp_offDate" runat="server">
                                                                </telerik:RadDatePicker>
                                                                <asp:CompareValidator ID="cv_Validate" runat="server" ControlToCompare="txt_DOJ"
                                                                    ControlToValidate="rdp_offDate" Display="Dynamic" meta:resourcekey="cv_Validate"
                                                                    Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Monday" runat="server" meta:resourcekey="lbl_Monday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Monday" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Tuesday" runat="server" meta:resourcekey="lbl_Tuesday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_tuesday" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Wednesday" runat="server" meta:resourcekey="lbl_Wednesday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_wednesday" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Thursday" runat="server" meta:resourcekey="lbl_Thursday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_thursday" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Friday" runat="server" meta:resourcekey="lbl_Friday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Friday" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Saturday" runat="server" meta:resourcekey="lbl_Saturday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Saturday" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Sunday" runat="server" meta:resourcekey="lbl_Sunday"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chk_Sunday" runat="server" />
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
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Picture" runat="server" meta:resourcekey="Picture" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="upnl_Uploadimage" runat="server">
                                                        <ContentTemplate>
                                                            <table align="center">
                                                                <tr>
                                                                    <td colspan="3" align="center">
                                                                        <asp:Label ID="lbl_Picture" runat="server" meta:resourcekey="lbl_Picture"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_UploadImg" runat="server" meta:resourcekey="lbl_UploadImg"></asp:Label>
                                                                    </td>
                                                                    <td style="margin-left: 40px">
                                                                        <asp:FileUpload ID="FUpload" runat="server" meta:resourcekey="FUpload" />
                                                                        <asp:RegularExpressionValidator ID="RExpession_Upload" ControlToValidate="FUpload"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only .jpg,png,jpeg,gif files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((JPG)|(gif)|(jpeg)|(png)|(jpg)|(GIF)|(JPEG)|(PNG))$" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btn_Upload" runat="server" Text="Upload Image" OnClick="btn_Upload_Click"
                                                                            ValidationGroup="Controls" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center">
                                                                        <asp:Image ID="RBI_Employee_Image" runat="server" Width="182px" Height="202px" />
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center">
                                                                        <asp:LinkButton ID="lnkPicDelete" runat="server" Text="Delete Picture" OnClick="lnkPicDelete_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <%-- <telerik:RadAjaxPanel ID="RAP_Upload" runat="server" LoadingPanelID="RLP_Upload">
                                                                </telerik:RadAjaxPanel>--%>
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
                                        <br />
                                        <br />
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Other_Details" runat="server" Selected="true" meta:resourcekey="OtherDetails"
                                        Width="800px" Height="500px">
                                        <br />
                                        <table style="width: 550px" align="center">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_OthrDtlsIdNumber" runat="server" Text="PF&nbsp;Number"></asp:Label>
                                                </td>
                                                <td >
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_IdNumber" runat="server" meta:resourcekey="rtxt_IdNumber"
                                                        MaxLength="50">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                               <td>
                                                    <%--<asp:Label ID="lbl_PinNumber" runat="server" Text="PAN&nbsp;Number" ></asp:Label>--%>
                                                    <%-- <asp:Label ID="Label1" runat="server" Text="Employee Number"></asp:Label>--%>
                                                </td>
                                                <td>
                                                   <%-- <b>:</b>--%>
                                                </td>
                                                <td>
                                                    <%--<telerik:RadTextBox ID="rtxt_PinNumber" runat="server" MaxLength="12" >
                                                    </telerik:RadTextBox>--%>
                                                </td>
                                                <td>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rtxt_PinNumber"
                                                        ErrorMessage="PAN Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="rtxt_PinNumber"
                                                        ErrorMessage="Enter only Alphanumerics for PAN Number" ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,12}$"
                                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--<asp:Label ID="lbl_NssfNo" runat="server" Text="NSSF&nbsp;Number" ></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <%--<b>:</b>--%>
                                                </td>
                                                <td>
                                                   <%-- <telerik:RadTextBox ID="rtxt_NssfNo" runat="server" meta:resourcekey="rtxt_NssfNo" 
                                                        MaxLength="15">
                                                    </telerik:RadTextBox>--%>
                                                </td>
                                                <td>
                                                    <%-- <asp:RequiredFieldValidator ID="rfnssf" runat="server" ControlToValidate="rtxt_NssfNo"
                                                        ErrorMessage="NSSF Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_NssfNo"
                                                        ErrorMessage="Enter only Alphanumerics for NSSF Number" ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,15}$"
                                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_NhifNo" runat="server" Text="Employer Number"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_NhifNo" runat="server" meta:resourcekey="rtxt_NhifNo"
                                                        MaxLength="10">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rtxt_NhifNo"
                                                        ErrorMessage="NHIF Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="rtxt_NhifNo"
                                                        ErrorMessage="Enter only Alphanumerics for NHIF Number" ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,10}$"
                                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td>
                                                 <%--   <asp:Label ID="lbl_PPIDNo" runat="server" Text="PP/ID&nbsp;Number" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td > 
                                                   <%-- <b>:</b>--%>
                                                </td>
                                                <td >
                                                   <%-- <telerik:RadTextBox ID="rtxt_PPIDNo" runat="server" meta:resourcekey="rtxt_PPIDNo"
                                                        MaxLength="50">
                                                    </telerik:RadTextBox>--%>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_NnakNo" runat="server" Text="Employee Number"></asp:Label>
                                                </td>
                                                <td>
                                                    <%--<b visible="false">:</b>--%> <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_NnakNo" runat="server" meta:resourcekey="rtxt_NnakNo"
                                                        MaxLength="50">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_TaxReliefAmt" runat="server" meta:resourcekey="lbl_TaxReliefAmt"
                                                        Text="EPF Number" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <%--<b visible="false">:</b>--%>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_TaxReliefAmt" runat="server" meta:resourcekey="rtxt_TaxReliefAmt"
                                                        MaxLength="50" Visible="false">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPassportNo" runat="server" Text="Passport No"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtPassportNo" runat="server">
                                                    </telerik:RadTextBox>
                                                    <%--<asp:TextBox ID="txtPassportNo" runat="server"></asp:TextBox>--%>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblExpiryDate" runat="server" Text="Passport&nbsp;Expiry&nbsp;Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdpExpiryDate" runat="server">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_MemberID" runat="server" Text="Provident Fund ID"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_MemberID" runat="server" MaxLength="20">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_KRA_PINNO" runat="server" Text="PIN Number"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_KRA_PINNO" runat="server" MaxLength="12">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <%--   <asp:RequiredFieldValidator ID="rfPINNumber" runat="server" ControlToValidate="rtxt_KRA_PINNO"
                                                        ErrorMessage="Pin Number is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="rtxt_KRA_PINNO"
                                                        ErrorMessage="Enter only Alphanumerics for PIN Number" ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,12}$"
                                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   <%-- <asp:Label ID="lbl_HELBNo" runat="server" Text="HELB Number"></asp:Label>--%>
                                                </td>
                                                <td>
                                                   <%-- <b>:</b>--%>
                                                </td>
                                                <td>
                                                   <%-- <telerik:RadTextBox ID="rtxt_HELBNo" runat="server" MaxLength="20">
                                                    </telerik:RadTextBox>--%>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lbl_CooperativeNo" runat="server" Text="Old Employee ID"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtxt_CooperativeNo" runat="server" MaxLength="20">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblProject" runat="server" Text="Project"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmbProject" runat="server" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>

                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblFunding" runat="server" Text="Funding Source"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_Funding" runat="server" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEmplyrGrat" runat="server" Text="Employer Gratuity Number"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbEmplyrGrat" runat="server" Filter="Contains" Enabled="false">
                                                    </telerik:RadTextBox>
                                                </td>

                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblEmplyeGrat" runat="server" Text="Employee Gratuity Number"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbEmplyeGrat" runat="server" Filter="Contains" Enabled="false">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblActivity" runat="server" Text="Activity"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbActivity" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>

                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblProgramme" runat="server" Text="Programme"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbProgramme" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOutCome" runat="server" Text="Out Come"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbOutCome" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>

                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblIntervention" runat="server" Text="Intervention"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbIntervention" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFocusArea" runat="server" Text="Focus Area"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbFocusArea" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>

                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblResultArea" runat="server" Text="Result Area"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbResultArea" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:Label ID="lblbudgetline" runat="server" Text="Budget Line"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbbudgetline" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trOrgUnit" visible="false">
                                                <td>
                                                    <asp:Label ID="lblOrgUnit" runat="server" Text="Org Unit"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="rtbOrgUnit" runat="server" Filter="Contains" MaxLength="25">
                                                    </telerik:RadTextBox>
                                                </td>

                                                <td></td>
                                                <td>
                                                    <%--<asp:Label ID="Label8" runat="server" Text="Employee Gratuity Number"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <%--<b>:</b>--%>
                                                </td>
                                                <td>
                                                    <%--<telerik:RadTextBox ID="RadTextBox8" runat="server" Filter="Contains">
                                                    </telerik:RadTextBox>--%>
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Physical_Details" runat="server" Selected="true" Width="800px"
                                        Height="550px">
                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <table style="width: 550px" align="center">
                                                    <tr>
                                                        <td colspan="8" align="left">
                                                            <asp:Label ID="lbl_EmployeeContactInfo" runat="server" Text="Employee Contact Information"
                                                                Font-Underline="true" Font-Bold="true"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_MobileNo" runat="server" Text="Mobile&nbsp;No"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadMaskedTextBox ID="rmtxt_MobileNo" runat="server" DisplayMask="##########"
                                                                Mask="##########">
                                                            </telerik:RadMaskedTextBox>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_LandlineNo" runat="server" Text="LandLine&nbsp;No"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadMaskedTextBox ID="rmtxt_LandlineNo" runat="server" DisplayMask="### ### #######"
                                                                Mask="### ### #######">
                                                            </telerik:RadMaskedTextBox>
                                                        </td>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="rev_MobileNo" runat="server" ControlToValidate="rmtxt_MobileNo"
                                                                Display="Dynamic" Text="Enter 10 digits for mobile  number" ValidationExpression="\d{10}"
                                                                ValidationGroup="Physical"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="rfv_MobileNo" runat="server" ErrorMessage="Please Enter Mobile No."
                                                                Enabled="false" Text="*" ValidationGroup="Controls" ControlToValidate="rmtxt_MobileNo"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="rev_LandlineNo" runat="server" ControlToValidate="rmtxt_LandlineNo"
                                                                Display="Dynamic" Text="Enter the Landline No. with STD Code" ValidationExpression="\[0-9]{3,4}[ ]*[0-9]{3,4}[ ]*[0-9]{7,8}"
                                                                ValidationGroup="Physical"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_EmailID" runat="server" Text="Email&nbsp;ID"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_EmailID" runat="server">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:RegularExpressionValidator ID="rev_EmailID" runat="server" ControlToValidate="rtxt_EmailID"
                                                                Text="Please Enter Valid Email ID" Display="Dynamic" ValidationGroup="Physical"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_EmailID" runat="server" ErrorMessage="Please Enter Email"
                                                                Enabled="false" Text="*" ValidationGroup="Controls" ControlToValidate="rtxt_EmailID"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSkypeId" runat="server" Text="Skype Id"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="txtSkypeId" runat="server">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lblExtensionNo" runat="server" Text="Extension No"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rntbExtensionNo" runat="server">
                                                            </telerik:RadTextBox>
                                                            <%--<telerik:RadNumericTextBox ID="rntbExtensionNo" runat="server">
                                                    </telerik:RadNumericTextBox>--%>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Label ID="lbl_Physical" runat="server" Text="Employee&nbsp;Physical&nbsp;Details"
                                                                Font-Bold="true" Font-Underline="true"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_Height" runat="server" Text="Height"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rtxt_Height" runat="server" MaxLength="4" MinValue="0">
                                                            </telerik:RadNumericTextBox>cms.
                                                            <%--<telerik:RadTextBox ID="rtxt_Height" runat="server"  MaxLength="3">
                                                    </telerik:RadTextBox>cms.--%>
                                                        </td>
                                                        <td>
                                                            <%-- <asp:RegularExpressionValidator ID="rev_Height" runat="server" ControlToValidate="rtxt_Height"
                                                                Text="Only&nbsp;numberes&nbsp;allowed" Display="Dynamic" ValidationGroup="Physical"
                                                                ValidationExpression="^\d+$">
                                                            </asp:RegularExpressionValidator>--%>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_Weight" runat="server" Text="Weight"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rtxt_Weight" runat="server" MaxLength="4" MinValue="0">
                                                            </telerik:RadNumericTextBox>kgs.
                                                            <%--<telerik:RadTextBox ID="rtxt_Weight" runat="server"  MaxLength="3">
                                                    </telerik:RadTextBox>kgs.--%>
                                                        </td>
                                                        <td>
                                                            <%--<asp:RegularExpressionValidator ID="rev_Weight" runat="server" ControlToValidate="rtxt_Weight"
                                                                Text="Only&nbsp;numbers&nbsp;allowed" Display="Dynamic" ValidationGroup="Physical"
                                                                ValidationExpression="\d+$">
                                                            </asp:RegularExpressionValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_Color" runat="server" Text="Skin&nbsp;Color"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_SkinColor" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_EyePower" runat="server" Text="Eye&nbsp;Power"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_EyePower" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_IdentificationMarks" runat="server" Text="Mole&nbsp;Identification&nbsp;Or&nbsp;Other&nbsp;Marks"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_IdentificationMarks" runat="server" MaxLength="500">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lblEMPPhysicalDetailsDoc" runat="server" Text="Physical Details Doc"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="FPhysicalDoc" runat="server"></asp:FileUpload>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="FPhysicalDoc"
                                                                ValidationGroup="Controls" runat="Server" ErrorMessage="Only doc files are allowed"
                                                                Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" />
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_Handicapped" runat="server" Text="Is&nbsp;Handicapped?"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chk_Handicapped" runat="server" OnCheckedChanged="chk_Handicapped_CheckedChanged"
                                                                AutoPostBack="True" />
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_HandicapDetails" runat="server" Text="Details" Visible="false"></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                            <telerik:RadTextBox ID="rtxt_Handicapped" runat="server" Visible="false" MaxLength="500">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Label ID="lbl_PhysicalIllness" runat="server" Text="Physical Illness For More Than A Week"
                                                                Font-Bold="true" Font-Underline="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_NameOfTreatment" runat="server" Text="Treatment&nbsp;Name"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_TreatmentName_Physical" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_HospitalName" runat="server" Text="Hospital&nbsp;Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_HospitalName_Physical" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_TreatmentDuration" runat="server" Text="Treatment&nbsp;Duration"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_TreatmentDuration_Physical" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>days
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_IllnessStatus" runat="server" Text="Current&nbsp;Illness&nbsp;Status"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_IllnessStatus_Physical" runat="server" MaxLength="500">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Label ID="lbl_MentalIlness" runat="server" Text="Mental Illness For More Than A Week"
                                                                Font-Bold="true" Font-Underline="true"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_TreatmentName" runat="server" Text="Treatment&nbsp;Name"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_TreatmentName_Mental" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_HospitalName_Mental" runat="server" Text="Hospital&nbsp;Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_HospitalName_Mental" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_TreatmentDuration_Mental" runat="server" Text="Treatment Duration"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_TreatmentDuration_Mental" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>days
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbl_IllnessStatus_Mental" runat="server" Text="Current&nbsp;Illness&nbsp;Status"> </asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_IllnessStatus_Mental" runat="server" MaxLength="50">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <table align="right">
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Button ID="btn_Physical_Save" runat="server" Text="Save" OnClick="btn_Physical_Save_Click"
                                                                ValidationGroup="Physical" Visible="false" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_Physical_Update" runat="server" Text="Update" OnClick="btn_Physical_Update_Click"
                                                                Visible="false" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_Physical_Cancel" runat="server" Text="Cancel" OnClick="btn_Physical_Cancel_Click"
                                                                Visible="false" />
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_Save" />
                                                <asp:PostBackTrigger ControlID="btn_Update" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <br />
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="SELF_LOGIN_DETAILS" runat="server" Width="800px" Selected="true">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblusergroup" runat="server" Text="User&nbsp;Group"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcmb_usergroup" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator ID="rfv_rcmb_usergroup" runat="server" Text="*" InitialValue="Select"
                                                                    ControlToValidate="rcmb_usergroup" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Select User Group"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="rtxt_pwd" runat="server" MaxLength="14" OnTextChanged="rtxt_pwd_TextChanged"
                                                                    AutoPostBack="true"></asp:TextBox>
                                                                <%--<telerik:RadTextBox ID="rtxt_pwd" runat="server" MaxLength="50" 
                                                                        >
                                                                       </telerik:RadTextBox>--%>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_rtxt_pwd" runat="server" ControlToValidate="rtxt_pwd"
                                                                    Text="*" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Enter Password">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblpasscode" runat="server" Text="PassCode"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="rtxt_passcode" runat="server" MaxLength="14" OnTextChanged="rtxt_passcode_TextChanged"
                                                                    AutoPostBack="true"></asp:TextBox>
                                                                <%--<telerik:RadTextBox ID="rtxt_passcode" runat="server" MaxLength="50" >
                                                                       </telerik:RadTextBox>--%>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_rtxt_passcode" runat="server" ErrorMessage="Please Enter Passcode"
                                                                    Text="*" ValidationGroup="Controls" ControlToValidate="rtxt_passcode" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="Important_Dates" runat="server" Width="800px">
                                        <br />
                                        <table style="width: 800px">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <table align="center">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_DateJoined" runat="server" Text="Date of Join"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="rdp_DateJoined" runat="server" TabIndex="1" Enabled="false">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_Confirm" runat="server" Text="Date of Confirm"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="rdp_Confirm" runat="server" TabIndex="1" Enabled="false">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_Birth" runat="server" Text="Date of Birth"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="rdp_Birth" runat="server" TabIndex="1" Enabled="false">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_DOA" runat="server" Text="Date of Anniversary"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="rdp_DOA" runat="server" TabIndex="1">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_PensionDate" runat="server" Text="Pension Joined Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="rdp_PensionDate" runat="server" TabIndex="1">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_MedTerminationDate" runat="server" Text="Medical Termination Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="rdp_MedTerminationDate" runat="server" TabIndex="1">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblOrientationDate" runat="server" Text="Orientation Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="radOrientationDate" runat="server" TabIndex="1">
                                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                            </Calendar>
                                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                                                            <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy" TabIndex="8">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblOrientationDoc" runat="server" Text="Orientation Document"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FOrientation" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="FOrientation"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only pdf files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" /><br />
                                                                        <a id="lnkUploadedOrien" runat="server" target="_blank" visible="false" href='#'>Download
                                                                            Orientation Document</a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblOfficialScerectsactDoc" runat="server" Text="Official Secrets Acts"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FOfficialScerectsactDoc" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="FOfficialScerectsactDoc"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only pdf files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" /><br />
                                                                        <a id="aOfficialScerectsactDoc" runat="server" target="_blank" visible="false" href='#'>Download Official Secrets Acts</a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblNextofKinForm" runat="server" Text="Next of Kin Form"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FNextofKinForm" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="FNextofKinForm"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only pdf files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" /><br />
                                                                        <a id="aNextofKinForm" runat="server" target="_blank" visible="false" href='#'>Download Next of Kin Form</a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblPSC2_1" runat="server" Text="PSC2/1"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FPSC2_1" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="FPSC2_1"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only pdf files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" /><br />
                                                                        <a id="aPSC2_1" runat="server" target="_blank" visible="false" href='#'>Download FPSC2/1</a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStaffParticulars" runat="server" Text="Staff Particulars"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="FStaffParticulars" runat="server"></asp:FileUpload>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="FStaffParticulars"
                                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only pdf files are allowed"
                                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" /><br />
                                                                        <a id="aStaffParticulars" runat="server" target="_blank" visible="false" href='#'>Download Staff Particulars</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Save" />
                                                            <asp:PostBackTrigger ControlID="btn_Update" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
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
                </div>
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
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:ValidationSummary ID="vs_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Controls" />
    <asp:ValidationSummary ID="vs_Lang" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Lang" />
    <asp:ValidationSummary ID="vs_Reference" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Referred" />
    <asp:ValidationSummary ID="vs_Family" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Family" />
    <asp:ValidationSummary ID="vs_Swipe" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Swipe" />
    <asp:ValidationSummary ID="vs_OT" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="OT" />
    <asp:ValidationSummary ID="vs_Contact" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Contact" />
    <asp:ValidationSummary ID="vs_Experience" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Exp" />
    <asp:ValidationSummary ID="vs_Qual" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Qual" />
    <asp:ValidationSummary ID="vs_Skills" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Skills" />
    <asp:ValidationSummary ID="vs_Onsite" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="OnSite" />
    <asp:ValidationSummary ID="vs_Shift" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Shift" />
</asp:Content>