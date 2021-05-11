<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Forms/Admin/masterAdmin.Master" AutoEventWireup="true"
    CodeBehind="frmSetupGroupExam.aspx.cs" Inherits="frmSetupGroupExam" %>

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
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function showpopupSaveTabHeader() {
                window.radopen("./dialogs/dialogGroupExamTabHeader.aspx", "windowSaveTabHeader");
            }
            function showpopupDeleteTabHeader() {
                window.radopen("./dialogs/dialogGroupExamTabHeaderDelete.aspx", "windowSaveTabHeader");
            }
            function showpopupEditTabHeader() {
                window.radopen("./dialogs/dialogGroupExamTabHeaderEdit.aspx", "windowSaveTabHeader");
            }
            function showpopupSaveGroupExamType() {
                window.radopen("./dialogs/dialogGroupExamTypeAdd.aspx", "windowSaveTabHeader");
            }
            function showpopupDeleteGroupExamType() {
                window.radopen("./dialogs/dialogGroupExamTypeDelete.aspx", "windowSaveTabHeader");
            }
            function showpopupEditGroupExamType() {
                window.radopen("./dialogs/dialogGroupExamTypeEdit.aspx", "windowSaveTabHeader");
            }
            function showpopupSaveGroupExam(args) {
                window.radopen("./dialogs/dialogGroupExamAdd.aspx?MODE=" + args, "windowSelectExam");
            }
            function set_AjaxRequest(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
            function refreshGrid(arg) {
                if (!arg) {
                    set_AjaxRequest("Rebind");
                }
                else {
                    set_AjaxRequest(arg);
                }
            }
            function OnClientClose() {
            }
        </script>
    </telerik:RadCodeBlock>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbButtomFix" />
                    <telerik:AjaxUpdatedControl ControlID="rtbMainNW" />
                    
                    <telerik:AjaxUpdatedControl ControlID="grdTabHearder" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamGroup" LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbButtomFix">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdTabHearder" LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="grdExamGroup" LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdTabHearder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdExamGroup" LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdExamGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" Behaviors="Close, Move" Animation="Resize" VisibleTitlebar="true" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowSaveTabHeader" runat="server" Behaviors="Close, Move"
                AutoSizeBehaviors="Default" Modal="true" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowSelectExam" runat="server" Behaviors="Close, Move"
                Width="800" Height="500"
                AutoSizeBehaviors="Default" Modal="true" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <div style="margin: 12px 0 0 0;">
        <table width="100%" cellspacing="0">
        <tr>
            <td colspan="3">
                <telerik:RadToolBar ID="rtbMainNW" runat="server" Width="100%" Height="80px" OnButtonClick="rtbMain_ButtonClick">
                    <Items>
                        <telerik:RadToolBarButton Value="btnSaveTabHearder" Text="Add Tab Hearder" ToolTip="Add Tab Hearder" Width="160px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/saveLarge.png"/>
                        <telerik:RadToolBarButton Value="btnSaveGroupExam" Text="Add Group Exam" ToolTip="Add Group Exam" Width="160px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/saveLarge.png"/>
                        <telerik:RadToolBarButton Value="btnSaveExam" Text="Add Exam" ToolTip="Add Exam" Width="160px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/saveLarge.png"/>
                    </Items>
                </telerik:RadToolBar>  
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <telerik:RadComboBox ID="cmbButtomFix" runat="server"
                                Height="170px" Width="100%" ShowMoreResultsBox="True" AutoPostBack="true"
                                OnSelectedIndexChanged="cmbButtomFix_SelectedIndexChanged" >
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="OR Imaging" Value="OR" Selected="true" />
                                    <telerik:RadComboBoxItem runat="server" Text="OPD Imaging" Value="OPD" />
                                </Items>
                             </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="grdTabHearder" runat="server" PageSize="15" Height="441px" ShowStatusBar="false"
                                AllowSorting="false" AllowPaging="false" EnableAJAX="true" AllowFilteringByColumn="false"  
                                OnNeedDataSource="grdTabHearder_NeedDataSource"
                                OnItemCommand="grdTabHearder_ItemCommand" 
                                OnSelectedIndexChanged="grdTabHearder_SelectedIndexChanged">
                                <ClientSettings EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                    <Scrolling AllowScroll="True" ScrollHeight="50px" UseStaticHeaders="true" />
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed"
                                    ClientDataKeyNames="GDEPT_ID" DataKeyNames="GDEPT_ID" ShowHeader="false">
                                    <Columns>
                                    <telerik:GridButtonColumn CommandName="delTabHeader" HeaderTooltip="delete Tab" ButtonType="ImageButton" HeaderStyle-BackColor="#4b6c9e"
                                        UniqueName="delTabHeader" ImageUrl="../../Resources/ICON/Actions-remove16.png">
                                        <HeaderStyle Width="25px" />
                                        <ItemStyle Width="16px" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn CommandName="editTabHeader" HeaderTooltip="edit Tab" ButtonType="ImageButton" UniqueName="editTabHeader" HeaderStyle-BackColor="#4b6c9e"
                                        ImageUrl="../../Resources/ICON/text_file.png">
                                        <HeaderStyle Width="25px" />
                                        <ItemStyle Width="16px" />
                                    </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="GDEPT_ID" HeaderText="GDEPT_ID" SortExpression="GDEPT_ID"
                                            UniqueName="colGDEPT_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%" Visible="false">
                                            <ItemStyle Wrap="true"  />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GDEPT_TEXT" HeaderText="Tab Hearder" SortExpression="GDEPT_TEXT" HeaderStyle-BackColor="#4b6c9e" HeaderStyle-ForeColor="White"
                                            UniqueName="colGDEPT_TEXT" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                            <HeaderStyle Width="110px" />
                                            <ItemStyle Wrap="true" Width="110px" />
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
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="grdExamGroup" runat="server" PageSize="15" Height="441px" ShowStatusBar="false"
                                AllowSorting="false" AllowPaging="false" EnableAJAX="true" AllowFilteringByColumn="false"  
                                OnNeedDataSource="grdExamGroup_NeedDataSource"
                                OnItemCommand="grdExamGroup_ItemCommand" 
                                OnSelectedIndexChanged="grdExamGroup_SelectedIndexChanged">
                                <ClientSettings EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                    <Scrolling AllowScroll="True" ScrollHeight="50px" UseStaticHeaders="true" />
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed"
                                    ClientDataKeyNames="GTYPE_ID" DataKeyNames="GTYPE_ID" ShowHeader="true">
                                    <Columns>
                                    <telerik:GridButtonColumn CommandName="delGroupExam" HeaderTooltip="delete Group Exam" ButtonType="ImageButton" HeaderStyle-BackColor="#4b6c9e"
                                        UniqueName="colDelGroupExam" ImageUrl="../../Resources/ICON/Actions-remove16.png">
                                        <HeaderStyle Width="25px" />
                                        <ItemStyle Width="16px" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn CommandName="editGroupExam" HeaderTooltip="edit Group Exam" ButtonType="ImageButton"  HeaderStyle-BackColor="#4b6c9e"
                                    UniqueName="colEditGroupExam" ImageUrl="../../Resources/ICON/text_file.png">
                                        <HeaderStyle Width="25px" />
                                        <ItemStyle Width="16px" />
                                    </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="GTYPE_ID" HeaderText="GTYPE_ID" SortExpression="GTYPE_ID"
                                            UniqueName="colGTYPE_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%" Visible="false">
                                            <ItemStyle Wrap="true"  />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GTYPE_TEXT" HeaderText="Group Exam" SortExpression="GTYPE_TEXT" HeaderStyle-BackColor="#4b6c9e" HeaderStyle-ForeColor="White"
                                            UniqueName="colGTYPE_TEXT" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                            <HeaderStyle Width="145px" />
                                            <ItemStyle Wrap="true" Width="140px" />
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
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="grdExam" runat="server" PageSize="15" Height="441px" ShowStatusBar="false"
                                AllowSorting="false" AllowPaging="false" EnableAJAX="true" AllowFilteringByColumn="false"  
                                OnNeedDataSource="grdExam_NeedDataSource"
                                OnItemCommand="grdExam_ItemCommand">
                                <ClientSettings EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                    <Scrolling AllowScroll="True" ScrollHeight="50px" UseStaticHeaders="true" />
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed"
                                    ClientDataKeyNames="GEXAM_ID" DataKeyNames="GEXAM_ID" ShowHeader="true">
                                    <Columns>
                                    <telerik:GridButtonColumn CommandName="delExam" HeaderTooltip="delete Exam" ButtonType="ImageButton" HeaderStyle-BackColor="#4b6c9e"
                                        UniqueName="colDelExam" ImageUrl="../../Resources/ICON/Actions-remove16.png">
                                        <HeaderStyle Width="25px" />
                                        <ItemStyle Width="16px" />
                                    </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="GEXAM_ID" HeaderText="GEXAM_ID" SortExpression="GEXAM_ID"
                                            UniqueName="colGEXAM_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%" Visible="false">
                                            <ItemStyle Wrap="true"  />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID" HeaderStyle-BackColor="#4b6c9e" HeaderStyle-ForeColor="White"
                                            UniqueName="colEXAM_UID" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Exam Name" SortExpression="EXAM_NAME" HeaderStyle-BackColor="#4b6c9e" HeaderStyle-ForeColor="White"
                                            UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
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
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
