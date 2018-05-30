<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregar_usuario.aspx.cs" Inherits="Administracion.agregar_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 54%;
        }
        .style3
        {
            width: 124px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
        }
        .style2
        {
            width: 124px;
        }
        .style4
        {
            width: 124px;
            font-size: x-small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style5
    {
        width: 124px;
        font-size: x-small;
        font-family: Arial, Helvetica, sans-serif;
        height: 21px;
    }
    .style6
    {
        height: 21px;
    }
        .style7
        {
            width: 124px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
            height: 29px;
        }
        .style8
        {
            height: 29px;
        }
        .style9
        {
            color: #000000;
        }
        .style10
        {
            width: 124px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
            height: 28px;
        }
        .style11
        {
            height: 28px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style7">
            Tipo de Usuario: </td>
        <td class="style8">
            <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="0">-- Seleccionar Usuario --</asp:ListItem>
                <asp:ListItem Value="1">Empleado</asp:ListItem>
                <asp:ListItem Value="2">Proveedor</asp:ListItem>
            </asp:DropDownList>
        </td>

        <td rowspan='13' class="style2">RFC:
        
        <asp:SqlDataSource ID="SqlDataSourceModulo" runat="server" 
                ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
                SelectCommand="SELECT [RFC], [IDEMODULO] FROM [Modulos]" 
                onselecting="SqlDataSourceModulo_Selecting"></asp:SqlDataSource>
            <asp:ListBox ID="lbModulorfc" runat="server" DataSourceID="SqlDataSourceModulo" 
                DataTextField="RFC" DataValueField="IDEMODULO" Height="200px" 
                SelectionMode="Multiple" Width="250px" style="margin-top: 0px"></asp:ListBox>
            &nbsp;
           
            </td>

           
            

    </tr>
        <tr>
        <td class="style3">
            Nombre o Razón Social:</td>
        <td>
            <asp:TextBox ID="tbNombre" runat="server" Width="352px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="tbNombre" ErrorMessage="Requiere nombre" 
                ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
        </tr>
    <tr>
        <td class="style7">
            Nombre usuario:</td>
        <td class="style8">
            <asp:TextBox ID="tbUsername" runat="server" MaxLength="15" Width="170px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="tbUsername" ErrorMessage="Requiere username" ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style3">
            Contraseña:</td>
        <td>
            <asp:TextBox ID="tbContraseña" runat="server" TextMode="Password" Width="168px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="tbContraseña" ErrorMessage="Requiere contraseña" 
                ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style10">
            Repetir contraseña:</td>
        <td class="style11">
            <asp:TextBox ID="tbRepetir" runat="server" TextMode="Password" Width="168px" 
                Height="22px"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="tbContraseña" ControlToValidate="tbRepetir" 
                ErrorMessage="Contraseña no es igual" ForeColor="Red">*</asp:CompareValidator>
            <asp:TextBox ID="tbRFC" runat="server" Visible="false" 
                style="margin-bottom: 0px"></asp:TextBox>
        </td>
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
        <td class="style3"><center>
            Permisos de Validación:</center></td>
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
        <td class="style3">
            Status:</td>
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="1">---Activo---</asp:ListItem>
                <asp:ListItem Value="0">---Inactivo---</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style3">
            <asp:Label ID="lRol" runat="server" Text="Rol:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlRol" runat="server" DataSourceID="SqlDataSourceRol" 
                DataTextField="descripcion" DataValueField="idRol">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceRol" runat="server" 
                ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>" 
                SelectCommand="SELECT [idRol], [descripcion] FROM [Roles]">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="lSesion" runat="server" Text="Sesion" Visible="False" 
                CssClass="style9"></asp:Label>
        </td>
        <td class="style6">
            <asp:DropDownList ID="ddlSesion" runat="server" 
                DataSourceID="SqlDataSourceSesion" DataTextField="descripcion" 
                DataValueField="idSesion">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceSesion" runat="server" 
                ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>" 
                SelectCommand="SELECT [descripcion], [idSesion] FROM [Sesiones]">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="style4">
            <asp:Label ID="lSucursal" runat="server" Text="Sucursal:" CssClass="style9"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlSucursal" runat="server" 
                DataSourceID="SqlDataSourceSucursal" DataTextField="Sucursal" 
                DataValueField="idSucursal">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceSucursal" runat="server" 
                ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
                
                SelectCommand="SELECT idSucursal, sucursal + ':' + clave AS Sucursal FROM Sucursales">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="style4">
            <asp:Label ID="lEmail" runat="server" Text="Email:" Visible="False" 
                CssClass="style9"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server" Height="59px" Width="372px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:Button ID="bGuardar" runat="server" Text="Guardar" 
                onclick="btnGuardar_Click"  />
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:Label ID="lMsj" runat="server" ForeColor="Red"></asp:Label>
            <br />

        </td>
    </tr>
</table>
</asp:Content>