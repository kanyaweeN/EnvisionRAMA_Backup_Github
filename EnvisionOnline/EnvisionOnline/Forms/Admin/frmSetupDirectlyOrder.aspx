<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Forms/Admin/masterAdmin.Master" AutoEventWireup="true"
    CodeBehind="frmSetupDirectlyOrder.aspx.cs" Inherits="frmSetupDirectlyOrder" %>

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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" />
                    <telerik:AjaxUpdatedControl ControlID="cmbRefUnit" />
                    <telerik:AjaxUpdatedControl ControlID="cmbClinicType" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbRefUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" />
                    <telerik:AjaxUpdatedControl ControlID="cmbRefUnit" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbClinicType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" />
                    <telerik:AjaxUpdatedControl ControlID="cmbClinicType" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdDataExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDataExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdDataSelected" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<table width="100%" cellspacing="0">
        <tr>
            <td colspan="2">
                <telerik:RadToolBar ID="rtbMainNW" runat="server" Width="100%" Height="80px" OnButtonClick="rtbMain_ButtonClick">
                    <Items>
                        <telerik:RadToolBarButton Value="btnSave" Text="Save" ToolTip="Save Data" Width="60px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/saveLarge.png"/>
                    </Items>
                </telerik:RadToolBar>  
            </td>
        </tr>
        <tr>
            <td valign="top" style="width:50%">
                <telerik:RadComboBox ID="cmbRefUnit" runat="server"
                    Height="170px" Width="100%" AutoPostBack="true"
                    ShowMoreResultsBox="True" EnableLoadOnDemand="True" 
                    OnItemsRequested="cmbRefUnit_ItemsRequested"
                    OnSelectedIndexChanged="cmbRefUnit_SelectedIndexChanged" />
            </td>
            <td valign="top" style="width:50%">
                <telerik:RadComboBox ID="cmbClinicType" runat="server"
                    Height="170px" Width="100%" AutoPostBack="true"
                    ShowMoreResultsBox="True" EnableLoadOnDemand="True" 
                    OnItemsRequested="cmbClinicType_ItemsRequested"
                    OnSelectedIndexChanged="cmbClinicType_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
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
                                    ImageUrl="../../Resources/ICON/add2-16.png">
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
                                    ImageUrl="../../Resources/ICON/Actions-remove16.png">
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
</asp:Content>
