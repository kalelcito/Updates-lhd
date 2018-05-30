<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="datosAdicionales.aspx.cs" Inherits="DataExpressWeb.datosAdicionales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="idFactura" DataSourceID="faltantes" Width="895px" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" Enabled=false runat="server" 
                        Text='<%# Bind("fecha") %>' Font-Size="Smaller" Height="16px" Width="102px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RFCEMI" SortExpression="RFCEMI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" Enabled=false runat="server" 
                        Text='<%# Bind("RFCEMI") %>' Font-Size="Smaller" Height="16px" Width="86px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("RFCEMI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Folio" SortExpression="folio">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" Enabled=false runat="server" 
                        Text='<%# Bind("folio") %>' Font-Size="Smaller" Height="16px" Width="65px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("folio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serie"  SortExpression="serie">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" Enabled=false runat="server" 
                        Text='<%# Bind("serie") %>' Font-Size="Smaller" Height="16px" Width="47px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("serie") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Condiciones de Pago" 
                SortExpression="condicionesDePago">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" 
                        Text='<%# Bind("condicionesDePago") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("condicionesDePago") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Orden" SortExpression="tipoOrden">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tipoOrden") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("tipoOrden") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Orden de Compra" SortExpression="ordenCompra">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2"  runat="server" Text='<%# Bind("ordenCompra") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ordenCompra") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No han llegado nuevas facturas.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#003151" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="faltantes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT GENERAL.idFactura, GENERAL.condicionesDePago, GENERAL.ordenCompra, GENERAL.tipoOrden, EMISOR.RFCEMI, GENERAL.serie, GENERAL.folio, CONVERT (varchar(30), CAST(GENERAL.fecha AS datetime), 126) AS fecha FROM GENERAL INNER JOIN EMISOR ON GENERAL.id_Emisor = EMISOR.IDEEMI WHERE (GENERAL.tipoOrden = '') OR (GENERAL.tipoOrden IS NULL) OR (GENERAL.ordenCompra = '') OR (GENERAL.ordenCompra IS NULL) OR (GENERAL.condicionesDePago = '') OR (GENERAL.condicionesDePago IS NULL) ORDER BY fecha" 
        
        
        UpdateCommand="UPDATE GENERAL SET condicionesDePago = @condicionesDePago, ordenCompra = @ordenCompra, tipoOrden = @tipoOrden WHERE (serie = @serie) AND (folio = @folio) AND (fecha = @fecha)">
        <UpdateParameters>
            <asp:Parameter Name="condicionesDePago" />
            <asp:Parameter Name="ordenCompra" />
            <asp:Parameter Name="tipoOrden" />
            <asp:Parameter Name="serie" />
            <asp:Parameter Name="folio" />
            <asp:Parameter Name="fecha" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
