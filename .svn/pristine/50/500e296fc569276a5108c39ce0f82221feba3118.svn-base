<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frm_FeedBackQuestionForm.aspx.cs" 
Inherits="Training_frm_FeedBackQuestionForm" %>
<html>
<head id="Head1" runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="GridFormDetailsViews" />
    <br />

<table align="center">
        <tr>
          <td>
           <asp:Label ID="lbl_TrainingName" runat="server" 
                                          ></asp:Label>
          </td>
          
        </tr>
        <tr>
          <td>
           <asp:Label ID="lbl_FeedBackDate" runat="server" 
                                          ></asp:Label>
          </td>
          
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
            <td>
               
             <%--      
                <asp:GridView ID="Rg_EMIDATA" runat="server">
                </asp:GridView>--%>
                
                   <asp:Label ID="lbl_Admin" runat="server" align="left" Text="Training FeedBack Questions" Font-Bold="True" Visible="false"></asp:Label>
                      </td>
        </tr>
        <tr>
        <td></td>
        </tr>
        <tr>
        <td></td>
        </tr>
                      <tr>
                      <td> 
                        <asp:Repeater ID="ReptFeedBack_Admin" runat="server">
                            <HeaderTemplate>
                                <table align="center"  style="border: solid 1px #9aadc4; width : 800px">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lblFeedQuesID" runat="server" Text='<%#Bind("FEEDBACKQUESTS_ID")%>'
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="border: 1; background-color: #9aadc4">
                                    <td colspan="6" valign="top" align="left">
                                        <asp:Label ID="lblQuestion" runat="server" Text='Question:    ' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblFeedQuesName" runat="server" Font-Bold="true" Text='<%#Bind("FEEDBACKQUESTS_QUESTION")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border: 1">
                                        <asp:RadioButtonList ID="rdbTest" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5px">
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
            </td>
        </tr>
    </table>
   </form>
</body>
</html>

