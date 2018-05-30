<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="validarFacturas.aspx.cs" Inherits="DataExpressWeb.validarFacturas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        body,
        html {
            lMsj margin: 0;
            padding: 0;
            color: #000;
            /* background:#a7a09a;*/
        }

        .btGrisNegrita {
            background-color: #F6CECE;
            color: #FFFFFF;
            font-size: 13px;
            border: 1px solid #333333;
            text-decoration: none;
            border-bottom-color: aliceblue;
            border-color: red;
            border-radius: 3px;
            text-align: center;
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
            height: 29px;
            width: 100px;
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
            font-family: Arial;
            font-size: 12px;
        }

        .style2 {
            font-family: Arial;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server" enctype="multipart/form-data">
        <div class="wrapper">
            <div class="header">
                <asp:Image ID="Image1" CssClass="logo" runat="server" ImageUrl="~/Imagenes-dhl/logo-dhl.png" />
            </div>
            <div class="main">
                <table style="width: 100%;">
                    <tr>
                        <td class="style13">
                            <br />
                            <a href="Default.aspx" style="text-decoration: none"></a>&nbsp;
        <asp:Panel ID="Panel3" runat="server" Height="525px" Width="357px" Style="margin-bottom: 0px" Visible="False">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Style="font-size: small; text-align: center; font-weight: 700;" Text="DETALLE DE VALIDACION DE LA FACTURA DIGITAL BASADO EN EL ANEXO 20"></asp:Label>
                    </td>
                </tr>
            </table>

            <table style="width: 100%;">
                <tr>
                    <td rowspan="2">&nbsp;</td>
                    <td class="style40">
                        <asp:Label ID="Label15" runat="server" Style="font-size: small;"
                            Text="Estatus completo de la factura digital:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style36"></td>
                </tr>
                <tr>
                    <td class="style41">
                        <asp:CheckBox ID="chCertificado" runat="server" Checked="True"
                            Visible="False" />
                        <span class="style9">
                            <asp:FileUpload ID="fuCertificado" runat="server" Visible="False"
                                Width="233px" />
                        </span></td>
                    <td class="style19">
                        <asp:Image ID="imgStatusok" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgStatusx" runat="server" Height="23px"
                            ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                    </td>
                </tr>
                <tr>
                    <td class="style33">
                        <asp:Label ID="Label14" runat="server" CssClass="style20"
                            Text="Ver. del comprobante"></asp:Label>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True"
                            OnCheckedChanged="CheckBox1_CheckedChanged" Text="OTM" ViewStateMode="Enabled"
                            Visible="False" />
                    </td>
                    <td class="style43">
                        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="12px" Text="Correo:"
                            Visible="False"></asp:Label>
                        <asp:TextBox ID="tbcorreo" runat="server" Font-Names="Arial" Font-Size="12px"
                            Height="19px" visble="true" Visible="False" Width="42px" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="tbcorreo" ErrorMessage="No es un correo Válido"
                            Font-Size="X-Small" ForeColor="Red"
                            ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+((\.[a-z0-9-]+)|(\.[a-z0-9-]+)(\.[a-z]{2,3}))([,][_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+((\.[a-z0-9-]+)|(\.[a-z0-9-]+)(\.[a-z]{2,3})))*$"></asp:RegularExpressionValidator>
                        <asp:Label ID="lbVersion" runat="server" Style="font-size: small" Width="278px"></asp:Label>
                    </td>
                    <td class="style28">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style33">
                        <asp:Label ID="Label13" runat="server" CssClass="style20" Text="R.F.C:"></asp:Label>
                    </td>
                    <td class="style43">
                        <asp:CheckBox ID="CheckBox2" runat="server"
                            OnCheckedChanged="CheckBox2_CheckedChanged" Text="Propinas"
                            ViewStateMode="Enabled" Visible="False" />
                        <asp:Label ID="lbRFC" runat="server" Style="font-size: small" Width="278px"></asp:Label>
                    </td>
                    <td class="style28"></td>
                </tr>
                <tr>
                    <td class="style33">
                        <asp:Label ID="Label5" runat="server" Style="font-size: small"
                            Text="Folio y Serie"></asp:Label>
                    </td>
                    <td class="style43">
                        <asp:Label ID="Ltm" runat="server" Text="Nombre: " Visible="False"></asp:Label>
                        <asp:Label ID="lbFolioSerie" runat="server" CssClass="style9" Width="278px"></asp:Label>
                    </td>
                    <td class="style28">
                        <asp:Image ID="imgFolSerok" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgFolSerx" runat="server" Height="23px"
                            ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                    </td>
                </tr>
            </table>
            <table class="style2" style="width: 90%; height: 21px;">
                <tr>
                    <td class="style34">
                        <asp:Label ID="Label6" runat="server" CssClass="style20"
                            Text="Año y No aprobación:"></asp:Label>
                    </td>
                    <td class="style38">
                        <asp:TextBox ID="nomOtm" runat="server" Visible="False"></asp:TextBox>
                        <asp:Label ID="lbAprobacion" runat="server" CssClass="style9" Width="278px"></asp:Label>
                    </td>
                    <td class="style28">
                        <asp:Image ID="imgAprobok" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgAprobx" runat="server" Height="23px"
                            ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                    </td>
                </tr>
            </table>
            <table class="style2" style="width: 100%;">
                <tr>
                    <td class="style33">
                        <asp:Label ID="Label7" runat="server" CssClass="style20" Text="Estructura:"></asp:Label>
                    </td>
                    <td class="style39">
                        <asp:FileUpload ID="exaOtm" runat="server" Visible="False" Width="234px" />
                        <asp:Label ID="lbEstructura" runat="server" CssClass="style9" Width="278px"></asp:Label>
                    </td>
                    <td class="style28">
                        <asp:Image ID="imgEstructuraok" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgEstructurax" runat="server" Height="23px"
                            ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                    </td>
                </tr>
            </table>
            <table class="style2" style="width: 100%;">
                <tr>
                    <td class="style33">
                        <asp:Label ID="Label8" runat="server" CssClass="style20" Text="Certificado:"></asp:Label>
                    </td>
                    <td class="style39">
                        <asp:Button ID="ButOtm" runat="server" OnClick="ButOtm_Click" Text="Agregar"
                            Visible="False" />
                        <asp:Label ID="lbCertificado" runat="server" CssClass="style9" Width="278px"></asp:Label>
                    </td>
                    <td class="style28">
                        <asp:Image ID="imgCerok" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgCerx" runat="server" Height="23px"
                            ImageUrl="~/imagenes/adv.png" Visible="False" Width="27px" />
                    </td>
                </tr>
            </table>
            <table class="style2" style="width: 100%;">
                <tr>
                    <td class="style33" valign="top">
                        <asp:Label ID="Label9" runat="server" CssClass="style20"
                            Text="Cadena original:"></asp:Label>
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="tbCO" runat="server" ReadOnly="True" TextMode="MultiLine"
                            Width="16px" Height="16px"></asp:TextBox>
                    </td>
                    <td class="style28">
                        <asp:Image ID="imgCOok" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgCOx" runat="server" Height="23px"
                            ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                    </td>
                </tr>
            </table>
            <table class="style2" style="width: 100%; height: 8px;">
                <tr>
                    <td class="style33" valign="top">
                        <asp:Label ID="Label10" runat="server" Style="font-size: small" Text="Sello:"></asp:Label>
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="tbSello" runat="server" ReadOnly="True" TextMode="MultiLine"
                            Width="16px" Height="16px"></asp:TextBox>
                    </td>
                    <td class="style28">
                        <asp:Image ID="imgSellook" runat="server" Height="23px"
                            ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                        <asp:Image ID="imgSellox" runat="server" Height="23px"
                            ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                        <asp:TextBox ID="tbMsj" runat="server" Font-Size="Small" ForeColor="#003151"
                            Height="16px" ReadOnly="True" Style="margin-top: 0px" TextMode="MultiLine"
                            Visible="False" Width="8%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style33" valign="top">&nbsp;<asp:Label ID="LabelO" runat="server" Style="font-size: small" Text="Otros"></asp:Label>
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="tbOtros" runat="server" TextMode="MultiLine" Width="16px"
                            Height="16px"></asp:TextBox>
                    </td>
                    <td class="style28">&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
            </table>
            <br />
            <br />
        </asp:Panel>
                        </td>
                        <td>
                            <center>

                                <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                                </asp:ScriptManager>
                                <asp:Panel ID="Panel2" runat="server" Height="551px" Width="600px"
                                    Style="margin-top: 9px;" BackColor="#FCFCFC" BorderColor="gray"
                                    BorderStyle="solid">
                                    <asp:Panel ID="Panel5" runat="server" BackColor="#CC0000" ForeColor="white"
                                        Font-Bold="True">
                                        SUBIR ARCHIVOS
                                    </asp:Panel>
                                    <br />
                                    <br />

                                    <table style="border-style: solid; border-color: #000; width: 90%; height: 289px; background-color: #FCFCFC;">

                                        <tr>
                                            <%--<td style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <asp:CheckBox ID="CheckSab" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="12px"
                                                    Text="Conoce el No. de Sabana" Visible="False" OnCheckedChanged="CheckSab_CheckedChanged" />
                                                <br />
                                                <asp:Label ID="Lsb0" runat="server" Font-Names="Arial" Font-Size="10px" ForeColor="#CC0000" Visible="False"></asp:Label>
                                            </td>--%>
                                            <td style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <table>
                                                    <tr>
                                                        <td colspan="0">
                                                            <asp:CheckBox ID="CheckSab" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="12px"
                                                                Text="Conoce el No. de Sabana" Visible="False" OnCheckedChanged="CheckSab_CheckedChanged" />
                                                            <asp:Label ID="Lsb0" runat="server" Font-Names="Arial" Font-Size="10px" ForeColor="#CC0000" Visible="False"></asp:Label>

                                                            <asp:CheckBox ID="CheckAnticipo" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="12px"
                                                                Text="Factura que ampara un Anticipo" Visible="False" OnCheckedChanged="CheckAnti_CheckedChanged" />
                                                            <%--</td>
                                                        <td></td>
                                                        <td>--%>
                                                            <asp:Label ID="LbRefB" runat="server" Text="Referencia Bancaria" Font-Names="Arial" Font-Size="12px" Visible="False"></asp:Label>
                                                            <asp:TextBox ID="tbRefB" runat="server" AutoPostBack="true" Font-Size="12px" Width="100px" Visible="false"></asp:TextBox>
                                                            <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="10px" ForeColor="#CC0000" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="NumSab" runat="server" Font-Names="Arial" Font-Size="12px" Text="No. de Sabana:" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextSab" runat="server" Font-Names="Arial" Font-Size="12px" Width="65px" Visible="False" MaxLength="8"></asp:TextBox>
                                                            <asp:Label ID="guion" runat="server" Text="-" Font-Names="Arial" Font-Size="12px" Visible="False"></asp:Label>
                                                            <asp:TextBox ID="TextSab1" runat="server" Font-Names="Arial" Font-Size="12px" Width="65px" Visible="False" MaxLength="4"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Lsite" runat="server" Font-Names="Arial" Font-Size="12px" Text="Site Origen:" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="siteSab" runat="server" Width="143px" Font-Names="Arial"
                                                                Font-Size="12px" Visible="False" AutoPostBack="True" OnTextChanged="siteSab_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Label ID="Lsb" runat="server" Font-Names="Arial" Font-Size="10px" ForeColor="#CC0000" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="style1"
                                                style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <asp:Label ID="LabCC" runat="server" Text="Código Contable:"></asp:Label>
                                            </td>
                                            <td align="center" style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="CodCont" runat="server" MaxLength="4" Width="35px"
                                                                Height="18px" Font-Names="Arial" Font-Size="12px" AutoPostBack="True"
                                                                OnTextChanged="CodCont_TextChanged"></asp:TextBox></td>
                                                        <td>.</td>
                                                        <td>
                                                            <asp:TextBox ID="CodCont0" runat="server" MaxLength="4" Width="35px"
                                                                Height="18px" Font-Names="Arial" Font-Size="12px" AutoPostBack="True"
                                                                OnTextChanged="CodCont0_TextChanged"></asp:TextBox></td>
                                                        <td>.</td>
                                                        <td>
                                                            <asp:TextBox ID="CodCont1" runat="server" MaxLength="4" Width="35px"
                                                                Height="18px" Font-Names="Arial" Font-Size="12px"></asp:TextBox></td>
                                                        <td>.</td>
                                                        <td>
                                                            <asp:TextBox ID="CodCont2" runat="server" MaxLength="2" Width="35px"
                                                                Height="18px" Font-Names="Arial" Font-Size="12px"
                                                                Style="text-transform: uppercase"></asp:TextBox></td>
                                                        <td>.</td>
                                                        <td>
                                                            <asp:TextBox ID="CodCont3" runat="server" MaxLength="3" Width="35px"
                                                                Height="18px" Font-Names="Arial" Font-Size="12px"
                                                                Style="text-transform: uppercase"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="9" align="center">
                                                            <asp:Label ID="Lfin" runat="server" Font-Names="Arial" Font-Size="10px"
                                                                ForeColor="Red" Visible="False"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="Lfin0" runat="server" Font-Names="Arial" Font-Size="10px"
                                                                ForeColor="Red" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                        </tr>
                                        <tr>
                                            <td style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <span class="style1">Documentos Adicionales</span><br />
                                                &nbsp;<asp:Label ID="Ladi" runat="server" Text="Nombre del Archivo Adicional: "
                                                    Font-Names="Arial" Font-Size="12px"></asp:Label>
                                            </td>

                                            <td style="border-style: ridge none outset none; border-width: thin; border-color: #000" align="left">
                                                <asp:FileUpload ID="examAdi" runat="server" Width="234px" Font-Names="Arial"
                                                    Font-Size="12px" />
                                                &nbsp;
                                        <br />
                                                <asp:TextBox ID="nomAdi" runat="server" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
                                                <asp:Button ID="ButAdi" runat="server" Text="Agregar" OnClick="Button1_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td
                                                style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <asp:Label ID="Label2" runat="server" Text="XML:" Font-Names="Arial"
                                                    Font-Size="12px"></asp:Label>
                                            </td>
                                            <td class="style60" align="left"
                                                style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <asp:FileUpload ID="fuXML" runat="server" Width="223px" Font-Names="Arial"
                                                    Font-Size="12px" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style57" align="left"
                                                style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <asp:Label ID="Label3" runat="server" Text="PDF:" Font-Names="Arial"
                                                    Font-Size="12px"></asp:Label>
                                            </td>
                                            <td style="text-align: left"
                                                style="border-style: ridge none outset none; border-width: thin; border-color: #000"
                                                class="style58">
                                                <asp:FileUpload ID="fuPDF" runat="server" Width="223px" Font-Names="Arial"
                                                    Font-Size="12px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1" style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                                <asp:Label ID="LabelOC" runat="server" Text="Orden de Compra:"></asp:Label>
                                            </td>
                                            <td class="style14" style="border-style: ridge none outset none; border-width: thin; border-color: #000" align="left">
                                                <asp:FileUpload ID="fuCompra" runat="server" Font-Names="Arial"
                                                    Font-Size="12px" />
                                                <br />
                                            </td>
                                        </tr>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                            <span class="style1">Propinas</span></td>
                        <td style="border-style: ridge none outset none; border-width: thin; border-color: #000" align="left">
                            <asp:TextBox ID="prop" runat="server" Font-Names="Arial" Font-Size="12px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr id="moneda" runat="server">
                        <td style="border-style: ridge none outset none; border-width: thin; border-color: #000"
                            class="style1">Moneda:
                        </td>
                        <td style="border-style: ridge none outset none; border-width: thin; border-color: #000" align="left">
                            <asp:DropDownList ID="Lmoneda" runat="server" DataSourceID="SqlDataMon"
                                DataTextField="codigoISO" DataValueField="codigoISO" Height="20px"
                                Width="80px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataMon" runat="server"
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>"
                                SelectCommand="SELECT [codigoISO] FROM [monedas] where activa = 'si' "></asp:SqlDataSource>
                        </td>
                    </tr>

                    <tr>

                        <td colspan="2" class="style61">
                            <asp:Label ID="lMsj" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style56" align="center">
                            <asp:Label ID="LabTim" runat="server" Font-Bold="True" Font-Names="Arial"
                                Font-Size="11px" Text="Tiempo límite de recepción (días):" Visible="False"></asp:Label>
                            <br />
                            <asp:TextBox ID="Textim" runat="server" Font-Names="Arial" Font-Size="11px"
                                Height="21px" Visible="False" Width="55px">30</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbarrayLog" runat="server" Font-Size="Medium" ForeColor="Black"
                                Style="font-size: small; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="bSubir" runat="server" CssClass="boton" OnClick="bSubir_Click"
                    Style="text-align: center; height: 22px; width: 75px;" Text="Cargar" ValidationGroup="Cargar" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="caN" runat="server" CssClass="boton" OnClick="caN_Click" Style="text-align: center; margin-top: 0px;" Text="Regresar" />
                <br />
                </asp:Panel>
                   
                    </center>
                    </td>
                <td class="style12">
                    <center>
                        <asp:Panel ID="Padi" runat="server" BorderColor="#000" BorderStyle="Ridge"
                            Height="220px" Width="305px" Visible="False">
                            <asp:Panel ID="Panel8" runat="server" BackColor="#CC0000" ForeColor="White"
                                Font-Bold="True">
                                Documentos Adicionales
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel6" runat="server" BorderColor="Black" BorderStyle="Ridge"
                                Height="124px" Width="264px">
                                <asp:RadioButtonList ID="docAdi" runat="server" Style="text-align: left">
                                </asp:RadioButtonList>
                            </asp:Panel>
                            <asp:Label ID="Labadi" runat="server" Font-Names="Arial" Font-Size="11px"
                                Text="Label" Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="Button1" runat="server" BackColor="#D40512" Font-Names="Arial"
                                Font-Size="11px" ForeColor="White" Text="Ver" OnClick="Button1_Click1" />
                            &nbsp;
                             <asp:Button ID="Button2" runat="server" BackColor="#D40512" Font-Names="Arial"
                                 Font-Size="11px" ForeColor="White" Text="Eliminar"
                                 OnClick="Button2_Click" Style="height: 22px; width: 54px" />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="Potm" runat="server" BorderColor="#E4B918" BorderStyle="Ridge"
                            Height="223px" Width="305px" Visible="False">
                            <asp:Panel ID="Panel9" runat="server" BackColor="#CC0000" ForeColor="White"
                                Font-Bold="True">
                                Documentos OTM
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel7" runat="server" BorderColor="#E4B918" BorderStyle="Ridge"
                                Height="132px" Width="270px" Style="margin-right: 7px">
                                <asp:RadioButtonList ID="Lotm" runat="server" Style="text-align: left">
                                </asp:RadioButtonList>
                            </asp:Panel>
                            <asp:Label ID="Labeotm" runat="server" Font-Names="Arial" Font-Size="11px"
                                Text="Label" Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="Button3" runat="server" BackColor="#D40512" Font-Names="Arial"
                                Font-Size="11px" ForeColor="White" Text="Ver" OnClick="Button3_Click" />
                            &nbsp;
                             <asp:Button ID="Button4" runat="server" BackColor="#D40512" Font-Names="Arial"
                                 Font-Size="11px" ForeColor="White" Text="Eliminar"
                                 OnClick="Button4_Click" />
                            <br />
                        </asp:Panel>
                    </center>
                    &nbsp;</td>
                </tr>
        </table>
            </div>
        </div>

    </form>
</body>
</html>
