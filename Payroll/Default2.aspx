<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Payroll_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<style type="text/css">
        /* Fixed Header */
        <%--.Scrollable
        {
            padding-top: 0px;
            position: relative;
            vertical-align: middle;
            line-height: 12px;
            text-align: center;
            top: expression(this.offsetParent.scrollTop);
        }
    </style>--%>
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

    <table align="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="u1" runat="server">
                    <ContentTemplate>
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
                                    <asp:Label ID="lbl_HD" runat="server" Text="HDA"></asp:Label>
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
                                    <asp:Label ID="lbl_HDL" runat="server" Text="HDL">
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

                                    <div id="divGrid" style="overflow: auto; width: 1000px; height: 500px">

                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            OnRowDataBound="GridView1_RowDataBound">

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
                                                <asp:TemplateField Visible="false" HeaderText="1">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList1" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="2">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList2" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="3">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList3" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="4">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList4" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="5">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList5" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="6">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList6" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="7">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList7" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="8">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList8" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="9">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList9" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="10">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList10" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="11">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList11" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="12">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList12" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="13">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList13" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="14">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList14" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="15">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList15" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="16">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList16" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="17">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList17" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="18">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList18" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="19">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList19" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="20">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList20" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="21">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList21" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="22">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList22" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="23">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList23" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="24">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList24" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="25">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList25" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="26">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList26" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="27">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList27" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="28">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList28" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="29">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList29" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="30">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList30" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="31">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmbList31" runat="server" SkinID="Attendance" EnableAutomaticLoadOnDemand="true"
                                                            AllowCustomText="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="P" Value="P" />
                                                                <telerik:RadComboBoxItem Text="A" Value="A" />
                                                                <telerik:RadComboBoxItem Text="L" Value="L" />
                                                                <telerik:RadComboBoxItem Text="W" Value="W" />
                                                                <telerik:RadComboBoxItem Text="T" Value="T" />
                                                                <telerik:RadComboBoxItem Text="C" Value="C" />
                                                                <telerik:RadComboBoxItem Text="H" Value="H" />
                                                                <telerik:RadComboBoxItem Text="HDA" Value="HD" />
                                                                <telerik:RadComboBoxItem Text="HDL" Value="HDL" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>
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