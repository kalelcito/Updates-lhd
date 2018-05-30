<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="roles.aspx.cs" Inherits="Administracion.roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="idRol" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="Vertical" Height="144px" style="font-size: x-small" 
        Width="913px" BackColor="White" BorderColor="#DEDFDE" 
        BorderWidth="1px" BorderStyle="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="descripcion" HeaderText="Descripción" 
                SortExpression="descripcion" >
            </asp:BoundField>
            <asp:CheckBoxField DataField="crear_cliente" HeaderText="Crear Cliente" 
                SortExpression="crear_cliente" />
            <asp:CheckBoxField DataField="crear_admin_sucursal" 
                HeaderText="Crear Admin Sucursal" SortExpression="crear_admin_sucursal" />
            <asp:CheckBoxField DataField="consultar_facturas_propias" 
                HeaderText="Facturas Propias" 
                SortExpression="consultar_facturas_propias" />
            <asp:CheckBoxField DataField="consultar_todas_facturas" 
                HeaderText="Todas las Facturas" 
                SortExpression="consultar_todas_facturas" />
            <asp:CheckBoxField DataField="reportesSucursales" 
                HeaderText="Rep. Sucursales" 
                SortExpression="reportesSucursales" />
            <asp:CheckBoxField DataField="reportesGlobales" 
                HeaderText="Rep Globales" 
                SortExpression="reportesGlobales" />
            <asp:CheckBoxField DataField="modificarEmpleado" 
                HeaderText="Modificar Empleado" 
                SortExpression="modificarEmpleado" />
            <asp:CheckBoxField DataField="asignacion_roles" HeaderText="Roles" 
                SortExpression="asignacion_roles" />
            <asp:CheckBoxField DataField="envio_facturas_email" 
                HeaderText="Envio Facturas(mail)" SortExpression="envio_facturas_email" />
            <asp:CheckBoxField DataField="agregar_documento" HeaderText="Crear Factura" 
                SortExpression="agregar_documento" />
            <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
            <a href='modificar_roles.aspx?id=<%# Eval("idRol") %>'>Modificar</a>
            </ItemTemplate> 
         
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
             <ItemTemplate>
            <a href='eliminarRol.aspx?id=<%# Eval("idRol") %>' onclick="return confirm('Esta  seguro que desea eliminar?')" >Eliminar</a>
            </ItemTemplate> 
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#0f7d0f" Font-Bold="True" HorizontalAlign="Center" 
            ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
            HorizontalAlign="Right" />
        <RowStyle BackColor="#EEF2F3" />
        <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="PA_consulta_rol" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="1111" Name="idRol" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    </asp:Content>
