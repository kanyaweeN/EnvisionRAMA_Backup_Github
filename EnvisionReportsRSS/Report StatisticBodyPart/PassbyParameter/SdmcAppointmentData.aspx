<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SdmcAppointmentData.aspx.cs" Inherits="PassbyParameter.SdmcAppointmentData" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <style type="text/css">
        .row {
            height: 493px;
            width: 1530px;
        }
        .auto-style15 {
            width: 100%;
        }
        .auto-style22 {
            width: 10%;
            height: 29px;
        }
        .auto-style23 {
            width: 11%;
            height: 29px;
        }

        .auto-style25 {
            width: 586px;
            height: 29px;
        }
        .auto-style26 {
            height: 29px;
        }

        .auto-style27 {
            height: 29px;
            width: 1%;
        }
        .auto-style28 {
            width: 586px;
            height: 27px;
        }
        .auto-style29 {
            height: 27px;
        }

        #Select1 {
            width: 211px;
            margin-left: 0px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row"> 
            <table class="auto-style15" >
                <tr>
                    <td style="text-align:right" colspan="5"></td>
                </tr>
                <tr>
                    <td class="auto-style25" style="text-align:right; font-size: Medium;" >Date :&nbsp;&nbsp; </td>
                    <td class="auto-style22"> 
                        <asp:TextBox ID="txtStartDate" runat="server" type="date" Width="100%" Height="100%"  Font-Size="Medium"></asp:TextBox> 

                    </td>
                    <td class="auto-style27" style="text-align:center; " >-</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtEndDate" runat="server" type="date" Width="100%" Height="100%" Font-Size="Medium"></asp:TextBox>
                    </td>
                    <td class="auto-style26"></td>
                </tr>
                <tr>
                    <td class="auto-style28" style="font-size: Medium; text-align: right;">Room :&nbsp;&nbsp; </td>
                    <td class="auto-style29" colspan="3" style="font-size: medium">
                        <asp:DropDownCheckBoxes ID="drpRoom" runat="server"                     
                            AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True"
                            style="top: 0px; left: 0px; height: 22px; width: 232px; height: 20px; " OnSelectedIndexChanged="drpRoom_SelectedIndexChanged" >
                                <Style SelectBoxWidth="100%" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="100"   />
                                <Texts SelectBoxCaption="Select Data"/>
                        </asp:DropDownCheckBoxes></td>
                    <td style="font-size: medium" class="auto-style29"></td>
                </tr>
                 <tr>
                    <td class="auto-style28" style="font-size: Medium; text-align: right;">Session :&nbsp;&nbsp; </td>
                    <td class="auto-style29" colspan="3" style="font-size: medium">
                        <asp:DropDownCheckBoxes ID="drpSession" runat="server"                     
                            AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True"
                            style="top: 0px; left: 0px; height: 22px; width: 232px; height: 20px; " OnSelectedIndexChanged="drpSession_SelectedIndexChanged" >
                                <Style SelectBoxWidth="100%" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="100"   />
                                <Texts SelectBoxCaption="Select Data"/>
                        </asp:DropDownCheckBoxes></td>
                    <td style="font-size: medium" class="auto-style29"></td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td class="auto-style26" colspan="3" style="text-align:right">
                        <asp:Button ID="btnRun" runat="server" Text="Run Report" Width="94px" font-size ="Medium" OnClick="btnRun_Click"  />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRun0" runat="server" Text="Cancel" Width="94px" font-size ="Medium"  />
                    </td>
                    <td class="auto-style26">
                    </td>
                </tr>
            </table>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

        </div>
    </form>

</body>
</html>

