<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OnlineEditOrder.aspx.cs" Inherits="OnlineEditOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Detail</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
    <style type="text/css">
        .Header
        {
	        background:#0026ff;
	        color:white;
	        width:auto;
	        padding:10px;
	        border:solid 2px #00ffff;
	        margin: 0 0 0 0;
        }
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
	    function NormalWindow() {
	        window.close();
        }
	    function CancelEdit() {
	        GetRadWindow().close();
	    }

    </script>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function showAllNextAppoint() {
                var parentPage = GetRadWindow().BrowserWindow;
                var parentRadWindowManager = parentPage.GetRadWindowManager();
                window.setTimeout(function () {
                    parentRadWindowManager.open("../../Forms/Dialogs/frmAllNextAppointment.aspx", "windowAllNextAppoint");
                }, 0);
            }
            function refreshGrid(arg) {
                if (!arg) {
                    set_AjaxRequest("Rebind");
                }
                else if (arg == 'DeleteOrder') {
                    set_AjaxRequest("DeleteOrder");
                }
                else if (arg == 'refreshGrid') {
                    RefreshGridWorklist();
                }
                else if (arg == 'ClinicalPopup') {
                    RefreshGridWorklist();
                }
            }
            function OnClientClose() {
            }
        </script>
    </telerik:RadCodeBlock>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rdoDischarge">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoDischarge" />
                    <telerik:AjaxUpdatedControl ControlID="chkCNMI" />
                    <telerik:AjaxUpdatedControl ControlID="lblNextApp" />
                    <telerik:AjaxUpdatedControl ControlID="dtNextAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="btnNexAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="btnAllNextAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="dtNextAppoint">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dtNextAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="btnAllNextAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="chkCNMI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAllNextAppoint">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAllNextAppoint" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <div class="Header">
        <telerik:RadTextBox ID="lblHeader" runat="server" TextMode="MultiLine" Height="80px"
                    Width="99%" BorderStyle="None" BackColor="#0026FF" Font-Size="Large" ForeColor="White" ReadOnly="True" Enabled="true" EnabledStyle-ForeColor="White" DisabledStyle-ForeColor="White"></telerik:RadTextBox>
    </div>
	<table style="border-spacing: 0px" width="100%" align="center">
	    <tr>
	        <td>
	            <asp:Label ID="labelStudyDatetime" runat="server" Text="Request Date : " Width="120px"></asp:Label>
	        </td>
	        <td colspan="2">
                <telerik:RadDateTimePicker ID="dateRequest" runat="server">
                <DateInput runat="server" DateFormat="dd/MM/yyyy HH:mm" DisplayDateFormat="dd/MM/yyyy HH:mm"></DateInput>
                </telerik:RadDateTimePicker>
	        </td>
	    </tr> 
	    <tr>
	        <td>
	            <asp:Label ID="labelAssignTo" runat="server" Text="Radiologist : " Width="100px"></asp:Label>
	        </td>
	        <td>
	            <telerik:RadComboBox ID="cmbAssignTo" runat="server" Height="170px" Width="100%"
                ShowMoreResultsBox="True" EnableLoadOnDemand="True" AutoPostBack="true"
                OnItemsRequested="cmbAssignTo_ItemsRequested"
                OnSelectedIndexChanged="cmbAssignTo_SelectedIndexChanged" 
                />
	        </td>
	         <td>
	        </td>
	    </tr>
        <tr>
	        <td>
	        </td>
	        <td>
	            <telerik:RadButton ID="rdoDischarge" ButtonType="ToggleButton" ToggleType="CheckBox"
                                        runat="server" Text="Discharge (ให้ผู้ป่วยกลับบ้าน)" GroupName="ChangeDate" OnCheckedChanged="rdoDischarge_CheckedChanged"
                                        Checked="false"/>
	        </td>
	         <td>
	        </td>
	    </tr>
        <tr>
	        <td>
	        </td>
	        <td>
	            <telerik:RadButton ID="chkCNMI" ButtonType="ToggleButton" ToggleType="CheckBox"
                                        runat="server" Text="ขอส่งผู้ป่วยไปนัดตรวจที่ รพ.รามาธิบดีจักรีนฤบดินทร์" OnCheckedChanged="chkCNMI_CheckedChanged"
                                        Checked="false"/>
	        </td>
	         <td>
	        </td>
	    </tr>
        <tr>
	        <td>
	        </td>
	        <td>
	            <telerik:RadButton ID="chkCT3D" ButtonType="ToggleButton" ToggleType="CheckBox"
                                        runat="server" Text="CT 3D"
                                        Checked="false" 
                    oncheckedchanged="chkCt3d_CheckedChanged"/>
	        </td>
	         <td>
	        </td>
	    </tr>
        <tr>
	        <td>
	            <asp:Label ID="lblNextApp" runat="server" Text="Next Appoint : " Width="120px" Visible="false"></asp:Label>
	        </td>
	        <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadDateTimePicker ID="dtNextAppoint" runat="server" Visible="false" AutoPostBackControl="Both" OnSelectedDateChanged="dtNextAppoint_SelectedDateChanged">
                            <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy HH:mm" DisplayDateFormat="dd/MM/yyyy HH:mm"></DateInput>
                            </telerik:RadDateTimePicker>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnAllNextAppoint" runat="server" Text="..." Width="20px" Visible="false" OnClick="btnAllNextAppoint_Click"></telerik:RadButton>
                        </td>
                    </tr>
                </table>
	        </td>
            <td></td>
	    </tr>
	    <tr>
	        <td colspan="3">
	            <asp:Label ID="labelComment" runat="server" Text="Comment : "></asp:Label>
	        </td>
	    </tr>
        <tr>
            <td colspan="3">
	            <telerik:RadTextBox ID="txtEditor" runat="server" TextMode="MultiLine" Height="100px"
                    Width="99%">
                </telerik:RadTextBox>
	        </td>
        </tr>
	    <tr>
	        <td colspan="3">
                
	            <telerik:RadButton ID="btnUpdate" runat="server" Text="ยืนยันการบันทึกข้อมูล" Width="98%" AutoPostBack="true" OnClick="btn_Click"></telerik:RadButton>
                <telerik:RadButton ID="btnWaitingList" runat="server" Text="ยืนยันการนัดไปที่แผนกเอกซเรย์" Width="98%" AutoPostBack="true" OnClick="btnWaitingList_Click"></telerik:RadButton>
                <telerik:RadButton ID="btnBackSchedule" runat="server" Text="ย้อนกลับ เพื่อเลือกวันนัดใหม่" Width="98%" AutoPostBack="true" OnClick="btnBackSchedule_Click"></telerik:RadButton>
                <telerik:RadButton ID="btnStat" runat="server" Text="แจ้งขอส่งตรวจเร่งด่วน" Width="98%" AutoPostBack="true" OnClick="btnStat_Click"></telerik:RadButton>
	        </td>
	    </tr>
	</table>
	</form>
</body>
</html>
