<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMutiMR.aspx.cs" Inherits="normalPageMutiMR" %>

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
        <telerik:RadTabStrip ID="tabMR" runat="server" MultiPageID="MultipageMR" Align="Justify">
            <Tabs>
                <telerik:RadTab Text="MRI Request" Selected="true" ></telerik:RadTab>
                <telerik:RadTab Text="MRI" ></telerik:RadTab>
                <telerik:RadTab Text="MRA" ></telerik:RadTab>
                <telerik:RadTab Text="MRV" ></telerik:RadTab>
                <telerik:RadTab Text="MRS" ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage  ID="MultipageMR" runat="server" SelectedIndex="1">
            <telerik:RadPageView ID="viewMRIRequest" runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageMR.aspx" Selected="true"></telerik:RadPageView>
            <telerik:RadPageView ID="viewMRI" runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageMRI.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewMRA" runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageMRA.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewMRV" runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageMRV.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewMRS" runat="server" Height="460" ContentUrl="~/Forms/Dialogs/normalPageMRS.aspx"></telerik:RadPageView>
        </telerik:RadMultiPage>
	</div>
	</form>
</body>
</html>
