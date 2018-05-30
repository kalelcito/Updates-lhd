<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar.aspx.cs" Inherits="DataRecepcionWeb.enviar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    
    <form id="form1" runat="server">
    
       <table style="width:100%;">
           <tr>
               <td>
                   <table style="width:100%;">
                       <tr>
                           <td>
                               Detalles de Validación:&nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               <asp:TextBox ID="tbFactura" runat="server" Height="328px" Width="683px" 
                                   TextMode="MultiLine"></asp:TextBox>
                           </td>
                       </tr>
                   </table>
               </td>
           </tr>
           <tr>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td>
                   &nbsp;</td>
           </tr>
       </table>
    
       </form>
</body>
</html>
