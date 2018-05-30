<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_rol.aspx.cs" Inherits="Administracion.crear_rol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="2" cellpadding="0" cellspacing="0" width="900px" style="color:Black;background-color:White;border-color:#DEDFDE;border-width:1px;border-style:None;height:144px;width:913px;border-collapse:collapse;font-size: x-small">
		<tr align="center" style="color:White;background-color:#0f7d0f;font-weight:bold;">
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
        <td align="center">
            <asp:TextBox ID="tbRol" runat="server" Width="143px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbRol" ErrorMessage="Requiere nombre del rol" 
                ForeColor="Red">*</asp:RequiredFieldValidator>
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
    <tr style="background-color:#EEF2F3;">
        <td colspan="11">
            <asp:Button ID="BCrear" runat="server" Text="Crear" style="text-align: center; height: 26px;" 
                Width="68px" onclick="BCrear_Click1" />
&nbsp;&nbsp;
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                Font-Size="XX-Small" ForeColor="Red" Height="10px" />
            <br />
        </td>
        </tr>
</table>
</asp:Content>
