<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menuAdmin.aspx.cs" Inherits="DataExpressWeb.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style9
        {
            width: 97px;
            height: 92px;
        }
        .style10
        {
            width: 1000px;
            height: 92px;
        }
        .style13
        {
            width: 987px;
            height: 385px;
        }
        .style14
        {
            width: 515px;
            height: 13px;
        }
        .style27
        {
            width: 515px;
            height: 11px;
        }
        .style31
        {
            width: 515px;
            height: 8px;
        }
        .style32
        {
            width: 1000px;
            height: 30px;
        }
        .style33
        {
            height: 30px;
        }
        .style34
        {
            width: 213px;
            height: 37px;
        }
        .style35
        {
            height: 37px;
        }
         #bus {
		position: absolute;
		left: 503px;
		top: 241px;
		z-index: 2;
        height: 340px;
        width: 420px;
        margin-left: 0px;
    }
	
	    #bus2 {
		position: absolute;
		left: 306px;
		top: 249px;
		z-index: 1;
            width: 822px;
            height: 337px;
        }
        .style36
        {
            width: 515px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 1216px">
<tr>
<td class="style9">
  <table style="height: 392px; width: 97px;">

   <tr>
    <td class="style36" style="border: thin solid #FFFF00; background-color: #FFFF99">
    <center>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="85px" 
            ImageUrl="~/Imagenes-dhl/D1.PNG" onclick="ImageButton1_Click" />
        <br />
        <strong>CONSULTA DE CFDI</strong></center>
       </td>
   </tr>
   <tr>
    <td class="style31" style="border: thin solid #FF0000; background-color: #FD393F;">
    <center>
        <asp:ImageButton ID="ImageButton2" runat="server" Height="77px" 
            ImageUrl="~/Imagenes-dhl/nuePro.PNG" Width="65px" 
            onclick="ImageButton2_Click" />
        <br />
        AGREGAR<br />
        ADMINISTRADOR</center>
       </td>
   </tr>
   <tr>
    <td class="style27" style="border: thin solid #FFFF00; background-color: #FFFF99">
    <center>
        <asp:ImageButton ID="ImageButton3" runat="server" Height="78px" 
            ImageUrl="~/Imagenes-dhl/D2.PNG" Width="71px" 
            onclick="ImageButton3_Click" />
        <br />
        ADMINISTRAR<br />
        PROVEEDORES</center>
       </td>
   </tr>
   <tr>
    <td class="style14" style="border: thin solid #FF0000; background-color: #FD393F;">
        <center>
        <asp:ImageButton ID="ImageButton4" runat="server" Height="85px" 
                ImageUrl="~/Imagenes-dhl/D5.PNG" Width="69px" 
                onclick="ImageButton4_Click" />
            <br />
            CONFIGURACIÓN</center>
       </td>
   </tr>
  </table>
</td>
<td class="style10" 
        style="border: medium groove #FF0000; background-color: #FFFF99">
  <table>
    <tr>
      <td class="style13">
      <asp:Panel ID="Panel5" runat="server" BackColor="#FFEA1E" BorderColor="#E4B918" 
        BorderStyle="Groove" Height="368px" Width="1091px" Visible="False">
          <asp:Panel ID="Panel6" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
              Height="76px" Width="1081px">
              <br />
              <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="Sqlista" 
                  DataTextField="rfc" DataValueField="rfc" Height="20px" Width="171px">
                  <asp:ListItem>SELECCIONA RFC</asp:ListItem>
              </asp:DropDownList>
              <br />
              <asp:SqlDataSource ID="Sqlista" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
                  SelectCommand="SELECT [rfc], [razonSocial] FROM [Proveedores]">
              </asp:SqlDataSource>
          </asp:Panel>
          <br />
           <asp:Panel ID="Panel7" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
              Height="256px" Width="1081px" ScrollBars="Auto">
              <br />

              <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" CellPadding="4" 
    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
     Width="1150px" style="margin-top: 0px; margin-left: 1px; margin-bottom: 0px;" BorderColor="#CC0000" 
        BorderStyle="Groove">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns >
     <asp:ImageField DataImageUrlField="EDOFAC" 
                        DataImageUrlFormatString="~/Imagenes/{0}.png" HeaderText="Estatus" >
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
        <asp:TemplateField HeaderText="Moneda" SortExpression="Moneda">
            <EditItemTemplate>
                <asp:TextBox ID="tbMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Código Contable" SortExpression="Código Contable">
            <EditItemTemplate>
                <asp:TextBox ID="tbCodCont" runat="server" Text='<%# Bind("CodCont") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lCodCont" runat="server" Text='<%# Bind("CodCont") %>'></asp:Label>
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
                <img  src="../../imagenes/info.ico" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
            </ItemTemplate>  
</asp:TemplateField>

         <asp:TemplateField HeaderText="ENVIAR" Visible="False">
            <ItemTemplate>
             <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idFactura") %>')">
                <center>
                <img  src="imagenes/mail.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a></center>
            </ItemTemplate>         
        </asp:TemplateField>

    </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No existen datos.
        </EmptyDataTemplate>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="XX-Small" />
    <PagerStyle BackColor="#284775" ForeColor="White" 
            HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#E9E7E2"/>
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
        SelectCommand="PA_facturas_basico_rec_2" SelectCommandType="StoredProcedure" >
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
          </asp:Panel>
          <br />
          <br />
          <br />
          <br />
        </asp:Panel>


      <span id="bus2">
      <center>
      <asp:Panel  ID="Panel4" runat="server" BackColor="#FFEA1E" BorderColor="#E4B918" 
        BorderStyle="Groove" Height="329px" Width="811px" ScrollBars="Auto" 
              Visible="False">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="807px" 
        DataKeyNames="idProveedor" AllowPaging="True" PageSize="10" Height="290px" 
              BorderColor="#CC0000" BorderStyle="Solid" style="margin-top: 0px">
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
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
        </asp:Panel>
        </center>

        </span>

      <span id="bus">
        <center>
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFEA1E" BorderColor="#E4B918" 
        BorderStyle="Groove" Height="332px" Width="412px" Visible="False">
        <asp:Panel ID="Panel2" runat="server" BackColor="#CC0000" Font-Bold="True" 
            ForeColor="White" Height="16px" Width="380px">
            REGISTRO DE ADMINISTRADOR</asp:Panel>
        <br />
        <asp:Panel ID="Panel3" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
            Height="247px" Width="374px">
            <table style="width: 308px; height: 47px">
            
                <tr>
                    <td class="style34">
                        RFC:</td>
                    <td class="style35">
                        <asp:TextBox ID="Trfc" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style32">
                        RAZÓN SOCIAL:</td>
                    <td class="style33">
                        <asp:TextBox ID="Trz" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <br />
            <table style="width: 333px">
            <tr>
            <td style="font-weight: bold">DATOS DE CONTACTO</td>
            </tr>
            </table>

            <br />

            <table style="width: 325px">
            <tr>
            <td>NOMBRE DEL CONTACTO:</td>
            <td>
                <asp:TextBox ID="Tct" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>TELÉFONO:</td>
            <td>
                <asp:TextBox ID="Ttel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>DIRECCIÓN DE CORREO:</td>
            <td>
                <asp:TextBox ID="Tcor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>NOMBRE DE USUARIO</td>
            <td>
                <asp:TextBox ID="Tus" runat="server"></asp:TextBox>
                </td>
            </tr>
            </table>
        </asp:Panel>
        <br />
<asp:Button 
                ID="bSesion" runat="server" BackColor="#FFD307" 
            BorderColor="#E4B918" BorderStyle="Ridge" Font-Size="Smaller" 
            Text="Aceptar" onclick="bSesion_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bSesion0" runat="server" BackColor="#FFD307" 
            BorderColor="#E4B918" BorderStyle="Ridge" Font-Size="Smaller"  Text="Cancelar" />
        &nbsp;<br />
    </asp:Panel>
    </center>
    </span>
      </td>
    </tr>
  </table>
</td>
</tr>
</table>

</asp:Content>
