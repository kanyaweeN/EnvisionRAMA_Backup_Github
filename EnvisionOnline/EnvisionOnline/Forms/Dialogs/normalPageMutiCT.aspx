<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMutiCT.aspx.cs" Inherits="normalPageMutiCT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
            margin:0 0 0 0;
            font-family:MS Sans Serif;
        }
        .header
        {
            position: relative;
            margin: 1px;
            padding: 0px;
            background: #4b6c9e;
            color: #f9f9f9;
            font-weight:bold;
            width: 100%;
        }
        .tabBGHover
        {
        	background: #00CCFF;
        }
        .tabBG1
        {
        	background: #006633;
        }
        .tabBG2
        {
        	background: #00CC00;
        }
        .tabPlainExam
        {
        	margin: 0px;
        	background: #505050;
        	height:50px;
        	width:150px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :larger;
        }
        .columnBold
        {
        	margin: 0px;
        	background: #4b6c9e;
        	height:25px;
        	width:110px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:25px;
        	width:120px;
            vertical-align:top;
        }
        .columnBoldSpine
        {
        	margin: 0px;
        	background: #4b6c9e;
        	height:20px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size : x-small;
        }
        .textStyleSpine
        {
        	Font-Size:x-small;
        	height:20px;
            vertical-align:top;
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
		//Put your JavaScript code here.
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="tabMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tabMain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="multipageMain" LoadingPanelID="LoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="multipageMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="multipageMain"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>

	<div>
        <telerik:RadTabStrip ID="tabCT" runat="server" MultiPageID="MultipageCT" Align="Justify">
            <Tabs>
                <telerik:RadTab Text="CT Request" Selected="true"></telerik:RadTab>
                <telerik:RadTab Text="CT"></telerik:RadTab>
                <telerik:RadTab Text="CTA"></telerik:RadTab>
                <telerik:RadTab Text="CTV" ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage  ID="MultipageCT" runat="server" SelectedIndex="1">
            <telerik:RadPageView ID="viewCTOriginal"    runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageCT.aspx" Selected="true"></telerik:RadPageView>
            <telerik:RadPageView ID="viewCTMain"        runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageCTMain.aspx"></telerik:RadPageView>     
            <telerik:RadPageView ID="viewCTA"           runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageCTA.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewCTV"           runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageCTV.aspx"></telerik:RadPageView>
        </telerik:RadMultiPage>
	</div>
	</form>
</body>
</html>
