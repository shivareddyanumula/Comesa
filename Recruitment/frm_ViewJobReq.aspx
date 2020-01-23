<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ViewJobReq.aspx.cs" Inherits="Recruitment_frm_ViewJobReq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

            <script language="javascript" type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog         
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)         
                    return oWindow;
                }

                function Close() {
                    GetRadWindow().Close();
                }
            </script>

        </telerik:RadScriptBlock>
        <div>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
                meta:resourcekey="RadFormDecorator1Resource1" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <table align="center" border="0">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_Heading" runat="server" meta:resourcekey="lbl_Heading" Font-Bold="True" Font-Size="Larger" Text="Resouce Requisition"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label1" runat="server" name="Manager Details" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_JobRequisition_page" runat="server" SelectedIndex="0"
                            Style="z-index: 10" Width="1014px">

                            <telerik:RadPageView ID="Rp_JobRequisition_ViewDetails" runat="server" Height="990px">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <b>Manager Details</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BU" runat="server" meta:resourcekey="lbl_BU" Text="Business Unit"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BU" runat="server" AutoPostBack="true" Filter="Contains"
                                                Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                            </telerik:RadComboBox>
                                            <%-- <telerik:RadComboBox ID="rcmb_BU" runat="server" AutoPostBack="true" Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator Enabled="false" ID="rfv_BU" runat="server" ControlToValidate="rcmb_BU"
                                                InitialValue="Select" ErrorMessage="Please Select Business Unit" meta:resourcekey="rfv_BU"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td></td>

                                        <td>
                                            <asp:Label ID="lbl_RaisedBy" runat="server" meta:resourcekey="lbl_RaisedBy" Text="Raised By"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                                MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="GetSelectedItem" OnSelectedIndexChanged="rcmb_RaisedBy_SelectedIndexChanged">
                                                <WebServiceSettings Method="GET_EmployeeBySearchStr" Path="frm_JobRequisition.aspx" />
                                            </telerik:RadComboBox>
                                            <%--<telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" AutoPostBack="true" Skin="WebBlue"
                                        Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator Enabled="false" ID="rfv_RaisedBy" runat="server" ControlToValidate="rcmb_RaisedBy"
                                                ErrorMessage="Please Choose RaisedBy" meta:resourcekey="rfv_RaisedBy" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Directorate" runat="server" meta:resourcekey="lbl_Directorate" Text="Directorate">
                                            </asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Directorate" runat="server" InitialValue="- Select -"
                                                Width="125px" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                        <td></td>

                                        <td>
                                            <asp:Label ID="lbl_Department" runat="server" meta:resourcekey="lbl_Department" Text="Department"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Department" runat="server" InitialValue="- Select -"
                                                Width="125px" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator Enabled="false" ID="rfv_Department" runat="server" ControlToValidate="rcmb_Department"
                                        ErrorMessage="Please Choose Department" meta:resourcekey="rfv_Department" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td></td>


                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Desc" runat="server" meta:resourcekey="lbl_Desc" Text="Resource Requisition Name"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_Desc" runat="server" Skin="WebBlue"
                                                Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator Enabled="false" ID="rfv_Desc" runat="server" ControlToValidate="rtxt_Desc" ErrorMessage="Please Enter Requisition Name" meta:resourcekey="rfv_Desc" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td></td>

                                        <td>
                                            <asp:Label ID="lbl_ExpectedDate" runat="server" meta:resourcekey="lbl_ExpectedDate" Text="Expected Closure Date"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_ExpectedDate" runat="server" Skin="WebBlue" Width="205px">
                                                <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <%-- <TimeView CellSpacing="-1">
                    </TimeView>
                    <TimePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />--%>
                                                <%-- <DatePopupButton HoverImageUrl="" ImageUrl="" />--%>
                                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator Enabled="false" ID="rfv_Expecteddate" runat="server" ControlToValidate="rdtp_ExpectedDate"
                                                ErrorMessage="Please Select Expected Closure Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
                                            <%-- <asp:CompareValidator ID="cv_Expecteddate" runat="server" ControlToValidate="rdtp_ExpectedDate" Type="Date" 
                                        ErrorMessage="Date Should Be Less Than The Current Date" Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>--%>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_interviewer" runat="server" meta:resourcekey="lbl_interviewer"
                                                Text="Assign Interviewer"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <%--<telerik:RadComboBox ID="rcmb_interviewer" MarkFirstMatch="true" MaxHeight="120px" runat="server" Skin="WebBlue" Width="125px"
                                                HighlightTemplatedItems="True" EmptyMessage="Please Enter Employee Name" EnableLoadOnDemand="true" OnClientItemsRequesting="GetSelectedItem" Visible="false">
                                                <WebServiceSettings Method="GET_EmployeeBySearchStr" Path="frm_JobRequisition.aspx"/>
                                            </telerik:RadComboBox>--%>
                                            <telerik:RadListBox ID="rlst_interviewer" Height="120px"
                                                Width="210px" runat="server" AllowDelete="True" Skin="WebBlue" AutoPostBackOnDelete="True">
                                            </telerik:RadListBox>
                                            <%--<telerik:RadComboBox ID="RadComboBox1" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="GetSelectedItem" OnSelectedIndexChanged="rcmb_RaisedBy_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchStr" Path="frm_JobRequisition.aspx" />
                                    </telerik:RadComboBox>--%>
                                            <%-- <telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_RaisedBy_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_jobrequisition.aspx" />
                                    </telerik:RadComboBox>--%>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btn_AddInterviewer" runat="server" Text="Add" Visible="false" />
                                        </td>

                                        <td>
                                            <asp:Label ID="lbl_JRID" runat="server" Text="JR ID" Visible="False">
                                            </asp:Label>
                                            <asp:Label ID="lbl_JRCode" runat="server" meta:resourcekey="lbl_JRCode" Text="Resource Requisition Code"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_JRCode" runat="server" EmptyMessage="Auto Generated Code" ReadOnly="True" Skin="WebBlue" Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                        <td>&#160;&nbsp;
                                        </td>
                                        <td align="right"></td>
                                        <td>
                                            <telerik:RadListBox ID="rlst_interviewer" Height="120px"
                                                Width="210px" runat="server" AllowDelete="True" Skin="WebBlue" AutoPostBackOnDelete="True">
                                            </telerik:RadListBox>
                                        </td>

                                        <td>
                                             <asp:RequiredFieldValidator Enabled="false" ID="rfv_rlst_interviewer" runat="server" ControlToValidate="rlst_interviewer"
                    ErrorMessage="Please Assign Atleast One Interviewer" meta:resourcekey="rfv_rlst_interviewer" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <b>Resource Requisition Details</b>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_financial" runat="server" Text="Financial Period"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_financialPeriod" runat="server" AutoPostBack="true" InitialValue="- Select -" MarkFirstMatch="true" Width="125px" Enabled="false" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>

                                        <td></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Status" runat="server" meta:resourcekey="lbl_Status" Text="Status"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" InitialValue="- Select -" MarkFirstMatch="true" Width="125px">
                                                <Items>
                                                    <%--<telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />--%>
                                                    <telerik:RadComboBoxItem runat="server" Text="Open" Value="1" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Close" Value="2" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Reopen" Value="3" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_Status" runat="server" ControlToValidate="rcmb_Status"
                                                ErrorMessage="Please Select a Status" ValidationGroup="Controls" meta:resourcekey="rfv_Status" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>

                                        <td>
                                            <asp:Label ID="lbl_Designation" runat="server" meta:resourcekey="lbl_Designation" Text="Position"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Designation" runat="server" InitialValue="- Select -" AutoPostBack="true" Filter="Contains"
                                                Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Designation_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_Designation" runat="server" ControlToValidate="rcmb_Designation" InitialValue="Select"
                                                ErrorMessage="Please Select Position" meta:resourcekey="rfv_Designation" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Grade" runat="server" meta:resourcekey="lbl_Grade" Text="Grade"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Grade" runat="server" InitialValue="- Select -" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Width="125px" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_Grade" runat="server" ControlToValidate="rcmb_Grade" ErrorMessage="Please Select Grade" meta:resourcekey="rfv_rcmb_Grade" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>


                                        <td>
                                            <asp:Label ID="lbl_Slab" runat="server" meta:resourcekey="lbl_Slab" Text="Slab"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <%--<telerik:RadComboBox ID="rcmb_Slab" runat="server" InitialValue="- Select -" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Width="125px">
                                            </telerik:RadComboBox>--%>
                                            <telerik:RadTextBox runat="server" ID="rtbGrade" Enabled="false"></telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_Slab" runat="server" ControlToValidate="rcmb_Slab" ErrorMessage="Please Select Slab" meta:resourcekey="rfv_rcmb_Slab" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                        </td>

                                    </tr>

                                    <tr>
                                        <%--<td>
                                    <asp:Label ID="lbl_req_for" runat="server" meta:resourcekey="lbl_req_for" Text="Requirement For"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_req_for" runat="server" InitialValue="- Select -"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem Text="Internal" Value="1" />
                                            <telerik:RadComboBoxItem Text="For Onsite Client" Value="2" />
                                            <telerik:RadComboBoxItem Text="For RFP or RFQ's" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_req_for" runat="server" ControlToValidate="rcmb_req_for"
                                        ErrorMessage="Please Select Requirement For" meta:resourcekey="rfv_rcmb_req_for" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>--%>

                                        <%-- <td>
                                    <asp:Label ID="lbl_Qualification" runat="server" meta:resourcekey="lbl_Qualification"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Qualification" runat="server" MarkFirstMatch="true" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator Enabled="false" ID="rfv_Qualification" runat="server" ControlToValidate="rcmb_Qualification" ErrorMessage="Please Choose Qualification " meta:resourcekey="rfv_Qualification" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_IsQualificationReQ" runat="server" meta:resourcekey="chk_IsQualificationReQ" />
                                </td>--%>

                                        <td>
                                            <asp:Label ID="lbl_Openings" runat="server" meta:resourcekey="lbl_Openings" Text="Target Openings"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RNT_Openings" runat="server" NumberFormat-DecimalDigits="0" AutoPostBack="true"
                                                Skin="WebBlue">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_Openinsgs" runat="server" ControlToValidate="RNT_Openings"
                                                ErrorMessage="Please Enter Targret Openings" meta:resourcekey="rfv_Openings" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
            <td>
                <asp:Label ID="lbl_reqto_work" runat="server" meta:resourcekey="lbl_reqto_work" Text="Required to Work"></asp:Label>
            </td>
            <td align="right">
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_reqto_work" runat="server" InitialValue="- Select -"
                    Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                        <telerik:RadComboBoxItem Text="Onsite" Value="1" />
                        <telerik:RadComboBoxItem Text="Internal" Value="2" />
                        <telerik:RadComboBoxItem Text="Both" Value="3" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_reqto_work" runat="server" ControlToValidate="rcmb_reqto_work"
                    ErrorMessage="Please Select Required to Work" meta:resourcekey="rfv_rcmb_reqto_work" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_RecruitmentFor" runat="server" meta:resourcekey="lbl_RecruitmentFor" Text="Recruitment For"></asp:Label>
            </td>
            <td align="right">
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_RecruitmentFor" runat="server" InitialValue="Select"
                    Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                    <Items>
                      <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                      <telerik:RadComboBoxItem runat="server" Text="Fresher" Value="Fresher" />
                      <telerik:RadComboBoxItem runat="server" Text="Experience" Value="Experience" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_RecruitmentFor" runat="server" ControlToValidate="rcmb_RecruitmentFor"
                    ErrorMessage="Please Select Recruitment For" meta:resourcekey="rfv_rcmb_RecruitmentFor" Text="*" InitialValue="Select"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>--%>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbl_SkillReq" runat="server" meta:resourcekey="lbl_SkillReq" Text="Skills Required"></asp:Label>
                                        </td>
                                        <td align="right" valign="top">:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkills" runat="server"></asp:Label><br />
                                            <%--<telerik:RadListBox ID="rlb_SkillReq" runat="server" AllowAutomaticUpdates="true" CheckBoxes="true" Height="100px" Width="200px">
                                    </telerik:RadListBox>--%>
                                        </td>
                                        <td></td>
                                        <td></td>

                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Qualification" meta:resourcekey="lbl_Qualification"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblQualifications" runat="server"></asp:Label>
                                            <%--<telerik:RadListBox ID="rlb_Qualification" runat="server" Skin="WebBlue" CheckBoxes="true" Height="130px" Width="200px">
                                    </telerik:RadListBox>--%>
                                        </td>
                                        <td></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Percentage" runat="server" meta:resourcekey="lbl_Percentage" Text="Percentage"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RNT_Percentage" runat="server" Skin="WebBlue" MaxValue="100" Type="Percent" Width="125px">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_Percentage" runat="server" ControlToValidate="RNT_Percentage"
                                                ErrorMessage="Please Enter Percentage " meta:resourcekey="rfv_Percentage" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>


                                        <td>
                                            <asp:Label ID="lbl_Experience" runat="server" meta:resourcekey="lbl_experience" Text="Years Of Experience"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RNT_Experience" runat="server" MinValue="0" Skin="WebBlue">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td><%--    <asp:Label ID ="lbl_yr" runat ="server" Text="(in Years)"></asp:Label>--%>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_Experience" runat="server" ControlToValidate="RNT_Experience" ErrorMessage="Please Enter Experience " meta:resourcekey="rfv_Experience" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_IsExperienceReq" runat="server" meta:resourcekey="chk_IsExperienceReq" />
                                        </td>
                                    </tr>

                                    <%--<tr>
            <td>
                <asp:Label ID="lbl_location" runat="server" meta:resourcekey="lbl_location" Text="Location"></asp:Label>
            </td>
            <td align="right">
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="rtxt_location" runat="server" 
                    Skin="WebBlue" Width="125px" MaxLength="500">
                </telerik:RadTextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator Enabled="false" ID="rfv_rtxt_location" runat="server" ControlToValidate="rtxt_location"
                    ErrorMessage="Please enter Location" meta:resourcekey="rfv_rtxt_location" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_emptype" runat="server" meta:resourcekey="lbl_emptype" Text="Employee Type"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Emptype" runat="server" InitialValue="- Select -"
                                                Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                <%-- <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="Permanent" Value="Permanent" />
                                            <telerik:RadComboBoxItem runat="server" Text="Contract" Value="Contract" />
                                            <telerik:RadComboBoxItem runat="server" Text="Consultant" Value="Consultant" />
                                        </Items>--%>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_Emptype" runat="server" ControlToValidate="rcmb_Emptype" InitialValue="Select"
                                                ErrorMessage="Please Select Employee Type" meta:resourcekey="rfv_rcmb_Emptype" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_Appctc" runat="server" Text="App..CTC"></asp:Label>
                                </td>
                                <td align="right">:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_Appctc" runat="server" Skin="WebBlue" Width="125px"
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator Enabled="false" ID="rfv_RNT_Appctc" runat="server" ControlToValidate="RNT_Appctc"
                                        ErrorMessage="Please Enter App.. CTC " meta:resourcekey="rfv_RNT_Appctc" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    <asp:Label ID="lbl_ctc" runat="server" Text="ctc" Visible="false"></asp:Label>
                                </td>
                                <td></td>
                            </tr>--%>
                                    <%-- <tr>
                                <td>
                                    <asp:Label ID="lbl_Dept_interviewer" runat="server" meta:resourcekey="lbl_Dept_interviewer" Text="Interviewer Department"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_dept_interviewer" runat="server" InitialValue="- Select -" AutoPostBack="true"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_dept_interviewer_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator Enabled="false" ID="rfv_rcmb_dept_interviewer" runat="server" ControlToValidate="rcmb_dept_interviewer"
                    ErrorMessage="Please Select Designation" meta:resourcekey="rfv_rcmb_dept_interviewer" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>--%>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbl_Comments" runat="server" Text="Comments"></asp:Label>
                                        </td>
                                        <td align="right" valign="top"><b>:</b></td>
                                        <td>
                                            <%--<telerik:RadTextBox ID="rtxt_Commentss" runat="server" Height="120px" Skin="WebBlue"
                                                MaxLength="500" Rows="4" TextMode="MultiLine" Width="140px">
                                            </telerik:RadTextBox>--%>

                                            <asp:TextBox ID="rtxt_Comments" runat="server" TextMode="MultiLine" Height="120px" MaxLength="500" Rows="4" Width="180px"></asp:TextBox>
                                        </td>
                                        <%--<td valign="top">
                                            <asp:RequiredFieldValidator Enabled="false" ID="rfv_Comments" runat="server" ControlToValidate="rtxt_Comments"
                                                ErrorMessage="Please Enter Comments " meta:resourcekey="rfv_Comments" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>--%>
                                        <td></td>
                                    </tr>
                                    <tr id="tr_ActDate" runat="server">
                                        <td>
                                            <asp:Label ID="lbl_ActualDate" runat="server" meta:resourcekey="lbl_ActualDate" Text="Actual Closed Date"></asp:Label>
                                        </td>
                                        <td align="right"><b>:</b></td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_ActualClosedDate" runat="server" Skin="WebBlue"
                                                Width="205px">
                                                <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                </Calendar>
                                                <%-- <TimeView CellSpacing="-1">
                    </TimeView>
                    <TimePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />--%>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <%--<td>
                     <asp:RequiredFieldValidator Enabled="false" ID="rfv_ActualClosedDate" runat="server" ControlToValidate="rdtp_ActualClosedDate"
                    ErrorMessage="Please Select Actual Closed Date" meta:resourcekey="rfv_ActualClosedDate" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>--%>
                                        <td></td>


                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                        <td></td>

                                        <td align="right">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                                Text="Update" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                ValidationGroup="Controls" Visible="False" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btn_Cancel" runat="server" OnCommand="btn_Cancel_Click" Text="Cancel" />
                                        </td>
                                        <td>
                                            <asp:ValidationSummary ID="vs_JobRequisition" runat="server" meta:resourcekey="vs_JobRequisition"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                        </td>
                                        <td></td>
                                    </tr>--%>
                                    <%-- <tr>
                                        <td colspan="4" align="center">
                                            <table width="100%">
                                                <tr>
                                                    <td width="100%">--%>
                                    <%--   <asp:Panel ID="pnl_multipage2" runat="server" Visible="false">
                                                            <%-- <asp:Label ID="lbl_heading" runat="server" Text="Assign SkillS"></asp:Label>--%>
                                    <%-- <table align="center">
                                                                <tr>
                                                                    <td align="center" colspan="7">
                                                                        <telerik:RadMultiPage ID="RM_Skills" runat="server">
                                                                            <telerik:RadPageView ID="RP_SkillForm" runat="server" Width="100%">
                                                                                <table align="center">
                                                                                    <tr>
                                                                                        <td align="left" colspan="3">
                                                                                            <telerik:RadGrid ID="RG_Skills" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                                                                                 PageSize="5" Width="300px">
                                                                                                <MasterTableView CommandItemDisplay="Top">
                                                                                                    <Columns>
                                                                                                        <telerik:GridBoundColumn DataField="JR_SKILLS_ID" HeaderText="Id" Visible="false">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridBoundColumn DataField="JR_ID" HeaderText="JR Id" Visible="false">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridBoundColumn DataField="SKILL_ID" HeaderText="Skills" Visible="false">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Skill Name">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridTemplateColumn>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton ID="lnk_Delete" runat="server" OnClientClick="return confirm('Do you want to delete this Skill?');" OnCommand="lnk_Delete_Command" CommandArgument='<%# Eval("JR_SKILLS_ID") %>'
                                                                                                                    Text="Delete"></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </telerik:GridTemplateColumn>
                                                                                                    </Columns>
                                                                                                    <CommandItemTemplate>
                                                                                                        <div align="right">
                                                                                                            <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_CommandSkills">Add</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </CommandItemTemplate>
                                                                                                </MasterTableView>
                                                                                            </telerik:RadGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                            <telerik:RadPageView ID="RP_skilldetails" runat="server" Width="100%">
                                                                                <table align="center">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lbl_Skills" runat="server" Text="Skills"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <b>:</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <telerik:RadComboBox ID="RCMB_Skills" runat="server"  >
                                                                                            </telerik:RadComboBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="chk_IsSkillReq" runat="server" meta:resourcekey="chk_IsSkillReq" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="7">
                                                                                            <asp:Button ID="btn_Add" runat="server" Text="Add" OnClick="btn_Save_Click1" ValidationGroup="Controls1" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>
                                    <%--  </asp:Panel>
                                                    </td>--%>
                                    <%--    </tr>
                                            </table>
                                        </td>
                                    </tr>--%>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>

            </table>
            <br />
        </div>
    </form>
</body>
</html>