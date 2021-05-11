<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="EnvisionOnline.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Logout EnvisionOnline</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
    <script language="javascript">
 function closeWindow(){
 window.opener = null
 window.close();
 }
</script>
</head>
<body style="margin:100 0 0 0;">
    <form id="form1" runat="server">
    <div align="center">
    <table width="100%">
        <tr>
        <td>
        <asp:Image ID="img" runat="server" ImageUrl="~/Resources/ICON/logout-icon300.png" />
        </td>
        </tr>
        <tr>
            <td>
        <asp:Label ID="label" runat="server" Text="Logout"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
