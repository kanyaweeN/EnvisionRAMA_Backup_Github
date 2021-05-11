<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineClinicalIndicationPopup.aspx.cs" Inherits="OnlineClinicalIndicationPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Please fill clinical indication.</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body 
        {
        margin:1 1 1 1;
        font-family:MS Sans Serif;
        	}
        .labelText
        {
        	font-size:smaller;
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
	    function CancelEdit() {
	        GetRadWindow().close();
	    }
	    function set_AjaxRequest(arg) {
	        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
	    }
	    function OnClientClose() {
	    }
	    function setReturnPopup(args) {
	        //	        set_AjaxRequest(args);
	        GetRadWindow().close(); //Return and close all.
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

	    function Close() {
	        GetRadWindow().close();
	    }

	    function showNormalAlert(args, length) {
	        var parentPage = GetRadWindow().BrowserWindow;
	        var parentRadWindowManager = parentPage.GetRadWindowManager();
	        window.setTimeout(function () {
	            switch (args) {
	                case 'UID4043':
	                    parentRadWindowManager.open("../../Forms/Dialogs/OnlineMultiMessageBox.aspx?ALT_UID=" + args + "&CUSTOM=" + length, "windowMultiMessageBox");
	                    break;
	                case 'checkIndication':
	                    parentRadWindowManager.open("../../Forms/Dialogs/OnlineMultiMessageBox.aspx?ALT_UID=ONL4011&CUSTOM=" + length, "windowMultiMessageBox");
	                    break;
	                case 'checkRefDoc':
	                    parentRadWindowManager.open("../../Forms/Dialogs/OnlineMultiMessageBox.aspx?ALT_UID=ONL4010&CUSTOM=" + length, "windowMultiMessageBox");
	                    break;
	                case 'checkRefUnit':
	                    parentRadWindowManager.open("../../Forms/Dialogs/OnlineMultiMessageBox.aspx?ALT_UID=ONL4016&CUSTOM=" + length, "windowMultiMessageBox");
	                    break;
	            }
	        }, 0);
	    }
	    function chkMessageBox(args) {
	        set_AjaxRequest(args);
	    }
	    function setReturnPopup(args) {
	        set_AjaxRequest(args);
	    }
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowMultiMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" 
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
        <table width="100%" cellspacing="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblExam" runat="server" CssClass="labelText"  Text="XX103 : Chest AP (Upright)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPriority" runat="server" CssClass="labelText"  Text="Priority :"  ></asp:Label></td>
                <td><telerik:RadComboBox    ID="cmbPriority"            Width="65px" ExpandDelay="10" runat="server" BorderStyle="None" OnSelectedIndexChanged="cmbPriority_SelectedIndexChanged" AutoPostBack="True"></telerik:RadComboBox>
                    <asp:Label ID="Label5" runat="server" CssClass="labelText"  Text=" Side :"  ></asp:Label>
                    <telerik:RadComboBox    ID="cmbSide"                Width="65px" ExpandDelay="10" runat="server"   BorderStyle="None" OnSelectedIndexChanged="cmbSide_SelectedIndexChanged" AutoPostBack="True"></telerik:RadComboBox>
                    <telerik:RadButton      ID="chkPortable"            Text="Portable" Value="N"  runat="server" ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox" OnCheckedChanged="chkPortable_SelectedIndexChanged"></telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td style="width:30px">
                    <asp:Label ID="label4" runat="server"  CssClass="labelText" Text="Clinical Indication : " />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtEditor" runat="server" TextMode="MultiLine" Height="90px" Width="100%"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDataOrder" runat="server" CssClass="labelText" Text="วันที่ตรวจ :"></asp:Label>
                            </td>
                            <td align="right" colspan="2">
                                <telerik:RadDateTimePicker ID="datetimeChange" runat="server" PopupDirection="TopLeft" >
                                    <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy HH:mm" DisplayDateFormat="dd/MM/yyyy HH:mm">
                                    </DateInput>
                                </telerik:RadDateTimePicker>
                            </td>
                            <td valign="top" align="right">
                                <telerik:RadButton ID="btnUpdate" runat="server" Text="OK" Width="80px" OnClick="btn_Click"></telerik:RadButton>
                            </td>
                            <td valign="top" align="right">
                                <telerik:RadButton ID="btnCancle" runat="server" Text="Cancel" Width="80px" OnClick="btnCancle_Click"></telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                             <td align="right">
                                <asp:Label ID="lblEstimateTime" runat="server" CssClass="labelText" Text="ระบุวันตรวจล่วงหน้า :"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="labelText" Text="Week :"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoWeek1" ButtonType="ToggleButton" ToggleType="Radio"
                                            runat="server" Text="1" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                            Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoWeek2" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="2" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoWeek4" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="4" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoWeek6" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="6" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="labelText" Text="Month :"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoMonth3" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="3" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoMonth6" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="6" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoMonth9" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="9" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="labelText" Text="Year :"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoYear1" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="1" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="rdoYear2" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="2" GroupName="ChangeDate" OnCheckedChanged="rdoChangeDate_CheckedChanged"
                                                    Checked="false">
                                </telerik:RadButton>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="labelRefDoc" runat="server" Width="100px"  CssClass="labelText" Text="Ordering Doc : " />
                            </td>
                            <td>
                            <telerik:RadComboBox ID="cmbRefDoc" runat="server" Height="140px" Width="228px" MarkFirstMatch="true"
                                ShowMoreResultsBox="True" EnableLoadOnDemand="True" OnItemsRequested="cmbRefDoc_ItemsRequested"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="labelRefUnit" runat="server" Width="100px" CssClass="labelText" Text="Ordering Dept : " />
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbRefUnit" runat="server" Height="140px" Width="228px" MarkFirstMatch="true"
                                ShowMoreResultsBox="True" EnableLoadOnDemand="True" OnItemsRequested="cmbRefUnit_ItemsRequested"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
	</form>
</body>
</html>
