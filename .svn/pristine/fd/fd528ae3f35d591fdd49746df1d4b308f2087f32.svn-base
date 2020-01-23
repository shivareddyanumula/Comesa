<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_attendancereport.aspx.cs" Inherits="PMS_frm_attendancereport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <script src="../Script/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function fun() {
            $(document).ready(function () {


                var rdbListIndex = $('#<%=rdbList.ClientID %> input[type=radio]:checked').val();
                if (rdbListIndex == "1") {
                    $('input[type="submit"]').removeAttr('disabled');

                }
                if (rdbListIndex == "2") {
                    $('input[type="submit"]').removeAttr('disabled');

                }
            });
        }
    </script>

    <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="updPanel1" runat="server">
                    <ContentTemplate>
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_Attenadnce" runat="server" Text="Attendance Import"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadMultiPage ID="Rm_Attenadnce_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto">
                                        <telerik:RadPageView ID="Rp_Attenadnce_VIEWMAIN" runat="server" Selected="True">
                                            <table align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit   :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BusinessUnitType"
                                                            ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcm_period" runat="server" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="rfv_period" runat="server" ControlToValidate="rcm_period"
                                                            ErrorMessage="Please Select Period" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td align="center">
                                                        <%-- <asp:LinkButton ID="lnk_downloadtemplate" runat="server" Text="Download Template"></asp:LinkButton>--%>
                                                        <a href="~/Download/Sample Of Attendance2.xlsx" runat="server" id="linkdownload">Download
                                                            Attendance Details template</a>
                                                        <%--</td>
                                <td>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                            <td>--%>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:FileUpload ID="fileupload_attendance" runat="server" />
                                                        <asp:Button ID="btn_uploadattendance" Text="Import Excel" runat="server" OnClick="btn_upload_onclick"
                                                            ValidationGroup="Controls" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <%-- <tr>
                            
                            <asp:LinkButton ID="lnk_ImportProcess1" runat="server"></asp:LinkButton>
                            </tr>--%>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <telerik:RadGrid ID="Rg_Attendancedtls" runat="server" AutoGenerateColumns="False"
                                                            GridLines="None" Skin="WebBlue" AllowFilteringByColumn="True">
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <%--  <telerik:GridBoundColumn DataField="Employee ID*" UniqueName="Employee ID*" HeaderText="EMPLOYEE ID"
                                                                        Visible="True">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" Visible="true" HeaderText="Employee Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("Employee ID*") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" Visible="true" HeaderText="Employee Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_empname" runat="server" Text='<%# Eval("Employee Name*") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <%-- <telerik:GridTemplateColumn AllowFiltering="false" Visible="true" HeaderText="Date Of Attendance" DataType="System.DateTime">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Attendance" runat="server" Text='<%# Eval("Date of Attendance*(dd/mm/yyyy)") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>--%>
                                                                    <telerik:GridBoundColumn DataField="Date of Attendance*(dd/mm/yyyy)" UniqueName="Date of Attendance*(dd/mm/yyyy)"
                                                                        AllowFiltering="false" HeaderText="Date Of Attendance" DataFormatString="{0:dd/MM/yyyy}"
                                                                        DataType="System.DateTime">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <%--  <telerik:GridTemplateColumn AllowFiltering="false" DataField="Date of Attendance*(dd/mm/yyyy)"
                                                                        UniqueName="Date of Attendance*(dd/mm/yyyy)" Visible="true" HeaderText="Date Of Attendance">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_doa" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>--%>
                                                                    <%--   <telerik:GridBoundColumn DataField="In Time*(hh:mm)24 Hrs" UniqueName="In Time*(hh:mm)24 Hrs"
                                                                        AllowFiltering="false" HeaderText="In Time">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" DataField="In Time*(hh:mm)24 Hrs"
                                                                        Visible="true" HeaderText="In Time">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txt_intime" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" DataField="Out Time*(hh:mm)24 Hrs"
                                                                        Visible="true" HeaderText="Out Time">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txt_outime" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--   <telerik:GridBoundColumn DataField="Out Time*(hh:mm)24 Hrs" UniqueName="Out Time*(hh:mm)24 Hrs"
                                                                        AllowFiltering="false" HeaderText="Out Time">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn AllowFiltering="false" Visible="true" HeaderText="Attendance Status"
                                                                        DataField="Attendance Status*">
                                                                        <ItemTemplate>
                                                                            <telerik:RadComboBox ID="rcmb_AttDtls_Status1" runat="server" Skin="WebBlue" AutoPostBack="false"
                                                                                MarkFirstMatch="true">
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem Text="Present" Value="P" />
                                                                                    <telerik:RadComboBoxItem Text="Absent" Value="A" />
                                                                                    <telerik:RadComboBoxItem Text="Leave" Value="L" />
                                                                                    <telerik:RadComboBoxItem Text="Weekly-Off" Value="W" />
                                                                                    <telerik:RadComboBoxItem Text="Travel" Value="T" />
                                                                                    <telerik:RadComboBoxItem Text="Comp Off" Value="C" />
                                                                                    <telerik:RadComboBoxItem Text="Holiday" Value="H" />
                                                                                    <telerik:RadComboBoxItem Text="Half Day Absent" Value="HD" />
                                                                                    <telerik:RadComboBoxItem Text="Half Day Leave" Value="HL" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--  <telerik:GridBoundColumn DataField="Attendance Status*" UniqueName="Attendance Status*"
                                                                        HeaderText="Attendance Status">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </telerik:GridBoundColumn>--%>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                                <tr id="trSelect" runat="server" visible="false" align="center">
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblSelection" runat="server" Text="Select :"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <%--AutoPostBack="true" OnSelectedIndexChanged="rdbList_SelectedIndexChanged"--%>
                                                                    <asp:RadioButtonList ID="rdbList" runat="server" RepeatDirection="Horizontal" OnClick="fun();">
                                                                        <asp:ListItem Text="Submit" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Finalize" Value="2"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <%--<asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" />
                                                        &nbsp; &nbsp;--%>
                                                        <%--<asp:Button ID="BTN_FINALISE" runat="server" Text="Finalize" OnClick="BTN_FINALISE_Click"/>
                                                        &nbsp; &nbsp; &nbsp;--%>
                                                        <asp:Button ID="BTN_FINALISE" runat="server" Text="Process" OnClick="BTN_FINALISE_Click"
                                                            Enabled="false" />
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ValidationSummary ID="vs_Attendance" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                            ValidationGroup="Controls" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_uploadattendance" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>