<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebPassParameter.aspx.cs" Inherits="ReportingPassParameter.WebForm1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 659px;
            width: 1238px;
        }
        .auto-style1 {
            width: 100%;
            height: 336px;
        }
        .auto-style2 {
            height: 31px;
        }
        .auto-style9 {
            height: 66px;
            width: 357px;
        }
        .auto-style10 {
            height: 31px;
            width: 357px;
        }
        .auto-style11 {
            width: 100%;
            height: 243px;
        }
        .auto-style12 {
            width: 88px;
            height: 22px;
        }
        .auto-style13 {
            width: 88px;
            height: 166px;
        }
        .auto-style14 {
            height: 66px;
        }
        .auto-style15 {
            width: 250px;
            height: 22px;
        }
        .auto-style16 {
            width: 250px;
            height: 166px;
        }
        .auto-style17 {
            width: 100%;
            height: 243px;
        }
        .auto-style18 {
            height: 24px;
        }
        .auto-style19 {
            height: 24px;
            width: 73px;
        }
        .auto-style20 {
            width: 73px;
        }
        .auto-style21 {
            height: 66px;
            width: 257px;
        }
        .auto-style22 {
            height: 31px;
            width: 257px;
        }
        
    </style>


</head>
<body style="height: 673px; width: 1250px;">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style21">
                    </td>
                <td class="auto-style9">
                    <asp:Panel ID="Panel1" runat="server" Direction="LeftToRight" Height="249px" ViewStateMode="Disabled" Width="352px">
                        <table class="auto-style11">
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="laStartDate" runat="server" Font-Bold="True" Font-Size="Smaller" Text="Start Date"></asp:Label>
                                    &nbsp;:</td>
                                <td class="auto-style15">
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="191px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageBtnStart" runat="server" Height="16px" ImageUrl="./Images/Calendar.ico" OnClick="ImageBtnStart_Click" style="margin-top: 0px" Width="16px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    &nbsp;</td>
                                <td class="auto-style16">
                                    <asp:Calendar ID="CalendarStart" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" OnSelectionChanged="CalendarStart_SelectionChanged" Visible="False" Width="199px">
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <OtherMonthDayStyle ForeColor="#808080" />
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                    </asp:Calendar>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="auto-style9">
                    <asp:Panel ID="Panel2" runat="server" Height="249px" Width="357px">
                        <table class="auto-style17">
                            <tr>
                                <td class="auto-style19">
                                    <asp:Label ID="laEndDate" runat="server" Font-Bold="True" Font-Size="Smaller" Text="End Date"></asp:Label>
                                    &nbsp;:</td>
                                <td class="auto-style18">
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="191px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageBtnEnd" runat="server" ImageUrl="./Images/Calendar.ico" OnClick="ImageBtnEnd_Click" Width="16px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td>
                                    <asp:Calendar ID="CalendarEndDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="CalendarEndDate_SelectionChanged" Visible="False" Width="200px">
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <OtherMonthDayStyle ForeColor="#808080" />
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                    </asp:Calendar>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style10">
                                <asp:DropDownCheckBoxes ID="ddchkModality" runat="server"                     
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="ddchkModality_SelectedIndexChanged">
                                     <Style SelectBoxWidth="160" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="80" />
                                     <Texts SelectBoxCaption="Select Modality" />
                                </asp:DropDownCheckBoxes>
                            </td>
                <td class="auto-style10">
                                 <asp:Label ID="lblModalityName" runat="server" Font-Size="Smaller"></asp:Label>
                            </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="btnRun" runat="server" Text="Run" Width="89px" />
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
    </form>

</body>

</html>
