<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Autorizar2.aspx.cs" Inherits="DataExpressWeb.Autorizar2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <style type="text/css">
        #Text1
        {
            width: 189px;
            margin-top: 0px;
        }
        #Text2
        {
            width: 474px;
        }
        #Text3
        {
            width: 164px;
        }
        #Text5
        {
            width: 139px;
        }
        #Text6
        {
            width: 138px;
        }
        .style6
     {
         width: 353px;
     }
        .style7
     {
         height: 45px;
         width: 353px;
     }
        .style8
     {
         width: 873px;
     }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table>
<tr>
</td>
<td class="style8"><center><H2 style="color: #008000">FACTURAs POR PAGAR</H2></center></td>
</tr>
<tr><td class="style8"><asp:TextBox ID="tbRFC0" runat="server" ReadOnly="True" Width="535px" 
                    Visible="False"></asp:TextBox></tr>
</table>


    <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" CellPadding="4" 
    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
     Width="810px" style="margin-top: 0px" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns >
            <asp:ImageField DataImageUrlField="EDOFAC" 
                        DataImageUrlFormatString="~/Imagenes/{0}.png">
                <ControlStyle Height="35px" Width="35px" />
                <HeaderStyle Width="7%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ImageField>
            <asp:TemplateField HeaderText="RFCEMI" SortExpression="RFCEMI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("RFCEMI") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("RFCEMI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NOMEMI" SortExpression="NOMEMI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NOMEMI") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NOMEMI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SERIE" SortExpression="SERIE">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("SERIE") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("SERIE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FOLIO" SortExpression="FOLIO">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("FOLIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("FOLIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA DE EMISIÓN" SortExpression="FECHA">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA DE RECEPCIÓN" SortExpression="FECHA">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("fechaRec") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("fechaRec") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Subtotal" SortExpression="Subtotal">
                <EditItemTemplate>
                    <asp:TextBox ID="tbSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total" SortExpression="Total">
                <EditItemTemplate>
                    <asp:TextBox ID="tbTotal" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lTotal" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="XML">
                <ItemTemplate>
                    <a href='download.aspx?file=<%# Eval("XMLARC") %>'>
                    <img  src="imagenes/xml32x32.png" alt="xml" border="0" align="middle" 
                    height="22" width="22"></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PDF">
                <ItemTemplate>
                    <a href='download.aspx?file=<%# Eval("PDFARC") %>'>
                    <img  src="imagenes/pdf32x32.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Marcar">
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server"/>
                            <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("FOLIO")%>' />
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

            <asp:TemplateField HeaderText="ENVIAR" Visible="False">
                <ItemTemplate>
                    <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idFactura") %>')">
                    <img  src="imagenes/mail.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No existen datos.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#0f7d0f" Font-Bold="True" ForeColor="White" 
            Font-Size="X-Small" />
        <PagerStyle BackColor="#284775" ForeColor="White" 
            HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
        SelectCommand="PA_facturas_basico_rec" SelectCommandType="StoredProcedure" >
    <SelectParameters>
        <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
        <asp:SessionParameter DefaultValue="S--X" Name="SUCURSAL" 
            SessionField="sucursalUser" Type="String" />
        <asp:SessionParameter DefaultValue="R---" Name="RFC" SessionField="rfcCliente" 
            Type="String" />
        <asp:SessionParameter DefaultValue="false" Name="ROL" SessionField="coFactTodas" 
            Type="Boolean" />
        <asp:Parameter DefaultValue="" Name="MODULO" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
    
    
    <asp:Label ID="error" runat="server" BorderStyle="None" Height="16px" 
        ForeColor="Red"></asp:Label>

    <table style="width: 805px">
    <tr>
    <td>       
    <asp:Button ID="AT" runat="server" Text="AUTORIZAR" onclick="val1_Click" 
            style="margin-left: 0px" />    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="NA" runat="server" Text="NO AUTORIZAR" onclick="NA_Click" />
        </td>
    <td class="style6">
        <asp:Button ID="REGRESAR" runat="server" Height="26px" Text="REGRESAR" 
        Width="109px" onclick="REGRESAR_Click" /></td>
    </tr>
    <tr>
    <td class="style7">
        <asp:Label ID="adv" runat="server" Font-Bold="True" Font-Size="Large" 
            ForeColor="Red" Visible="False"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="S" runat="server" Font-Bold="True" ForeColor="#00CC00" 
            Text="SI" Visible="False" onclick="S_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="N" runat="server" Font-Bold="True" ForeColor="Red" Text="NO" 
            Visible="False" onclick="N_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        </td>
    </tr>
    </table>
    
</asp:Content>
