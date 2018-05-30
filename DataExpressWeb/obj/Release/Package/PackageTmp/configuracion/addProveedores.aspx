<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addProveedores.aspx.cs" Inherits="DataExpressWeb.addProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 160px;
            height: 26px;
        }
        .style3
        {
            height: 26px;
        }
        .style5
        {
            text-align: left;
        }
        .style7
    {
        width: 160px;
        height: 5px;
    }
    .style8
    {
        height: 5px;
    }
    .style9
    {
        width: 160px;
        height: 47px;
    }
    .style10
    {
        height: 47px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <div class="style5">
            <strong><center>Proveedores<br />
                <br />
            </center></strong></div>
        <table align="center" style="width: 62%;">
            <tr>
                <td class="style2">
                    RFC:
                </td>
                <td class="style3">
                    <asp:TextBox ID="tbRFC" runat="server" Width="305px" style="margin-bottom: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    Razón Social:</td>
                <td class="style10">
                    <asp:TextBox ID="tbNombre" runat="server" Width="306px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <br />
                    </td>
            </tr>
            <tr>
                <td colspan="2"><center>
                    <asp:Button ID="bGuardar" runat="server" style="text-align: center" 
                        Text="Guardar" onclick="bGuardar_Click" />
                        </center>
                </td>
            </tr>
        </table>
        <asp:Label ID="lMensaje" runat="server" ForeColor="#CC3300"></asp:Label>
        <br />
        
    </p>
</asp:Content>
