<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OlvideContra.aspx.cs" Inherits="DataExpressWeb.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            width: 508px;
        }
        .style7
        {
            width: 355px;
        }
        .style8
        {
            width: 78px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 1201px">
<tr>
<td class="style7"></td>
<td class="style6">
<center>

    <asp:Panel ID="Panel1" runat="server" BackColor="#FCFCFC" BorderColor="Gray" 
        BorderStyle="solid" BorderWidth="1px" Height="195px" Width="405px">
        <asp:Panel ID="Panel3" runat="server" BackColor="#CC0000" Font-Bold="True" 
            ForeColor="White">
            SOLICITUD DE REESTABLECIMIENTO DE CONTRASEÑA</asp:Panel>
        <br />
        <asp:Panel ID="Panel4" runat="server" BorderColor="Gray" BorderStyle="solid" 
            Height="100px" Width="365px">

            <table style="width: 361px; height: 67px">
            <tr>
            <td class="style8">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes-dhl/olcon.PNG" />
                </td>
            <td>
             <table style="width: 260px">
             <tr>
             <td class="style8"></td>
             <td>Porfavor, igrese su RFC y Usuario</td>
             </tr>
             <tr>
             <td class="style8">RFC:</td>
             <td>
                 <asp:TextBox ID="rfc" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
             <td class="style8">Usuario:</td>
             <td>
                 <asp:TextBox ID="usu" runat="server"></asp:TextBox>
                 </td>
             </tr>
             </table>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Button ID="bLimpiar" runat="server" BackColor="#CC0000" ForeColor="White" 
            BorderColor="#CC0000" BorderStyle="solid" Font-Size="12px"  Font-Names="Arial" Font-Bold="true"
            Text="Aceptar" onclick="bLimpiar_Click" OnClientClick="return confirm('Seguro que desea reestablecer su contraseña');" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bLimpiar0" runat="server" BackColor="#CC0000" 
            BorderColor="#CC0000" BorderStyle="solid" Font-Size="12px"  Font-Names="Arial" Font-Bold="true" ForeColor="White"
            onclick="bLimpiar0_Click" Text="Cancelar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </asp:Panel>

</center>
</td>
<td>&nbsp;</td>
</tr>
</table>
</asp:Content>
