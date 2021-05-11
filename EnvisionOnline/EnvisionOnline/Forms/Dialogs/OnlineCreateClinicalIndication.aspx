<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineCreateClinicalIndication.aspx.cs" Inherits="OnlineCreateClinicalIndication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Create Clinical Label</title>
	<meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
    <style type="text/css">
        body
        {
        margin:0 0 0 0;
        font-family:MS Sans Serif;
        	}
         .textButton
        {
            text-align:left;
            vertical-align:text-top;
            }
        .labelText
        {
        	font-size:smaller;
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
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<table>
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text="Create Indication" Font-Bold="true" Font-Size="Medium"></asp:Label>
                 </br>
                 </br>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label3" runat="server" Text="Please enter" CssClass="labelText"></asp:Label>
            </td>
        </tr>
        <tr>
	        <td>
                <telerik:RadTextBox ID="txtNewLabel" runat="server" Width="350"></telerik:RadTextBox>
	        </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="lblIndicationGroup" runat="server" Text="Select Indication Group (Optional)" CssClass="labelText"></asp:Label>
            </td>
        </tr>
        <tr>
	        <td>
                <telerik:RadComboBox ID="cmbClinical" runat="server"
                    Height="120px" Width="350px" Filter="None" AutoCompleteSeparator=";" AllowCustomText="false"
                    ShowMoreResultsBox="false" EnableLoadOnDemand="True"
                    OnItemsRequested="cmbClinical_ItemsRequested"
                    />
	        </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadButton ID="btnCreate" runat="server" Text="Create" Width="80" AutoPostBack="true" OnClick="btnCreate_Click"></telerik:RadButton>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Width="80" AutoPostBack="true" OnClick="btnCancel_Click"></telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
