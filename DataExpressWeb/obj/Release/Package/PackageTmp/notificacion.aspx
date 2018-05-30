<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notificacion.aspx.cs" Inherits="DataExpressWeb.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style8
    {
        width: 1233px;
    }
    .style9
    {
        width: 891px;
    }
    .style10
    {
        height: 41px;
    }
    .style11
    {
        height: 41px;
        width: 50px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
<tr>
<td class="style9"></td>
<td class="style8">
<center>
    <asp:Panel ID="P1" runat="server" Height="145px" Width="469px" 
        BackColor="#00CC00" BorderColor="#E4B918" BorderStyle="Groove">
        <asp:Panel ID="hd" runat="server" BackColor="#D40511" Font-Bold="True" 
            ForeColor="White" Height="23px">
            ¡ CONFIRMACIÓN !</asp:Panel>
<table style="width: 466px; height: 65px">
<tr>
<td class="style11">
<center>
    <asp:Image ID="Im" runat="server" Height="60px" Width="61px" />
    </center>
    </td>
<td class="style10">
<center>
    <asp:Label ID="mso" runat="server" Font-Bold="True" Font-Size="12px" 
        Text="Label" Font-Names="Arial" ForeColor="Black"></asp:Label>
    </center>
    </td>
</tr>
</table>
        <br />
        <asp:Button ID="ok" runat="server" 
            BorderColor="#CC0000" BorderStyle="solid" Font-Bold="True" BackColor="#CC0000" Font-Names="Arial" ForeColor="White" 
            Font-Size="12px" Text="OK" onclick="ok_Click" />
    </asp:Panel>
    </center>
</td>
<td class="style6"></td>
</tr>
</table>
</asp:Content>
