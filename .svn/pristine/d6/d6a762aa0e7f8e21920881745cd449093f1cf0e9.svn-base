<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_EMPAppraisalDetails.aspx.cs" Inherits="PMS_frm_EMPAppraisalDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
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

            <center><b>Employee Appraisal Details </b></center>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lbl_Role" runat="server" Text="Position" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:Label ID="lbl_Role_Name" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%--  <asp:Label ID="lbl_Project" runat="server" Text="Project" Font-Bold="true"></asp:Label>--%>
                    </td>
                    <td>
                        <%--  <b>:</b>--%>
                    </td>
                    <td>
                        <%--   <asp:Label ID="lbl_Project_Name" runat="server" ></asp:Label>--%>
                    </td>
                    <td></td>
                    <td></td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_RPMgr" runat="server" Text="Reporting Manager" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:Label ID="lbl_RPMgr_Name" runat="server"></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_ApprMgr" runat="server" Text="Group Manager" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:Label ID="lbl_ApprMgr_Name" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RG_EmpAppraisalDetails" runat="server" AutoGenerateColumns="False"
                            AllowSorting="false" AllowMultiRowSelection="False" Skin="WebBlue" GridLines="None">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Type" DataField="A" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Type" DataField="B">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Name" DataField="NAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Description" DataField="DESC">
                                    </telerik:GridBoundColumn>
                                    <%-- <telerik:GridBoundColumn HeaderText="Measure" DataField="MEASURE">
          </telerik:GridBoundColumn>
          <telerik:GridBoundColumn HeaderText="Weightage" DataField="WEIGHTAGE">
          </telerik:GridBoundColumn>
          <telerik:GridBoundColumn HeaderText="Target" DataField="TARGET" Visible="false" Display="false">
          </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn HeaderText="Self Rating (%)" DataField="TARGET_ACHIEVED">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridTemplateColumn HeaderText="Self Rating" UniqueName="TARGET_ACHIEVED">
            <ItemTemplate>
                <telerik:RadRating ID="rtng_emprtng" runat="server" ItemCount="5" Precision="Exact" 
                   Enabled="false" Value='<%# Convert.ToDouble(Eval("TARGET_ACHIEVED")) %>'>
                </telerik:RadRating>
            </ItemTemplate>
            </telerik:GridTemplateColumn>--%>
                                    <telerik:GridBoundColumn HeaderText="Self Comments" DataField="EMP_COMMENTS">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Manager Rating (%)" DataField="MGR_RATING">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridTemplateColumn HeaderText="Manager Rating" UniqueName="MGR_RATING">
            <ItemTemplate>
                <telerik:RadRating ID="rtng_emprtng" runat="server" ItemCount="5" Precision="Exact" 
                   Enabled="false" Value='<%# Convert.ToDouble(Eval("MGR_RATING")) %>'>
                </telerik:RadRating>
            </ItemTemplate>
            </telerik:GridTemplateColumn>--%>
                                    <telerik:GridBoundColumn HeaderText="Manager Comments" DataField="MGR_COMMENTS">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>