<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineMessageBox2.aspx.cs" Inherits="OnlineMessageBox2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        .ImgMessage
        {
        	float: left;
	        margin:0 0 0 5px;
        	}
        .messageText
        {
        	width:460px;
	        float: left;
	        margin:0 0 0 45px;
        	}
        
        body
        {
        margin:0 0 0 0;
        font-family:MS Sans Serif;
        font-size:larger;
        	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline">
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
	    function CloseAndRebind2(args) {
	        GetRadWindow().BrowserWindow.CloseAndRebind(args);
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
	<table align="left" width="100%">
	    <tr>
	        <td colspan="4" width ="100%" >
            <div class="ImgMessage" >
                <asp:Image ID="imgAlert" runat="server" 
                    Width="40px" />
            </div >
                <div class="messageText">
                <telerik:RadTextBox ID="lblShowText" runat="server" ReadOnly="true" 
                     BorderStyle="None"
                     ReadOnlyStyle-BackColor="Transparent" Font-Bold="true" Width="100%" 
                     TextMode="MultiLine" Height="150px">
                    <PasswordStrengthSettings ShowIndicator="False" CalculationWeightings="50;15;15;20" PreferredPasswordLength="10" MinimumNumericCharacters="2" RequiresUpperAndLowerCaseCharacters="True" MinimumLowerCaseCharacters="2" MinimumUpperCaseCharacters="2" MinimumSymbolCharacters="2" OnClientPasswordStrengthCalculating="" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID=""></PasswordStrengthSettings>
                    <ReadOnlyStyle BackColor="Transparent"></ReadOnlyStyle>
                 </telerik:RadTextBox>
                </div>
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

