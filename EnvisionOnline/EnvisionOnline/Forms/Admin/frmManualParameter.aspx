<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Forms/Admin/masterAdmin.Master" AutoEventWireup="true"
    CodeBehind="frmManualParameter.aspx.cs" Inherits="frmManualParameter" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../CSS/adminStyle.css" rel="stylesheet" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<div>
    <table align="center" style="border-spacing: 0px;" width="100%">
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblUser" runat="server" Text="Username : " CssClass="labelText"></asp:Label>
                        </td>
	                    <td>
                           <asp:TextBox ID="txtUser" runat="server" Width="150px"></asp:TextBox>
	                    </td>
                        <td align="right">
                            <asp:Label ID="lblPassword" runat="server" Text="Password : " CssClass="labelText"></asp:Label>
                        </td>
	                    <td>
                           <asp:TextBox ID="txtPass" runat="server" Width="150px"></asp:TextBox>
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
                    <asp:Label ID="Label4" runat="server" Text="Form : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadComboBox ID="cmbForm" runat="server" Height="80px" Width="150px">
                        <Items>
                            <telerik:RadComboBoxItem Text="O1" />
                            <telerik:RadComboBoxItem Text="O2" />
                            <telerik:RadComboBoxItem Text="R1" />
                            <telerik:RadComboBoxItem Text="R2" />
                            <telerik:RadComboBoxItem Text="W" />
                            <telerik:RadComboBoxItem Text="A1" />
                        </Items>
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
                    <asp:Label ID="Label6" runat="server" Text="Authen : " CssClass="labelText"></asp:Label>
                </td>
	            <td>
                    <telerik:RadComboBox ID="cmbAuthen" runat="server" Height="80px" Width="150px" AutoPostBack="false">
                        <Items>
                            <telerik:RadComboBoxItem Text="Resident"/>
                            <telerik:RadComboBoxItem Text="Staff"/>
                            <telerik:RadComboBoxItem Text="Extern"/>
                            <telerik:RadComboBoxItem Text="Other"/>
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
                    <asp:Label ID="txtAlert" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </td>
            </tr>
	    </table>
	</div>
</asp:Content>