<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminCat.aspx.cs" Inherits="DataExpressWeb.Formulario_web128" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
            .navigation
        {
            text-decoration:none;
            
            
            }
                  .panelBodyWrapper
{
    border:1px ridge #666666;
    }
            
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
                
                 #bus12 {
		position: absolute;
		left: 626px;
		top: 143px;
		z-index: 1;
            height: 30px;
            width: 110px;
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
	width:100px;
	
}
        .style10
    {
        height: 46px;
    }
    .style12
    {
        width: 197px;
    }
    .style13
    {
        width: 293px;
        height: 126px;
    }
    .style14
    {
        width: 197px;
        height: 47px;
    }
    .style15
    {
        width: 248px;
        height: 47px;
    }
    .style16
    {
        height: 47px;
        width: 194px;
    }
    .style17
    {
        width: 248px;
    }
    .style18
    {
        width: 197px;
        height: 126px;
    }
    .style19
    {
        width: 194px;
    }
        .style22
        {
            width: 197px;
            height: 84px;
        }
        .style23
        {
            width: 248px;
            height: 84px;
        }
        .style24
        {
            height: 415px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MenuIzquierdo" runat="server">
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
      <span class="titulo"><asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx"   runat="server" >Administración de Configuración</asp:HyperLink></span><br />
      <%} %>

      <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
      { %>
     <span class="titulo"><asp:HyperLink ID="HyperLink6" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx"   runat="server" >Administración de Mensaje</asp:HyperLink></span><br />
       <%} %>

      <span class="tituloActive">Administración de Catálogos</span><br />

      <%if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
        { %>
    <span class="titulo"><asp:HyperLink ID="HyperLink2" NavigateUrl="~/reportes/reporteSucursalesA.aspx"  runat="server">Reportes</asp:HyperLink></span><br />
    <%} %>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel2" runat="server" Height="530px" Width="800px" 
                        style="margin-top: 9px; "  BackColor="#FCFCFC" BorderColor="gray" 
                        BorderStyle="solid" ScrollBars="Horizontal">
 <table style="width: 799px; height: 497px">
 <tr>
  <td colspan="2" align="center" class="style10">
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="12px" Text="Catálogos"></asp:Label>
     </td>
     <td>
      <span id="bus12">
                              <center>
                              <asp:Panel CssClass="panelWrapper" ID="PanelSeg" runat="server" ScrollBars="Auto" 
                                      Height="23px" Width="102px" Visible="false">

                                  <%-- ////////////////PARA LA SEGURIDAD DEL ADMINISTRADOR///////////////////////
        <asp:Panel CssClass="panelHeader" ID="Panel1" runat="server">Ingrese los datos de un administrador</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel3" runat="server" Width="369px" Height="129px">
            <br />
                <table class="formEditar">
                 <tr>
                  <td align="center">
                  <asp:Label ID="Label376" runat="server" Text="Usuario:" Font-Names="Arial" 
                          Font-Size="12px"></asp:Label>
                  </td> 
                  <td align="center">
                      <asp:TextBox ID="TextUser" runat="server" Font-Names="Arial" Font-Size="12px" 
                          Height="23px" Width="145px"></asp:TextBox>
                  </td>
                 </tr>
                 <tr>
                  <td align="center">
                  <asp:Label ID="Label5098" runat="server" Text="Contraseña:" Font-Names="Arial" 
                          Font-Size="12px"></asp:Label>
                  </td>
                  <td align="center">
                      <asp:TextBox ID="TextPas" runat="server" Font-Names="Arial" Font-Size="12px" 
                          Height="23px" Width="145px" TextMode="Password"></asp:TextBox>
                     </td>
                 </tr>
                </table>
                </asp:Panel>
                                      --%>
                <asp:Label ID="LabelMENSAJE" runat="server" Text="Está seguro que desea actualizar la información?" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                   <br />
<asp:Button CssClass="botonForm"  ID="But2" runat="server"  Text="Actualizar" 
                                      onclick="But2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="But" runat="server"  Text="Cancelar" onclick="But_Click" /> <%--onclick="Button12_Click"--%>
<br />
                </asp:Panel>
                </center>
                </span>
     </td>
 </tr>
 <tr>
  <td class="style12" align="center">
      <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="12px" Text="Selecciona el Catálogo:"></asp:Label>
     </td>
  <td class="style17" align="center">
      <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Arial" 
          Font-Size="12px" Height="30px" Width="186px" 
          onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
          AutoPostBack="True">
          <asp:ListItem>Seleccionar</asp:ListItem>
          <asp:ListItem>Proveedores</asp:ListItem>
          <asp:ListItem Value="Catalogo-Analistas">Catálogo de Analistas A</asp:ListItem>
          <%--<asp:ListItem Value="Catalogo-Analistas2">Catálogo de Analistas B</asp:ListItem>--%>
      </asp:DropDownList>
     </td>
  <td class="style19"></td>
 </tr>
<tr>
<td colspan="3" align="center" class="style24">
    <asp:Panel ID="PanCat" runat="server" Height="410px" Visible="False">
    <table style="width: 780px; height: 405px;">
    <tr>
    <td>
        <asp:Label ID="LabelN" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="12px" Text="Subir Catálogo:" Visible="False"></asp:Label>
    </td>
    <td align="left">
        <asp:FileUpload ID="ArcCat" runat="server" Font-Names="Arial" 
            Font-Size="12px" Visible="False" />
        <br />
        <asp:Label ID="Lms5" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="10px" ForeColor="#CC0000" Visible="False"></asp:Label>
    </td>
    <td>
        <asp:Button ID="ButCat" runat="server" Text="Subir Catálogo" 
            onclick="Button5_Click" 
            OnClientClick="return confirm('El archivo a subir deberá incluir el formato adecuado de lo contrario podría causar inconvenientes');" 
            Visible="False" />
    </td>
    </tr>
    <tr>
  <td class="style14">
      <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="12px"></asp:Label>
     </td>
  <td class="style15">
      <asp:TextBox ID="TextBusc" runat="server" Font-Names="Arial" Font-Size="12px" 
          Height="25px" Width="179px"></asp:TextBox>
      <asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="12px" 
          Text="Buscar" onclick="Button2_Click" />
     </td>
  <td class="style16">
      <asp:Label ID="Lms1" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="10px" ForeColor="#CC0000"></asp:Label>
     </td>
 </tr>
  <tr>
   <td class="style14">
      <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="12px" Text="Centro de costos: "></asp:Label>
     </td>
       <td class="style15">
      <asp:TextBox ID="Centro1" runat="server" Font-Names="Arial" Font-Size="12px" 
          Height="25px" Width="79px"></asp:TextBox>
      <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="12px" Text="-"></asp:Label>
      <asp:TextBox ID="Centro2" runat="server" Font-Names="Arial" Font-Size="12px" 
          Height="25px" Width="79px"></asp:TextBox>
           <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="12px" 
          Text="Buscar" onclick="ButtonCC_Click" />
     </td>
 </tr>
 <tr>
  <td class="style18"></td>
  <td class="style13" colspan="2">
      <asp:ListBox ID="ListaReg" runat="server" Width="506px"></asp:ListBox>
      <br />
      <asp:Button ID="ButEdit" runat="server" Font-Names="Arial" Font-Size="12px" 
          Text="Editar" onclick="ButEdit_Click" />
      <br />
      <asp:Label ID="Lms2" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="10px" ForeColor="#CC0000"></asp:Label>
     </td>
 </tr>
 <tr>
  <td class="style22"></td>
  <td class="style23" colspan="2">
      <asp:TextBox ID="TextMod" runat="server" Font-Names="Arial" Font-Size="12px" 
          Height="24px" Width="506px"></asp:TextBox>
      <br />
      <asp:Label ID="Lform" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="10px" ForeColor="Black"></asp:Label>
      <br />
      <asp:Button ID="Button3" runat="server" Font-Names="Arial" Font-Size="12px" 
          onclick="Button3_Click" Text="Modificar" />
      <br />
      <asp:Label ID="Lms3" runat="server" Font-Bold="True" Font-Names="Arial" 
          Font-Size="10px" ForeColor="#CC0000"></asp:Label>
     </td>
 </tr>
 <tr>
 <td>
     <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
         Font-Size="12px" Text="Agregar nuevo registro:"></asp:Label>
 </td>
 <td colspan="3" align="left">
     <asp:TextBox ID="TextAgre" runat="server" Font-Names="Arial" Font-Size="12px" 
         Height="24px" Width="506px"></asp:TextBox>
     <br />
     </td>
 </tr>
 <tr>
 <td></td>
 <td colspan="2" align="left">
     <asp:Label ID="Lform1" runat="server" Font-Bold="True" Font-Names="Arial" 
         Font-Size="10px" ForeColor="Black"></asp:Label>
     <br />
     <asp:Button ID="Button4" runat="server" Font-Names="Arial" Font-Size="12px" 
         onclick="Button4_Click" Text="Agregar" />
     <br />
     <asp:Label ID="Lms4" runat="server" Font-Bold="True" Font-Names="Arial" 
         Font-Size="10px" ForeColor="#CC0000"></asp:Label>
     </td>
 </tr>
    </table>
    </asp:Panel>
    </td>
</tr>
 </table>
 </asp:Panel>
</asp:Content>
