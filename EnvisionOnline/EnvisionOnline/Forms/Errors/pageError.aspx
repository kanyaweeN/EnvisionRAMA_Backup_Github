<%@ Page Language="C#" MasterPageFile="~/Forms/Errors/masterErrorpage.Master" AutoEventWireup="true" CodeBehind="pageError.aspx.cs" Inherits="EnvisionOnline.Forms.Errors.pageError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    แจ้งเตือน
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblShowErrorMessage" Font-Bold="true" Font-Size="X-Large" Font-Underline="True" ForeColor="#0066FF">
                    เกิดข้อผิดพลาดกับระบบ กรุณาติดต่อ IT x-ray
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtShowErrorMessage" runat="server" BorderStyle="None" Enabled="true" ReadOnly="true" TextMode="MultiLine" Width="100%" Height="300px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>

