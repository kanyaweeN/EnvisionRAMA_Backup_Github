<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBasicClinicalIndication.aspx.cs" Inherits="frmBasicClinicalIndication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Basic Clinical Indication</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
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
	    function NormalWindow() {
	        window.close();
	    }
	    function CancelEdit() {
	        GetRadWindow().close();
	    }
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="treeIndicationView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="rtoolResult" runat="server" Width="100%" OnButtonClick="rtoolResult_ButtonClick">
                    <Items>
                        <telerik:RadToolBarButton Value="btnSave" Text="Save" ToolTip="Save" Width="60px"  ImageUrl="../../Resources/ICON/saveAndClose.png" ImagePosition="Left"/>
                        <telerik:RadToolBarButton Value="btnCancel" Text="Cancel" ToolTip="Cancel" Width="60px"  ImageUrl="../../Resources/ICON/close3_16.png" ImagePosition="Left"/>
                        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTreeView ID="treeIndicationView" runat="server" CheckBoxes="true" Width="100%" Height="100%"
                    TriStateCheckBoxes="true" CheckChildNodes="true"
                    OnNodeCheck="treeIndicationView_NodeCheck"
                    OnNodeClick="treeIndicationView_NodeClick"
                    OnNodeCreated="treeIndicationView_NodeCreated"
                    OnNodeDataBound="treeIndicationView_NodeDataBound"
                        >
                </telerik:RadTreeView>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
