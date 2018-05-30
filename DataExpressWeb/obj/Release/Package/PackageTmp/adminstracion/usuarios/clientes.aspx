<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="Administracion.clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSourceEmpleados" CellPadding="4" ForeColor="Black" 
        GridLines="Vertical" Width="611px" 
        DataKeyNames="idCliente" BackColor="White" 
        BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None" 
    Height="77px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre o Razón Social" 
                SortExpression="NOMBRE_COMPLETO" />
            <asp:BoundField DataField="USERNAME" HeaderText="Usuario" 
                SortExpression="USERNAME" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" 
                SortExpression="Estado" ReadOnly="True" />
            <asp:BoundField DataField="descripcion" HeaderText="Rol" 
                SortExpression="descripcion" />
        <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
            <a href='modificar_usuario.aspx?idmbdi=<%# Eval("idCliente") %>'>Modificar</a>
            </ItemTemplate> 
        </asp:TemplateField>
              
        </Columns>
        <EmptyDataTemplate>
            No existen registros disponibles.
        </EmptyDataTemplate>
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
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        
        SelectCommand="SELECT Clientes.idCliente, Clientes.nombreCliente AS NOMBRE_COMPLETO, Clientes.userCliente AS USERNAME, CASE WHEN Clientes.status = 0 THEN 'Inactivo' WHEN Clientes.status = 1 THEN 'Activo' END AS 'Estado',Roles.descripcion FROM Clientes INNER JOIN Roles ON Clientes.id_Rol = Roles.idRol">
    </asp:SqlDataSource>
</asp:Content>
