<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Forms/Admin/masterAdmin.Master" AutoEventWireup="true"
    CodeBehind="frmSetupCinicalIndicationWithUnit.aspx.cs" Inherits="frmSetupCinicalIndicationWithUnit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../CSS/adminStyle.css" rel="stylesheet" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled">
		<Scripts>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
	    
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="treeIndicationView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl  ControlID="treeIndicationView" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbRefUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbRefUnit" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbMainNW">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtbMainNW" />
                    <telerik:AjaxUpdatedControl ControlID="btnSave" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<table width="100%" cellspacing="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbMainNW" runat="server" Width="100%" Height="80px" OnButtonClick="rtbMain_ButtonClick">
                    <Items>
                        <telerik:RadToolBarButton Value="btnSave" Text="Save" ToolTip="Save Clinical Indication" Width="60px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/saveLarge.png"/>
                    </Items>
                </telerik:RadToolBar>  
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadComboBox ID="cmbRefUnit" runat="server"
                    Height="170px" Width="100%" AutoPostBack="true"
                    ShowMoreResultsBox="True" EnableLoadOnDemand="True" 
                    OnItemsRequested="cmbRefUnit_ItemsRequested"
                    OnSelectedIndexChanged="cmbRefUnit_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
</asp:Content>
