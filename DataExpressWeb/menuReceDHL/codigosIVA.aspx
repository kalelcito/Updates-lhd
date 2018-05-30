<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="codigosIVA.aspx.cs" Inherits="DataExpressWeb.Formulario_web118" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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
            height: 49px;
            width: 147px;
        }
    
       #bus11 {
		position: absolute;
		left: 626px;
		top: 143px;
		z-index: 1;
            height: 55px;
            width: 160px;
        }
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
	width:130px;
	
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
      <span class="titulo"><asp:HyperLink ID="HyperLink1" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx"  runat="server" >Administración de Proveedores</asp:HyperLink></span><br /> 
    <%} %>>

    <span class="tituloActive">Administración de Receptores de CFDI</span>
    
    <%if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
      { %>
            <li><asp:HyperLink ID="HyperLink13" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/receptoresCfdi.aspx"  runat="server">Receptores de CFDI</asp:HyperLink></li>
            <%} %>

       <li><span class="tituloActive">Códigos de IVA</span></li>

                      <% if (!(Session["permisos"].ToString().IndexOf("NuevoIVA") < 0))
                         { %>
                           <li><asp:LinkButton onclick="Button33_Click" ID="LinkButton2" CssClass="sideMenu"  runat="server">Nuevo Registro</asp:LinkButton></li>
                           <%} %>

                           <% if (!(Session["permisos"].ToString().IndexOf("EditarIVA") < 0))
                              { %>
                          <li><asp:LinkButton ID="LinkButton3" onclick="Button35_Click" CssClass="sideMenu"  runat="server" >Editar</asp:LinkButton></li>
                           <%} %>

 <%if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
   { %>
      <span class="titulo"><asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx"   runat="server" >Administración de Configuración</asp:HyperLink></span><br />
    <%} %>

    <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
      { %>
     <span class="titulo"><asp:HyperLink ID="HyperLink6" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx"   runat="server" >Administración de Mensaje</asp:HyperLink></span><br />
       <%} %>

       <%if (!(Session["permisos"].ToString().IndexOf("AdmCat") < 0))
         { %>
       <span class="titulo"><asp:HyperLink ID="HyperLink3" NavigateUrl="~/menuReceDHL/adminCat.aspx"   runat="server" >Administración de Catálogos</asp:HyperLink></span><br />
       <%} %>
       <%if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
         { %>
    <span class="titulo"><asp:HyperLink ID="HyperLink2" NavigateUrl="~/reportes/reporteSucursalesA.aspx"  runat="server">Reportes</asp:HyperLink></span><br />
    <%} %>

    </ul> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Códigos IVA</h1>

                        <table style="width: 301px; height: 33px">
                            
                            <tr>
                               <td>
                                  <span id="bus10">
                                   <center style="height: 48px; width: 140px">
                                   <asp:Panel CssClass="panelWrapper" ID="PcrearIVA" runat="server" ScrollBars="Auto" 
                                           Height="32px" Width="113px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel38" runat="server">Crear codigos de IVA</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel1" runat="server" Width="464px">
                <table class="formEditar">
                <tr>
                        <td>
                            Receptor de CFDI:</td>
                        <td>
                            <asp:DropDownList CssClass="textboxForm" ID="DroprecepCre" runat="server" 
                                Height="16px" Width="107px" DataSourceID="receptorsql" 
                                DataTextField="razonSoc" DataValueField="razonSoc">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="receptorsql" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT [razonSoc] FROM [receptorCFDI]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Impuesto:</td>
                        <td>
                            <%--ontextchanged="filtro_TextChanged"--%>
                            <asp:TextBox ID="TcreIva" runat="server" Enabled="False" Font-Names="Arial" 
                                Font-Size="12px" Height="22px" Width="100px">IVA</asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            Tasa:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="TtasaCre" runat="server" 
                                TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="TcodCre" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código GL:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="TglCre" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button26" runat="server"  Text="Grabar" onclick="Button26_Click"  OnClientClick="return confirm('Seguro que deseas crear un código nuevo');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button25" runat="server"  Text="Cancelar" onclick="Button25_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                                   </center>
                                  </span>

                                  <span id="bus11">
                                    <center style="height: 58px; width: 180px">
                                       <asp:Panel CssClass="panelWrapper" ID="PeditIva" runat="server" 
                                            ScrollBars="Auto" Visible="false" Height="34px" Width="120px">
        <asp:Panel CssClass="panelHeader" ID="Panel41" runat="server">Editando codigos de IVA</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel42" runat="server" Width="455px">
                <table class="formEditar">
                <tr>
                        <td>
                            Receptor de CFDI:</td>
                        <td>
                            <asp:DropDownList CssClass="textboxForm" ID="Dropedi" runat="server" 
                                DataSourceID="SqlDataSouedit" DataTextField="razonSoc" 
                                DataValueField="razonSoc">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSouedit" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT [razonSoc] FROM [receptorCFDI]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Impuesto:</td>
                        <td>
                            <%--ontextchanged="filtro_TextChanged"--%>
                            <asp:TextBox ID="TeditIv" runat="server" Enabled="False" Font-Names="Arial" 
                                Font-Size="12px" Height="23px" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            Tasa:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Ttasaedi" runat="server" 
                                TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tcodedi" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Código GL:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tgledi" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button28" runat="server"  Text="Grabar" onclick="Button28_Click"  OnClientClick="return confirm('Seguro que desea editar un código IVA');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button27" runat="server"  Text="Cancelar" onclick="Button27_Click" /> <%--onclick="Button12_Click"--%>
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
                           <br />
                            <asp:Panel ID="Panel20" runat="server" BorderColor="#CC0000" BorderStyle="none" 
                     Width="80%" ScrollBars="Auto">
                          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="solid" BorderWidth="1px"  Font-Size="10px"  style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
         <asp:TemplateField HeaderText="Marcar">
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server"/>
                            <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idIva")%>' />
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
            
            <asp:TemplateField HeaderText="Impuesto" SortExpression="impu">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("impuesto") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("impuesto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tasa" SortExpression="tasa">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tasa") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("tasa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Código" SortExpression="codi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label511" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Código GL" SortExpression="codig">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGL") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label512" runat="server" Text='<%# Bind("codigoGL") %>'></asp:Label>
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
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center"  Font-Size="12px" Font-Names="Arial" />
        <RowStyle BackColor="#f2f2ed" ForeColor="#333333"  Font-Size="12px" Font-Names="Arial" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [idIva],[rfc],[razonSoc],[impuesto],[tasa],[codigo] ,[codigoGL] FROM [codigosIVA] order by [idIva] desc">
    </asp:SqlDataSource>
                     </asp:Panel>
                           </td>
                         </tr>
                       </table>
</asp:Content>
