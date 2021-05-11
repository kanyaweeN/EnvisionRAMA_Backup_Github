<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineOrderCancelForm.aspx.cs" Inherits="OnlineOrderCancelForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Cancel Order</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
        margin:1 1 1 1;
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
	<div>
	<table id="mainTable" style="border-style: none; " width="100%" align="center" border="0" cellspacing="0">
        <tr valign="top">
            <td>
                <telerik:RadGrid ID="grdReason" runat="server" PageSize="30" Height="340px"
                OnNeedDataSource="grdReason_NeedDataSource"
                OnSelectedIndexChanged="grdReason_SelectedIndexChanged" >
                <ClientSettings EnablePostBackOnRowClick="true">
                    <Selecting AllowRowSelect="true" />
                    <Scrolling AllowScroll="true"/>
                </ClientSettings>
                <MasterTableView Width="100%" EditMode="InPlace" ClientDataKeyNames="CAN_ID" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                Summary="grdData table">
                <Columns>
                    <telerik:GridBoundColumn DataField="CAN_ID" HeaderText="can_id" Visible="false">
                    <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CAN_UID" HeaderText="can_uid" Visible="false">
                    <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CAN_NAME" HeaderText="Reason" Visible="true">
                    <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                </Columns>
                </MasterTableView>
                <PagerStyle Mode="NextPrevAndNumeric" />
                <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
                </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr valign="top">
            <td>
                <asp:TextBox ID="txtReason" runat="server" Width="100%" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr valign="top">
            <td>
                <asp:Label ID="lbAlertReason" runat="server" Width="100%" ForeColor="Red" ></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td>
                <telerik:RadButton ID="btnDelete" runat="server" Text="Confirm" ButtonType="StandardButton"
                 OnClick="btnDelete_Click" AutoPostBack="true"
                >
                </telerik:RadButton>
            </td>
        </tr>
	</table>

	</div>
	</form>
</body>
</html>
