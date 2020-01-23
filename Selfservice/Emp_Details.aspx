<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Emp_Details.aspx.cs" Inherits="Selfservice_Emp_Details" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <br />
    <br />
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function ShowPop(ID) {
                var win = window.radopen('../Selfservice/Personal.aspx?ID=' + ID, "RW_EmpDetails");
                win.center();
                win.set_modal(true);
            }

            function ShowPop_Skills(ID) {
                var win = window.radopen('../Selfservice/Skills.aspx?ID=' + ID, "RW_EmpDetails");
                win.center();
                win.set_modal(true);
            }

            function ShowPop_Qual(ID) {
                var win = window.radopen('../Selfservice/Qualification.aspx?ID=' + ID, "RW_EmpDetails");
                win.center();
                win.set_modal(true);
            }

            function ShowPop_Fam(ID) {
                var win = window.radopen('../Selfservice/Family.aspx?ID=' + ID, "RW_EmpDetails");
                win.center();
                win.set_modal(true);
            }

            function ShowPop_Employ(ID) {
                var win = window.radopen('../Selfservice/Past_Employ.aspx?ID=' + ID, "RW_EmpDetails");
                win.center();
                win.set_modal(true);
            }

            function ShowPop_Con(ID) {
                var win = window.radopen('../Selfservice/Contact.aspx?ID=' + ID, "RW_ConDetails");
                win.center();
                win.setSize("700", "300");
                win.set_modal(true);
            }

            function ShowPop_MediClaims(ID) {
                var win = window.radopen('../Selfservice/frm_Emp_MedicalClaims.aspx?EMP_ID=' + ID, "RW_ConDetails");
                win.center();
                win.setSize("700", "400");
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_EmpDetails" runat="server" SelectedIndex="0" Width="600px">
                    <telerik:RadPageView ID="RPV_EmpDetails" runat="server">
                        <table cellpadding="5" cellspacing="5">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_EmpDetails" runat="server" OnClick="lnk_EmpDetails_Click">Personal Details</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Qualification" runat="server" OnClick="lnk_Qualification_Click">Qualification Details</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Skills" runat="server" OnClick="lnk_Skills_Click">Skill Details</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Family" runat="server" OnClick="lnk_Family_Click">Family Details</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Employment" runat="server" OnClick="lnk_Employment_Click">Past Employment Details</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Contact" runat="server" OnClick="lnk_Contact_Click">Contact Details</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_MedicalClaims" runat="server" OnClick="lnk_MedicalClaims_Click">Medical Claim Details</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" Width="300px"
                    Height="198px">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Height="174px">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Image ID="Img_Employee" runat="server" Height="150px" Width="142px" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
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
</asp:Content>