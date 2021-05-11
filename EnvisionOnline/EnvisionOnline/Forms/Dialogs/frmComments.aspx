<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmComments.aspx.cs" Inherits="frmComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
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
	    function OnClientClose(args) {
	        GetRadWindow().close();
	    }
	    function CloseAndRebind(args) {
	        GetRadWindow().BrowserWindow.chkMessageBox(args);
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

    <div id="tabClinical" runat='server'>
	<table width="100%" style="display:block;">
        <tr>
            <td>
                <telerik:RadTabStrip ID="tabClinicalText" runat="server" 
                    MultiPageID="multipageClinicalText" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Clinical Text" Selected="true" ImageUrl="../../Resources/ICON/text_file.png">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="multipageClinicalText" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="viewClinicalText" runat="server">
                        <table style="width:100%">
                            <tr>
                                <td>
                                    <telerik:RadTextBox ID="txtEditor" runat="server" 
                                    TextMode="MultiLine" ReadOnly="true"
                                    Width="100%" Height="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                    <telerik:RadButton  ID="btnEdit2" runat="server" Text="Edit" OnClick="btnEdit_Click" Enabled="False" width="100px"/>
                                    <telerik:RadButton  ID="btnSave2" runat="server" Text="Save" OnClick="btnSave_Click" Visible="False" width="100px"/>
                                    <telerik:RadButton  ID="btnCancel2" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="False" width="100px"/>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    </div>

    <div id="tabComment" runat='server'>
    <table width="100%" id="tabComment">
        <tr>
            <td>
                <telerik:RadTabStrip ID="tabComments" runat="server" 
                    MultiPageID="multipageCommentText" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Comment Text" Selected="true">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="multipageCommentText" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="viewCommentText" runat="server">
                            <telerik:RadTextBox ID="txtComment" runat="server" 
                            TextMode="MultiLine" ReadOnly="true"
                            Width="100%" Height="150px" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    </div>
	</form>
</body>
</html>
