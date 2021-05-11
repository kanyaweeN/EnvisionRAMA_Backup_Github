<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineNewEmployee.aspx.cs" Inherits="OnlineNewEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
        margin:0 0 0 0;
        font-family:MS Sans Serif;
        	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled">
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
	</telerik:RadAjaxManager>
	<div>
    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="label3" runat="server" Text="ไม่มีชื่อผู้ใช้งานในระบบ กรุณากรอก ชื่อ-สกุล(ภาษาไทย และ ภาษาอังกฤษ) เพื่อยืนยันการใช้งาน"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server" Text="ชื่อ : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td>
                <asp:Label ID="label2" runat="server" Text="Name : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFnameEng" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtLnameEng" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
