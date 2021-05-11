<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPreviewReport.aspx.cs" Inherits="frmPreviewReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
     <style type="text/css">
        body
        {
            background-color: #666666;
        }
        div .line
        {
            background-color: #FFFFFF;
            height: 1px;
            width: 100%;
        }
        div .header
        {
            color: #FFFFFF;
            font-size: 24px;
            font-weight: bold;
            font-family:Microsoft Sans Serif;
        }
        table .patient_info td
        {
            width: auto;
        }
        .label_text
        {
            color: #FFFFFF;
            font-family:Microsoft Sans Serif;
        }
        .label_value
        {
            color: #FFFFFF;
            font-family:Microsoft Sans Serif;
        }
    </style>
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
	<script language='JavaScript' type='text/JavaScript'>
	    var tenth = '';

	    function ninth() {
	        if (document.all) {
	            (tenth);
	            alert("Right Click Disable");
	            return false;
	        }
	    }

	    function twelfth(e) {
	        if (document.layers || (document.getElementById && !document.all)) {
	            if (e.which == 2 || e.which == 3) {
	                (tenth);
	                return false;
	            }
	        }
	    }
	    if (document.layers) {
	        document.captureEvents(Event.MOUSEDOWN);
	        document.onmousedown = twelfth;
	    } else {
	        document.onmouseup = twelfth;
	        document.oncontextmenu = ninth;
	    }
	    document.oncontextmenu = new Function('return false')
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<div>
        <div id="divHeader" runat="server" class="header">
            <label id="lblOrgNameValue" runat="server" />
        </div>
        <br />
        <div id="divPatientInfo" runat="server">
            <table class="patient_info">
                <tr>
                    <td>
                        <label id="lblPatientNameText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblPatientNameValue" runat="server" class="label_value" />
                    </td>
                    <td>
                        <label id="lblRefDocNameText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblRefDocNameValue" runat="server" class="label_value" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblHNText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblHNValue" runat="server" class="label_value" />
                    </td>
                    <td>
                        <label id="lblPatientDOBText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblPatientDOBValue" runat="server" class="label_value" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblPatientAgeAndGenderText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblPatientAgeAndGenderValue" runat="server" class="label_value" />
                    </td>
                    <td>
                        <label id="lblRefUnitNameText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblRefUnitNameValue" runat="server" class="label_value" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblExamNameText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblExamNameValue" runat="server" class="label_value" />
                    </td>
                    <td>
                        <label id="lblExamDateText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblExamDateValue" runat="server" class="label_value" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblAccessionNoText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblAccessionNoValue" runat="server" class="label_value" />
                    </td>
                    <td>
                        <label id="lblRequestNoText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblRequestNoValue" runat="server" class="label_value" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblResultStatusText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblResultStatusValue" runat="server" class="label_value" />
                    </td>
                    <td>
                        <label id="lblSeverityNameText" runat="server" class="label_text" />
                    </td>
                    <td>
                        <label id="lblSeverityNameValue" runat="server" class="label_value" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div id="divResult" runat="server" />
	</div>
	</form>
</body>
</html>
