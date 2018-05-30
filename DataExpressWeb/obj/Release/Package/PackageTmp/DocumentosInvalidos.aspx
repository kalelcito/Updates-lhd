<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentosInvalidos.aspx.cs" Inherits="DataExpressWeb.DocumentosInvalidos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #Text1
        {
            width: 189px;
            margin-top: 0px;
        }
        .style1
        {            text-align: left;
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
        .style2
        {
            width: 241px;
        }
        .style3
        {
        }
        .style6
        {
            height: 37px;
        }
        .style7
        {
            height: 37px;
            width: 291px;
        }
        .style8
        {
            width: 291px;
        }
    </style>
    
    <script type="text/javascript" language="javascript">
        function openPopup(strOpen) {
            open(strOpen, "Info",
         "status=1, width=500, height=300, top=100, left=300");
        }
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 93%;">
        <tr>
            <td class="style1" colspan="3">
                <asp:TextBox ID="TextBox6" runat="server" BorderStyle="None" 
                    style="text-align: center; font-weight: 700; font-size: medium" Width="1008px">FACTURAS INVÁLIDAS</asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                Razon Social:<br />
                <asp:TextBox ID="tbNombre" runat="server" Width="518px"></asp:TextBox>
                <br />
                </td>
        </tr>
        <tr>
            <td class="style7">
                RFC:<br />
                <asp:TextBox ID="tbRFC" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style6">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                Escribe el Folio o Folios:<br />
                <asp:TextBox ID="tbFolioAnterior" runat="server"></asp:TextBox>
                &nbsp;Formato(1,2,3,4-8)<br />
                </td>
            <td class="style3">
             <%  if (Convert.ToBoolean(Session["coFactTodas"]))
                 {  %>
             <!--   <asp:Label ID="lSucursal" runat="server" Text="Clave sucursal:"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlSucursal" runat="server" 
                    DataSourceID="SqlDataSourceSucursales" DataTextField="Sucursal" 
                    DataValueField="idSucursal">
                    <asp:ListItem>-----</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceSucursales" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>" 
                    
                    SelectCommand="SELECT idSucursal, sucursal + ':' + clave AS Sucursal FROM Sucursales ORDER BY clave ASC">
                </asp:SqlDataSource>
                 <%  }  %> -->
                Serie:<br />
                <asp:TextBox ID="tbSerie" runat="server"></asp:TextBox>
                </td>
            <td rowspan="2">
                <br /> <center style="height: 231px">
                
               
                <legend ></legend>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSourceLog" Font-Size="X-Small" 
                        ForeColor="#333333" GridLines="None" Width="322px" 
        Visible="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                            <asp:BoundField DataField="archivo" HeaderText="Archivo" 
                                SortExpression="archivo" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#003151" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceLog" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
                        
        SelectCommand="SELECT TOP (4) fecha, archivo FROM LogErrorFacturas  ORDER BY fecha DESC">
                    </asp:SqlDataSource>
                   
&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl="~/configuracion/log/logError.aspx">LogError</asp:HyperLink>
                                       
                     </center>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Fecha Inicial:<asp:Calendar ID="calFechaAnterior" 
                    runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" 
                    Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="102px" 
                    NextPrevFormat="FullMonth" Width="109px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle Font-Bold="True" ForeColor="#003151" BackColor="White" 
                        BorderColor="White" BorderWidth="4px" Font-Size="12pt" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <br />
            </td>
            <td class="style2">
                Fecha Final:<asp:Calendar ID="calFechaFin" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="103px" NextPrevFormat="FullMonth" Width="147px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle ForeColor="#003151" BackColor="White" BorderColor="White" 
                        BorderWidth="4px" Font-Bold="True" Font-Size="12pt" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Button ID="bBuscar" runat="server" onclick="Button1_Click" Text="Buscar" 
                    Width="87px" />
            &nbsp;&nbsp;
                <asp:Button ID="bActualizar" runat="server" onclick="Button1_Click1" 
                    Text="Actualizar" />
            </td>
            <td class="style2">
                <asp:Label ID="lMensaje" runat="server" ForeColor="Black"></asp:Label>
            </td>
            <td>

                <asp:Button ID="bMail" runat="server" onclick="Button1_Click2" 
                    Text="Enviar por E-mail" Visible="False" />
                   
                <asp:DropDownList ID="ddlDocumentosEnviar" runat="server" Visible="False">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                    <asp:ListItem Value="1">XML</asp:ListItem>
                    <asp:ListItem Value="2">PDF</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lSeleccionDocus" runat="server" 
                        Text="Documentos Seleccionado:" Visible="False"></asp:Label></td>
        </tr>
    </table>
    <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" CellPadding="4" 
    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
     Width="904px" style="margin-top: 0px; text-align: center;" >
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns >
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
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:Label>
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

         <asp:TemplateField HeaderText="ENVIAR">
            <ItemTemplate>
             <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idFactura") %>')">
                <img  src="imagenes/mail.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
            </ItemTemplate>         
        
        </asp:TemplateField>
           <asp:TemplateField HeaderText="DETALLE" SortExpression="DETALLE">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("detalleVal") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("detalleVal") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
               


                     <asp:TemplateField HeaderText="Resultado Validación">
            <ItemTemplate>
             <a href="javascript:openPopup('ResultadoVal.aspx?idfa=<%# Eval("idFactura") %>')">
             <center>
                <img  src="../../imagenes/info.ico" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a></center>
            </ItemTemplate>         
        </asp:TemplateField>
    </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No existen datos.
        </EmptyDataTemplate>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#003151" Font-Bold="True" ForeColor="White" 
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
        SelectCommand="PA_facturasInv_basico_rec" 
        SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
        <asp:SessionParameter DefaultValue="S--X" Name="SUCURSAL" 
            SessionField="sucursalUser" Type="String" />
        <asp:SessionParameter DefaultValue="R---" Name="RFC" SessionField="rfcCliente" 
            Type="String" />
        <asp:SessionParameter DefaultValue="false" Name="ROL" SessionField="coFactTodas" 
            Type="Boolean" />
        <asp:Parameter Name="MODULO" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click3" 
        Text="Limpiar" Visible="False" />
                
<br />
</asp:Content>