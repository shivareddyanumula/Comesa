<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_trainingattendancedtls.aspx.cs" Inherits="Training_frm_trainingattendancedtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_AttendanceDtls" runat="server" Text="Attendance Details" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="lbl_attend_id" runat="server" Visible="false"></asp:Label>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <asp:Label ID="lbl_AttDtls_BU" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Attdtls_BU" runat="server" MarkFirstMatch="true"
                    Skin="WebBlue" OnSelectedIndexChanged="rcmb_Attdtls_BU_SelectedIndexChanged"
                    AutoPostBack="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_AttDtls_Training" runat="server" Text="Training Attendance :"></asp:Label>
            </td>
            <td>
                
            </td>
            <td>
                <telerik:RadComboBox  ID="rcmb_Attdtls_Training" runat="server" MarkFirstMatch="true" Filter="Contains"
                    AutoPostBack="true" Skin="WebBlue" OnSelectedIndexChanged="rcmb_Attdtls_TRG_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr runat="server" id="tblr_AttDtls_AttDt" >
            <td>
                <asp:Label ID="lbl_AttDtls_AttDt" runat="server" Text="Date of Attendance :"></asp:Label>
            </td>
            <td>
                
            </td>
            <td>
                <telerik:RadDatePicker  ID="rdtp_AttDtls_AttDt" runat="server"
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
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <telerik:RadGrid  ID="rgd_AttDtls_Emp" runat="server"
                    Skin="WebBlue" AutoGenerateColumns="False" Visible="false">
                    <HeaderContextMenu Skin="WebBlue">
                    </HeaderContextMenu>
                    <MasterTableView>
                        <Columns>
                        
                        <%-- <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_attendid" runat="server" Text='<%# Eval("ATTENDANCE_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn meta:resourcekey="ATTENDANCE_EMP_NAME" Visible="true"
                                HeaderText="Employee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_empName" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <%--<telerik:GridTemplateColumn HeaderText="Attendance Status" DataField="ATTENDANCE_LEAVE_STATUS"
                                        UniqueName="ATTENDANCE_LEAVE_STATUS">--%>
                            <telerik:GridTemplateColumn HeaderText="Attendance Status" DataField="ATTENDANCE_STATUS" UniqueName="ATTENDANCE_STATUS">
                                <ItemTemplate>
                                    <telerik:RadComboBox  ID="rcmb_AttDtls_Status" runat="server"
                                        Skin="WebBlue" AutoPostBack="false" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Present" Value="P" />
                                            <telerik:RadComboBoxItem Text="Absent" Value="A" />
                                            <%-- <telerik:RadComboBoxItem Text="Leave" Value="L" />
                                                    <telerik:RadComboBoxItem Text="Weekly-Off" Value="W" />
                                                    <telerik:RadComboBoxItem Text="Travel" Value="T" />
                                                    <telerik:RadComboBoxItem Text="Comp Off" Value="C" />
                                                    <telerik:RadComboBoxItem Text="Holiday" Value="H" />--%>
                                        </Items>
                                    </telerik:RadComboBox>
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
                <asp:Button ID="btn_AttDtls_Submit" runat="server" OnClick="btn_AttDtls_Submit_Click"
                    Text="Submit" Visible="False" />
                <asp:Button ID="btn_finalise" runat="server" OnClick="btn_finalise_Submit_Click"
                    Text="Finalise" Visible="False" />
            </td>
             <td align="center" colspan="3">
                 &nbsp;</td>
            <%--<td>
                <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
            </td>--%>
        </tr>
    </table>
</asp:Content>
