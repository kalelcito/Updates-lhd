<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminMensaje.aspx.cs" Inherits="DataExpressWeb.Formulario_web126" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style7
        {
            text-align: center;
            width: 602px;
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
	width:100px;
	
}
        .style9
        {
            width: 202px;
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

      

      <span class="tituloActive">Administración de Mensaje</span><br />

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
    <asp:Panel ID="Panel2" runat="server" Height="444px" Width="724px" 
                        style="margin-top: 9px; "  BackColor="#FCFCFC" BorderColor="gray" 
                        BorderStyle="solid">
    <table style="height: 433px; width: 720px; font-family: Arial; font-size: 12px;">
    <tr>
        <td colspan="4" align="center"><strong>Configuración del Mensaje Principal<br /> </strong></td>
      </tr>
      <tr>
        <td class="style9">Tamaño del cuadro del mensaje:</td>
        <td colspan="3">
            <asp:TextBox ID="Ttama" runat="server" Height="28px" Width="144px" 
                MaxLength="7"></asp:TextBox>
            &nbsp; (formato: ancho [1 a 3 números] -largo [1 a 3 números])</td>
        
      </tr>
      <tr>
        <td class="style9">Color del cuadro del mesaje:</td>
        <td class="style19">
            <asp:TextBox ID="TcolPan" runat="server" Height="26px" Width="144px" 
                Columns="7" MaxLength="7"></asp:TextBox>
            (formato: hexadecimal)</td>
        <td align="center" class="style16">
            <asp:Button ID="Button1" runat="server" Text="Validar Color" Height="26px" 
                Width="93px" onclick="Button1_Click" />
          </td>
          <td align="center">
              <asp:Panel ID="P1" runat="server" BorderColor="Black" BorderStyle="Solid" 
                  BorderWidth="2px" Width="18px" Height="18px">
                  </asp:Panel>
              <asp:Label ID="m" runat="server" Font-Size="9px" ForeColor="#D40511" 
                  Visible="False"></asp:Label>
          </td>
      </tr>
      <tr>
        <td class="style9">Texto del título del mensaje:</td>
        <td class="style10" colspan="3">
            <asp:TextBox ID="Ttitulo" runat="server" Width="316px" Height="27px"></asp:TextBox>
          </td>

      </tr>
      <tr>
        <td class="style9">Color de la letra del título:</td>
        <td class="style19">
            <asp:TextBox ID="TcolTit" runat="server" Height="27px" Width="144px" 
                MaxLength="7"></asp:TextBox>
            (formato: hexadecimal)</td>
        <td  align="center" class="style16">
            <asp:Button ID="Button2" runat="server" Height="26px" Text="Validar Color" 
                Width="91px" onclick="Button2_Click" />
          </td>
        <td align="center">
            <asp:Panel ID="P2" runat="server" BorderColor="Black" BorderStyle="Solid" 
                BorderWidth="2px" Width="18px" Height="18px">
                </asp:Panel>
            <asp:Label ID="m2" runat="server" Font-Size="9px" ForeColor="#D40511" 
                  Visible="False"></asp:Label>
          </td>
      </tr>
      <tr>
        <td class="style9">Cuerpo del mensaje:</td>
        <td class="style21" colspan="3">
            <asp:TextBox ID="Tcuerpo" runat="server" TextMode="MultiLine" Height="41px" 
                Width="318px" Font-Names="Arial"></asp:TextBox>
            &nbsp;<br /> (saltos de línea: poner el símbolo &quot;&amp;&quot;)</td>
      </tr>
      <tr>
        <td class="style9">Color de la letra del mensaje:</td>
        <td class="style19">
            <asp:TextBox ID="TcolorCuer" runat="server" Height="27px" Width="148px" 
                MaxLength="7"></asp:TextBox>
            (formato: hexadecimal)</td>
        <td align="center" class="style16">
            <asp:Button ID="Button3" runat="server" Height="26px" Text="Validar Color" 
                Width="93px" onclick="Button3_Click" />
          </td>
        <td align="center">
         <asp:Panel ID="P3" runat="server" BorderColor="Black" BorderStyle="Solid" 
                BorderWidth="2px" Width="18px" Height="18px">
             </asp:Panel>
            <asp:Label ID="m3" runat="server" Font-Size="9px" ForeColor="#D40511" 
                  Visible="False"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="style9">&nbsp;</td>
        <td class="style19">Habilitar:
            <asp:CheckBox ID="Check" runat="server" />
          </td>
        <td class="style16"></td>
        <td></td>
      </tr>
      <tr>
        <td colspan="4" align="center">
            <asp:Label ID="mensaje" runat="server" ForeColor="#D40511"></asp:Label>
            <br />
          </td>
      </tr>

      <tr>
        <td class="style9">Ultima modificación:
            <br />
            &nbsp;<asp:Label ID="Lfecha" runat="server" ForeColor="#D40511"></asp:Label>
          </td>
        <td class="style19">&nbsp;</td>
        <td class="style12" colspan="2">
            <asp:Button ID="Button4" runat="server" BackColor="#D40511" ForeColor="White" 
                Text="Actualizar" onclick="Button4_Click" />
          </td>
      </tr>
    </table>
 </asp:Panel>
</asp:Content>

