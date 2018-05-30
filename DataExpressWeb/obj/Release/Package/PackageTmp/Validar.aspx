<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Validar.aspx.cs" Inherits="DataExpressWeb.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <h2>Bienvenido a DataExpress: </h2>
    <style type="text/css">
         .style2
        {
             width: auto;
             margin:  1 auto; /* centrado */
             background: white;
             box-shadow: inset 1px 0px 3px 0px #3366FF;
             border-radius: 5px;
        } 
         .style3
        {
             width: auto;
             margin:  1 auto; /* centrado */
             background: white;
             box-shadow: inset 1px 1px 3px 1px #0099FF;
             border-radius: 15px;
        } 
         .style5
         {
             text-shadow: 0.1em 0.1em #C0C0C0;
             color: #0f7d0f;
         }
        .style9
        {
            font-size: small;
        }
        .style12
        {
            width: 335px;
        }
        .style13
        {
            width: 305px;
        }
        .style14
        {
            text-align: left;
        }
        .style17
        {
            text-align: left;
        }
        .style19
        {
            text-align: left;
        }
        .style20
        {
            font-size: small;
        }
        .style28
        {
            text-align: left;
        }
        .style33
        {
            text-align: right;
            width: 143px;
        }
        .style34
        {
            text-align: right;
            width: 142px;
        }
        .style35
        {
            text-align: center;
            width: 143px;
        }
        .style36
        {
            text-align: left;
            height: 22px;
        }
        .style38
        {
            text-align: left;
            width: 354px;
        }
        .style39
        {
            text-align: left;
            width: 350px;
        }
        .style40
        {
            text-align: left;
            height: 22px;
            width: 338px;
        }
        .style41
        {
            text-align: center;
            width: 338px;
        }
        .style43
        {
            text-align: left;
            width: 338px;
        }
        .style45
        {
        }
        .style46
        {
            font-size: medium;
            text-shadow: 0.1em 0.1em #CCCCCC;
            color: #0f7d0f;
        }
        .style47
        {
            width: 84px;
        }
        .style48
        {
            text-align: center;
            width: 84px;
        }
        .style51
        {
            font-size: x-large;
        }
        .style52
        {
            font-size: large;
        }
        .style53
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 960px">
<tr>
    <td class="style45">
    &nbsp;&nbsp; <span class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong> 
        </strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    </td>
</tr>
</table>
    <p style=" font-size: medium; text-align:center" class="style46" ><strong>VALIDAR COMPROBANTE</strong></p>
    <p style=" font-size: medium; text-align:center">
        <table style="width:100%;">
            <tr>
                <td class="style13">
                    <asp:Panel ID="Panel1" runat="server">
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Height="341px" Width="330px" 
                        style="margin-top: 9px">
                        <table class="style3" style="width: 125%;">
                        <tr>
                        <td class="style53"></td>
                        <td class="style53">Busqueda de Archivos:</td>
                        </tr>
                        <tr>
                        <td class="style53"></td>
                        </tr>
                            <tr>
                                <td class="style48">
                                    <asp:Label ID="Label1" runat="server" Text="XML:"></asp:Label>
                                </td>
                                <td class="style14">
                                    <asp:FileUpload ID="fuXML" runat="server" Width="223px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style48">
                                    <asp:Label ID="Label2" runat="server" Text="PDF:"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:FileUpload ID="fuPDF" runat="server" Width="223px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style47">
                                    &nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="chCertificado" runat="server" Checked="True" 
                                        Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style48">
                                    &nbsp;</td>
                                <td class="style14">
                                    <span class="style9">
                                    <asp:FileUpload ID="fuCertificado" runat="server" Visible="False" 
                                        Width="233px" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                            <td class="style48">
                                    <asp:Label ID="Label19" runat="server" Text="Correo:"></asp:Label>
                                </td>
                            <td class="style14">
                            <asp:TextBox ID="tbcorreo" runat="server" visble="true"/>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="tbcorreo" ErrorMessage="No es un correo Válido" 
                                    Font-Size="X-Small" ForeColor="Red" 
                                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+((\.[a-z0-9-]+)|(\.[a-z0-9-]+)(\.[a-z]{2,3}))([,][_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+((\.[a-z0-9-]+)|(\.[a-z0-9-]+)(\.[a-z]{2,3})))*$"></asp:RegularExpressionValidator>
                            </td>
                            </tr>
                            <tr>
                                <td class="style48">
                                    &nbsp;</td>
                                <td class="style19">
                                    <asp:Button ID="bSubir" runat="server" onclick="bSubir_Click" 
                                        style="text-align: center" Text="Validar Factura" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style47">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lMsj" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style47">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style47">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <asp:TextBox ID="tbMsj" runat="server" Font-Size="Small" ForeColor="#003151" 
                            Height="46px" ReadOnly="True" TextMode="MultiLine" Width="18%" 
                            Visible="False"></asp:TextBox>
                        <br />
                        <br />                            
                        <br />
                    </asp:Panel>
                    <br />                            
        <a href="Default.aspx" style="text-decoration:none"> <span class="style51">&nbsp;</span><span 
                        class="style52">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Volver a Inicio</span></a>
    
                </td>
                <td class="style12">
                    <asp:Panel ID="Panel3" runat="server" Height="360px" Width="547px" 
                        style="margin-bottom: 0px">
                        <table class="style2" style="width:100%;">
                            <tr>
                                <td class="style17">
                                    <asp:Label ID="Label12" runat="server" 
                                        style="font-size: small; text-align: center; font-weight: 700;" 
                                        Text="DETALLE DE VALIDACION DE LA FACTURA DIGITAL BASADO EN EL ANEXO 20"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="style2" style="width:100%;">
                            <tr>
                                <td class="style35" rowspan="2">
                                    &nbsp;</td>
                                <td class="style40">
                                    <asp:Label ID="Label15" runat="server" style="font-size: small;" 
                                        Text="Estatus completo de la factura digital:"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="style36">
                                </td>
                            </tr>
                            <tr>
                                <td class="style41">
                                    <asp:Label ID="lbarrayLog" runat="server" 
                                        style="font-size: small; font-weight: 700" Font-Size="Medium" 
                                        ForeColor="Black"></asp:Label>
                                </td>
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
                                </td>
                                <td class="style43">
                                    <asp:Label ID="lbVersion" runat="server" style="font-size: small" Width="278px"></asp:Label>
                                </td>
                                <td class="style28">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style33">
                                    <asp:Label ID="Label13" runat="server" CssClass="style20" Text="R.F.C:"></asp:Label>
                                </td>
                                <td class="style43">
                                    <asp:Label ID="lbRFC" runat="server" style="font-size: small" Width="278px"></asp:Label>
                                </td>
                                <td class="style28">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style33">
                                    <asp:Label ID="Label5" runat="server" style="font-size: small" 
                                        Text="Folio y Serie"></asp:Label>
                                </td>
                                <td class="style43">
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
                        <table class="style2" style="width:100%;">
                            <tr>
                                <td class="style34">
                                    <asp:Label ID="Label6" runat="server" CssClass="style20" 
                                        Text="Año y No aprobación:"></asp:Label>
                                </td>
                                <td class="style38">
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
                        <table class="style2" style="width:100%;">
                            <tr>
                                <td class="style33">
                                    <asp:Label ID="Label7" runat="server" CssClass="style20" Text="Estructura:"></asp:Label>
                                </td>
                                <td class="style39">
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
                        <table class="style2" style="width:100%;">
                            <tr>
                                <td class="style33">
                                    <asp:Label ID="Label8" runat="server" CssClass="style20" Text="Certificado:"></asp:Label>
                                </td>
                                <td class="style39">
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
                        <table class="style2" style="width:100%;">
                            <tr>
                                <td class="style33" valign="top">
                                    <asp:Label ID="Label9" runat="server" CssClass="style20" 
                                        Text="Cadena original:"></asp:Label>
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="tbCO" runat="server" ReadOnly="True" TextMode="MultiLine" 
                                        Width="278px"></asp:TextBox>
                                </td>
                                <td class="style28">
                                    <asp:Image ID="imgCOok" runat="server" Height="23px" 
                                        ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                                    <asp:Image ID="imgCOx" runat="server" Height="23px" 
                                        ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                                </td>
                            </tr>
                        </table>
                        <table class="style2" style="width:100%; height: 8px;">
                            <tr>
                                <td class="style33" valign="top">
                                    <asp:Label ID="Label10" runat="server" style="font-size: small" Text="Sello:"></asp:Label>
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="tbSello" runat="server" ReadOnly="True" TextMode="MultiLine" 
                                        Width="278px"></asp:TextBox>
                                </td>
                                <td class="style28">
                                    <asp:Image ID="imgSellook" runat="server" Height="23px" 
                                        ImageUrl="~/imagenes/ok-small.png" Visible="False" Width="23px" />
                                    <asp:Image ID="imgSellox" runat="server" Height="23px" 
                                        ImageUrl="~/imagenes/x_small.png" Visible="False" Width="27px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style33" valign="top">
                                    &nbsp;<asp:Label ID="LabelO" runat="server" style="font-size: small" Text="Otros"></asp:Label>
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="tbOtros" runat="server" TextMode="MultiLine" Width="278px"></asp:TextBox>
                                </td>
                                <td class="style28">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table style="width:100%;">
                        </table>
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </p>
    <p style=" font-size: medium; text-align:left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    </p>
    <p style=" font-size: medium; text-align:left">&nbsp;</p>

</asp:Content>
