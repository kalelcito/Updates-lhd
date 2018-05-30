<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="receptoresCfdi.aspx.cs" Inherits="DataExpressWeb.Formulario_web117" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
          .navigation
        {
            text-decoration:none;
            
            
            }
            .reportes
            {text-decoration:none;
                }
             ul.navigation
             {
                 padding: 0 0 1em 1.75em;
                 list-style-image:url(../imagenes/arrow.png);
                 list-style-position:inside;
                 
                 
                 }
             
            .sideMenu
            {
                text-decoration:none;
                 font-family:Arial;
                    font-weight:normal;
                    font-size:12px;
                
                }
            .sideMenu:hover
            {
                 text-decoration:underline;
                 color:#C90101 ;
                
                }
                
                    .tituloActive
                 {
                 /*padding: 0 0 1em 1.75em;*/
                 list-style-position:inside;
                 font: normal bold 12px Arial;
                     }
                     .titulo
                     {
                         list-style-position:inside;
                 font: normal normal 12px Arial;
                         }
                    h1 {
	background-color:#C90101 ;
	color: #fff ;
	font:normal bold 20px arial;
	width:200px;
	
}
    .panelBodyWrapper
{
    border:1px ridge #666666;
    }
                 .panelHeader
{
    background-color:#d40511;

    border:1px groove black;
    font-family:Arial;
    font-weight:bold;
    font-size:14px;
   
    color:#fff;
     height:20px;
     width:auto;

    }
.panelWrapper
    {
    background-color:#e8e8e4;
    border-style: solid;
        border-color: #d40511;
        border-width:1px;
    }    
    
.formEditar
{
    width: 450px; 
    height: 152px; 
  
    font-family: Arial; 
    font-weight: bold;
    font-size:12px;
    line-height:18px;
    
    color: #666666; 
    text-align:right;
    
    
    }
.textboxForm
{
    font: Normal 12px Arial;
    }
/*Estilo para el boton*/    
.botonForm
{
    background-color:#d40511;
    border-color:#e4b918;
    border-bottom-style:ridge;
    font-weight:normal;
    font-size:11px;
    color:#ffffff;
    height:23px;
    width:87px;

    }
.botonForm:hover
{
    color:#ffcc00;
    }
    
   #bus10 {
		position: absolute;
		left: 780px;
		top: 152px;
		z-index: 1;
            height: 59px;
            width: 150px;
        }
    
       #bus11 {
		position: absolute;
		left: 626px;
		top: 143px;
		z-index: 1;
            height: 57px;
            width: 197px;
        }
    
</style>

</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <ul class="navigation">
    <%if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
      { %>
   <span class="titulo"><asp:HyperLink ID="HyperLink5" NavigateUrl="~/menuReceDHL/UsuariosDhl.aspx"  runat="server">Administración de Usuarios</asp:HyperLink></span><br />
   <%} %>

   <%if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
     { %>
 <span class="titulo"><asp:HyperLink ID="HyperLink1" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx"  runat="server">Administración de Proveedores</asp:HyperLink></span><br /> 
    <%} %>

    <span class="tituloActive">Administración de Receptores de CFDI</span>
    
            <li><span class="tituloActive">Receptores de CFDI</span></li>

            <%if (!(Session["permisos"].ToString().IndexOf("NuevoRec") < 0))
              { %>
                       <li><asp:LinkButton ID="LinkButton1" onclick="Button31_Click"  CssClass="sideMenu"  runat="server">Nuevo Registro</asp:LinkButton></li>
                       <%} %>

<%if (!(Session["permisos"].ToString().IndexOf("EditarRec") < 0))
  { %>
        <li><asp:LinkButton ID="LinkButton4" onclick="Button32_Click"  CssClass="sideMenu"  runat="server">Editar</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("CodigosIVA") < 0))
          { %>
         <li><asp:HyperLink ID="HyperLink14" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/codigosIVA.aspx"  runat="server">Códigos de IVA</asp:HyperLink></li>
         <%} %>
        
        <%if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
          { %>
      <span class="titulo"><asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx"   runat="server">Administración de Configuración</asp:HyperLink></span><br />
  <%} %>

  <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
    { %>
  <span class="titulo"><asp:HyperLink ID="HyperLink3" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx"   runat="server">Administración de Mensaje</asp:HyperLink></span><br />
    <%} %>

    <%if (!(Session["permisos"].ToString().IndexOf("AdmCat") < 0))
      { %>
    <span class="titulo"><asp:HyperLink ID="HyperLink6" NavigateUrl="~/menuReceDHL/adminCat.aspx"   runat="server" >Administración de Catálogos</asp:HyperLink></span><br />
    <%} %>

    <%if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
      { %>
    <span class="titulo"><asp:HyperLink ID="HyperLink2" NavigateUrl="~/reportes/reporteSucursalesA.aspx"  runat="server">Reportes</asp:HyperLink></span><br />
    <%} %>
    </ul>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Receptores de CFDI</h1>

                        <table style="width: 288px; height: 33px">
                           
                            <tr>
                              <td>
                                 
                                  &nbsp;</td>
                            </tr>

                            <tr>
                               <td>
                                  <span id="bus10">
                                    <center style="height: 63px; width: 156px">
                                      <asp:Panel CssClass="panelWrapper" ID="Pagreceptor" runat="server" ScrollBars="Auto" 
                                            Height="52px" Width="103px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel" runat="server">Crear receptor de CFDI</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel33" runat="server" Height="236px" Width="456px">
                <table class="formEditar">
                <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfcag" runat="server"  
                                TextMode="SingleLine" Width="177px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Razón Social::</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trzag" runat="server" 
                                TextMode="SingleLine" Width="178px" ></asp:TextBox><%--ontextchanged="filtro_TextChanged"--%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            Org. ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Torag" runat="server" 
                                TextMode="SingleLine" Width="178px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Oracle ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Toracag" runat="server" 
                                TextMode="SingleLine" Width="178px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código GL IVA Retenido:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tglag" runat="server" 
                                TextMode="SingleLine" Width="179px"  ></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Código GL ISR Retenido:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tglretag" runat="server" 
                                TextMode="SingleLine" Width="179px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo de Proveedor "Flete":
                        </td>
                        <td>
                            <asp:DropDownList CssClass="textboxForm" ID="Droptipag" runat="server" 
                                Height="23px" Width="188px">
                                <asp:ListItem>FLETES</asp:ListItem>
                                <asp:ListItem>BIENES Y SERVICIOS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código GL IVA Retenido "Flete":
                        </td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tglretenag" runat="server" 
                                TextMode="SingleLine" Width="182px"  ></asp:TextBox>
                        </td>
                    </tr> 
                      <tr>
                        <td>
                            <asp:CheckBox ID="Checag" runat="server" /> Activo
                        </td>
                          
                    </tr> 
                    
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button22" runat="server"  Text="Grabar" onclick="Button22_Click"  OnClientClick="return confirm('Seguro que desea crear un nuevo receptor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button21" runat="server"  Text="Cancelar" onclick="Button21_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                                    </center>
                                  </span>

                                  <span id="bus11">
                                     <center style="height: 62px; width: 193px">
                                        <asp:Panel CssClass="panelWrapper" ID="Peditar" runat="server" ScrollBars="Auto" 
                                             Height="53px" Width="160px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel35" runat="server">Editando receptor de CFDI</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel36" runat="server" Height="220px" Width="458px">
                <table class="formEditar">
                <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfcedit" runat="server"  
                                TextMode="SingleLine" Width="164px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Razón Social::</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trzedit" runat="server" 
                                TextMode="SingleLine" Width="165px" ></asp:TextBox><%--ontextchanged="filtro_TextChanged"--%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            Org. ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Torgedit" runat="server" 
                                TextMode="SingleLine" Width="165px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Oracle ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Toacleedit" runat="server" 
                                TextMode="SingleLine" ontextchanged="Toacleedit_TextChanged" Width="165px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código GL IVA Retenido:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tcodgledit" runat="server" 
                                TextMode="SingleLine" Width="164px"  ></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Código GL ISR Retenido:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tglisredit" runat="server" 
                                TextMode="SingleLine" Width="166px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo de Proveedor "Flete":
                        </td>
                        <td>
                            <asp:DropDownList CssClass="textboxForm" ID="Droptipedit" runat="server" 
                                Height="17px" Width="174px">
                                <asp:ListItem>FLETES</asp:ListItem>
                                <asp:ListItem>BIENES Y SERVICIOS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código GL IVA Retenido "Flete":
                        </td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tglretenidoedit" runat="server" 
                                TextMode="SingleLine" Width="164px"  ></asp:TextBox>
                        </td>
                    </tr> 
                      
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button24" runat="server"  Text="Grabar" onclick="Button24_Click"  OnClientClick="return confirm('Seguro que desea editar el receptor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button23" runat="server"  Text="Cancelar" onclick="Button23_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                                     </center>
                                  </span>
                               </td>
                            </tr>

                       </table>
                       <table>
                          <tr>
                             <td>
                             <br />
                             <asp:Panel ID="Panel19" runat="server" BorderColor="#CC0000" BorderStyle="none" 
                     style=" width:70%" ScrollBars="Auto">
                         <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1355px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="1px"  Font-Size="10px"  
                             style="margin-top: 0px" CellSpacing="1" Visible="false">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:TemplateField HeaderText="Marcar">
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server"/>
                            <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idreceptorCFDI")%>' />
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razón Social" SortExpression="raz">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("razonSoc") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("razonSoc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Org ID" SortExpression="or">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OrdID") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("OrdID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Oracle ID" SortExpression="ora">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OracleID") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("OracleID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Código GL IVA Retenido" SortExpression="cod">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGLret") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label511" runat="server" Text='<%# Bind("codigoGLret") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Código GL ISR Retenido" SortExpression="codis">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGLISRret") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label512" runat="server" Text='<%# Bind("codigoGLISRret") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo de Proveedor Flete" SortExpression="tipProv">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("tipProvFlet") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label513" runat="server" Text='<%# Bind("tipProvFlet") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Código GL IVA Retenido Flete" SortExpression="fle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGLIVAret") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label515" runat="server" Text='<%# Bind("codigoGLIVAret") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Habilitado" SortExpression="habi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("habilitado") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label514" runat="server" Text='<%# Bind("habilitado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No existen registros.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="12px" Font-Names="Arial" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" Font-Size="12px" Font-Names="Arial" />
        <RowStyle BackColor="#f2f2ed" ForeColor="#333333" Font-Size="12px" Font-Names="Arial" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [idreceptorCFDI],[rfc],[razonSoc],[OrdID],[OracleID],[codigoGLret] ,[codigoGLISRret],[tipProvFlet],[codigoGLIVAret],[habilitado] FROM [receptorCFDI] order by  [idreceptorCFDI] desc">
    </asp:SqlDataSource>
                     </asp:Panel>
                             </td>
                          </tr>
                       </table>

</asp:Content>
