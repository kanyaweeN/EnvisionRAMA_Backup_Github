<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialogGroupExamAdd.aspx.cs" Inherits="dialogGroupExamAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Add Exam</title>
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
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" />
                    <telerik:AjaxUpdatedControl ControlID="cmbGroupExamType" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbGroupExamType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdDataExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	    <div>
            <table width="100%" style="border-style: none; border-width: thin; padding: 0px; margin: 0px; border-spacing: 0px" align="center">
            <tr>
                <td colspan="2">
                     <telerik:RadToolBar ID="rtbMainNW" runat="server" Width="100%" Height="80px" OnButtonClick="rtbMain_ButtonClick">
                        <Items>
                            <telerik:RadToolBarButton Value="btnSave" Text="Save" ToolTip="Add Exam" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../../Resources/ICON/saveLarge.png"/>
                        </Items>
                    </telerik:RadToolBar>  
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadComboBox ID="cmbGroupExamType" runat="server" OnSelectedIndexChanged="cmbGroupExamType_SelectedIndexChanged" AutoPostBack="true"
                            Height="170px" Width="100%" ShowMoreResultsBox="True">
                     </telerik:RadComboBox>
                </td>
            </tr>
                 <tr valign="top" class="nottarget">
                    <td valign="top" style="width:50%">
                    <telerik:RadGrid ID="grdDataExam" runat="server" PageSize="30"  Width="100%"
                             AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="True"
                                OnNeedDataSource="grdDataExam_NeedDataSource"
                                OnItemCommand="grdDataExam_ItemCommand" 
                                >
                                <ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView TableLayout="Fixed" EditMode="InPlace" ClientDataKeyNames="EXAM_ID" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                                    Summary="grdData table">
                                    <Columns>
                                        <telerik:GridButtonColumn CommandName="AddExam" ButtonType="ImageButton" UniqueName="colAddExam"
                                            ImageUrl="../../../Resources/ICON/add2-16.png">
                                            <HeaderStyle Width="25px" />
                                            <ItemStyle Width="16px" />
                                        </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                                            UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                            UniqueName="colEXAM_UID" AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%">
                                            <HeaderStyle Width="100%" />
                                            <ItemStyle Width="100%" Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Exam Name" SortExpression="EXAM_NAME"
                                            UniqueName="colEXAM_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%">
                                            <HeaderStyle Width="100%" />
                                            <ItemStyle Width="100%" Wrap="true" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <FilterMenu EnableTheming="True">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </FilterMenu>
                            </telerik:RadGrid>
                    </td>
                    <td valign="top" style="width:50%">
                    <telerik:RadGrid ID="grdDataSelected" runat="server" PageSize="30"
                             AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="True"
                                OnNeedDataSource="grdDataSelected_NeedDataSource"
                                OnItemCommand="grdDataSelected_ItemCommand" 
                                >
                                <ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView TableLayout="Fixed" EditMode="InPlace" ClientDataKeyNames="EXAM_ID" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                                    Summary="grdData table">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                                            UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                            UniqueName="colEXAM_UID" AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%">
                                            <HeaderStyle Width="100%" />
                                            <ItemStyle Width="100%" Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Exam Name" SortExpression="EXAM_NAME"
                                            UniqueName="colEXAM_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%">
                                            <HeaderStyle Width="100%" />
                                            <ItemStyle Width="100%" Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="deleteExam" ButtonType="ImageButton" UniqueName="coldeleteExam"
                                            ImageUrl="../../../Resources/ICON/Actions-remove16.png">
                                            <HeaderStyle Width="25px" />
                                            <ItemStyle Width="16px" />
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <FilterMenu EnableTheming="True">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </FilterMenu>
                            </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
	</form>
</body>
</html>
