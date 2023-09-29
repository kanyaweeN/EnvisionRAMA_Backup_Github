<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPagePlainFilm.aspx.cs" Inherits="normalPagePlainFilm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server"  CdnSettings-TelerikCdn="Disabled"/>
    <style type="text/css">
        body
        {
            margin:0 0 0 0;
            font-family:MS Sans Serif;
        }
        .header
        {
            position: relative;
            margin: 1px;
            padding: 0px;
            background: #4b6c9e;
            color: #f9f9f9;
            font-weight:bold;
            width: 100%;
        }
        .tabBGHover
        {
        	background: #00CCFF;
        }
        .tabBG1
        {
        	background: #006633;
        }
        .underline
        {
        	 border-color:Green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="tabMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tabMain" />
                    <telerik:AjaxUpdatedControl ControlID="tabRoutine"/>
                    <telerik:AjaxUpdatedControl ControlID="tabHeadNeck"/>
                    <telerik:AjaxUpdatedControl ControlID="tabChestAbdomen"/>
                    <telerik:AjaxUpdatedControl ControlID="tabSpine"/>
                    <telerik:AjaxUpdatedControl ControlID="tabHipPelvis"/>
                    <telerik:AjaxUpdatedControl ControlID="tabShoulder"/>
                    <telerik:AjaxUpdatedControl ControlID="tabUpperEx"/>
                    <telerik:AjaxUpdatedControl ControlID="tabLowerEx"/>
                    <telerik:AjaxUpdatedControl ControlID="tabOtherBone"/>
                    <telerik:AjaxUpdatedControl ControlID="tabERTrauma"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="multipageMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="multipageMain"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
	    <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center" class="header" colspan="6">
                    <asp:Label ID="lblHeard" runat="server" Text="Plain Film"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <telerik:RadTabStrip ID="tabMain" runat="server" MultiPageID="multipageMain" Orientation="VerticalLeft" Width="135" Height="460" Skin="WebBlue" >
                        <Tabs>
                            <telerik:RadTab Value="tabRoutine"      Text="Routine Case"             SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover"  Selected="true"></telerik:RadTab>
                            <telerik:RadTab Value="tabHeadNeck"     Text="Head and Neck"            SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabChestAbdomen" Text="Chest and Abdomen"        SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabSpine"        Text="Spine"                    SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabHipPelvis"    Text="Hip and Pelvis"           SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabShoulder"     Text="Shoulder and Clavicle"    SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabUpperEx"      Text="Upper Extremity"          SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabLowerEx"      Text="Lower Extremity"          SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabOtherBone"    Text="Other Bone"               SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                            <telerik:RadTab Value="tabERTrauma"     Text="ER Trauma Series"         SelectedCssClass="tabBG1" HoveredCssClass="tabBGHover" ></telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                </td>
                <td colspan="5" valign="top">
                    <telerik:RadMultiPage ID="multipageMain" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="viewRutine"    Height="660" Width="935" runat="server" ContentUrl="normalPageCRRutineCase.aspx" Selected="true"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewHead"      Height="660" Width="935" runat="server" ContentUrl="normalPageCRHeadAndNeck.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewChest"     Height="660" Width="935" runat="server" ContentUrl="normalPageCRChestAndAbdomen.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewSpine"     Height="660" Width="935" runat="server" ContentUrl="normalPageCRSpine.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewHip"       Height="660" Width="935" runat="server" ContentUrl="normalPageCRHipAndPelvis.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewShoulder"  Height="660" Width="935" runat="server" ContentUrl="normalPageCRShoulderAndClavicle.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewUpperEx"   Height="660" Width="935" runat="server" ContentUrl="normalPageCRUpperExtremity.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewLowerrEx"  Height="660" Width="935" runat="server" ContentUrl="normalPageCRLowerExtremity.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewBone"      Height="660" Width="935" runat="server" ContentUrl="normalPageCRBone.aspx"></telerik:RadPageView>
                        <telerik:RadPageView ID="viewER"        Height="660" Width="935" runat="server" ContentUrl="normalPageCRERTraumaSeries.aspx"></telerik:RadPageView>
                    </telerik:RadMultiPage>
                </td>
            </tr>
        </table>
	</form>
</body>
</html>
