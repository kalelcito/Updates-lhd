<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="perfilProv.aspx.cs" Inherits="DataExpressWeb.Formulario_web124" %>
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
        width: 203px;
    }

</style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server" >
    <div>
   <center>
   <asp:Panel ID="Panel2" runat="server" Height="505px" Width="569px" 
                        style="margin-top: 9px; "  BackColor="#FCFCFC" BorderColor="gray" 
                        BorderStyle="solid">
                        <br />
                        <br />

     <table style="width: 522px; font-family: Arial; font-size: 12px; height: 351px;">
       <tr>
          <td colspan="2"><center>
              <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                  Text="DATOS DEL PROVEEDOR"></asp:Label>
              <br />
              </center></td>
       </tr>
       <tr>
         <td class="style8">RFC:</td>
         <td>
             <asp:Label ID="Lgrup" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
         <td class="style8">Razón Social:</td>
         <td>
             <asp:Label ID="Lraz" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
         <td>
             Tipo de Proveedor:</td>
         <td>
             <asp:Label ID="Lprov" runat="server"></asp:Label>
         </td>
       </tr>
       <tr>
         <td colspan="2"><center>
             <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                 Text="DATOS DE LOCALIZACIÓN"></asp:Label>
             <br />
             </center></td>
       </tr>
       <tr>
         <td colspan="2"><center>
             <asp:TextBox ID="Tloc" runat="server" Height="76px" ReadOnly="True" 
                 TextMode="MultiLine" Width="374px"></asp:TextBox>
                 </center>
           </td>
       </tr>
       <tr>
         <td colspan="2"><center>
             <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="DATOS EDITABLES"></asp:Label>
             <br />
             </center></td>
       </tr>
       <tr>
         <td class="style9">Nombre del Contacto:</td>
         <td class="style10">
             <asp:TextBox ID="Tnom" runat="server" Width="146px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td>Teléfono:</td>
         <td>
             <asp:TextBox ID="Ttel" runat="server" Width="147px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td>Correo:</td>
         <td>
             &nbsp;<asp:TextBox ID="Tcorr" runat="server" Width="147px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td class="style8">Login:</td>
         <td>
             <asp:TextBox ID="Tlog" runat="server" Width="146px"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td class="style8">Contraseña:</td>
         <td>
             <asp:TextBox ID="Tpass" runat="server" Width="145px"></asp:TextBox>
           </td>
       </tr>
       <tr>
       <td colspan="2"> <center> Fecha de último cambio:&nbsp;
           <asp:Label ID="Lfecha" runat="server" ForeColor="#D40511"></asp:Label>
           <br />
           </center>
           </td>
       </tr>
       <tr>
         <td><center>
             <asp:Button ID="Button1" runat="server" BackColor="#D40511" Font-Bold="True" 
                 Font-Names="Arial" ForeColor="White" onclick="Button1_Click" 
                 Text="Actualizar" OnClientClick="return confirm('Seguro que desea actualizar la información');" />
                 </center>
           </td>
         <td>
         <center>
             <asp:Button ID="Button2" runat="server" BackColor="#D40511" Font-Bold="True" 
                 Font-Names="Arial" ForeColor="White" onclick="Button2_Click" Text="Regresar" />
                 </center>
           </td>
       </tr>
     </table>
     </asp:Panel>
   </center>
  </div>
</asp:Content>

