<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmManualParamterWinForm.aspx.cs" Inherits="frmManualParamterWinForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <link href="../../CSS/adminStyle.css" rel="stylesheet" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled">
		<Scripts>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
		//Put your JavaScript code here.
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<div>
    <table align="center" style="border-spacing: 0px;" width="100%">
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblUser" runat="server" Text="Username : " CssClass="labelText" Enabled="false"></asp:Label>
                        </td>
	                    <td>
                           <asp:TextBox ID="txtUser" runat="server" Width="150px" Enabled="false"></asp:TextBox>
	                    </td>
                        <td align="right">
                            <asp:Label ID="lblPassword" runat="server" Text="Password : " CssClass="labelText" Enabled="false"></asp:Label>
                        </td>
	                    <td>
                           <asp:TextBox ID="txtPass" runat="server" Width="150px" Enabled="false"></asp:TextBox>
	                    </td>
                        </tr>
                    </table>
                </td>
	        </tr>
	        <tr>
	            <td colspan="2" width="100%" align="center">
                    <asp:Label ID="labelDesc" runat="server" Text="Mandatory Parameter" Font-Bold="true" Font-Italic="true" Font-Size="Smaller"></asp:Label>
	            </td>
	        </tr>
	        <tr>
                <td align="right">
                    <asp:Label ID="lblHN" runat="server" Text="HN : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadTextBox ID="txtHN" runat="server" Width="150px"></telerik:RadTextBox>
	            </td>
	        </tr>
	        <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Ordering Department : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadComboBox ID="cmbRefUnit" runat="server"
                    Height="170px" Width="150px"
                    ShowMoreResultsBox="True" EnableLoadOnDemand="True" 
                    OnItemsRequested="cmbRefUnit_ItemsRequested"/>
	            </td>
	        </tr>
	        <tr>
                <td align="right">
                    <asp:Label ID="lblClinicType" runat="server" Text="Clinic Type : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadComboBox ID="cmbClinicType" runat="server" Height="100px" Width="150px" AutoPostBack="false">
                         <Items>
                            <telerik:RadComboBoxItem Text="Premium" />
                            <telerik:RadComboBoxItem Text="Special" />
                            <telerik:RadComboBoxItem Text="Regular" />
                        </Items>
                    </telerik:RadComboBox>
	            </td>
	        </tr>
            <tr>
	            
	            <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Insurance Type : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadComboBox ID="cmbInsuraceType" runat="server" Height="140px" Width="150px" AutoPostBack="false">
                    </telerik:RadComboBox>
	            </td>
	        </tr>
	         <tr>
	            <td align="right">
                    <asp:Label ID="Label5" runat="server" Text="Encounter Type : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadComboBox ID="cmbEncounter" runat="server" Height="100px" Width="150px" AutoPostBack="false">
                        <Items>
                            <telerik:RadComboBoxItem Text="AMB = OPD Encounter" />
                            <telerik:RadComboBoxItem Text="EMER = ER Encounter" />
                            <telerik:RadComboBoxItem Text="IMP = IPD Encounter" />
                            <telerik:RadComboBoxItem Text="SS = Short Stay Encounter" />
                            <telerik:RadComboBoxItem Text="OTH = OTHER Encounter(not use)" />
                        </Items>
                    </telerik:RadComboBox>
	            </td>
	        </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="CT/MR : " CssClass="labelText"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkCTMR" runat="server" OnCheckedChanged="chekbox_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </td>
            </tr>
	    </table>
	</div>
	</form>
</body>
</html>
