<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviarInv.aspx.cs" Inherits="DataExpressWeb.enviarInv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    
    <fieldset style="width: 441px" >
    <legend>E-mail:</legend>
        Factura:<br />
        <asp:TextBox ID="tbFactura" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;Emails:<br />
        <asp:TextBox ID="tbEmail" runat="server" Height="62px" 
            ontextchanged="TextBox2_TextChanged" Width="353px"></asp:TextBox>
        
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbEmail" ErrorMessage="Requiere email" ForeColor="Red"></asp:RequiredFieldValidator>
        
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="tbEmail" ErrorMessage="Email inválido" ForeColor="Red" 
            ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+((\.[a-z0-9-]+)|(\.[a-z0-9-]+)(\.[a-z]{2,3}))([,][_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+((\.[a-z0-9-]+)|(\.[a-z0-9-]+)(\.[a-z]{2,3})))*$"></asp:RegularExpressionValidator>
        
        <asp:Label ID="Label1" runat="server"></asp:Label>
        
        <br />
        <asp:Label ID="lMensaje" runat="server" ForeColor="#CC0000"></asp:Label>
        
        <br />

        <asp:Button ID="bEnviarEmail" runat="server" onclick="bEnviarEmail_Click" 
            Text="Enviar E-mail" />

        <asp:Label ID="Label2" runat="server"></asp:Label>

        </fieldset>
    </form>
</body>
</html>
