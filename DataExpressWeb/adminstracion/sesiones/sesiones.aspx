<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sesiones.aspx.cs" Inherits="Administracion.sesiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" DataKeyNames="idSesion" 
        BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" 
    BorderStyle="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" 
                SortExpression="descripcion" />
            <asp:BoundField DataField="conexiones_simultaneas" 
                HeaderText="Conexiones simultaneas" 
                SortExpression="conexiones_simultaneas" />
            <asp:BoundField DataField="duracion_sesion" HeaderText="Duracion sesión" 
                SortExpression="duracion_sesion" />
            <asp:BoundField DataField="intentos" HeaderText="Intentos" 
                SortExpression="intentos" />
            <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
            <a href='modificar_sesion.aspx?id=<%# Eval("idSesion") %>'>Modificar</a>
            </ItemTemplate> 
                        
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
             <ItemTemplate>
            <a href='eliminarSesion.aspx?id=<%# Eval("idSesion") %>' onclick="return confirm('Esta  seguro que desea eliminar?')" >Eliminar</a>
            </ItemTemplate> 
            
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#148FCA" Font-Bold="True" ForeColor="White" 
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>" 
        
        SelectCommand="SELECT [descripcion], [conexiones_simultaneas], [duracion_sesion], [intentos], [idSesion] FROM [Sesiones]">
    </asp:SqlDataSource>
</asp:Content>
