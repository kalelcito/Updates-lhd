<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reglas.aspx.cs" Inherits="DataExpressWeb.distribucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="idEmailRegla" DataSourceID="reglasDataSource" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="479px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="nombreRegla" HeaderText="Nombre Regla" 
                SortExpression="nombreRegla" />
            <asp:CheckBoxField DataField="estadoRegla" HeaderText="Estado" 
                SortExpression="estadoRegla" />
            <asp:TemplateField HeaderText="Eliminar">
             <ItemTemplate>
            <a href='modReglas.aspx?regladi=<%# Eval("idEmailRegla") %>'" >Modificar</a>
            </ItemTemplate> 
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#003151" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEF2F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="reglasDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT * FROM [EmailsReglas]"></asp:SqlDataSource>
</asp:Content>
