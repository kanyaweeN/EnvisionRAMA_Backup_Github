<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmQuickOrder.aspx.cs" Inherits="frmQuickOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Quick Order</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
             margin:0 0 0 0; 
             font-family:MS Sans Serif;
             }
        .gridTopTen
        {
	        float: left;
	        margin: 50 0 0 5px;
        }
        .gridFavorite
        {
	         float: right;
	        margin: 0 0 0 5px;
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
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled">
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
    <table width="100%">
        <tr>
            <td style="width:50%">
                <telerik:RadGrid ID="grdExamTop10" runat="server" PageSize="10" Height="223px" ShowStatusBar="true"
            AllowSorting="True" AllowPaging="True" EnableAJAX="true" OnNeedDataSource="grdExamTop10_NeedDataSource"
            >
            <ClientSettings EnableRowHoverStyle="true">
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="57px" />
            </ClientSettings>
            <MasterTableView TableLayout="Auto" AutoGenerateColumns="false" ClientDataKeyNames="EXAM_ID"
                Summary="grdData table">
                <Columns>
                    <telerik:GridButtonColumn CommandName="AddExam" HeaderTooltip="Make Study" ButtonType="ImageButton" UniqueName="colAddExam"
                        ImageUrl="../../Resources/ICON/add2-16.png">
                        <HeaderStyle Width="16px" />
                        <ItemStyle Width="16px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                        UniqueName="colEXAM_UID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Top Ten" SortExpression="EXAM_NAME"
                        UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                        UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RATE" HeaderText="RATE" SortExpression="RATE"
                        UniqueName="colRATE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="MODALITY_ID" SortExpression="MODALITY_ID"
                        UniqueName="colMODALITY_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE" SortExpression="NEED_SCHEDULE"
                        UniqueName="colNEED_SCHEDULE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </FilterMenu>
        </telerik:RadGrid>
            </td>
            <td style="width:50%">
                <telerik:RadGrid ID="grdExamFavorite" runat="server" PageSize="10" Height="223px"
            ShowStatusBar="true" AllowSorting="True" AllowPaging="True" EnableAJAX="true"
            OnNeedDataSource="grdExamFavorite_NeedDataSource" 
            >
            <ClientSettings EnableRowHoverStyle="true">
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="57px" />
            </ClientSettings>
            <MasterTableView TableLayout="Fixed" AutoGenerateColumns="false" ClientDataKeyNames="EXAM_ID"
                Summary="grdData table">
                <Columns>
                    <telerik:GridButtonColumn CommandName="AddExam" HeaderTooltip="Make Study" ButtonType="ImageButton" UniqueName="colAddExam"
                        ImageUrl="../../Resources/ICON/add2-16.png">
                        <HeaderStyle Width="16px" />
                        <ItemStyle Width="16px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                        UniqueName="colEXAM_UID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Favorite" SortExpression="EXAM_NAME"
                        UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="100%" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                        UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RATE" HeaderText="RATE" SortExpression="RATE"
                        UniqueName="colRATE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="MODALITY_ID" SortExpression="MODALITY_ID"
                        UniqueName="colMODALITY_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE" SortExpression="NEED_SCHEDULE"
                        UniqueName="colNEED_SCHEDULE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </FilterMenu>
        </telerik:RadGrid>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
