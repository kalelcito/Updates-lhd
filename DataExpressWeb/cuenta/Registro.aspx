<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="DataExpressWeb.Registro" %>

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style type="text/css">
    <style type="text/css">
        #Text1
        {
            margin-right: 1px;
        }
        .style1
        {
            color: #FF3300;
        }
           .columnRight
                 {
                     height:500px;
    float:right;
    width:1010px;
    padding:10px;
                     }
        .columnLeft
             {
    border-width:1px;
    border-right-style:solid;
    border-right-color:#F5F5F5;
    box-shadow:10px 0px 15px #F5F5F5;
    height:500px;
    float:left;
   /* margin-right:20px;
    padding:20px*/
                 }
.boton
{
color:#ffffff;
font-family:Arial;
border-color:#C90101 ;
background-color:#C90101 ;
border-style:solid;
font-size:normal;
float:right;
}
.boton:hover
{
color:#ffcc00;
}

        .dhlImage3
        {
            float:right;
            }
            .dhlImage1
            {text-align:center;
                }
                .dhlImage2
                {
                    float:left;
                    }
                    .textbox
                    {
                        padding:0 0 0 1em;
                        }
                        .footer
{   /*position:static;
    top:5px;*/
    color: #ffcc00;
    clear:both;
    background-color:#ffcc00;
  Height:36px; Width:100%;
   

}
.dhlLogo
{
    padding:.5em 0 0 1.75em;
    }

    </style>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
 <div class="logo" style="border: 0px solid #ffcc00; width:100%; position:absolute; top:0; right:0px;
 background-color: #ffcc00; height: 50px;" ">
    <asp:Image ID="Image1" CssClass="dhlLogo" runat="server" Height="29px" ImageUrl="~/Imagenes-dhl/logp-dhl.jpg" Width="164px"  />
    </div>
    <br />
     <fieldset style="width:473px">
      <legend>Datos de Registro</legend>
        RFC Usuario:<br />
         <asp:TextBox ID="tbRfcuser" runat="server" Width="160px"></asp:TextBox>
         <br />
         E-mail:<br />
         <asp:TextBox ID="tbEmail" runat="server" Width="279px"></asp:TextBox>
         <br />
        Contraseña:<br />
         <asp:TextBox ID="tbPass" runat="server" Width="160px" TextMode="Password" 
            ></asp:TextBox>
         <br />
         Confirmar
        Contraseña:<br />
         <asp:TextBox ID="tbPass0" runat="server" Width="160px" TextMode="Password"></asp:TextBox>
         <br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
             ErrorMessage="RFC Invalido" ControlToValidate="tbRfcuser" 
             ValidationExpression="^([A-Z\s]{4})\d{6}([A-Z\w]{3})$" CssClass="style1"></asp:RegularExpressionValidator>
         <br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  
             ErrorMessage="Email Invalido" ControlToValidate="tbEmail" 
             ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
             CssClass="style1"></asp:RegularExpressionValidator>
         <br />
         <asp:CompareValidator ID="CompareValidator1" runat="server" 
             ControlToCompare="tbPass" ControlToValidate="tbPass0" 
             ErrorMessage="Confirme la contrasenia Correctamente" CssClass="style1"></asp:CompareValidator>
         <br />
      </fieldset>
     <br />
    <asp:Button ID="bRegistrarse" runat="server" Text="Registrar" 
         onclick="bRegistrarse_Click" />
    <br />
        <div  style="border: 0px solid #ffcc00; width:100%; position:absolute; bottom:0; right:0px; background-color: #ffcc00; height: 50px;" ">
 </div>
 </form>
</body>
</html> 
