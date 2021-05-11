<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineAlertPatientPhone.aspx.cs" Inherits="EnvisionOnline.Forms.Dialogs.OnlineAlertPatientPhone" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
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
        .target
        {
 	border:solid 2px #808080;
	width:320px;
	height:30px;
	padding:3px;
	background:#abddf6;
    font:italic bold 16px/30px Georgia, serif;
        	 }
        	 .nottarget
        	 {
        	 	font:italic 12px/20px;
        	 	}
        body
        {
        margin:0 0 0 0;
        font-family:MS Sans Serif;
        	}
    </style>
</head>
<body>
 
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
	    function PrintAndClose(url) {
	        window.open(url);
	        GetRadWindow().close();
	    }
	    function CancelEdit() {
	        GetRadWindow().close();
	    }

	    
    </script>
     
  

  <form id="form1" runat="server">
    <div class="Header">
        <asp:Label ID="lblHeader" runat="server" Text="ยืนยันหมายเลขโทรศัพท์สำหรับติดต่อผู้ป่วย"></asp:Label>
    </div>
    
    <div>
    
    <table width="100%" style="border-style: none; border-width: thin; padding: 0px; margin: 0px; border-spacing: 0px" align="center">
         <tr valign="top" class="nottarget">
            <td colspan="2">
                <asp:Label ID="lblPatient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr valign="top" class="nottarget">
            <td colspan="2">
                <asp:Label ID="lblPatient2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr valign="top" class="nottarget">
            <td>
            </td>
        </tr>
        <tr valign="top" class="target">
             <td>
                <asp:Label ID="label2" runat="server" Text="Phone1 : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr valign="top" class="target">
             <td>
                <asp:Label ID="label4" runat="server" Text="Phone2 : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone2" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr valign="top">
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnUpdate" runat="server" Text="Preview and Print" OnClick="btnUpdate_Click" />
           </td>
        </tr>
    </table>
        </div>
        </form>
   </body>
</html>
