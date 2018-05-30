<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="Administracion.empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSourceEmpleados" CellPadding="4" ForeColor="Black" 
        GridLines="Vertical" Width="898px" 
        DataKeyNames="idEmpleado" BackColor="White" 
        BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre Completo" 
                SortExpression="NOMBRE_COMPLETO" />
            <asp:BoundField DataField="USERNAME" HeaderText="Username" 
                SortExpression="USERNAME" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" 
                SortExpression="Estado" ReadOnly="True" />
            <asp:BoundField DataField="descripcion" HeaderText="Rol" 
                SortExpression="descripcion" />
            <asp:BoundField DataField="Sucursal" HeaderText="Clave Sucursal" 
                SortExpression="Sucursal" />
        <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
            <a href='modificar_usuario.aspx?idmrdxbdi=<%# Eval("idEmpleado") %>'>Modificar</a>
            </ItemTemplate> 
        </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#0f7d0f" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
            HorizontalAlign="Right" />
        <RowStyle BackColor="#EEF2F3" Font-Size="Smaller" />
        <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceEmpleados" runat="server" 
        ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>" 
        
        
        SelectCommand="SELECT Empleados.idEmpleado, Empleados.nombreEmpleado AS NOMBRE_COMPLETO, Empleados.userEmpleado AS USERNAME, CASE WHEN Empleados.status = 0 THEN 'Inactivo' WHEN Empleados.status = 1 THEN 'Activo' END AS 'Estado', Roles.descripcion, Sucursales.idSucursal, Sucursales.clave AS Sucursal FROM Empleados INNER JOIN Roles ON Empleados.id_Rol = Roles.idRol INNER JOIN Sucursales ON Empleados.id_Sucursal = Sucursales.idSucursal">
    </asp:SqlDataSource>
</asp:Content>
