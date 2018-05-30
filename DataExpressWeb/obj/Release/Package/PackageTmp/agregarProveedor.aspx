<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarProveedor.aspx.cs" Inherits="DataExpressWeb.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
         #bus2 {
		position: absolute;
		left: 537px;
		top: 151px;
		z-index: 1;
            height: 33px;
            width: 106px;
        }
        .style6
        {
            width: 348px;
            font-family:Arial;
            font-size:12px;
        }
        .style7
        {
            width: 500px;
            font-family:Arial;
            font-size:12px;
        }
        .style8
        {
            height: 26px;
            font-family:Arial;
            font-size:12px;
        }
        .style9
        {
            width: 93px;
            font-family:Arial;
            font-size:12px;
        }
        .style10
        {
            height: 26px;
            width: 93px;
            font-family:Arial;
            font-size:12px;
        }
        .panel1
        {
            
            margin-right:450px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 1207px">
<tr>
<td class="style6">
    
    &nbsp;</td>
<td class="style7">
<center>
    <asp:Panel ID="Panel1" runat="server" BackColor="#FCFCFC" BorderColor="Gray" BorderWidth="1px"
        BorderStyle="solid" Height="380px" Width="382px" CssClass="panel1">
        <asp:Panel ID="Panel2" runat="server" BackColor="#CC0000" Font-Bold="True" Font-Size="12px" Font-Names="Arial"
            ForeColor="White" Height="16px" Width="380px">
            REGISTRO DE PROVEEDOR</asp:Panel>
        <br />
        <asp:Panel ID="Panel3" runat="server" BorderColor="gray" BorderStyle="none" BorderWidth="1px"
            Height="255px" Width="334px">
            <table style="width: 257px; height: 47px">
            
                <tr>
                    <td class="style9">
                        RFC:</td>
                    <td>
                        <asp:TextBox ID="Trfc" Style="text-transform: uppercase" runat="server" 
                            MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        RAZÓN SOCIAL:</td>
                    <td class="style8">
                        <asp:TextBox ID="Trz" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <br />
            <table style="width: 333px; font-family:Arial;
            font-size:12px;">
            <tr>
            <td style="font-weight: bold; font-family:Arial; font-size:12px;">DATOS DE CONTACTO</td>
            </tr>
            </table>

            <br />

            <table style="width: 325px; font-family:Arial;
            font-size:12px;">
            <tr>
            <td>NOMBRE DEL CONTACTO:</td>
            <td>
                <asp:TextBox ID="Tct" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>TELÉFONO:</td>
            <td>
                <asp:TextBox ID="Ttel" runat="server" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>DIRECCIÓN DE CORREO:</td>
            <td>
                <asp:TextBox ID="Tcor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>NOMBRE DE USUARIO</td>
            <td>
                <asp:TextBox ID="Tus" runat="server"></asp:TextBox>
                </td>
            </tr>
            </table>
        </asp:Panel>
        <br />
       <br />
       <br />
<asp:Button ID="bSesion" runat="server" BackColor="#CC0000" 
            BorderColor="#CC0000" BorderStyle="solid" Font-Size="12px" Font-Names="arial" Font-Bold="true" ForeColor="White"
            Text="Aceptar" onclick="bSesion_Click" OnClientClick="return confirm('Seguro que desea registrase como proveedor');" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bSesion0" runat="server" BackColor="#CC0000" 
            BorderColor="#CC0000" BorderStyle="solid" Font-Size="12px" Font-Names="arial" Font-Bold="true" ForeColor="White"
            onclick="bSesion0_Click" Text="Cancelar" />
        &nbsp;<br />
    </asp:Panel>
    </center>
    </td>
<td>&nbsp;</td>
</tr>
</table>

<span id="bus2">
<center style="width: 78px">
<asp:Panel ID="Ppriv" runat="server" BackColor="#FCFCFC" 
        BorderColor="Gray" BorderWidth="1px"
        BorderStyle="solid" Height="22px" Width="74px" CssClass="panel1" 
        Visible="false" ScrollBars="Auto">
        <asp:Panel ID="Panel5" runat="server" BackColor="#CC0000" Font-Bold="True" 
            Font-Size="12px" Font-Names="Arial"
            ForeColor="White" Height="16px" Width="604px">
           
            ¡ AVISO DE PRIVACIDAD !</asp:Panel>
            <br/>
        <asp:TextBox ID="TextBox1" runat="server" Font-Names="Arial" Font-Size="12px" 
            Height="262px" ReadOnly="True" TextMode="MultiLine" Width="535px">AQUIE VA EL AVISO DE PRIVACIDAD</asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="Button2" runat="server" BackColor="#d40511" 
            BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" 
            Height="23px" onclick="Button2_Click" Text="Aceptar" Width="87px" 
            onclientclick="return confirm('¡ Está acepatando los términos y condiciones !');" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" BackColor="#d40511" 
            BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" 
            Height="23px" Text="Cancelar" Width="87px" onclick="Button1_Click" />
        <br/>
            </asp:Panel>
            </center>

            </span>
</asp:Content>
