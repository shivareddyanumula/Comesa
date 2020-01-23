<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_MissionAboutUs.aspx.cs" Inherits="Masters_frm_MissionAboutUs" %>

<asp:Content ID="cntMissionAboutUs" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Mission and Vision" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTabStrip runat="server" ID="rts_TabStrip" BorderColor="Black" SelectedIndex="0" MultiPageID="RadMultiPage1">
                    <Tabs>
                        <telerik:RadTab Text="Assembly" BorderColor="Black" PageViewID="RadPageView1" >
                        </telerik:RadTab>
                        <telerik:RadTab Text="Senate" PageViewID="RadPageView2">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" BorderColor="#9999ff" Width="950px" BorderWidth="1px" BorderStyle="Solid">
                    <telerik:RadPageView runat="server" ID="RadPageView1" Selected="true" Width="950px">
                       <asp:UpdatePanel ID="upnl1" runat="server">
                           <ContentTemplate>
                               <table align="left" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="hdnAssemblyMissionID" runat="server" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Mission and Vision:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="rtxtAssemblyMission" Height="150px" Width="550px"  runat="server"  meta:resourcekey="rtxtAssemblyMission" TextMode="MultiLine" TabIndex="1" ></asp:TextBox>

                                </td>
                            </tr>
                            <tr>

                                <td align="right">About us :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="rtxtAssemblyAboutUs" Height="150px" Width="550px" runat="server"  meta:resourcekey="rtxtAssemblyAboutUs" TextMode="MultiLine" TabIndex="2" ></asp:TextBox>

                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click" TabIndex="3"
                                        Text="Update" Visible="False" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="3"
                                        Text="Save" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="4"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_ServiceProvider" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                           </ContentTemplate>

                       </asp:UpdatePanel>
                         
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2"  Width="950px">
                        <table align="left" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="hdnSenateMissionID" runat="server" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Mission and Vision:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="rtxtSenateMission" Height="150px" Width="550px" runat="server" TextMode="MultiLine" TabIndex="1" ></asp:TextBox>

                                </td>
                            </tr>
                            <tr>

                                <td align="right">Aboutus :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="rtxtSenateAboutUs" Height="150px" Width="550px" runat="server" TextMode="MultiLine" TabIndex="2" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btnSenate_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btnSenate_Save_Click" TabIndex="3"
                                        Text="Update" Visible="False"  ValidationGroup="Controls1" />
                                    <asp:Button ID="btnSenate_Save" runat="server" meta:resourcekey="btnSenate_Save" OnClick="btnSenate_Save_Click" TabIndex="3"
                                        Text="Save"  ValidationGroup="Controls1" />
                                    <asp:Button ID="btnSenate_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="4"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls1" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>


            </td>
        </tr>
        
    </table>
    
</asp:Content>

