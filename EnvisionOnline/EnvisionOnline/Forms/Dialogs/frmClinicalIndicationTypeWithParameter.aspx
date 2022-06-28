<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmClinicalIndicationTypeWithParameter.aspx.cs" Inherits="frmClinicalIndicationTypeWithParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Clinical Indecation</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
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
	    //Put your JavaScript code here.
    </script>
    <telerik:RadCodeBlock ID="blockGrid" runat="server">
        <script type="text/javascript">
            function OnClientClose() {
                GetRadWindow().close();
            }
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
                return oWindow;
            }
            function AlphabetOnly(sender, eventArgs) {
                var c = eventArgs.get_keyCode();
                if (c == 60)
                    alert('Please change "<" to another word!!');
            }
        </script>
    </telerik:RadCodeBlock>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="treeIndicationTypeView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="treeIndicationView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" colspan="2">
                    <table width="100%" cellspacing="0">
                        <tr>
                            <td width="100%" valign="top">
                                <div style="width: 100%;">
                                <telerik:RadTreeView ID="treeIndicationTypeView" runat="server" CheckBoxes="true" Height="390px"
                                    OnNodeCheck="treeIndicationTypeView_NodeCheck"
                                    OnNodeClick="treeIndicationTypeView_NodeClick"
                                    OnNodeCreated="treeIndicationTypeView_NodeCreated"
                                    OnNodeDataBound="treeIndicationTypeView_NodeDataBound" >
                                </telerik:RadTreeView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <telerik:RadTabStrip ID="tabClinicalText" runat="server" MultiPageID="multipageClinicalText">
                        <Tabs>
                            <telerik:RadTab Text="Clinical Text" Selected="true" ImageUrl="../../Resources/ICON/text_file.png">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="multipageClinicalText" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="viewClinicalText" runat="server">
                                <telerik:RadTextBox ID="txtEditor" runat="server" TextMode="MultiLine" Width="100%" Height="90px" >
                                    <ClientEvents OnKeyPress="AlphabetOnly" />
                                </telerik:RadTextBox>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:Label>
                </td>
                <td align="right" style="width:200px">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr align="center">
                            <td align="right"><telerik:RadButton ID="btnSave" runat="server" Text="Save" Width="100px" AutoPostBack="true" OnClick="btnSave_Click"></telerik:RadButton></td>
                            <td align="left"><telerik:RadButton ID="btnCancle" runat="server" Text="Cancel" Width="100px" AutoPostBack="true" OnClick="btnCancle_Click"></telerik:RadButton></td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>
	</form>
</body>
</html>
