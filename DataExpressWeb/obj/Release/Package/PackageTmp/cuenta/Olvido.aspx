<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Olvido.aspx.cs" Inherits="DataExpressWeb.Olvido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #Text1
        {
            margin-right: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <fieldset style="width:287px">
      <legend>Ingrese su RFC</legend>
        RFC Usuario:<br />
         <asp:TextBox ID="user" runat="server" ></asp:TextBox>
         <br />
         su contraseña ha sido enviada a su  correo electrónico.<br />
      </fieldset>
    <br />
    <asp:Button ID="bEnviar" runat="server" Text="Enviar" />
    <br />
</asp:Content>
