<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlinePopupDatetime.aspx.cs" Inherits="OnlinePopupDatetime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Modify Order Datetime</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            margin:5 5 5 5;
        }
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

	    function CancelEdit() {
	        GetRadWindow().close();
	    }
    </script>

	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="numericValue">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbMode" />
                    <telerik:AjaxUpdatedControl ControlID="datetimeChange" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbMode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="numericValue" />
                    <telerik:AjaxUpdatedControl ControlID="datetimeChange" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="datetimeChange">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="datetimeChange"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <table class="style1">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblEstimateTime" runat="server" CssClass="labelText" Text="ระบุวันตรวจล่วงหน้า :"></asp:Label>
            </td>
        </tr>
        <tr>
                <td></td>
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
            <td></td>
        </tr>
    </table>
	    <table class="style1">
            <tr>
                <td colspan="3">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table style="border-style: none; " width="200" border="0" cellspacing="0">
                        <tr>
                            <td>
                                <telerik:RadNumericTextBox ID="numericValue" runat="server" Type="Number" 
                                Label="Next date value : " LabelWidth="100"  Width="150"
                                NumberFormat-DecimalDigits="0" MaxValue="300" MinValue="0" MaxLength="300"
                                OnTextChanged="numericValue_TextChanged" AutoPostBack="true">
                            </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbMode" runat="server" RenderingMode="Full" AllowCustomText="false" Width="100px"
                                 OnSelectedIndexChanged="cmbMode_SelectedIndexChanged" AutoPostBack="true">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Weeks" />
                                        <telerik:RadComboBoxItem Text="Months" />
                                        <telerik:RadComboBoxItem Text="Years" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <telerik:RadDateTimePicker ID="datetimeChange" runat="server" PopupDirection="TopLeft" >
                        <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy HH:mm" DisplayDateFormat="dd/MM/yyyy HH:mm">
                        </DateInput>
                    </telerik:RadDateTimePicker>
                </td>
                <td>
                    <telerik:RadButton ID="btnUpdate" runat="server" Text="Update" OnClick="btn_Click"></telerik:RadButton>
                </td>
            </tr>
        </table>
	</form>
</body>
</html>
