<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVNAWorklist.aspx.cs" Inherits="frmVNAWorklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
    <style type="text/css">
        body
        {
        margin:0 0 0 0;
        font-family:MS Sans Serif;
        	}
        .textButton
        {
            text-align:left;
            vertical-align:text-top;
            }
        .btnVNA
        {
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
		//Put your JavaScript code here.
    </script>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function showPrintPreview(url) {
                var optionUrl = "width=" + screen.width + ",height=" + screen.height + ',Left=0,Top = 0,scrollbars=no,resizable=yes,menubar=yes,toolbar=yes,maximize=1';
                window.open(url, 'Preview', optionUrl);
            }
        </script>
    </telerik:RadCodeBlock>
	<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
	    <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
	            <UpdatedControls>
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="chkShowAllData" />
                    <telerik:AjaxUpdatedControl ControlID="txtSearch" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
	        <telerik:AjaxSetting AjaxControlID="grdData">
	            <UpdatedControls>
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="txtSearch" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="chkShowAllData">
	            <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkShowAllData" />
                    <telerik:AjaxUpdatedControl ControlID="txtSearch" />
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtSearch">
	            <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkShowAllData" />
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbMainWL">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtbMainWL" />
                    <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
	    </AjaxSettings>
	</telerik:RadAjaxManager>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            <telerik:RadToolBar ID="rtoolSearch" runat="server" Width="100%" Orientation="Horizontal">
            <Items>
                <telerik:RadToolBarButton Value="rtoolbtnSearch">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="imgWorklist" ImageUrl="~/Resources/ICON/browse_16.png" runat="server" Height="20px" Width="20px" />
                                </td>
                                <td>
                                    <asp:Label ID="labelWorklistLogo" runat="server" Text="Worklist" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labelSearch" runat="server" Text="Search : " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_OnTextChanged"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="True">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="rtoolbtnChkAll">
                    <ItemTemplate>
                        <telerik:RadButton ID="chkShowAllData" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox"
                            Text="Show All Data" CommandName="Play" OnCheckedChanged="chkShowAllData_OnCheckedChanged"
                            AutoPostBack="true" >
                        </telerik:RadButton>
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
                        OnItemDataBound="grdData_ItemDataBound" >
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <MasterTableView TableLayout="Fixed" EditMode="InPlace" ClientDataKeyNames="VN" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                            Summary="grdData table">
                            <SortExpressions>
                                <telerik:GridSortExpression SortOrder="Descending" FieldName="EFFECTIVE_START_DATE" />
                            </SortExpressions>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="grdbtnUpload" HeaderText="Upload" ButtonType="ImageButton"
                                    UniqueName="grdbtnUpload_Unigue" ImageUrl="../../Resources/ICON/upload-16.png">
                                    <HeaderStyle Width="25px" />
                                     <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="HN" HeaderText="HN" SortExpression="HN"
                                    UniqueName="colHN" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="true" >
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="50px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PATIENT_NAME" HeaderText="Patient Name" SortExpression="PATIENT_NAME"
                                    UniqueName="colPATIENT_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="true" >
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Width="100px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnViewer" HeaderText="Viewer" ButtonType="ImageButton"
                                    UniqueName="grdbtnViewer_Unigue" ImageUrl="../../Resources/ICON/vna_16.png">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="VN" HeaderText="Visit Number" SortExpression="Visit Number"
                                    UniqueName="colVN" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="true">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="45px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EFFECTIVE_START_DATE" UniqueName="colEFFECTIVE_START_DATE" HeaderText="Visit Datetime"
                                    DataType="System.DateTime"
                                    SortExpression="Visit Datetime"  AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%"
                                    Visible="true" >
                                    <HeaderStyle Width="105px" />
                                    <ItemStyle Width="105px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UNIT_NAME" HeaderText="Unit Name" SortExpression="Unit Name"
                                    UniqueName="colUNIT_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle Width="200px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STMO_NAME" HeaderText="STMO_NAME" SortExpression="STMO_NAME"
                                    UniqueName="colSTMO_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                     Visible="false">
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle Width="200px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="VNA_PATH" HeaderText="VNA_PATH" SortExpression="VNA_PATH"
                                    UniqueName="colVNA_PATH" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                     Visible="false">
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle Width="200px" Wrap="true" />
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
