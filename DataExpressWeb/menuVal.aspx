<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menuVal.aspx.cs" Inherits="DataExpressWeb.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            width: 325px;
        }
        .style7
        {
        width: 236px;
    }
        .style8
        {
            width: 1800px;
            height: 600px;
        }
        .style9
        {
            width: 325px;
            height: 35px;
        }
        .style10
        {
            width: 236px;
            height: 35px;
        }
        .style11
        {
            height: 35px;
        }
    .style12
    {
        height: 41px;
    }
    .style13
    {
        width: 236px;
        height: 41px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 728px; height: 106px" frame="above">
<tr>
<td class="style6"></td>
<td class="style7"></td>
</tr>
<tr>
<td class="style9">
<h2 style="color: #008000">FACTURAS POR VALIDAR</h2>
    </td>
<td class="style10">
    <asp:Button ID="Button2" runat="server" Text="ACCEDER" 
        onclick="Button2_Click" Font-Bold="True" Font-Size="Small" 
        ForeColor="Black" BackColor="#FFCC66" Width="201px" />

    </td>

    <td class="style11">
        &nbsp;</td>
</tr>
<tr>
<td class="style12">    <h2 style="color: #008000">FACTURAS POR PAGAR</h2></td>
<td class="style13">
    <asp:Button ID="Button3" runat="server" Text="ACCEDER" 
        onclick="Button3_Click" Font-Bold="True" ForeColor="Black" 
        BackColor="#FFFF99" Width="201px" /></td>
</tr>
<tr>
<td class="style6">
    <br />
    <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="REGRESAR" 
        onclick="Button1_Click" />
    </td>
    <td class="style7">
        <img class="style8" src="imagenes/hl.png" style="width:222px; height: 86px"/></td>
    <td>&nbsp;</td>
    </tr>

</table>
</asp:Content>
