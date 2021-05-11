<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialogGroupExamTabHeader.aspx.cs" Inherits="dialogGroupExamTabHeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Create Tab Hearder</title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        .Header
        {
	        background:#0026ff;
	        color:white;
	        width:auto;
	        padding:10px;
	        border:solid 2px #00ffff;
	        margin: 0 0 0 0;
        }
        .target
        {
 	border:solid 2px #808080;
	width:320px;
	height:30px;
	padding:3px;
	background:#abddf6;
    font:italic bold 16px/30px Georgia, serif;
        	 }
        	 .nottarget
        	 {
        	 	font:italic 12px/20px;
        	 	}
        body
        {
        margin:0 0 0 0;
        font-family:MS Sans Serif;
        	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
	     function CloseAndRebind(args) {
	         GetRadWindow().BrowserWindow.refreshGrid(args);
	         GetRadWindow().close();
	     }

	     function GetRadWindow() {
	         var oWindow = null;
	         if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
	         else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

	         return oWindow;
	     }
	     function CancelEdit() {
	         GetRadWindow().close();
	     }
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
        <div>
            <table width="100%" style="border-style: none; border-width: thin; padding: 0px; margin: 0px; border-spacing: 0px" align="center">
                 <tr valign="top" class="nottarget">
                    <td>
                        <asp:Label ID="lblTabHeader" runat="server">Tab Header : </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTabHeader" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
	</form>
</body>
</html>
