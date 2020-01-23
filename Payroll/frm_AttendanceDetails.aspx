<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_AttendanceDetails.aspx.cs" Inherits="Payroll_frm_AttendanceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_COMPOFFDetails" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcmb_Attdtls_BU">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Attdtls_Period">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Attdtls_PeriodElements">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdtp_AttDtls_AttDt">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_AttDtls_Submit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <telerik:RadScriptBlock ID="rsbScripts" runat="server">

                <script language="javascript" type="text/javascript">
                    function confirmationSave() {
                        if (confirm("Do you want to finalize the Attendance?")) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    function Status(r) {
                        debugger;
                        confirm("Are you sure.It Updates with the same data.");
                        return true;
                    }
                    //                    function OnConfirm() {
                    //                        var x = confirm('Do you want to Proceed?');
                    //                        if (x) {
                    //                            document.getElementById('hfConfirm').value = "True";
                    //                        }
                    //                        else {
                    //                            document.getElementById('hfConfirm').value = "False";
                    //                        }
                    //                        return true;
                    //                    }
                </script>

            </telerik:RadScriptBlock>
            <%-- <asp:HiddenField ID="hfConfirm" runat="server" />--%>
            <table align="center" style="vertical-align: top;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_AttendanceDtlsHeader" runat="server" Text="Attendance Details"
                            Font-Bold="True" meta:resourcekey="lbl_AttendanceDtlsHeader"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
            <table align="center" style="vertical-align: top;">
                <tr>
                    <td>
                        <asp:Label ID="lbl_AttDtls_BU" runat="server" Text="Business Unit" meta:resourcekey="lbl_AttDtls_BU"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmb_Attdtls_BU" runat="server" MarkFirstMatch="true" meta:resourcekey="rcmb_Attdtls_BU"
                            Skin="WebBlue" OnSelectedIndexChanged="rcmb_Attdtls_BU_SelectedIndexChanged" Filter="Contains" AutoPostBack="True">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_AttDtls_Period" runat="server" meta:resourcekey="lbl_AttDtls_Period"
                            Text="Period"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmb_Attdtls_Period" runat="server" MarkFirstMatch="true" Filter="Contains"
                            AutoPostBack="True" Skin="WebBlue" meta:resourcekey="rcmb_Attdtls_Period" OnSelectedIndexChanged="rcmb_Attdtls_Period_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr runat="server" id="tblr_AttDtls_PeriodElements" visible="false">
                    <td>
                        <asp:Label ID="lbl_AttDtls_PeriodElements" runat="server" Text="Period&nbsp;Elements"></asp:Label>
                        <%--meta:resourcekey="lbl_AttDtls_PeriodElements" --%>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmb_Attdtls_PeriodElements" MarkFirstMatch="true" runat="server" Filter="Contains"
                            AutoPostBack="True" Skin="WebBlue" meta:resourcekey="rcmb_Attdtls_Period" OnSelectedIndexChanged="rcmb_Attdtls_PeriodElements_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr runat="server" id="tblr_AttDtls_AttDt" visible="false">
                    <td>
                        <asp:Label ID="lbl_AttDtls_AttDt" runat="server" Text="Date of Attendance" meta:resourcekey="lbl_AttDtls_AttDt"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdtp_AttDtls_AttDt" runat="server" meta:resourcekey="rdtp_AttDtls_AttDt"
                            Skin="WebBlue" OnSelectedDateChanged="rdtp_AttDtls_AttDt_SelectedDateChanged"
                            AutoPostBack="True">
                            <DateInput AutoPostBack="True" Skin="WebBlue">
                            </DateInput>
                            <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:Image ID="Image1" runat="server" Height="15px" ImageUrl="~/Images/Green1.png"
                            Width="20px" />
                    </td>
                    <td>
                        <asp:Label ID="lbl_color" runat="server" Text="-->Attendance already done"> </asp:Label>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td align="center" colspan="3">
                        <telerik:RadGrid ID="rgd_AttDtls_Emp" runat="server" meta:resourcekey="rgd_AttDtls_Emp"
                            Skin="WebBlue" AutoGenerateColumns="False" Visible="false">
                            <HeaderContextMenu Skin="WebBlue">
                            </HeaderContextMenu>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                Text="Check All" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn meta:resourcekey="ATTENDANCE_EMP_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("ATTENDANCE_EMP_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn meta:resourcekey="ATTENDANCE_EMP_NAME" Visible="true"
                                        HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_empName" runat="server" Text='<%# Eval("ATTENDANCE_EMP_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Attendance Status" DataField="ATTENDANCE_LEAVE_STATUS"
                                        UniqueName="ATTENDANCE_LEAVE_STATUS">
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="rcmb_AttDtls_Status" runat="server" MarkFirstMatch="true"
                                                OnSelectedIndexChanged="rcmb_AttDtls_Status_SelectedIndexChanged" Skin="WebBlue"
                                                AutoPostBack="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Present" Value="P" ForeColor="Black" />
                                                    <telerik:RadComboBoxItem Text="Absent" Value="A" ForeColor="Red" />
                                                    <telerik:RadComboBoxItem Text="Leave" Value="L" ForeColor="Magenta" />
                                                    <telerik:RadComboBoxItem Text="Weekly-Off" Value="W" ForeColor="Blue" />
                                                    <telerik:RadComboBoxItem Text="Travel" Value="T" ForeColor="DodgerBlue" />
                                                    <telerik:RadComboBoxItem Text="Comp Off" Value="C" ForeColor="Maroon" />
                                                    <telerik:RadComboBoxItem Text="Holiday" Value="H" ForeColor="DarkGreen" />
                                                    <telerik:RadComboBoxItem Text="Half Day Absent" Value="HD" ForeColor="Gray" />
                                                    <telerik:RadComboBoxItem Text="Half Day Leave" Value="HL" ForeColor="DarkGoldenrod" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn meta:resourcekey="ATTENDANCE_NOOFHOURS" Visible="false"
                                        HeaderText="No. Of Hours Worked" UniqueName="NOOFHOURS">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="rntxt_noofhours" runat="server" AutoPostBack="true"
                                                MaxLength="4" Text='<%#Eval("ATTENDANCE_NOOFHOURS") %>' MinValue="0.00" OnTextChanged="rntxt_noofhours_TextChanged">
                                            </telerik:RadNumericTextBox>
                                            <asp:RangeValidator ID="rgv_rntxt_noofhours" runat="server" ErrorMessage="*" Type="Double"
                                                MaximumValue='<%#Eval("BUSINESSUNIT_NOOFHOURS") %>' ControlToValidate="rntxt_noofhours">
                                            </asp:RangeValidator>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <FilterMenu Skin="WebBlue">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="btn_AttDtls_Submit" runat="server" meta:resourcekey="btn_AttDtls_Submit"
                            OnClick="btn_AttDtls_Submit_Click" Text="Submit" Visible="False" />
                        <asp:Button ID="btn_AttDtls_Finalize" runat="server" meta:resourcekey="btn_AttDtls_Finalize"
                            OnClick="btn_AttDtls_Finalize_Click" Text="Finalize" Visible="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>