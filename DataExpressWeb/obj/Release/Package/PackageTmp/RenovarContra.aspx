<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RenovarContra.aspx.cs" Inherits="DataExpressWeb.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            width: 1167px;
        }
        .style7
        {
            width: 1074px;
        }
        .style8
        {
            width: 989px;
        }
        .style9
        {
            height: 19px;
        }
        .style11
        {
            height: 29px;
        }
        .style16
        {
            height: 4px;
            font-family:Arial;
            font-size:12px;
        }
        .style17
        {
            height: 21px;
            font-family:Arial;
            font-size:12px;
        }
        .style18
        {
            height: 23px;
        }
        .style19
        {
            height: 16px;
            font-family:Arial;
            font-size:12px;
        }
        .style20
        {
            height: 29px;
            width: 28px;
        }
        .style21
        {
            font-size: 9px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="height: 501px">
<tr>
<td colspan="3">
    <br />
    </td>
</tr>
<tr>
<td class="style8"></td>
<td class="style7">
<center>
    <asp:Panel ID="Panel1" runat="server" Width="386px" BackColor="#FCFCFC" 
        BorderColor="Gray" BorderStyle="solid" Height="459px" BorderWidth="1px">
        <asp:Panel ID="Panel2" runat="server" BackColor="#CC0000" Font-Bold="True" 
            ForeColor="White" Height="22px">
            RENOVACIÓN DE CONTRASEÑA</asp:Panel>
        <br />
        <asp:Panel ID="Panel3" runat="server" BorderColor="#FCFCFC" BorderStyle="solid" BorderWidth="1px" 
            Height="358px" Width="358px">
            <table style="width: 340px; height: 350px; font-weight: bold;">
            <tr>
            <td class="style20" style="color: #FF0000">
                <center style="width: 207px; font-family:Arial;
            font-size:12px;">FAVOR DE MODIFICAR Y ACTUALIZAR SU CONTRASEÑA<br />
                    <span class="style21">(Deberá de ser de mínimo de 8 caracteres, incluyendo 
                    minúsculas, mayúsculas, números y caracteres especiales)</span></center> </td>
            <td class="style11">
                <asp:Image ID="Image3" runat="server" />
                </td>
            </tr>
            <tr>
            <td colspan="2" class="style17"><center> CONTRASEÑA ACTUAL:</center></td>
            </tr>
            <tr>
            <td colspan="2" class="style18">
            <center>
                <asp:TextBox ID="vieja" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                </center>
                </td>
            </tr>
            <tr>
            <td colspan="2" class="style19"><center> NUEVA CONTRASEÑA:</center></td>
            </tr>
            <tr>
            <td colspan="2" class="style17">
            <center>
                <asp:TextBox ID="nueva" runat="server" Width="156px"></asp:TextBox>
                </center>
                </td>
            </tr>
            <tr>
            <td  colspan="2" class="style9">
            <center>
                <asp:Image ID="Image2" runat="server" Height="23px" 
                    ImageUrl="~/Imagenes-dhl/barra.PNG" Width="162px" />
                </center>
                </td>
            </tr>
            <tr>
            <td colspan="2" class="style16"><center>CONFIRMA TU NUEVA CONTRASEÑA</center></td>
            </tr>
            <tr>
            <td colspan="2" class="style9">
            <center>
                <asp:TextBox ID="confir" runat="server" Width="155px"></asp:TextBox>
                </center>
                </td>
            </tr>
            <tr>
              <td colspan="2" align="center">
                  <asp:Label ID="msj" runat="server" Font-Names="Arial" Font-Size="12px" 
                      ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Button ID="ace" runat="server" BackColor="#CC0000" BorderColor="#CC0000" 
            BorderStyle="solid" Font-Bold="True" Font-Names="arial" Font-Size="12px" ForeColor="White"
            style="text-align: center; margin-top: 0px;" Text="Aceptar" 
            onclick="ace_Click" 
            onclientclick="return confirm('Seguro que desea renovar su contraseña');" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="caN" runat="server" BackColor="#CC0000" BorderColor="#CC0000" ForeColor="White" 
            BorderStyle="solid" Font-Bold="True" Font-Names="arial" Font-Size="12px"
            style="text-align: center; margin-top: 0px;" Text="Cancelar" 
            onclick="caN_Click" />
    </asp:Panel>
</center>
    </td>
<td class="style6"></td>
</tr>
</table>
</asp:Content>
