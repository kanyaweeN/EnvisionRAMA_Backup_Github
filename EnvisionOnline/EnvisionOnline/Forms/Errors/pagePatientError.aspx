<%@ Page Language="C#" MasterPageFile="~/Forms/Errors/masterErrorpage.Master" AutoEventWireup="true" CodeBehind="pagePatientError.aspx.cs" Inherits="EnvisionOnline.Forms.Errors.pagePatientError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    แจ้งเตือน
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblShowErrorMessage" Font-Bold="true" Font-Size="X-Large" Font-Underline="True" ForeColor="#0066FF">
                    ไม่พบข้อมูลคนไข้ในระบบ กรุณาติดต่อ IT x-ray
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Underline="false" ForeColor="RosyBrown">
                    กรุณาจดข้อมูลด้านล่างนี้ให้ เจ้าหน้าที่ : 
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