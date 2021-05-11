<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAllNextAppointment.aspx.cs" Inherits="frmAllNextAppointment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>All Next Appointment</title>
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
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
    <script type="text/javascript">
        function OnClientClose() {
        }
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
	</telerik:RadAjaxManager>
	<table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="grdData" runat="server" PageSize="30"
                    AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="True"
                    Width="100%"
                    OnNeedDataSource="grdData_NeedDataSource"
                    >
                    <ClientSettings EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="true" />
                    </ClientSettings>
                    <MasterTableView TableLayout="Fixed" EditMode="InPlace" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                        Summary="grdData table">
                        <Columns>
                            <telerik:GridBoundColumn DataField="appt_date" HeaderText="Date" SortExpression="appt_date"
                                UniqueName="colappt_date" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="appt_doc_code" HeaderText="Doc Code" SortExpression="appt_doc_code"
                                UniqueName="colappt_doc_code" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="appt_doc_name" HeaderText="Doc Name" SortExpression="appt_doc_name"
                                UniqueName="colappt_doc_name" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="appt_doc_dept_code" HeaderText="Dept Code" SortExpression="appt_doc_dept_code"
                                UniqueName="colappt_doc_dept_code" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="appt_doc_dept_name" HeaderText="Dept Name" SortExpression="appt_doc_dept_name"
                                UniqueName="colappt_doc_dept_name" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                Visible="true">
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
    </table>
	</form>
</body>
</html>
