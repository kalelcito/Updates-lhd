<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sucursales.aspx.cs" Inherits="Administracion.sucursales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataKeyNames="idSucursal" DataSourceID="SqlDataSource1" 
    ForeColor="Black" GridLines="Vertical" Width="588px" 
        BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" 
    BorderStyle="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="clave" HeaderText="Clave" />
        <asp:BoundField DataField="sucursal" HeaderText="Sucursal" 
            SortExpression="sucursal" />
        <asp:BoundField DataField="domicilio" HeaderText="Domicilio" 
            SortExpression="domicilio" />
        <asp:TemplateField HeaderText="Modificar">
           <ItemTemplate>
            <a href='modificarSucursal.aspx?id=<%# Eval("idSucursal") %>'>Modificar</a>
            </ItemTemplate> 
        
        </asp:TemplateField>

    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#0f7d0f" Font-Bold="False" ForeColor="White" 
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
    ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
    SelectCommand="SELECT * FROM [Sucursales]"></asp:SqlDataSource>
</asp:Content>
