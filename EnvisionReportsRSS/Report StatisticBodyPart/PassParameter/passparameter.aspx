<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="passparameter.aspx.cs" Inherits="PassParameter.passparameter" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 547px;
        }
        .auto-style4 {
            width: 9px;
        }
        .auto-style5 {
            width: 547px;
            height: 31px;
        }
        .auto-style7 {
            width: 9px;
            height: 31px;
        }
        .auto-style8 {
            height: 31px;
        }
        .auto-style9 {
            width: 160px;
            height: 31px;
        }
        .auto-style10 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5" style="font-family: AngsanaUPC; text-align: right;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" style="font-size: medium" Text="Date :"></asp:Label>
                </td>
                <td class="auto-style9" style="font-family: AngsanaUPC">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td class="auto-style7" style="font-family: AngsanaUPC; text-align: center;">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="-"></asp:Label>
                </td>
                <td class="auto-style9" style="font-family: AngsanaUPC">
                    <asp:TextBox ID="txtEndDate" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td class="auto-style8" style="font-family: AngsanaUPC"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style10" colspan="3">
                    <asp:DropDownCheckBoxes ID="ddchkModality" runat="server"                     
                            AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" 
                            CssClass="FreeTextFilterSelection" DataTextField="Text"
                          style="top: 0px; left: 0px; height: 22px; width: 232px;" OnSelectedIndexChanged="ddchkModality_SelectedIndexChanged">
                                     <Style SelectBoxWidth="323" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="80"  />
                                     <Texts SelectBoxCaption="Select Data"/>
                    </asp:DropDownCheckBoxes></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style10" colspan="3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
