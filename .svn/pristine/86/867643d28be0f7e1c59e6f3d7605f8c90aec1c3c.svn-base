<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Attendance3.aspx.cs" Inherits="Payroll_frm_Attendance3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript">
        function ShowPopup(BU, PD, PE) {
            alert(BU);
            var win = window.radopen('../Payroll/frm_ViewAttendance.aspx?BU=' + BU + '&PD=' + PD + '&PE=' + PE, "RW_IncidentDetails");
            //var win = window.radopen('../Masters/Frm_leaveBalances.aspx', "RW_IncidentDetails");
            alert(PD);
            win.center();
            //win.set_height("650");
            //win.set_width("700");
            win.set_modal(true);
            //win.set_title("Employee Due To Retire Report");
        }
    </script>--%>
    <style type="text/css">
        .gvheaderFixed {
            font-weight: bold;
            position: relative;
            background-color: White;
        }

        td.freezepane {
            text-align: left;
            border-width: 0;
            background-color: White;
            position: relative;
            cursor: default;
            left: inherit;
        }

        .WrapperDiv {
            width: 800px;
            height: 400px;
            border: 1px solid black;
        }

            .WrapperDiv TH {
                position: relative;
            }

            .WrapperDiv TR {
                /* Needed for IE */
                height: 0px;
            }

        .rgAdvPart {
            display: none;
        }

        .overlay {
            position: absolute !important;
            background-color: white;
            top: 0px;
            left: 0px;
            width: 100%;
            height: 5000%;
            opacity: 0.8;
            -moz-opacity: 0.8;
            filter: alpha(opacity=80);
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=80)";
            z-index: 10000;
        }

        .CenterPB {
            position: absolute;
            left: 50%;
            top: 50%;
            margin-top: -30px; /* make this half your image/element height */
            margin-left: -30px; /* make this half your image/element width */
        }

        /*#testTable
        {
            width: 300px;
            margin-left: auto;
            margin-right: auto;
        }
        #tablePagination
        {
            background-color: Transparent;
            font-size: 0.8em;
            padding: 0px 5px;
            height: 20px;
        }
        #tablePagination_paginater
        {
            margin-left: auto;
            margin-right: auto;
        }
        #tablePagination img
        {
            padding: 0px 2px;
        }
        #tablePagination_perPage
        {
            float: left;
        }
        #tablePagination_paginater
        {
            float: right;
        }--*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <script type="text/javascript">
        function SetFocus() {
            // tlrkComboBoxes[0] represents the client-side object of the first combobox
            // tlrkComboBoxes[1] represents the client-side object of the second combobox
            var input = document.getElementById(tlrkComboBoxes[0].InputID);
            input.focus();
            tlrkComboBoxes[1].Disable();
        }
        function ShowPopp(BU, PD, PE) {
            //var win = window.radopen('../Payroll/frm_ViewAttendance.aspx?BU=' + BU + '&PD=' + PD + '&PE=' + PE, "RW_IncidentDetails");
            //var win = window.radopen('../Payroll/frm_ViewAttendance.aspx', "RW_IncidentDetails");
            var win = window.radopen('../Masters/Frm_leaveBalances.aspx', "RW_lbalances");
            //alert(PD);
            //alert(PE);
            win.center();
            win.set_modal(true);
            win.set_title("Sample...");
        }
        function ShowPop(BU, PD, PE) {
            //var win = window.radopen('../Masters/Frm_leaveDetails.aspx', "RW_leavedetails");
            //debugger;
            //alert("hii");
            var win = window.open('../Payroll/frm_ViewAttendance.aspx?BU=' + BU + '&PD=' + PD + '&PE=' + PE, "RW_IncidentDetails");
            //var win = window.open('frm_ViewAttendance.aspx',"RW_leavedetails");
            //alert("hi");
            //win.center();
            //win.set_modal(true);
        }
    </script>

    <script type="text/javascript">
        function HandleDrill(sender, eventArgs) {
            var item = eventArgs.get_item();
            //alert(item.get_text() + ":" + item.get_value()); // alert the new item text and value. 
        }
    </script>

    <%--<script src="../jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../jquery.tablePagination.0.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(
     function() {
         $('table').tablePagination({});
     });
    </script>--%>
    <table align="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="u1" runat="server">
                    <ContentTemplate>
                        <div style="text-align: center;" class="">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="u1"
                                DynamicLayout="true">
                                <ProgressTemplate>
                                    <div style="align-content: center;" class="overlay">
                                        <img src="../Images/small_loading.gif" alt="Loading..." style="height: 23px; width: 26px">
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <asp:Label ID="Label1" runat="server" Visible="false">
                        </asp:Label>
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Header" runat="server" Text="Attendance" Font-Bold="true">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AttBusinessUnit" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_AttBusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Period">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AttPeriod" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr runat="server" id="tblr_AttPeriodElement" visible="false">
                                <td>
                                    <asp:Label ID="lbl_PeriodElement" runat="server" Text="Period Element">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AttPeriodElement" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_AttPeriodElement_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                        <br />
                        <table align="left">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Note" runat="server" Text="NOTE" Font-Underline="true"></asp:Label>
                                </td>
                                <td colspan="18">
                                    <asp:Label ID="lbl_Meaning" runat="server" Text="Symbols and their meaning" Font-Underline="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_P" runat="server" Text="P"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Present" runat="server" Text="Present"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_L" runat="server" Text="L"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Leave" runat="server" Text="Leave"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_A" runat="server" Text="A"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Absent" runat="server" Text="Absent"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_W" runat="server" Text="W"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_WeeklyOff" runat="server" Text="Weekly-Off"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_T" runat="server" Text="T"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Travel" runat="server" Text="Travel"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_C" runat="server" Text="C"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_CompOff" runat="server" Text="Comp-Off"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_H" runat="server" Text="H"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Holiday" runat="server" Text="Holiday"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_HD" runat="server" Text="HA"></asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_HalfDay" runat="server" Text="Half-Day Absent"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_HDL" runat="server" Text="HL">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>=</b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_HalfDayLeave" runat="server" Text="Half-Day Leave"></asp:Label>
                                </td>
                                <td></td>
                                <td colspan="15"></td>
                            </tr>
                        </table>
                        <table align="center" width="100%">
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">

                                    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="1140px">
                                        <%--  <div id="GridViewContainer"  style="width:1000px;height:600px;">--%>
                                        <%--   <div id="AdjResultsDiv" style="overflow: auto; width: 1000px">--%>

                                        <%--  <asp:GridView ID="rg_Attendence" runat="server" AutoGenerateColumns="false" Width="1100px" Height="1000px" 
                                            OnRowEditing="rg_Attendence_RowEditing" OnRowUpdating="rg_Attendence_RowUpdating" OnRowCancelingEdit="rg_Attendence_RowCancelingEdit" OnRowDataBound="rg_Attendence_RowDataBound">
                                        --%>
                                        <telerik:RadGrid ID="rg_Attendence" runat="server" Width="100%" Height="500px" AutoGenerateColumns="false"
                                            OnItemDataBound="rg_Attendence_ItemDataBound" OnNeedDataSource="rg_Attendence_NeedDataSource" OnUpdateCommand="rg_Attendence_UpdateCommand"
                                            EnableModelValidation="True" ForeColor="#333333" GridLines="Vertical">
                                            <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                                            <ClientSettings>
                                                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                                            </ClientSettings>
                                            <MasterTableView EditMode="InPlace">

                                                <Columns>
                                                    <telerik:GridTemplateColumn Visible="true" ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Employee Name" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("ATTENDANCE_EMP_NAME") %>'></asp:Label>--%>
                                                            <%#Eval("ATTENDANCE_EMP_NAME") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("ATTENDANCE_EMP_NAME") %>'>
                                                            </asp:Label>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-Width="10px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList1" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D1") %>--%>
                                                            <%# Eval("D1").ToString() == "HD" ? "HA" : Eval("D1") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList1" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%--<asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D2").ToString() == "HD" ? "HA" : Eval("D2") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList2" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D3").ToString() == "HD" ? "HA" : Eval("D3") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList3" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D4").ToString() == "HD" ? "HA" : Eval("D4") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList4" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D5").ToString() == "HD" ? "HA" : Eval("D5") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList5" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D6").ToString() == "HD" ? "HA" : Eval("D6") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList6" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D7").ToString() == "HD" ? "HA" : Eval("D7") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList7" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D8").ToString() == "HD" ? "HA" : Eval("D8") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList8" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D9").ToString() == "HD" ? "HA" : Eval("D9") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList9" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D10").ToString() == "HD" ? "HA" : Eval("D10") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList10" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D11").ToString() == "HD" ? "HA" : Eval("D11") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList11" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D12").ToString() == "HD" ? "HA" : Eval("D12") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList12" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D13").ToString() == "HD" ? "HA" : Eval("D13") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList13" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D14").ToString() == "HD" ? "HA" : Eval("D14") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList14" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D15").ToString() == "HD" ? "HA" : Eval("D15") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList15" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D16").ToString() == "HD" ? "HA" : Eval("D16") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList16" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D17").ToString() == "HD" ? "HA" : Eval("D17") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList17" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D18").ToString() == "HD" ? "HA" : Eval("D18") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList18" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D19").ToString() == "HD" ? "HA" : Eval("D19") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList19" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D20").ToString() == "HD" ? "HA" : Eval("D20") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList20" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D21").ToString() == "HD" ? "HA" : Eval("D21") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList21" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D22").ToString() == "HD" ? "HA" : Eval("D22") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList22" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D23").ToString() == "HD" ? "HA" : Eval("D23") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList23" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D24").ToString() == "HD" ? "HA" : Eval("D24") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList24" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D25").ToString() == "HD" ? "HA" : Eval("D25") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList25" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D26").ToString() == "HD" ? "HA" : Eval("D26") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList26" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D27").ToString() == "HD" ? "HA" : Eval("D27") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList27" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D28").ToString() == "HD" ? "HA" : Eval("D28") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList28" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D29").ToString() == "HD" ? "HA" : Eval("D29") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList29" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D30").ToString() == "HD" ? "HA" : Eval("D30") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList30" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="rcmbList2" runat="server" Text=""></asp:Label>--%>
                                                            <%--<%# Eval("D2") %>--%>
                                                            <%# Eval("D31").ToString() == "HD" ? "HA" : Eval("D31") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="rcmbList31" runat="server" SkinID="Attendance">
                                                                <Items>
                                                                    <asp:ListItem Text="P" Value="P" />
                                                                    <asp:ListItem Text="A" Value="A" />
                                                                    <asp:ListItem Text="L" Value="L" />
                                                                    <asp:ListItem Text="W" Value="W" />
                                                                    <%-- <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />--%>
                                                                    <asp:ListItem Text="H" Value="H" />
                                                                    <asp:ListItem Text="HA" Value="HD" />
                                                                    <asp:ListItem Text="HL" Value="HL" />
                                                                    <%-- <asp:ListItem Text="WH" Value="WH" />
                                                            <asp:ListItem Text="OS" Value="OS" />
                                                            <asp:ListItem Text="OD" Value="OD" />--%>
                                                                </Items>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lbl_EmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'>
                                                            </asp:Label>--%>
                                                            <%# Eval("EMP_EMPCODE") %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>

                                                            <asp:Label ID="lbl_EmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'>
                                                            </asp:Label>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Employee Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Empid" runat="server" Text='<%# Eval("ATTENDANCE_EMP_ID") %>'>
                                                            </asp:Label>
                                                            <%-- <%# Eval("ATTENDANCE_EMP_ID") %>--%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("ATTENDANCE_EMP_ID") %>' Visible="false">
                                                            </asp:Label>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridEditCommandColumn EditText="Edit" ButtonType="LinkButton" CancelText="Cancel" UpdateText="Update"></telerik:GridEditCommandColumn>
                                                    <%-- <telerik:GridEditCommandColumn EditText="Edit" ButtonType="LinkButton" CancelText ="Cancel" UpdateText="Update"></telerik:GridEditCommandColumn>--%>
                                                    <%--<asp:CommandField ShowEditButton="True" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="#507CD1"/>--%>
                                                    <%-- <telerik:GridTemplateColumn HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkAttendanceEdit" runat="server" Text="Edit" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="lnkAttendanceEdit_Command"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>--%>
                                                </Columns>
                                            </MasterTableView>
                                            <%--<EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderStyle="Solid" BorderWidth="1" BorderColor="#507CD1"></HeaderStyle>
                                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                        <RowStyle BackColor="#EFF3FB" BorderStyle="Solid" BorderWidth="1" BorderColor="#507CD1"></RowStyle>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>--%>
                                        </telerik:RadGrid>
                                        <%--</div>--%>
                                    </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="false" OnClick="btn_Save_Click" />
                                    <%--<asp:Button ID="btn_Finalize" runat="server" Text="Finalize" Visible="false" OnClick="btn_Save_Click" />--%>
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="rg_Attendence" EventName="rg_Attendence_RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="rg_Attendence" EventName="rg_Attendence_RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="rg_Attendence" EventName="rg_Attendence_RowCancelingEdit" />--%>
                        <asp:PostBackTrigger ControlID="rg_Attendence" />
                        <asp:PostBackTrigger ControlID="btn_Save" />
                    </Triggers>
                </asp:UpdatePanel>
                <%--      </telerik:RadAjaxPanel>
                <telerik:RadAjaxLoadingPanel ID="RALP_ATTENDANCE" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>