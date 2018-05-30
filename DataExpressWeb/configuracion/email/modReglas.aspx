<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modReglas.aspx.cs" Inherits="DataExpressWeb.modReglas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 160px;
            height: 26px;
        }
        .style3
        {
            height: 26px;
        }
        .style5
        {
            text-align: left;
        }
    .style7
    {
        width: 160px;
        height: 5px;
    }
    .style8
    {
        height: 5px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <div class="style5">
            <strong><center>Reglas de Distribución Email<br />
            </center></strong></div>
        <table align="center" style="width: 62%;">
            <tr>
                <td class="style2">
                    Nombre:</td>
                <td class="style3">
                    <asp:TextBox ID="tbNombre" runat="server" Width="306px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    RFC:
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbRFC" runat="server" Width="305px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Estado</td>
                <td class="style8">
                    <asp:DropDownList ID="ddlEstado" runat="server" Height="20px" Width="126px">
                        <asp:ListItem Value="1">Activa</asp:ListItem>
                        <asp:ListItem Value="0">Inactiva</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Emails:<br />
                    <asp:TextBox ID="tbEmail" runat="server" Height="69px" Width="558px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"><center>
                    <asp:Button ID="bActualizar" runat="server" style="text-align: center" 
                        Text="Actualizar Regla" onclick="bActualizar_Click" />
                        </center>
                </td>
            </tr>
        </table>
        <asp:Label ID="lMensaje" runat="server" ForeColor="#CC3300"></asp:Label>
        <br />
        
    </p>
</asp:Content>
