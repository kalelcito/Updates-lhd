<%@ Page Title="Página principal" Language="C#"  AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DataExpressWeb._Default" %>

        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
       .table
       {
           margin-left:420px;
           margin-right:auto;
           position:fixed;
           top:250px;
           }
           .spanMensaje
           {
               font-family:Arial;
               font-weight:bold;
               font-size:12px;
               }
               .boton
               {
                   margin-left:220px;
                   margin-right:auto;
                   
                   }
                   .boton:hover
                   {
                       color:#ffcc00;
                       }
                       .dhlLogo
                       {padding:1em 0 0 1.75em;
                           }
                   
    </style>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div class="logo" style="border: 0px solid #ffcc00; width:100%; position:absolute; top:0; right:0px;
 background-color: #ffcc00; height: 68px;" ">
    <asp:Image ID="Image1" CssClass="dhlLogo" runat="server" Height="42px" ImageUrl="~/Imagenes-dhl/logo-dhl.png" Width="113px"  />
    </div>
    <table class="table">
<tr>

<td >

    <asp:Panel ID="Panel1" runat="server" Height="115px" Width="469px" 
        BackColor="#FCFCFC" BorderColor="gray" BorderWidth="1px" BorderStyle="solid">

        <asp:Panel ID="Panel3" runat="server" BackColor="#CC0000" Font-Bold="True" 
            ForeColor="White" Font-Names="Arial" HorizontalAlign="Center">
            ¡ ADVERTENCIA !</asp:Panel>
<table style="width: 466px; height: 45px">
<tr>
<td>
    <asp:Image ID="Image2" runat="server" Height="36px" 
        ImageUrl="~/Imagenes-dhl/warning.png" Width="45px" />
    </td>
<td>

<span class="spanMensaje">
    El acceso a esta aplicación está prohibido a personas no autorizadas.</span>
    </center>
    </td>
</tr>
</table>
        <br />
        <asp:Button CssClass="boton" ID="bSesion" runat="server" BackColor="#CC0000" 
            BorderColor="#CC0000" ForeColor="White" BorderStyle="solid" Font-Names="arial" Font-Bold="True" Font-Size="12px" 
            onclick="bSesion_Click" Text="OK" />
    </asp:Panel>
</td>
</tr>
</table>
 </form>
</body>
</html>     

