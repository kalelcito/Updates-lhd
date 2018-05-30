<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="DataExpressWeb.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="479px" 
        DataKeyNames="idProveedor" AllowPaging="True" PageSize="15">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="idProveedor" HeaderText="idProveedor" 
                InsertVisible="False" ReadOnly="True" SortExpression="idProveedor" 
                Visible="False" />
            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razón Social" SortExpression="razonSocial">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("razonSocial") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("razonSocial") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nombre del Contacto" SortExpression="contacto">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("contacto") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("contacto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Teléfono" SortExpression="telefono">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("telefono") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Correo" SortExpression="correo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("correo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:CommandField ShowDeleteButton="true" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#003151" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#FFFFFF" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEF2F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [rfc], [idProveedor], [razonSocial], [contacto], [telefono], [correo] FROM [Proveedores]" 
        
    UpdateCommand="UPDATE Proveedores SET rfc= @rfc, razonSocial= @razonSocial WHERE (idProveedor= @idProveedor)"
    DeleteCommand="DELETE FROM Proveedores WHERE (idProveedor= @idProveedor)">
   

        <UpdateParameters>
            <asp:Parameter Name="rfc" />
            <asp:Parameter Name="razonSocial" />
            <asp:Parameter Name="contacto" />
            <asp:Parameter Name="telefono" />
            <asp:Parameter Name="correo" />
            <asp:Parameter Name="idProveedor" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
