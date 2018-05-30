<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_usuario.aspx.cs" Inherits="Administracion.modificar_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 99px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
        }
        .style2
        {
            width: 99px;
        }
        .style4
        {
            height: 20px;
        }
        .style6
        {
            width: 399px;
        }
        .style13
    {
            width: 302px;
        }
        .style14
        {
            width: 118px;
        }
        .style15
        {
            height: 20px;
            font-size: x-small;
        }
        .style16
        {
            width: 463px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style6" colspan="3">
            &nbsp;</td>
    </tr>
        <tr>
        <td class="style3">
            Nombre completo:</td>
        <td class="style13">
            <asp:TextBox ID="tbNombre" runat="server" Width="228px"></asp:TextBox>
        </td>
        <td class="style14">
            &nbsp;</td>
        <td class="style16" style="text-align: left" rowspan="7">
            RFC:<br />
            <asp:ListBox ID="lbModulo" runat="server" DataSourceID="SqlDataSourceModulo2" 
                DataTextField="RFC" DataValueField="IDEMODULO" Height="221px" 
                SelectionMode="Multiple" Width="250px" style="margin-top: 5px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSourceModulo2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
                SelectCommand="SELECT [RFC], [IDEMODULO] FROM [Modulos]"></asp:SqlDataSource>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            Username:</td>
        <td class="style13">
            <asp:TextBox ID="tbUsername" runat="server" MaxLength="15" Width="170px"></asp:TextBox>
        </td>
        <td class="style14">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            Contraseña:</td>
        <td class="style13">
            <asp:TextBox ID="tbContraseña" runat="server" Width="168px"></asp:TextBox>
        </td>
        <td class="style14">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            Status:</td>
        <td class="style13">
            <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Value="1">Activo</asp:ListItem>
                <asp:ListItem Value="0">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="style14">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            Rol:</td>
        <td class="style13">
            <asp:DropDownList ID="ddlRol" runat="server" DataSourceID="SqlDataSource2" 
                DataTextField="descripcion" DataValueField="idRol">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
                SelectCommand="SELECT * FROM [Roles]"></asp:SqlDataSource>
            </td>
        <td class="style14">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style13">
            <asp:DropDownList ID="ddlSesion" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="descripcion" DataValueField="idSesion" Visible="False">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
                SelectCommand="SELECT * FROM [Sesiones]"></asp:SqlDataSource>
            </td>
        <td class="style14">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            Sucursal:</td>
        <td class="style13">
            <asp:DropDownList ID="ddlSucursal" runat="server" DataSourceID="SqlDataSource3" 
                DataTextField="Sucursal" DataValueField="idSucursal">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
                
                SelectCommand="SELECT idSucursal, sucursal + ':' + clave AS Sucursal FROM Sucursales"></asp:SqlDataSource>
            </td>
        <td class="style14">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style3">
            Permiso:</td>
        <td>
            <asp:DropDownList ID="permisoList" runat="server">
            <asp:ListItem Value="0">Ambos</asp:ListItem>
            <asp:ListItem Value="1">Proveedor</asp:ListItem>
                <asp:ListItem Value="2">Distribuidor</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td class="style3">
            Permisos de Validación:</td>
        <td>
            <asp:DropDownList ID="dllVal" runat="server">
            <asp:ListItem Value="0">Ninguno</asp:ListItem>
            <asp:ListItem Value="1">Nivel 1</asp:ListItem>
            <asp:ListItem Value="2">Nivel 2</asp:ListItem>
            <asp:ListItem Value="3">Ambos</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
        <tr>
        <td class="style4">
            &nbsp;</td>
        <td class="style13">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style16" style="text-align: left" rowspan="7">
        </td>
        </tr>
        <tr>
        <td class="style15">
            </td>
        <td colspan="3" class="style4">
            <asp:Button ID="bModificar" runat="server" Text="Modificar" 
                style="height: 26px" onclick="bModificar_Click1" />
            <asp:Button ID="bCancelar" runat="server" onclick="bCancelar_Click" 
                Text="Cancelar" />
        </td>
        </tr>
        <tr>
        <td class="style4">
            &nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
        </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style6" colspan="3">
            &nbsp;</td>
    </tr>
        <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style6" colspan="3">
            &nbsp;</td>
        </tr>
        </table>


</asp:Content>
