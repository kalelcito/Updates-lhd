<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_roles.aspx.cs" Inherits="Administracion.modificar_roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">



        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="2" cellpadding="0" cellspacing="0" width="900px">
    <tr>
        <td align="center">
                Descripción</td>
        <td align="center">
                Crear Cliente</td>
        <td align="center">
                Crear Admin Sucursal</td>
        <td align="center">
                Facturas Propias</td>
        <td align="center">
                Todas las Facturas</td>
        <td align="center">
                Rep. Sucursales</td>
        <td align="center">
                Rep Globales</td>
        <td align="center">
                Modificar Empleado</td>
        <td align="center">
                Roles</td>
        <td align="center">
                Envio Facturas(mail)</td>
        <td align="center">
                Crear Factura</td>
    </tr>
    <tr>
        <td >
            <asp:TextBox ID="tbRol" runat="server" Width="95px" Height="24px"></asp:TextBox>
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbCrear_cliente" runat="server" EnableViewState="true" 
                Checked='<%# Convert.ToBoolean(Eval("crear_admin_sucursal")) %>' />
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbCrear_admin" runat="server" />
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbConsulta_propias" runat="server" style="font-size: x-small" />
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbConsulta_todas" runat="server"  />
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbReportesSucursales" runat="server" />
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbReportesGlobales" runat="server" style="font-size: x-small" />
            
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbModificarEmpleado" runat="server" style="font-size: x-small" />
        </td>
        <td align="center" >
            
            <asp:CheckBox ID="cbAsignar_rol" runat="server" />
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbEnvio_fac" runat="server" style="font-size: x-small" />
           
        </td>
        <td align="center" >
            <asp:CheckBox ID="cbAgregar_doc" runat="server" style="font-size: x-small" />
        </td>
    </tr>
    <tr>
        <td colspan="11">
&nbsp;&nbsp;
            <br />
            <asp:Button ID="bModificar" runat="server" onclick="bModificar_Click" 
                Text="Modificar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="bCancelar" runat="server" onclick="bCancelar_Click" 
                Text="Cancelar" />
        </td>
    </tr>
</table>
</asp:Content>
