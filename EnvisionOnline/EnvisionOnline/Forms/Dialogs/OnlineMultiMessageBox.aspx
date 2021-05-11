<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineMultiMessageBox.aspx.cs" Inherits="OnlineMultiMessageBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="x-ua-compatible" content="IE=8" />
    <title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <style type="text/css">
        .ImgMessage
        {
        	float: left;
	margin:0 0 0 5px;
        	}
        .messageText
        {
	        float: left;
	        margin:0 0 0 45px;
        	}
        
        body
        {
        margin:1 1 1 1;
        font-family:MS Sans Serif;
        	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
	    function OnClientClose(args) {
	        GetRadWindow().close();
	    }
	    function CloseAndRebind(args) {
	        GetRadWindow().BrowserWindow.setReturnPopup(args);
	        GetRadWindow().close();
	    }
	    function GetRadWindow() {
	        var oWindow = null;
	        if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
	        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
	        return oWindow;
	    }
	    function returnValue(arg, windowManager) {
	        //Get a reference to the parent page (Default.aspx)      
	        var oWnd = GetRadWindow();

	        //get a reference to the second RadWindow      
	        var dialog1 = oWnd.get_windowManager().getWindowByName(windowManager);

	        // Get a reference to the first RadWindow's content
	        var contentWin = dialog1.get_contentFrame().contentWindow

	        //Call the predefined function in Dialog1
	        contentWin.setReturnPopup(arg);

	        //Close the second RadWindow
	        oWnd.close();
	    }
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<table align="left">
	    <tr>
	        <td colspan="4">
                <table width="100%">
                    <tr>
                        <td>
                            <div >
                                <asp:Image ID="imgAlert" class="ImgMessage" runat="server" Width="40px" />
                            </div>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="lblShowText" runat="server" ReadOnly="true" 
                                 BorderStyle="None"
                                 ReadOnlyStyle-BackColor="Transparent" Font-Bold="true" Width="100%" 
                                 TextMode="MultiLine" Height="90px">
                             </telerik:RadTextBox>
                        </td>
                    </tr>
                </table>
	        </td>
	    </tr>
	    <tr>
	        <td colspan="2" rowspan="1" width="50%">
                <telerik:RadButton ID="btn3" runat="server" Text="save and print" OnClick="btn3_Click" Width="95%"></telerik:RadButton>
	        </td>
	        <td colspan="1" rowspan="1" width="25%">
	            <telerik:RadButton ID="btn2" runat="server" Text="save" OnClick="btn2_Click" Width="95%"></telerik:RadButton>
	        </td>
	        <td colspan="1" rowspan="1" width="25%">
	            <telerik:RadButton ID="btn1" runat="server" Text="save" OnClick="btn1_Click" Width="95%"></telerik:RadButton>
	        </td>
	    </tr>
	</table>
	</form>
</body>
</html>
