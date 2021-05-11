<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ExceptionError.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
	<telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <link href="ErrorLogsStyle.css" rel="stylesheet" />
    </head>
<body>
	<form id="form1" runat="server">
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager runat="server" ID="radAjaxManager" onajaxrequest="radAjaxManager_AjaxRequest">
        <AjaxSettings>
         <telerik:AjaxSetting AjaxControlID="grdException">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdException"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdException"/>
                    <telerik:AjaxUpdatedControl ControlID="comboSearch" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <table width="100%">
    <tr>
                <td colspan="2">
                    <telerik:RadToolBar ID="rtoolSearch" runat="server" Width="100%">
                        <Items>
                        <telerik:RadToolBarButton Value="rtoolCmbSearch">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="comboSearch" Runat="server" 
                                        AutoPostBack="True" 
                        onselectedindexchanged="comboSearch_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" 
                                                Owner="comboSearch" Text="User ID" Value="1" />
                            <telerik:RadComboBoxItem runat="server" 
                                                Owner="comboSearch" Text="IP Address" Value="2" />
                            <telerik:RadComboBoxItem runat="server" 
                                                Owner="comboSearch" Text="Date" Value="3" />
                        </Items>
                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="labelSearch" runat="server" Text="Search : " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" 
                                                    OnTextChanged="txtSearch_OnTextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                
</ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Value="rtoolbtnSearch">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="labelSearch" runat="server" Text="Search : " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" 
                                                    OnTextChanged="txtSearch_OnTextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Value="rtoolbtnDatetime">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                           <asp:Label ID="labelDateFrom" runat="server" Text=" Search by Date : " 
                                                    Font-Bold="True" Visible="False"></asp:Label>
                                            </td>
                                        
                                            <td>
                                            <telerik:RadDatePicker ID="dtFromDate" runat="server" Culture="th-TH" 
                                                    Calendar-CultureInfo="th-TH" Calendar-FastNavigationStep="12" 
                                                    onselecteddatechanged="dtFromDate_SelectedDateChanged" 
                                                    SelectedDate="2015-09-02" Visible="False">
                                                <Calendar runat="server" FastNavigationStep="12" UseColumnHeadersAsSelectors="False" 
                                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput ReadOnly="true" runat="server" DateFormat="d/M/yyyy" DisplayDateFormat="d/M/yyyy" 
                                                    EnableSingleInputRendering="True" LabelWidth="64px" SelectedDate="2015-09-02">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                            </td>
                                        
                                            <td>
                                            <asp:Label ID="labelDateTo" runat="server" Text=" To All Future." Font-Bold="True" 
                                                    Visible="False"></asp:Label>
                                            </td>
                                       
                                            <td>
                                            <telerik:RadDatePicker ID="dtToDate" runat="server" Culture="th-TH" 
                                                    Calendar-CultureInfo="Thai (Thailand)" Calendar-FastNavigationStep="12" 
                                                    onselecteddatechanged="dtToDate_SelectedDateChanged" 
                                                    SelectedDate="2015-09-02" Visible="False">
                                                <Calendar runat="server" FastNavigationStep="12" UseColumnHeadersAsSelectors="False" 
                                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput ReadOnly="true" runat="server" DateFormat="d/M/yyyy" DisplayDateFormat="d/M/yyyy" 
                                                    EnableSingleInputRendering="True" LabelWidth="64px" SelectedDate="2015-09-02">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                            </td>
                                        
                                            <td>
                                            <telerik:RadButton ID="btnSearch" runat="server" Text="Go" 
                                                    OnClick="btnSearch_OnClick" style="top: 0px; left: 0px">
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
                                        AutoPostBack="true" style="top: 0px; left: 0px" >
                                    </telerik:RadButton>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
        <tr>
             <td colspan="3">
                
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript" language="javascript">
        function OnRowDblClick(sender, args) {
            var grid = sender;
            var keyErrorID = args.getDataKeyValue('ERROR_ID');
            param = keyErrorID;
            set_AjaxRequest(param);
        }
    </script>
</telerik:RadScriptBlock>
  
<telerik:RadScriptBlock ID="blockGrid" runat="server">
        <script type="text/javascript">
            function set_AjaxRequest(arg) {
                $find("<%= radAjaxManager.ClientID %>").ajaxRequest(arg);
            }       
        </script>
</telerik:RadScriptBlock>                           

<telerik:RadGrid ID="grdException" runat="server" CellSpacing="0" 
    Width="100%" AllowPaging="True" AllowSorting="True" EnableAJAX="true"
    onitemcommand="grdException_ItemCommand" 
    onneeddatasource="grdException_NeedDataSource" ShowStatusBar="True" 
                AllowFilteringByColumn="True" GridLines="None">
    <ClientSettings>
    <Selecting CellSelectionMode="None" AllowRowSelect="True"></Selecting>
        <ClientEvents OnRowDblClick="OnRowDblClick" />
    </ClientSettings>
        <MasterTableView GridLines="None" AutoGenerateColumns="False" ClientDataKeyNames="ERROR_ID">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>

            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>

                <Columns>
                    <telerik:GridButtonColumn CommandName="ShowAlret" 
                        FilterControlAltText="Filter ShowAlret column" HeaderText="Link" Text="URL" 
                        UniqueName="ShowAlret">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="ERROR_ID" 
                        FilterControlWidth="100%" FilterControlAltText="Filter colERROR_ID column" HeaderText="Error ID" 
                        ShowFilterIcon="False" SortExpression="ERROR_ID" UniqueName="colERROR_ID" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="USER_LOGIN" 
                        FilterControlWidth="100%" FilterControlAltText="Filter colUSER_LOGIN column" HeaderText="User Login" 
                        ShowFilterIcon="False" SortExpression="USER_LOGIN" UniqueName="colUSER_LOGIN">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" 
                        DataField="USER_HOST_ADDRESS" 
                        FilterControlWidth="100%" FilterControlAltText="Filter colUSER_HOST_ADDRESS column" 
                        HeaderText="User Host Address" ShowFilterIcon="False" 
                        SortExpression="USER_HOST_ADDRESS" UniqueName="colUSER_HOST_ADDRESS">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="ERROR_MESSAGE" 
                        FilterControlWidth="100%" FilterControlAltText="Filter colERROR_MESSAGE column" 
                        HeaderText="Error Message" ShowFilterIcon="False" 
                        SortExpression="ERROR_MESSAGE" UniqueName="colERROR_MESSAGE">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="ERROR_SOURCE" 
                        FilterControlWidth="100%" FilterControlAltText="Filter colERROR_SOURCE column" HeaderText="Error Source" 
                        ShowFilterIcon="False" SortExpression="ERROR_SOURCE" 
                        UniqueName="colERROR_SOURCE">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="PIC_PATH" 
                        FilterControlAltText="Filter colPIC_PATH column" HeaderText="PIC_PATH" 
                        ShowFilterIcon="False" SortExpression="PIC_PATH" UniqueName="colPIC_PATH" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="CREATED_BY" 
                        FilterControlAltText="Filter colCREATED_BY column" HeaderText="Created By" 
                        ShowFilterIcon="False" SortExpression="CREATED_BY" UniqueName="colCREATED_BY" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="CREATED_ON" 
                        FilterControlWidth="100%" FilterControlAltText="Filter colCREATED_ON column" HeaderText="Createed  On" 
                        ShowFilterIcon="False" SortExpression="CREATED_ON" UniqueName="colCREATED_ON">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                </Columns>

            <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
        </MasterTableView>

            <FilterItemStyle Width="100%" />

            <FilterMenu EnableImageSprites="False"></FilterMenu>

</telerik:RadGrid>
    
            </td>
        </tr>
    </table>

	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
	<script type="text/javascript">
	    function openRadWindow() 
        {
	        window.radopen("ImageException.aspx", "windowNormalPage");
	    }
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdException">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdException" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
        EnableShadow="True" ShowContentDuringLoad="False" VisibleStatusbar="False">
        <Windows>
            <telerik:RadWindow ID="windowNormalPage" Title="Troubleshooting Guide" 
                runat="server" Behaviors="Close, Move"
                Modal="true" Skin="Telerik" 
                Behavior="Close, Move" VisibleStatusbar="False" AutoSize="True">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    
    

    </form>
</body>
</html>
