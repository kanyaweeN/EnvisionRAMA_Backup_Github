<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Forms/Admin/masterAdmin.Master" AutoEventWireup="true"
    CodeBehind="frmManageExamOnline.aspx.cs" Inherits="frmManageExamOnline" %>

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
                    <telerik:AjaxUpdatedControl ControlID="lblExam" />
                    <telerik:AjaxUpdatedControl ControlID="chkCanRequestOnline" />
                    <telerik:AjaxUpdatedControl ControlID="chkNeedSchedule" />
                    <telerik:AjaxUpdatedControl ControlID="chkNeedApprove" />
                    <telerik:AjaxUpdatedControl ControlID="chkVisibleReq" />
                    <telerik:AjaxUpdatedControl ControlID="txtOnlineDisplay" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdDataExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblExam" />
                    <telerik:AjaxUpdatedControl ControlID="chkCanRequestOnline" />
                    <telerik:AjaxUpdatedControl ControlID="chkNeedSchedule" />
                    <telerik:AjaxUpdatedControl ControlID="chkNeedApprove" />
                    <telerik:AjaxUpdatedControl ControlID="chkVisibleReq" />
                    <telerik:AjaxUpdatedControl ControlID="txtOnlineDisplay" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0">
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
                            <telerik:GridButtonColumn CommandName="selectExam" ButtonType="ImageButton" UniqueName="colselectExam"
                                ImageUrl="../../Resources/ICON/text_file.png">
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
                <table border="0" cellpadding="10px" cellspacing="0" style="width:100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblExam" runat="server" Text="Exam : " ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="chkCanRequestOnline" Text="Can Request Online" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" TabIndex="1"></telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="chkNeedSchedule" Text="Exam Need Schedule" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" TabIndex="2"></telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="chkNeedApprove" Text="Exam Need Approve" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" TabIndex="3"></telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="chkVisibleReq" Text="Visible Exam in Online Request" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" TabIndex="4"></telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Text Display in Request Online
                            <telerik:RadTextBox ID="txtOnlineDisplay" runat="server" TextMode="SingleLine"  Width="100%"
                    EmptyMessage="Type Words Online Show" TabIndex="5" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="btnUpdate" runat="server" OnClick="update_Click"
                                Text="Update" GroupName="GroupName1">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Please Restart IIS 10.6.34.55 and 10.6.34.56 for update Exam Data.
            </td>
        </tr>
    </table>
</asp:Content>
