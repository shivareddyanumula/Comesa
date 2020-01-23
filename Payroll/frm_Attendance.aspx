<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Attendance.aspx.cs" Inherits="Payroll_frm_Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    </script>

    <script type="text/javascript">
        function HandleDrill(sender, eventArgs) {
            var item = eventArgs.get_item();
            alert(item.get_text() + ":" + item.get_value()); // alert the new item text and value. 
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
                        <div style="text-align: center;">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="u1"
                                DynamicLayout="true">
                                <ProgressTemplate>
                                    <img src="../Images/small_loading.gif" style="height: 23px; width: 26px">
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <asp:Label ID="Label1" runat="server" Visible="false">
                        </asp:Label>
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Header" runat="server" Text="Attendence Details">
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
                                    <%--<asp:DropDownList runat="server" ID="rcmb_AttPeriodElement" AutoPostBack="true"  OnSelectedIndexChanged="rcmb_AttPeriodElement_SelectedIndexChanged">
                            
                        </asp:DropDownList>--%>
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

                                    <asp:Panel ID="Panel1" runat="server" Height="1000px" Width="1000px" ScrollBars="Auto">
                                        <%--  <div id="GridViewContainer"  style="width:1000px;height:600px;">--%>
                                        <%--   <div id="AdjResultsDiv" style="overflow: auto; width: 1000px">--%>
                                        <asp:GridView ID="rg_Attendence" runat="server" AutoGenerateColumns="false" GridLines="None"
                                            Width="1000px" Height="1000px" AllowPaging="true" PageSize="10">
                                            <%--<ClientSettings>
                                            <Scrolling UseStaticHeaders="true" AllowScroll="true" SaveScrollPosition="false"
                                                FrozenColumnsCount="1" />
                                        </ClientSettings>
                                        <MasterTableView Width="100%" EnableColumnsViewState="true">
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />--%>
                                            <Columns>
                                                <asp:TemplateField Visible="false" HeaderText="Employee Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Empid" runat="server" Text='<%# Eval("ATTENDANCE_EMP_ID") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="true" HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("ATTENDANCE_EMP_NAME") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList1" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList2" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList3" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList4" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList5" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList6" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList7" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList8" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList9" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="10">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList10" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList11" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList12" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList13" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList14" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList15" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList16" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList17" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList18" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList19" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList20" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList21" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList22" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList23" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList24" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList25" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList26" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList27" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList28" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList29" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList30" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="rcmbList31" runat="server" SkinID="Attendance">
                                                            <asp:ListItem Text="P" Value="P" />
                                                            <asp:ListItem Text="A" Value="A" />
                                                            <asp:ListItem Text="L" Value="L" />
                                                            <asp:ListItem Text="W" Value="W" />
                                                            <asp:ListItem Text="T" Value="T" />
                                                            <asp:ListItem Text="C" Value="C" />
                                                            <asp:ListItem Text="H" Value="H" />
                                                            <asp:ListItem Text="HA" Value="HD" />
                                                            <asp:ListItem Text="HL" Value="HL" />
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="Employee Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_EmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </asp:Panel>

                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="false" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Finalize" runat="server" Text="Finalize" Visible="false" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--      </telerik:RadAjaxPanel>
                <telerik:RadAjaxLoadingPanel ID="RALP_ATTENDANCE" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>