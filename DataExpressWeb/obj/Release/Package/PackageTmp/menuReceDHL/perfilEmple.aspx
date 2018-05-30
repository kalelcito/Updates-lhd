<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="perfilEmple.aspx.cs" Inherits="DataExpressWeb.Formulario_web125" %>
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
    }
.panelWrapper
{
    background-color:#e8e8e4;
    border-bottom-style:groove;
        border-left-color: #E4B918;
        border-right-color: #E4B918;
        border-top-color: #E4B918;
        border-bottom-color: #E4B918;
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
            height: 84px;
            width: 122px;
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
    .style8
    {
        width: 171px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <ul class="navigation">
    <%if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
      { %>
     <span class="titulo"><asp:HyperLink ID="HyperLink5" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx" runat="server">Administración de Usuarios</asp:HyperLink></span><br />
   <%} %>

   <%if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
     { %>
    <span class="titulo"><asp:HyperLink ID="HyperLinkinicio1" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx" runat="server">Administración de Proveedores</asp:HyperLink></span><br />
      <%} %>

      <%if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
        { %>
     <span class="titulo"><asp:HyperLink ID="HyperLinkinicio3" NavigateUrl="~/menuReceDHL/receptoresCfdi.aspx"  runat="server">Administración de Receptores de CFDI</asp:HyperLink></span><br /> 
   <%} %>
    
    <%if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
      { %>
      <span class="titulo"><asp:HyperLink ID="HyperLinkinicio4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx"   runat="server">Administración de Configuración</asp:HyperLink></span><br />
    <%} %>
    
       <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
         { %>
        <span class="titulo"><asp:HyperLink ID="HyperLink2" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx"   runat="server">Administración de Mensaje</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmCat") < 0))
          { %>
        <span class="titulo"><asp:HyperLink ID="HyperLink6" NavigateUrl="~/menuReceDHL/adminCat.aspx"   runat="server" >Administración de Catálogos</asp:HyperLink></span><br />
        <%} %>>

        <%if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
          { %>
    <span class="titulo"><asp:HyperLink ID="HyperLinkinicio2" NavigateUrl="~/reportes/reporteSucursalesA.aspx"  runat="server">Reportes</asp:HyperLink></span><br />
    <%} %>
    </ul> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div>
   <center>
   <asp:Panel ID="Panel2" runat="server" Height="268px" Width="600px" 
                        style="margin-top: 9px; "  BackColor="#FCFCFC" BorderColor="gray" 
                        BorderStyle="solid">
                        <br />
                        <br />
     <table style="width: 522px; font-family: Arial; font-size: 12px;">
       <tr>
         <td colspan="2"> <center> &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" 
                 Font-Names="Arial" Text="DATOS DEL EMPLEADO"></asp:Label>
             </center></td>
       </tr>
       <tr>
         <td class="style8">Grupo:</td>
         <td>
             <asp:Label ID="Lgrup" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
         <td class="style8">Proveedor:</td>
         <td>
             <asp:Label ID="Lprov" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
         <td class="style8">Nombre:</td>
         <td>
             <asp:TextBox ID="Tnom" runat="server" Width="144px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td class="style8">Login:</td>
         <td>
             <asp:TextBox ID="Tlog" runat="server" Width="144px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td class="style8">Contraseña:</td>
         <td>
             <asp:TextBox ID="Tpass" runat="server" Width="145px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td colspan="2">Fecha de última modificación:&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Lfecha" runat="server" ForeColor="#D40511"></asp:Label>
           </td>
       </tr>
       <tr>
         <td>
             <asp:Button ID="Button1" runat="server" BackColor="#D40511" Font-Bold="True" 
                 Font-Names="Arial" ForeColor="White" onclick="Button1_Click" 
                 Text="Actualizar" OnClientClick="return confirm('Seguro que desea actualizar la información');" />
           </td>
         <td>
             <asp:Button ID="Button2" runat="server" BackColor="#D40511" Font-Bold="True" 
                 Font-Names="Arial" ForeColor="White" onclick="Button2_Click" Text="Regresar" />
           </td>
       </tr>
     </table>
     </asp:Panel>
   </center>
  </div>
</asp:Content>

