<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DataExpressWeb.Login" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
        .columnRight {
            height: 300px;
            float: right;
            width: 800px;
            padding: 10px;
        }

        .columnLeft {
            border-width: 1px;
            border-right-style: solid;
            Privacidad .aspx border-right-color:#F5F5F5;
            box-shadow: 10px 0px 15px #F5F5F5;
            height: 500px;
            float: left;
            /* margin-right:20px;
    padding:20px*/
        }

        .boton {
            color: #ffffff;
            font-family: Arial;
            border-color: #C90101;
            background-color: #C90101;
            border-style: solid;
            font-size: normal;
            float: left;
        }

            .boton:hover {
                color: #ffcc00;
            }


        .dhlImage1 {
            text-align: center;
            position: absolute;
            right: 425px;
        }

        .textbox {
            padding: 0 0 0 1em;
        }

        .footer {
            Height: 36px;
            width: 100%;
            float: left;
            background-color: #ffcc00;
        }

        .dhlLogo {
            padding: .5em 0 0 1.75em;
            background-image: url('/Imagenes-dhl/logo-dhl.png');
        }

        h1 {
            font-size: 14px;
            font-weight: bold;
            font-family: Arial;
        }

        #LinkButton1 {
            text-decoration: none;
            font-size: 12px;
            color: #000;
            font-family: Arial;
        }

        #LinkButton2 {
            text-decoration: none;
            font-size: 12px;
            color: #000;
            font-family: Arial;
        }

        #LinkButton1:hover {
            text-decoration: underline;
            color: #CC0000;
        }

        #LinkButton2:hover {
            text-decoration: underline;
            color: #CC0000;
        }

        .dhlLogo {
            padding: 1em 0 0 1.75em;
            background-image: url('Imagenes-dhl/logo-dhl.png');
            height: 29px;
            width: 120px;
            position: absolute;
        }

        .mensaje {
            font-size: 12px;
            font-family: Arial;
        }

        body,
        html {
            margin: 0;
            padding: 0;
            color: #000;
            /* background:#a7a09a;*/
        }

        .wrapper {
            width: 100%;
            margin: 0 auto;
            background: #fff;
        }

        .main {
            width: 98%;
            margin: 0 auto;
            background: #fff;
        }

        .header {
            border: 0px solid #ffcc00;
            width: 100%;
            background-color: #ffcc00;
            height: 68px;
        }

        .logo {
            height: 42px;
            width: 113px;
            padding: 1em 0 0 1.75em;
        }

        .boton {
            color: #ffffff;
            font-family: Arial;
            border-color: #C90101;
            background-color: #C90101;
            border-style: solid;
            font-size: normal;
        }

            .boton:hover {
                color: #ffcc00;
            }



        .style1 {
            height: 22px;
        }

        .panelWrapper {
            background-color: #e8e8e4;
            border-style: solid;
            border-color: #d40511;
            border-width: 1px;
        }

        #panelMensaje {
            align-content: center;
            margin-right: 30%;
            margin-left: 0%;
        }
    </style>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrapper">

            <div class="header">
                <asp:Image ID="Image1" CssClass="logo" runat="server" ImageUrl="~/Imagenes-dhl/logo-dhl.png" />
            </div>
            <div class="main">
                <div class="columnLeft">
                    <br />
                    <br />
                    <br />
                    <br />
                    <h1>Iniciar sesión</h1>
                    <br />
                    <div class="textbox">
                        <br />
                        <asp:DropDownList ID="DropDownList1" runat="server"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True" Height="18px" Width="153px">
                            <asp:ListItem>Selecciona ingreso</asp:ListItem>
                            <asp:ListItem>Proveedor</asp:ListItem>
                            <asp:ListItem Value="Administrador">Empleado</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="14px"
                            Text="RFC:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbrfc" runat="server" Visible="False"></asp:TextBox>
                        <br />
                        &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="14px"
                            Text="Usuario:" Visible="false"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbRfcuser" runat="server" Visible="False"></asp:TextBox>
                        <br />
                        &nbsp;<asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="14px"
                            Text="Contraseña:" Visible="false"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbPass" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:LinkButton ID="LinkButton1" runat="server"
                            NavigateUrl="~/Privacidad.aspx" OnClick="LinkButton1_Click">¿Nuevo Proveedor? Regístrese ahora.</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton2" runat="server" NavigateUrl="~/OlvideContra.aspx"
                            OnClick="LinkButton2_Click">¿Olvidó su contraseña?</asp:LinkButton>
                    </div>
                    <br />
                    <asp:Label ID="not" runat="server" Font-Names="Arial" Font-Size="12px"
                        ForeColor="#CC0000"></asp:Label>
                    <br />
                    <asp:Button CssClass="boton" ID="bSesion" runat="server" OnClick="bSesion_Click" Text="Iniciar sesión" />
                    <asp:Label ID="lMensaje" runat="server" ForeColor="Red"></asp:Label>

                    <asp:Button CssClass="boton" ID="bRegistrar" runat="server" Text="Registrarse como proveedor" OnClick="bRegistrar_Click" Visible="false" />
                    <asp:Button ID="bOlvide" runat="server" Text="Olvide mi contraseña" OnClick="bOlvide_Click" Visible="false" />
                    <asp:Button ID="bLimpiar" runat="server" Text="Limpiar" OnClick="bLimpiar_Click" Visible="false" />
                </div>


                <div class="columnRight">

                    <asp:Panel ID="Pmsj" runat="server" ScrollBars="Auto"
                        Visible="False">
                        <center>
                            <table style="width: auto; height: auto;">
                                <tr>
                                    <td class="style1" align="center">
                                        <asp:Label ID="Ltit" runat="server" Font-Bold="True" Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Lmsj" runat="server" Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </asp:Panel>
                    <br />
                    <br />
                    <div id="panelMensaje">
                        <asp:Panel ID="PanelMensaje" CssClass="panelWrapper" runat="server"
                            BorderStyle="Groove" HorizontalAlign="Left" Visible="False">
                            <asp:Panel ID="pMensaje" runat="server" Visible="False">
                                <center>
                                    <table style="width: auto; height: auto;">
                                        <tr>
                                            <td class="style1" align="center">
                                                <asp:Label ID="titulo" runat="server" Font-Bold="True" Font-Names="Arial"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="justify">
                                                <asp:Label ID="mensaje" runat="server" Font-Names="Arial"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1" align="center">
                                                <asp:Label ID="TextCom" runat="server" Font-Names="Arial" Text="Comunicado Proveedores DSC"></asp:Label>
                                                <a href="../Imagenes-dhl/Proveedores DSC.pdf" target="_blank">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes-dhl/cfdiv33.PNG" Width="60px" Height="60px" />
                                                </a>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="style1" align="center">
                                                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Text="Comunicado Transportistas DSC"></asp:Label>
                                                <a href="../Imagenes-dhl/Proveedores DSC - Transportistas.pdf" target="_blank">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes-dhl/cfdiv33.PNG" Width="60px" Height="60px" />
                                                </a>
                                            </td>

                                        </tr>
                                    </table>
                                </center>
                            </asp:Panel>
                            <center>
                                <asp:Panel ID="Panel46" runat="server" Height="27px" HorizontalAlign="Right" BackColor="#C0C0C0">
                                    <asp:Button ID="ButtonAceptar" runat="server" BackColor="#d40511"
                                        BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px"
                                        Text="Aceptar" Width="87px" ForeColor="White" OnClick="ButtonAceptar_Click" />&nbsp&nbsp&nbsp&nbsp
                                </asp:Panel>
                            </center>
                        </asp:Panel>
                    </div>
                    <div class="dhlImage1">
                        <center>
                            <span class="mensaje"></span>
                        </center>
                        <a href="../Imagenes-dhl/aviso portal.pdf" target="_blank">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes-dhl/manu.PNG" />
                        </a>
                    </div>
                </div>
            </div>
        </div>


    </form>
</body>
</html>

