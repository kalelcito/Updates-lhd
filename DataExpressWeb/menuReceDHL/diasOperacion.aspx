<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="diasOperacion.aspx.cs" Inherits="DataExpressWeb.Formulario_web119" %>
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
        
     #bus5 {
		position: absolute;
		left: 770px;
		top: 149px;
		z-index: 1;
            height: 29px;
            width: 94px;
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
	width:185px;
	
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
   
            <li><span class="tituloActive">Días de Operación</span></li>
            
            
             <%if (!(Session["permisos"].ToString().IndexOf("EditarDia") < 0))
               { %>
           <li><asp:LinkButton ID="LinkButton2" onclick="Button37_Click" CssClass="sideMenu"  runat="server">Editar</asp:LinkButton></li>
           <%} %>

           <%--<li><asp:LinkButton ID="LinkButton1"  CssClass="sideMenu"  runat="server">Filtrar</asp:LinkButton></li>--%>
           <%if (!(Session["permisos"].ToString().IndexOf("Monedas") < 0))
             { %>
            <li><asp:HyperLink ID="HyperLink16" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/monedas.aspx"  runat="server">Monedas</asp:HyperLink></li>
            <%} %>

             <%if (!(Session["permisos"].ToString().IndexOf("TipoProv") < 0))
               { %>
            <li><asp:HyperLink ID="HyperLink9" CssClass="sideMenu"  runat="server" NavigateUrl="~/menuReceDHL/tiposProveedor.aspx">Tipo de Proveedor</asp:HyperLink></li>
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
    <h1>Días de Operación</h1>

                        <table style="width: 173px; height: 33px">
                         
                            <tr>
                              <td colspan="2"><span ID="bus5">
                <center style="height: 30px; width: 72px">
                <asp:Panel ID="Pdias" runat="server" CssClass="panelWrapper"  
                        Height="16px" Visible="False" 
                                            Width="43px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel32" runat="server" CssClass="panelHeader" 
                         Height="16px" 
                        Width="415px">
                        Editando día de la operación</asp:Panel>
                                            <asp:Panel ID="Panel44" runat="server" CssClass="panelBodyWrapper"
                                                Height="181px" Width="392px">
                                                <table style="width: 383px; height: 119px;">
                                                    <tr>
                                                        <td>
                                                            Día de la semana:</td>
                                                        <td>
                                                            <asp:Label ID="Ldia1" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                          </td>
                                                        <td>
                                                            
                                                            <asp:CheckBox ID="Checkdia" runat="server" Text="Habilitado" />
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Hora de Inicio:</td>
                                                        <td>
                                                            
                                                            <asp:DropDownList ID="Dropdia1" CssClass="textboxForm" runat="server" Height="16px" Width="69px">
                                                                <asp:ListItem>08:00</asp:ListItem>
                                                                <asp:ListItem>09:00</asp:ListItem>
                                                                <asp:ListItem>10:00</asp:ListItem>
                                                                <asp:ListItem>11:00</asp:ListItem>
                                                                <asp:ListItem>12:00</asp:ListItem>
                                                                <asp:ListItem>13:00</asp:ListItem>
                                                                <asp:ListItem>14:00</asp:ListItem>
                                                                <asp:ListItem>15:00</asp:ListItem>
                                                                <asp:ListItem>16:00</asp:ListItem>
                                                                <asp:ListItem>17:00</asp:ListItem>
                                                                <asp:ListItem>18:00</asp:ListItem>
                                                                <asp:ListItem>19:00</asp:ListItem>
                                                                <asp:ListItem>20:00</asp:ListItem>
                                                                <asp:ListItem>21:00</asp:ListItem>
                                                                <asp:ListItem>22:00</asp:ListItem>
                                                                <asp:ListItem>23:00</asp:ListItem>
                                                                <asp:ListItem>24:00</asp:ListItem>
                                                            </asp:DropDownList>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Hora de finalización:</td>
                                                        <td>
                                                          <asp:DropDownList ID="Dropdia2"  CssClass="textboxForm" runat="server" Height="17px" Width="68px">
                                                                <asp:ListItem>08:00</asp:ListItem>
                                                                <asp:ListItem>09:00</asp:ListItem>
                                                                <asp:ListItem>10:00</asp:ListItem>
                                                                <asp:ListItem>11:00</asp:ListItem>
                                                                <asp:ListItem>12:00</asp:ListItem>
                                                                <asp:ListItem>13:00</asp:ListItem>
                                                                <asp:ListItem>14:00</asp:ListItem>
                                                                <asp:ListItem>15:00</asp:ListItem>
                                                                <asp:ListItem>16:00</asp:ListItem>
                                                                <asp:ListItem>17:00</asp:ListItem>
                                                                <asp:ListItem>18:00</asp:ListItem>
                                                                <asp:ListItem>19:00</asp:ListItem>
                                                                <asp:ListItem>20:00</asp:ListItem>
                                                                <asp:ListItem>21:00</asp:ListItem>
                                                                <asp:ListItem>22:00</asp:ListItem>
                                                                <asp:ListItem>23:00</asp:ListItem>
                                                                <asp:ListItem>24:00</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                    <td>Tipos de Proveedores:</td>
                                                    <td>
                                                        <asp:ListBox ID="ListPr" runat="server" Width="165px" SelectionMode="Multiple" 
                                                            DataSourceID="SqlDataSo" DataTextField="nombre" DataValueField="nombre">
                                                        </asp:ListBox>
                                                        <asp:SqlDataSource ID="SqlDataSo" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
                                                            SelectCommand="SELECT [nombre] FROM [tipoProveedor]"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button53" runat="server"  
                                                Text="Grabar" Width="87px" onclick="Button53_Click" CssClass="botonForm" OnClientClick="return confirm('Seguro que desea editar el día');" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                            
                                            <asp:Button ID="Button54" runat="server" 
                                                  Text="Cancelar" onclick="Button54_Click" CssClass="botonForm" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span></td>
                            </tr>
                       </table>
                       <table>
                         <tr>
                           <td>
                           <br />
                           <div style =" border: 1px solid #d40511; background-color:#d40511; 
                height:auto; Width:998px; margin:0; padding:0">
                <table cellspacing="0" cellpadding = "0" rules="all" border="1" id="tblHeader" 
                 style="font-family:Arial;font-size:12px;width:auto;color:white;
                 border-collapse:collapse;height:100%;">
                    <tr>
                       <td style ="width:50px;text-align:center">Marcar</td>
                       <td style ="width:92px;text-align:center">Día</td>
                       <td style ="width:92px;text-align:center">Habilitado</td>
                       <td style ="width:92px;text-align:center">Hora de Inicio</td>
                       <td style ="width:115px;text-align:left">Hora de Finalización</td>
                       <td style ="width:550px;text-align:left">Tipo de Proveedor</td>
                    </tr>
                </table>
                </div>
                            <asp:Panel ID="Panel21" runat="server" BorderColor="#CC0000" 
                                         BorderStyle="none" Width="1000px" ScrollBars="Auto">
                         <asp:GridView ID="GridView5"  ShowHeader="false" runat="server" 
                                    AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
        CellPadding="1" ForeColor="#333333" DataKeyNames="dia" GridLines="None" Width="1000px" AllowPaging="True" 
                                             PageSize="7" 
              BorderColor="#CC0000" BorderStyle="solid" BorderWidth="1px"  Font-Size="10px" 
                                    style="margin-top: 0px" CellSpacing="1" Visible="false">
        <AlternatingRowStyle BackColor="White" ForeColor="#000000"/>
        <Columns>

        <asp:TemplateField HeaderText="Marcar" ItemStyle-Width="48px" >
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server" />
                            <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("dia")%>' />
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

            <asp:TemplateField HeaderText="Día" SortExpression="dia" ItemStyle-Width="90px">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dia") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Width="90px" Text='<%# Bind("dia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Habilitado" SortExpression="hab" ItemStyle-Width="90px">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("habilitado") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Width="90px" Text='<%# Bind("habilitado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Hora de Inicio" SortExpression="HI" ItemStyle-Width="90px">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("horaIni") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Width="90px" Text='<%# Bind("horaIni") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Hora de Finalización" SortExpression="HF" ItemStyle-Width="113px" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"  Text='<%# Bind("horaFin") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("horaFin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo de Proveedor" SortExpression="tp" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox34" runat="server"  Text='<%# Bind("Proveedores") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label34" runat="server" Text='<%# Bind("Proveedores") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>
            No existen registros.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" 
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
                                
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
                                    SelectCommand="SELECT [dia],[habilitado],[horaIni],[horaFin],[Proveedores] FROM [diasOperacion]">
                                </asp:SqlDataSource>
                     </asp:Panel>
                           </td>
                         </tr>
                       </table>
</asp:Content>
