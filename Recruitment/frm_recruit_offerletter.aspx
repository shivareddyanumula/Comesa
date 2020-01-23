<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frm_recruit_offerletter.aspx.cs"
    Inherits="Recruitment_frm_recruit_offerletter" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" language="javascript">
        function print() {
            //    alert('Hello');
            window.print();
            //  return false;
        }

        function PrintContent() {

            var wrapperDiv = document.getElementById("EditorOffer");
            var printIframe = document.createElement("IFRAME");
            document.body.appendChild(printIframe);
            var printDocument = printIframe.contentWindow.document;
            printDocument.designMode = "on";
            printDocument.open();
            printDocument.write("<html><head></head><body>" + wrapperDiv.innerHTML + "</body></html>");
            printIframe.style.position = "absolute";
        //    printIframe.style.top = "-1000px";
            printIframe.style.top = "-800px";
            printIframe.style.left = "-800px";

            if (document.all) {
                printDocument.execCommand("Print", null, false);
            }
            else {
                printDocument.contentWindow.print();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="300px"
            >
            <telerik:RadEditor runat="server" ID="EditorOffer" SkinID="DefaultSetOfTools" 
                Height="515">
                <Tools>
                    <telerik:EditorToolGroup Tag="TEST">
                        <telerik:EditorTool Enabled="true" Name="Print" ShowText="true" ShowIcon="true" />
                    </telerik:EditorToolGroup>
                </Tools>
            </telerik:RadEditor>
        </telerik:RadAjaxPanel>
        &nbsp;</div>
    </form>
</body>
</html>
