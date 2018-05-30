<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="construccion.aspx.cs" Inherits="DataExpressWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            font-size: xx-large;
            font-family: "Comic Sans MS";
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <span class="style1">Pagina en Construccion!
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/construccion.png" />
    </span>
</asp:Content>
