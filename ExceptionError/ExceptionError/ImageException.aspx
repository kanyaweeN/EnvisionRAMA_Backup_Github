<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageException.aspx.cs" Inherits="ExceptionError.ImageException" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <link href="ErrorLogsStyle.css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 125px;
            margin-left: 0px;
            height: 20px;
            padding: 5px;
            text-align: left;
        }
        .style2
        {
            width: 400px;
            margin-left: 0px;
            height: 20px;
            padding: 5px;
            text-align: left;
        }
    </style>
</head>
<body style="height: 383px; margin-bottom: 14px; width: 1063px;">
    <form id="form1" runat="server">

    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>

    <table width="100%">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="styleTable">
                                <asp:Label ID="laUserId" runat="server" Text="User ID &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " 
                                    EnableViewState="False"></asp:Label>
                            </td>
                            <td class="styleTable">
                                <asp:Label ID="txtUserId" runat="server" Text="UserID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="styleTable">
                                <asp:Label ID="laHostAddress" runat="server" Text="Host Address &nbsp;: " ></asp:Label>
                             </td>
                            <td class="styleTableRight">
                                <asp:Label ID="txtHostAddress" runat="server" Text="HostAddress"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="styleTable" valign="top">
                                <asp:Label ID="laErrorMessage1" runat="server" Text="Error Message : "></asp:Label>
                        </td>
                            <td height="300" >
                                <telerik:RadTextBox ID="txtErrorMessage" Runat="server" 
                                    style="top: 0px; left: 0px" TextMode="MultiLine" Width="100%" 
                                    Height="300px" ReadOnly="True">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="styleTable">
                                <asp:Label ID="laErrorSource" runat="server" Text="Error Source &nbsp;&nbsp;: "></asp:Label>
                            </td>
                            <td class="styleTableRight">
                                <asp:Label ID="txtErrorSource" runat="server" Text="ErrorSource"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="laCreatedOn" runat="server" Text="Created On &nbsp;&nbsp;&nbsp;&nbsp;: "></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="txtCreatedOn" runat="server" Text="CreatedOn"></asp:Label>
                            </td>
                        </tr>
                        </table>
                    <table>
                        <tr>
                            <td width="200">
                                <asp:Label ID="laTroubleshootingGuide" runat="server" Text="Troubleshooting Guide : "></asp:Label>
                            </td>
                            <td class="styleTableRight" align="left">
                                <asp:Label ID="txtTroubleshootingGuide" runat="server" Text="TroubleshootingGuide"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="width: 532px; margin-left: 0px; height: 305px;" align="center">
                        <tr>
                            <td>
                                <asp:Image ID="errorImage" runat="server" Width="100%" Height="300px" ImageAlign="Middle" ImageUrl="  " />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
    </table>
    </form>
</body>
</html>
