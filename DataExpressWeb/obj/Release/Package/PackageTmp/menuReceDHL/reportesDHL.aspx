<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportesDHL.aspx.cs" Inherits="DataExpressWeb.Formulario_web122" %>
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

 <%if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
   { %>
 <span class="titulo"><asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx"   runat="server">Administración de Configuración</asp:HyperLink></span><br />
 <%} %>

 <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
              { %>
         <span class="titulo"><asp:HyperLink ID="HyperLink2" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx"   runat="server">Administración de Mensaje</asp:HyperLink></span><br />
         <%} %>

         <%if (!(Session["permisos"].ToString().IndexOf("AdmCat") < 0))
           { %>
          <span class="titulo"><asp:HyperLink ID="HyperLink6" NavigateUrl="~/menuReceDHL/adminCat.aspx"   runat="server" >Administración de Catálogos</asp:HyperLink></span><br />
          <%} %>

 <span class="tituloActive">Reportes</span>
    </ul> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
