<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_sesion.aspx.cs" Inherits="Administracion.modificar_sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style2
        {
            width: 177px;
            font-size: x-small;
        }
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 177px;
            font-size: small;
        }
        .style4
        {
            width: 177px;
            font-size: small;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="style3">
                Descripción</td>
            <td>
                <asp:TextBox ID="tbDescripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Conexiones simultaneas</td>
            <td>
                <asp:DropDownList ID="ddlConexiones" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Duración&nbsp; de sesión</td>
            <td>
                <asp:DropDownList ID="ddlDuracion" runat="server">
                    <asp:ListItem Value="00:30">00:30</asp:ListItem>
                    <asp:ListItem Value="01:00">01:00</asp:ListItem>
                    <asp:ListItem Value="02:00">02:00</asp:ListItem>
                    <asp:ListItem Value="02:30">02:30</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Intentos</td>
            <td>
                <asp:DropDownList ID="ddlIntentos" runat="server" DataTextField="intentos">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="bModificarsesion" runat="server" 
                    onclick="bModificarsesion_Click" Text="Modificar" />
                <asp:Button ID="bCancelar" runat="server" onclick="bCancelar_Click" 
                    Text="Cancelar" />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
