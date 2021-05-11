<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmEnvisionOrderWL.aspx.cs" Inherits="frmEnvisionOrderWL" %>

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
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline">
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
                    case 'checkRefUnit':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4016", "windowOnlineMessageBox");
                        break;
                    case 'CANNOT_REQONLINE':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4014", "windowOnlineMessageBox");
                        break;
                    case 'RemoveExamFavorite':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4004", "windowOnlineMessageBox");
                        break;
                    case 'CannotPrint':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4019", "windowOnlineMessageBox");
                        break;
                    case 'IsBusy':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args , "windowOnlineMessageBox");
                        break;
                    case 'DeleteSchedule':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args, "windowOnlineMessageBox");
                        break;
                }
            }
            function printDocument(url) {
                window.radopen(url, "windowPrintDocument");
            }
            function showPrintPreview(url) {
                window.open(url);
            }
            function showPreviewReport(accession) {
                window.radopen("../../ReportViewer/frmPreviewReport.aspx?Accession_no=" + accession, "windowPreviewReport");
            }
            function showPreviewComment(url) {
                window.radopen(url, "windowPreviewReport");
            }
            function showDeleteCase(url) {
                window.radopen("../../Forms/Dialogs/OnlineOrderCancelForm.aspx?" + url, "windowCancelReason");
            }
            function showHelp() {
                window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequest.pdf', '_newtab');
            }
            function showFilter(mode) {
                switch (mode) {
                    case 'CT':
                        window.open('http://miracleonline/manualonlinerequest/pdf/Screening_CT.pdf', '_newtab');
                    break;
                case 'MR':
                    window.open('http://miracleonline/manualonlinerequest/pdf/Screening_MRI.pdf', '_newtab');
                    break;

                }
                
            }
            function showAlertPatientPhone(url) {
                window.radopen("../../Forms/Dialogs/OnlineAlertPatientPhone.aspx?" + url, "windowAlertPatientPhone");
            }
            var popupWin;
            function showNewWindows(args) {
                popupWin = window.open("http://miracleonline/SynapseManageLink/AccessionNOpacsurl.html?AccessionNo=" + args, "name");
                popupWin.focus();
                return false;
            }
            function showQuickOrder(arg) {
                window.radopen("../../Forms/Dialogs/OnlineClinicalIndicationPopup.aspx?EXAM_ID="+arg.toString(), "windowQuickOrder");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="blockAjaxManage" runat="server">
        <script type="text/javascript">
            function OnClientClose() {
            }
            function OnRequestStart(sender, args) {
            }
            function OnResponseEnd(sender, args) {
            }
            function set_AjaxRequest(args) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(args);
            }
            function RefreshGridWorklist() {
                var masterTable = $find("<%= grdData.ClientID %>").get_masterTableView();
                masterTable.rebind();
            }
            function refreshGrid(arg) {
                if (!arg) {
                    set_AjaxRequest("Rebind");
                }
                else if (arg == 'DeleteOrder') {
                    set_AjaxRequest("DeleteOrder");
                }
                else if (arg == 'refreshGrid') {
                    RefreshGridWorklist();
                }
                else if (arg == 'ClinicalPopup') {
                    RefreshGridWorklist();
                }
            }
            function chkMessageBox(args) {
                set_AjaxRequest(args);
            }
            function setReturnPopup(args) {
                set_AjaxRequest(args);
            }
            function getHelp()  
            {
                var combo = $find('<%=cmbManual.ClientID %>');
                var _value = combo.get_selectedItem().get_value();
                switch (_value) {
                    case "1":
                        window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequest.pdf', '_newtab');
                    break;
                case "2":
                    window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequestCT.pdf', '_newtab');
                    break;
                case "3":
                    window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequestMRI.pdf', '_newtab');
                    break;
                case "4":
                    window.open('http://miracleonline/manualonlinerequest/pdf/SimpleScreening.pdf', '_newtab');
                    break;
                }
            }
        </script>
    </telerik:RadCodeBlock>
   <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
	    <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
	            <UpdatedControls>
	                <telerik:AjaxUpdatedControl ControlID="grdData" LoadingPanelID="RadAjaxLoadingPanel1" />
	            </UpdatedControls>
	        </telerik:AjaxSetting>
	        <telerik:AjaxSetting AjaxControlID="grdData">
	            <UpdatedControls>
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
	<telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" NavigateUrl="~/Forms/Dialogs/OnlineMessageBox.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowMultiMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" NavigateUrl="~/Forms/Dialogs/OnlineMultiMessageBox.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowCancelReason" runat="server" Behaviors="Move" Modal="true"
                Width="400" Height="480" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowAlertPatientPhone" runat="server" Behaviors="Move" Modal="true"
                Width="400" Height="300" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowQuickOrder" runat="server" Behaviors="Close, Move" Modal="true"
                Width="500" Height="400" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowEditOrder" runat="server" Behaviors="Move" Modal="true" ReloadOnShow="true"
                Width="400" Height="450" NavigateUrl="~/Forms/Dialogs/OnlineEditOrder.aspx" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowPreviewReport" runat="server" 
             VisibleStatusbar="false" AutoSize="true" AutoSizeBehaviors="Height" OffsetElementID="offsetElement"
            Behaviors="Close, Move" Modal="true" ReloadOnShow="true"
              Width="700" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowPrintDocument" runat="server" 
             VisibleStatusbar="false" AutoSize="true" AutoSizeBehaviors="Height" OffsetElementID="offsetElement"
            Behaviors="Close, Move" Modal="true" ReloadOnShow="true"
              Width="700" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <div>
        <table id="mainTable"style="border-width: thin; border-style: none; border-spacing: 0px;"  width="100%" align="center"  border="0" cellspacing="0" cellpadding="0">
            <tr style="background-color: #000080">
            <td align="left">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="labelHead" runat="server" Text="Envision Online" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbVersion" runat="server" Text="v. 4.4.3.15" ForeColor="White" 
                                Font-Size="X-Small" Width="100px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                 <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmployeeName" runat="server" Text="Employee" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadButton Text="Log out" ID="btnLogout" runat="server" ButtonType="ToggleButton"
                                Width="60px" ForeColor="Red" OnClick="btnLogout_OnClick">
                            </telerik:RadButton>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="cmbManual" runat="server"  
                                EmptyMessage="คู่มือ"  Font-Bold="true"
                                AutoPostBack="true" OnClientSelectedIndexChanged="getHelp" >
                                <Items>
                                    <telerik:RadComboBoxItem Text="คู่มือพื้นฐาน" Value="1" />
                                    <telerik:RadComboBoxItem Text="คู่มือ CT" Value="2" />
                                    <telerik:RadComboBoxItem Text="คู่มือ MRI" Value="3" />
                                    <telerik:RadComboBoxItem Text="Simple Screeing CT & MRI" Value="4" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
            <tr valign="top" style="border-style: none">
            <td colspan="2">
                <telerik:RadToolBar ID="rtoolPatient" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton Value="rtoolbtnPatient">
                            <ItemTemplate>
                                <asp:Label ID="labelHN" runat="server" Text="HN : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblHN" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace1" runat="server" Width="10px" Text=""></asp:Label>
                                <asp:Label ID="labelPatientName" runat="server" Text="Name : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace2" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelGender" runat="server" Text="Gender : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace3" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelAge" runat="server" Text="Age : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace4" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelDOB" runat="server" Text="DOB : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblDOB" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace5" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelPhone" runat="server" Text="Phone : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblNonResident" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </td>
            </tr>
            <tr valign="top" style="border-style: none; border-width:thin;">
            <td colspan="2">
                <telerik:RadToolBar ID="rtoolHISPatient" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton Value="rtoolbtnHISPatient">
                            <ItemTemplate>
                                <asp:Label ID="labelInsurance" runat="server"  Font-Bold="True" Text="Insurance : "></asp:Label>
                                <asp:Label ID="txtInsurance" runat="server" Text="  "></asp:Label>
                                <asp:Label ID="labelClinicType" runat="server" Font-Bold="True" Text="Clinic type : "></asp:Label>
                                <asp:Label ID="txtClinicType" runat="server" Text="" ></asp:Label>
                                <asp:Label ID="labelRefUnit" runat="server" Text="Ordering Dept : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="txtRefUnit" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadToolBar ID="rtbMainWL" runat="server" Width="100%" Height="80px" OnButtonClick="rtbMain_ButtonClick">
                        <Items>
                            <telerik:RadToolBarButton Value="btnNewOrder" Text="New Order" ToolTip="Make New Order" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/order_32.png"/>
                             <telerik:RadToolBarButton Value="btnRefresh" Text="Refresh" ToolTip="Refresh Worklist" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/refresh32.png"/>
                             <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                             <telerik:RadToolBarButton Value="btnQuickOrder" Text="Chest X-Ray" ToolTip="Quick Order" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                             <telerik:RadToolBarButton Value="btnQuickOrder2" Text="CR01" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder3" Text="CR02" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder4" Text="CR03" ToolTip="CR01" Width="60px"
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder5" Text="CR04" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder6" Text="CR05" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder7" Text="CR06" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder8" Text="CR07" ToolTip="CR01" Width="60px"
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder9" Text="CR08" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnQuickOrder10" Text="CR09" ToolTip="CR01" Width="60px" 
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/chestIcon_resize.jpg"
                              Visible="false"/>
                              <telerik:RadToolBarButton Value="btnVNA" Text="VNA" ToolTip="VNA" Width="60px" CssClass="btnVNA"
                             ImagePosition="AboveText" ImageUrl="../../Resources/ICON/vna_32.png"
                              Visible="false"/>
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadToolBar ID="rtoolSearch" runat="server" Width="100%" Orientation="Horizontal">
                        <Items>
                            <telerik:RadToolBarButton Value="rtoolbtnSearch">
                                <ItemTemplate>
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
                                                <asp:Label ID="labelSearch" runat="server" Text="Search : " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_OnTextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Value="rtoolbtnDatetime">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                           <asp:Label ID="labelDateFrom" runat="server" Text=" Search by Date From to ++ : " Font-Bold="True"></asp:Label>
                                            </td>
                                        
                                            <td>
                                            <telerik:RadDatePicker ID="dtFromDate" runat="server" Culture="th-TH" Calendar-CultureInfo="th-TH" Calendar-FastNavigationStep="12">
                                    </telerik:RadDatePicker>
                                            </td>
                                        
                                            <td>
                                            <asp:Label ID="labelDateTo" runat="server" Text=" To All Future." Font-Bold="True" Visible="false"></asp:Label>
                                            </td>
                                       
                                            <td>
                                            <telerik:RadDatePicker ID="dtToDate" runat="server" Culture="th-TH" Calendar-CultureInfo="Thai (Thailand)" Calendar-FastNavigationStep="12" Visible="false">
                                    </telerik:RadDatePicker>
                                            </td>
                                        
                                            <td>
                                            <telerik:RadButton ID="btnSearchDate" runat="server" Text="Go" OnClick="btnSearchDate_OnClick">
                                    </telerik:RadButton>
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
                <td colspan="2">
                    <telerik:RadGrid ID="grdData" runat="server" PageSize="30"
                     AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="True"
                        OnNeedDataSource="grdData_NeedDataSource"
                        OnItemCommand="grdData_ItemCommand" 
                        OnItemDataBound="grdData_ItemDataBound"
                        OnDataBound="grdData_OnDataBound"
                        OnPreRender="grdData_PreRender" >
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <MasterTableView TableLayout="Fixed" EditMode="InPlace" ClientDataKeyNames="ONL_REQ,EXAM_UID" AllowAutomaticUpdates="true" AutoGenerateColumns="false"
                            Summary="grdData table">
                            <SortExpressions>
                                <telerik:GridSortExpression SortOrder="Descending" FieldName="ORDER_DT" />
                            </SortExpressions>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="grdbtnEdit" HeaderText="Edit" ButtonType="ImageButton"
                                    UniqueName="grdbtnEdit_Unigue" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnDelete" HeaderText="Del." ButtonType="ImageButton"
                                    UniqueName="grdbtnDelete_Unigue" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnFilterPrint" HeaderText="Consent Form." ButtonType="ImageButton"
                                    UniqueName="grdbtnFilterPrint_Unigue" ImageUrl="../../Resources/ICON/preferences-desktop-peripherals-3_16.png"
                                    Visible="true" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnDirectPrint" HeaderText="Print" ButtonType="ImageButton"
                                    UniqueName="grdbtnDirectPrint_Unigue" ImageUrl="../../Resources/ICON/print-icon.png"
                                    Visible="true" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnPreviewReport" HeaderText="Report" ButtonType="ImageButton"
                                    UniqueName="grdbtnPreviewReport_Unigue" ImageUrl="../../Resources/ICON/report_16.png"
                                    Visible="true" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="PRIORITY_TEXT" HeaderText="Priority" SortExpression="Priority"
                                    UniqueName="colPRIORITY_TEXT" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="true">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="45px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS_TEXT" HeaderText="Status" SortExpression="STATUS_TEXT"
                                    UniqueName="colSTATUS_TEXT" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    AllowFiltering="True">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="50px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HN" HeaderText="HN" SortExpression="HN"
                                    UniqueName="colHN" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false" >
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="50px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PATIENT_NAME" HeaderText="Patient Name" SortExpression="PATIENT_NAME"
                                    UniqueName="colPATIENT_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false" >
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SEVERITY_TEXT" HeaderText="Severity" SortExpression="SEVERITY_TEXT"
                                    UniqueName="colSEVERITY_TEXT" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle Width="60px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ORDER_DT" UniqueName="colOrderDT" HeaderText="Study Datetime"
                                    DataType="System.DateTime"
                                    SortExpression="Study Datetime"  AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%"
                                    Visible="false" >
                                    <HeaderStyle Width="105px" />
                                    <ItemStyle Width="105px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="strEXAM_DT" DataType="System.String" HeaderText="Study Datetime"
                                SortExpression="strEXAM_DT" UniqueName="colstrEXAM_DT" AutoPostBackOnFilter="true"
                                ShowFilterIcon="false" FilterControlWidth="100%">
                                <HeaderStyle Width="105px" />
                                <ItemStyle Width="105px" Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TYPE_NAME_ALIAS" HeaderText="Mod." SortExpression="Modality"
                                    UniqueName="colModality" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnSynapse" HeaderText="" ButtonType="ImageButton"
                                    UniqueName="grdbtnSynapse_Unigue" ImageUrl="../../Resources/Logo/synapse16.jpg">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnShowClinical" HeaderText="" ButtonType="ImageButton"
                                    UniqueName="grdbtnShowClinical_Unigue" ImageUrl="../../Resources/ICON/text_file.png"
                                    Visible="true" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="grdbtnShowComment" HeaderText="" ButtonType="ImageButton"
                                    UniqueName="grdbtnShowComment_Unigue" ImageUrl="../../Resources/ICON/Comment-add-icon16.png"
                                    Visible="true" >
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </telerik:GridButtonColumn>
                               
                                <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Exam Name" SortExpression="EXAM_NAME"
                                    UniqueName="colEXAM_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%">
                                    <HeaderStyle Width="160px" />
                                    <ItemStyle Width="160px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PAT_DEST_DESC" HeaderText="Loc." SortExpression="PAT_DEST_DESC"
                                    UniqueName="colPAT_DEST_DESC" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="35px" Wrap="true" />
                                    <ItemStyle Width="35px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BPVIEW_NAME" HeaderText="Side" SortExpression="Side"
                                    UniqueName="colSide" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle Width="40px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REF_DOCNAME" HeaderText="Ordering Doc." SortExpression="REF_DOCNAME"
                                    UniqueName="colREF_DOCNAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ASSIGNED_NAME" HeaderText="Radiologist" SortExpression="ASSIGNED_NAME"
                                    UniqueName="colASSIGNED_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REF_UNIT_DESC" HeaderText="Ordering Dept." SortExpression="Ordering Dept."
                                    UniqueName="colREF_UNIT_DESC" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Width="100px" Wrap="true" />
                                </telerik:GridBoundColumn>
                                

                                <telerik:GridBoundColumn DataField="PRIORITY" HeaderText="Priority" SortExpression="Priority"
                                    UniqueName="colPriority" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" SortExpression="Status"
                                    UniqueName="colStatus" AutoPostBackOnFilter="true" ShowFilterIcon="true" AllowFiltering="True"
                                    Visible="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SEVERITY_ID" HeaderText="SEVERITY_ID" SortExpression="SEVERITY_ID"
                                    UniqueName="colSEVERITY_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MODALITY_UID" HeaderText="Modality Code" SortExpression="ModalityCode"
                                    UniqueName="colModalityCode" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                    UniqueName="colEXAM_UID" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false"  FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PAT_DEST_ID" HeaderText="Service Loc." SortExpression="PAT_DEST_ID"
                                    UniqueName="colPAT_DEST_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REF_DOC" HeaderText="Ordering Doc." SortExpression="REF_DOC"
                                    UniqueName="colREF_DOC" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false" FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ASSIGNED_TO" HeaderText="Radiologist" SortExpression="ASSIGNED_TO"
                                    UniqueName="colASSIGNED_TO" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%"
                                    Visible="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BPVIEW_ID" HeaderText="BPVIEW_ID" SortExpression="BPVIEW_ID"
                                    UniqueName="colBPVIEW_ID" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ACCESSION_NO" HeaderText="ACCESSION_NO" SortExpression="ACCESSION_NO"
                                    UniqueName="colACCESSION_NO" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PAT_STATUS" HeaderText="PAT_STATUS" SortExpression="PAT_STATUS"
                                    UniqueName="colPAT_STATUS" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="INSURANCE_TYPE_ID" HeaderText="INSURANCE_TYPE_ID"
                                    SortExpression="INSURANCE_TYPE_ID" UniqueName="colINSURANCE_TYPE_ID" Visible="False"
                                    AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REF_UNIT" HeaderText="REF_UNIT" SortExpression="REF_UNIT"
                                    UniqueName="colREF_UNIT" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REG_ID" HeaderText="REG_ID" SortExpression="REG_ID"
                                    UniqueName="colREG_ID" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CLINIC_TYPE" HeaderText="CLINIC_TYPE" SortExpression="CLINIC_TYPE"
                                    UniqueName="coCLINIC_TYPE" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ORDER_ID" HeaderText="ORDER_ID" SortExpression="ORDER_ID"
                                    UniqueName="coORDER_ID" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SCHEDULE_ID" HeaderText="SCHEDULE_ID" SortExpression="SCHEDULE_ID"
                                    UniqueName="coSCHEDULE_ID" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                                    UniqueName="coEXAM_ID" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ONL_REQ" HeaderText="ONL_REQ" SortExpression="ONL_REQ"
                                    UniqueName="coONL_REQ" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
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
        </table>
    </div>
	</form>
</body>
</html>
