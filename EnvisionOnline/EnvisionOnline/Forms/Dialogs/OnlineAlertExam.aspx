<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OnlineAlertExam.aspx.cs" Inherits="OnlineAlertExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Conflict Exam</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
    <style type="text/css">
        .RadToolBar .rtbInner {
            text-align:right;
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
	    function returnValue(arg, windowManager) {
	        //Get a reference to the parent page (Default.aspx)      
	        var oWnd = GetRadWindow();

	        //get a reference to the second RadWindow      
	        var dialog1 = oWnd.get_windowManager().getWindowByName(windowManager);

	        // Get a reference to the first RadWindow's content
	        var contentWin = dialog1.get_contentFrame().contentWindow

	        //Call the predefined function in Dialog1
	        contentWin.setReturnPopup(arg);

	        //Close the second RadWindow
	        oWnd.close();
	    }
    </script>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
	    <AjaxSettings>
	        <telerik:AjaxSetting AjaxControlID="RadGrid1">
	            <UpdatedControls>
	                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
	    </AjaxSettings>
	</telerik:RadAjaxManager>
    <div>
        <telerik:RadToolBar ID="rtoolResult" runat="server" Width="100%" 
            onbuttonclick="rtoolResult_ButtonClick">
            <Items>
                <telerik:RadToolBarButton Value="btnSave" Text="OK" ToolTip="Save" Width="60px"
                    ImageUrl="../../Resources/ICON/saveAndClose.png" ImagePosition="Left" />
                <telerik:RadToolBarButton Value="btnCancel" Text="Cancel" ToolTip="Cancel" Width="60px"
                    ImageUrl="../../Resources/ICON/close3_16.png" ImagePosition="Left" />
            </Items>
        </telerik:RadToolBar>
    </div>
   <%-- <div>
        <table style="width:100%">
            <tr>
                <td style="text-align:right">
                    <telerik:RadButton  ID="btnOk" runat="server" Text="Save" OnClick="btnSave_Click" width="100px"/>
                    <telerik:RadButton  ID="btnCancel" runat="server" Text="Cencel" OnClick="btnCancel_Click" width="100px"/>
                </td>
            </tr>
        </table>
    </div>--%>
    <div>
                    <telerik:RadGrid ID="RadGrid1" AllowPaging="True" 
                    AllowFilteringByColumn="True" AllowSorting="True"
                    runat="server" PageSize="10" 
                    onneeddatasource="RadGrid1_NeedDataSource">
                        <MasterTableView TableLayout="Fixed" AutoGenerateColumns="False">
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="APPOINTMENT_DT" DataField="APPOINTMENT_DATETIME" UniqueName="APPOINTMENT_DATETIME" DataType="System.String"
                                    FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="140px" />
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="SCHEDULE_DATA" DataField="SCHEDULE_DATA" UniqueName="SCHEDULE_DATA" 
                                    FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <FilterMenu EnableTheming="True">
                            <CollapseAnimation Duration="100" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid>
    </div>
	
    
	</form>
</body>
</html>
