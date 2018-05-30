<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tiposProveedor.aspx.cs" Inherits="DataExpressWeb.Formulario_web121" %>
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
	width:180px;
	
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
    width: 378px; 
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
    border-bottom-style:ridge;
    font-weight:normal;
    font-size:11px;
    color:#ffffff;
    width:87px;
        border-left-color: #e4b918;
        border-right-color: #e4b918;
        border-top-color: #e4b918;
        border-bottom-color: #e4b918;
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
            height: 43px;
            width: 148px;
        }
    
       #bus11 {
		position: absolute;
		left: 626px;
		top: 143px;
		z-index: 1;
            height: 45px;
            width: 144px;
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

    <%if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
      { %>
    <span class="titulo"><asp:HyperLink ID="HyperLink3" NavigateUrl="~/menuReceDHL/receptoresCfdi.aspx"  runat="server">Administración  de Receptores de CFDI</asp:HyperLink></span><br />    
    <%} %>


    <span class="tituloActive">Administración de Configuración</span>
    <%if (!(Session["permisos"].ToString().IndexOf("Dias") < 0))
      { %>
    <li><asp:HyperLink ID="HyperLink15" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/diasOperacion.aspx"  runat="server"> Días de Operación</asp:HyperLink></li>
    <%} %>

    <%if (!(Session["permisos"].ToString().IndexOf("Monedas") < 0))
      { %>
    <li><asp:HyperLink ID="HyperLink16" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/monedas.aspx"  runat="server">Monedas</asp:HyperLink></li>
    <%} %>


    <li><span class="tituloActive">Tipo de Proveedor</span></li>
     <%if (!(Session["permisos"].ToString().IndexOf("NuevoProv") < 0))
       { %>
    <li><asp:LinkButton ID="LinkButton1" onclick="Button42_Click" CssClass="sideMenu"  runat="server">Nuevo Registro</asp:LinkButton></li>
    <%} %>
    <%if (!(Session["permisos"].ToString().IndexOf("EditarProv") < 0))
      { %>
    <li><asp:LinkButton ID="LinkButton4" onclick="Button43_Click" CssClass="sideMenu"  runat="server">Editar</asp:LinkButton></li>
    <%} %>

    <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
      { %>
    <span class="titulo"><asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx"   runat="server">Administración de Mensaje</asp:HyperLink></span><br />
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
    <h1 >Tipo de Proveedor</h1>

                        <table style="width: 236px; height: 33px">
                            

                            <tr>
                              <td>
                                <span id="bus10">
                                  <center style="height: 45px; width: 136px">
                                        <asp:Panel CssClass="panelWrapper" ID="Pcrearprov" runat="server" 
                                            ScrollBars="Auto" Height="32px" Width="129px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel53" runat="server">Crear Tipo de Proveedor</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel54" runat="server" Width="420px">
                <table class="formEditar">
                <tr>
                        <td>
                           Nombre:</td>
                        <td align="center">
                            <asp:TextBox CssClass="textboxForm" ID="Tnomcrear" runat="server" TextMode="SingleLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                           <asp:CheckBox ID="Checcrear1" runat="server" />Permitir carga de propinas o servicios</td>
                        
                    </tr>
                      <tr>
                        <td colspan="2" align="center">
                           <asp:CheckBox ID="Checcrear2" runat="server" />Activo</td>
                        
                    </tr>
                    
                    
                   
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button36" runat="server"  Text="Grabar" onclick="Button36_Click"  OnClientClick="return confirm('Seguro que desea crear un tipo de proveedor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button35" runat="server"  Text="Cancelar" onclick="Button35_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                                  </center>
                                </span>

                                <span id="bus11">
                                <center>
                                   <asp:Panel CssClass="panelWrapper" ID="PeditTipoPr" runat="server" 
                                        ScrollBars="Auto" Height="40px" Visible="false" Width="135px">
        <asp:Panel CssClass="panelHeader" ID="Panel56" runat="server">Editando Tipo de Proveedor</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel57" runat="server" Width="400px">
                <table class="formEditar">
                <tr>
                        <td >
                           Nombre:</td>
                        <td align="center">
                            <asp:TextBox CssClass="textboxForm" ID="Teditarnom" runat="server" TextMode="SingleLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                           <asp:CheckBox ID="Checeditar1" runat="server" />Permitir carga de propinas o servicios
                           </td>
                        
                    </tr>
                      <tr>
                        <td colspan="2" align="center">
                           <asp:CheckBox ID="Checeditar2" runat="server" />Activo</td>
                        
                    </tr>   
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button38" runat="server"  Text="Grabar" onclick="Button38_Click"  OnClientClick="return confirm('Seguro que desea editar el tipo de proveedor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button37" runat="server"  Text="Cancelar" onclick="Button37_Click" /> <%--onclick="Button12_Click"--%>
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
          <asp:Panel ID="Panel23" runat="server" BorderColor="#CC0000" BorderStyle="none" 
                    Width="1250px" ScrollBars="Auto">
                         <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource8" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="80%" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="solid" BorderWidth="1px"  Font-Size="10px"  style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#000" Font-Size="12px" Font-Names="Arial"/>
        <Columns>
        <asp:TemplateField HeaderText="Marcar">
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server"/>
                            <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idTipProv")%>' />
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="nome">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Permitir Carga de Propinas o Servicios" SortExpression="permPropServ">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("permPropServ") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("permPropServ") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Activo" SortExpression="ac0">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("activo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
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
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" Font-Size="12px" Font-Names="Arial"/>
        <RowStyle BackColor="#f2f2ed" ForeColor="#000" Font-Size="12px" Font-Names="Arial"/>
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [idTipProv],[nombre],[permPropServ],[activo] FROM [tipoProveedor] order by [idTipProv] desc">
    </asp:SqlDataSource>
                     </asp:Panel>
       </td>
    </tr>
  </table>
</asp:Content>
