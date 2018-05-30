<%@ Page Title="Mostrar" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Mostrar.aspx.cs" Inherits="ups.Mostrar" %>

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
        </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <body>
   <fieldset>
   <legend> Configuración General </legend>
        <table style="width: 77%; height: 157px;">
            <tr>
            <td class="style1">
                Directorio de Documentos:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbDirdocs" runat="server" Width="496px" ReadOnly="True" 
                    Height="16px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Directorio de Txt:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbDirtxt" runat="server" Width="496px" ReadOnly="True" 
                    ontextchanged="tbDirtxt_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Directorio de Respaldo:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbDirrespaldo" runat="server" Width="496px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                email_Notificación:</td>
            <td class="style2">
                <asp:TextBox ID="tbemalNotificacion" runat="server" Width="496px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:TextBox ID="tbDircerti" runat="server" Width="496px" ReadOnly="True" 
                    Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:TextBox ID="tbDirllaves" runat="server" Width="497px" ReadOnly="True" 
                    Visible="False"></asp:TextBox>
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