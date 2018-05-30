<%@ Page Title="Mostrar" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="servermail.aspx.cs" Inherits="DataExpressWeb.configuracion.email.servermail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
        <style type="text/css">
            .style1
            {
                width: 243px;
            }
            .style2
            {
                width: 243px;
                height: 26px;
            }
            .style3
            {
                font-size: 1em;
            }
        </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<body>
 <fieldset>
 <legend>  <strong><span class="style3">Configuración del Servidor de Correos</span></strong> 
 </legend>
<table style="width: 56%; height: 157px;">
            <tr>
                <td class="style1">
                    Servidor SMTP:</td>
                <td>
                    <asp:TextBox ID="tbServidor" runat="server" Width="349px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Puerto:
                </td>
                <td>
                    <asp:TextBox ID="tbPuerto" runat="server" Width="349px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Usuario:
                </td>
                <td>
                    <asp:TextBox ID="tbUsuario" runat="server" Width="347px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Contraseña</td>
                <td>
                    <asp:TextBox ID="tbPassword" runat="server" Width="346px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>

        <tr>
            <td class="style1">
                SSL:
            </td>
            <td class="style2">
                <asp:CheckBox ID="cbSSL" runat="server" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                E-mail de envio:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbEmailEnvio" runat="server" Width="348px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        </table>
     <center>      
         <asp:Button ID="bModificar" runat="server" style="text-align: center" 
           Text="Modificar" onclick="bModificar_Click" />
         <asp:Button ID="bActualizar" runat="server" onclick="bActualizar_Click" 
             Text="Actualizar" Visible="False" />
</center>
</fieldset>
</body>

       

</asp:Content>