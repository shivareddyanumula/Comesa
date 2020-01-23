<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Dashboradmngr.aspx.cs" Inherits="Masters_Default3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <script type="text/javascript">
        function ShowPop_LeaveChart() {
            var win = window.radopen('../Security/frm_LeaveChart.aspx', "RadWindow1");
            win.center();
            win.set_modal(true);
        }
    </script>

    <script type="text/javascript">
        function ShowPop() {

            var win = window.radopen('../PMS/frm_KRAApprove.aspx', "RW_KRAApproval");

            win.center();
            //win.height = 30;
            win.set_modal(true);
        }
        function ShowPopForm() {
            var win = window.radopen("../Payroll/frm_empleavebal.aspx", "RW_Login");
            win.center();
            win.set_modal(true);
        }
        function ShowLeaveBalance() {
            var win = window.radopen("../Payroll/frmLeaveBalances.aspx", "RW_LeaveBalance");
            win.center();
            win.set_modal(true);
        }
    </script>

    <div class="middlebox3">

        <div class="left1">

            <div class="lefthdr1">
                QUICK LINKS
            </div>

            <div class="leftbox1a">

                <ul id="verticalmenu" class="glossymenu">

                    <%--<li> <asp:LinkButton ID="lnk_Expense" runat="server" Text="Expense Request" OnClick="lnk_Expense_Click"
                                    ForeColor="#275071"></asp:LinkButton></li>--%>
                    <li>
                        <asp:LinkButton ID="lnk_LoanAdvance" runat="server" Text="Loan/Advances Request"
                            OnClick="lnk_LoanAdvance_Click" ForeColor="White"></asp:LinkButton></li>

                    <li>
                        <asp:LinkButton ID="lnk_EmpSearch" runat="server" Text="Employee Search" ForeColor="White"
                            OnClick="lnk_EmpSearch_Click"></asp:LinkButton></li>

                    <li>
                        <asp:LinkButton ID="lnl_EmployeesCalender" runat="server" Text="Team Leave Calendar"
                            ForeColor="White" OnClick="lnl_EmployeesCalender_Click"></asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="lnk_MyCalender" runat="server" Text="My Leave Calendar" ForeColor="White"
                            OnClick="lnk_MyCalender_Click"></asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="lnk_LeaveBalances" runat="server" Text="My Leave Balances" ForeColor="White"
                            OnClick="lnk_LeaveBalances_Click"></asp:LinkButton>
                    </li>

                </ul>

            </div>
            <!--leftbox1a end-->

            <div class="lefthdr2" id="tr_bday" runat="server">
                BIRTHDAY REMINDER<br />
                <asp:Label ID="lbl_Birthday" runat="server" Style="font-weight: 700; font-size: small"></asp:Label><br />
                <asp:Label ID="lbl_Reminders" runat="server" Text="HAPPY BIRTHDAY TO" Style="font-weight: 700; font-size: small"></asp:Label><br />
                <u>
                    <telerik:RadTicker ID="RTicker" runat="server" AutoStart="true" Loop="true" TickSpeed="50"
                        Font-Bold="True" Font-Names="Arial" Font-Size="12pt">
                        <Items>
                            <telerik:RadTickerItem Text='<%# Eval("EMPNAME")%>'></telerik:RadTickerItem>
                        </Items>
                    </telerik:RadTicker>
            </div>

            <div class="leftbox2a">
            </div>

            <div class="lefthdr3">
                CALENDER
                        
            </div>

            <div class="leftbox2a">
                <asp:Calendar ID="emp_Calendar" runat="server" TodayDayStyle-BackColor="Gray" TodayDayStyle-ForeColor="White"
                    ForeColor="#FFFFFF" TitleStyle-BackColor="#133A6D" TitleStyle-ForeColor="White" Width="98%"
                    SelectedDayStyle-ForeColor="White" SelectedDayStyle-BackColor="Gray" NextPrevStyle-ForeColor="White"></asp:Calendar>
            </div>
            <br /><br />
            <%--<div class="lefthdr3a"><a href="../Masters/frm_userMissionandVission.aspx" style="color: white;">Mission and Vision</a></div>--%>
            
        </div>
        <!--left1 end-->


        <div class="rightsidebox1a">
            <div class="rightboxtext1a">
                NOTIFICATIONS
            </div>

            <div class="rightboxtext1b">
                <asp:Panel ID="pnl_Notification" runat="server" Font-Bold="true"
                    Font-Size="Large">
                    <%-- <a href="http://test.dhanushinfotech.com/SmartHR_LeaveManagementSystem/index.html"
                        target="_blank" style="color: Blue; font: Large;">Please click here to view LMS Online Demo </a>--%>
                </asp:Panel>
            </div>
        </div>

    </div>

</asp:Content>