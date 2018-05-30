<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="DataExpressWeb.Formulario_web113" %>
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
     height:16px;
     width:415px;

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
    width: 383px; 
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
    Width:244px;
    Height:21px;
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
            height: 54px;
            width: 105px;
        }
    
       #bus11 {
		position: absolute;
		left: 780px;
		top: 152px;
		z-index: 1;
            height: 55px;
            width: 112px;
        }
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
	width:90px;
	color: #fff ;
	font:normal bold 20px arial;
	
}
</style>
</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
     <ul class="navigation">

     <%if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
       { %>
     <span class="titulo"><asp:HyperLink ID="HyperLink5" NavigateUrl="~/menuReceDHL/UsuariosDhl.aspx" runat="server">Administración de Usuarios</asp:HyperLink></span><br />
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
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
          { %>
    <span class="titulo"><asp:HyperLink ID="HyperLinkinicio2" NavigateUrl="~/reportes/reporteSucursalesA.aspx"  runat="server">Reportes</asp:HyperLink></span><br />
    <%} %>

    </ul> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    

</asp:Content>
