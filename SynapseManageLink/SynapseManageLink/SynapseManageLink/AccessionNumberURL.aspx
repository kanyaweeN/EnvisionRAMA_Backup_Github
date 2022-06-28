<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessionNumberURL.aspx.cs" Inherits="SynapseManageLink.AccessionNumberURL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function openURLFunction(accno) {
            var popupWin = window.open("AccessionNOpacsurl.html?AccessionNo=" + accno, "name","",false);
            popupWin.focus();
        }
        function openURLFunctionHN(HN) {
            var popupWin = window.open("PatientIDpacsurl.html?PatientID=" + HN, "name");
            popupWin.focus();
        }
        var popupWin;
        function showNewWindows(args) {
            popupWin = window.open("http://localhost:9090?QueryMode=AN&Value=" + args, "name");
            popupWin.focus();
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<%--    <div>
        <asp:Label ID="Label1" runat="server" Text="Accession No :  "></asp:Label>
        <asp:TextBox ID="txt" runat="server" Text="123456789" Width="500px"></asp:TextBox>
        <asp:Button ID="btn" runat="server" Text="Go" OnClick="btn_click"/>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="HN :  "></asp:Label>
        <asp:TextBox ID="txtHN" runat="server" Text="123456789" Width="500px"></asp:TextBox>
        <asp:Button ID="btnHN" runat="server" Text="Go" OnClick="btnHN_click"/>
    </div>--%>
    </form>
</body>
</html>
