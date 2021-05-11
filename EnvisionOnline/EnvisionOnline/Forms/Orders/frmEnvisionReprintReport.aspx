<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEnvisionReprintReport.aspx.cs" Inherits="frmEnvisionReprintReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
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
   <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	    <AjaxSettings>
	        <telerik:AjaxSetting AjaxControlID="grdData">
	            <UpdatedControls>
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtoolSearch">
	            <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtoolSearch" />
                    <telerik:AjaxUpdatedControl ControlID="btnSearch" />
                    <telerik:AjaxUpdatedControl ControlID="txtSearch" />
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
	    </AjaxSettings>
	</telerik:RadAjaxManager>
     <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function OnClientClose() {
            }
            function chkMessageBox(args) {
            }
            function showPrintPreview(url) {
                window.open(url);
            }
            var popupWin;
            function showNewWindows(args) {
                popupWin = window.open("http://miracleonline/SynapseManageLink/AccessionNOpacsurl.html?AccessionNo=" + args, "name");
                popupWin.focus();
                return false;
            }
            function showNormalAlert(args) {
                switch (args) {
                    case 'EditOrder':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4006", "windowOnlineMessageBox");
                        break;
                    case 'ManualPopup':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args, "windowOnlineMessageBox");
                        break;
                    case 'checkRefDoc':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4010", "windowOnlineMessageBox");
                        break;
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" NavigateUrl="~/Forms/Dialogs/OnlineMessageBox.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<table width="100%" cellpadding="0" cellspacing="0">
        <tr>
             <td colspan="2">
                    <telerik:RadToolBar ID="rtoolSearch" runat="server" Width="100%" Orientation="Vertical">
                        <Items>
                            <telerik:RadToolBarButton Value="rtoolbtnSearch">
                                <ItemTemplate>
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgWorklist" ImageUrl="~/Resources/ICON/browse_16.png" runat="server"
                                            Height="20px" Width="20px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="labelWorklistLogo" runat="server" Text="Worklist" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="labelSearch" runat="server" Text="Search by HN : " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" />
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                        </Items>
                    </telerik:RadToolBar>
                </td>
        </tr>
        <tr>
                <td>
                    <telerik:RadGrid ID="grdData" runat="server" PageSize="30"
                     AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="True"
                        OnNeedDataSource="grdData_NeedDataSource"
                        OnItemCommand="grdData_ItemCommand" 
                        OnItemDataBound="grdData_ItemDataBound"
                        >
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <MasterTableView TableLayout="Fixed" EditMode="InPlace" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                            Summary="grdData table">
                            <SortExpressions>
                                <telerik:GridSortExpression SortOrder="Descending" FieldName="Result Time" />
                            </SortExpressions>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="grdbtnPrintA5" HeaderText=" " ButtonType="LinkButton" Text="Print A5" Visible="true"
                                    UniqueName="grdbtnPrintA5_Unigue" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center"/>
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnPrintA4" HeaderText=" " ButtonType="LinkButton"  Text="Print A4" Visible="true"
                                    UniqueName="grdbtnPrintA4_Unigue" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center"/>
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="HN" HeaderText="HN" SortExpression="HN"
                                    UniqueName="colHN" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name"
                                    UniqueName="colPatient_Name" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    AllowFiltering="True">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Width="100px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Accession No" HeaderText="Accession No" SortExpression="Accession No"
                                    UniqueName="colAccessionNo" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false" >
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="50px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnSynapse" HeaderText="" ButtonType="ImageButton"
                                    UniqueName="grdbtnSynapse_Unigue" ImageUrl="../../Resources/Logo/synapse16.jpg">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="Exam Code" HeaderText="Exam Code" SortExpression="Exam Code"
                                    UniqueName="colExamCode" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false" >
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Exam Name" HeaderText="Exam Name" SortExpression="Exam Name"
                                    UniqueName="colExamName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RESULT_STATUS" HeaderText="Status" SortExpression="RESULT_STATUS"
                                    UniqueName="colRESULT_STATUS" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="50px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Result Time" UniqueName="colResultTime" HeaderText="Result DateTime"
                                    DataType="System.DateTime"
                                    SortExpression="Result Time"  AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%"
                                    Visible="true" >
                                    <HeaderStyle Width="90px" />
                                    <ItemStyle Width="90px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Radiologist" HeaderText="Radiologist"
                                SortExpression="Radiologist" UniqueName="colRadiologist" AutoPostBackOnFilter="true"
                                ShowFilterIcon="false" FilterControlWidth="100%">
                                <HeaderStyle Width="105px" />
                                <ItemStyle Width="105px" Wrap="False" />
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
