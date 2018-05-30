<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComprobantesOTM.aspx.cs" Inherits="DataExpressWeb.Formulario_web127" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="StylesEx.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            overflow: auto;
        }

        .modalPopupMP {
            display: block;
            width: auto;
            height: auto;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.428571429;
            color: #000;
            vertical-align: middle;
            border: solid;
            background-color: white;
            border: 1px solid #66afe9;
            border-radius: 4px;
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
            -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
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

        .panelHeader {
            background-color: #d40511;
            border: 1px groove black;
            font-family: Arial;
            font-weight: bold;
            font-size: 14px;
            color: #fff;
            height: 20px;
            width: auto;
        }

        .panelWrapper {
            background-color: #e8e8e4;
            border-style: solid;
            border-color: #d40511;
            border-width: 1px;
        }

        #bus {
            position: absolute;
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 67px;
            width: 112px;
        }

        #bus2 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 71px;
            width: 141px;
        }

        #bus3 {
            position: absolute;
            left: 1022px;
            top: 175px;
            z-index: 1;
            height: 63px;
            width: 103px;
        }

        #bus4 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus5 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus6 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus7 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #navigation {
            text-decoration: none;
        }

        .sideMenuComprobantesFiscales:hover {
            text-decoration: underline;
            color: #C90101;
        }

        ul#navigation {
            padding: 0 0 1em 1.75em;
            list-style-image: url(../imagenes/arrow.png);
            list-style-position: inside;
        }

        .titulo {
            padding: 0 0 1em 1.75em;
            list-style-position: inside;
            font: normal bold 12px Arial;
        }



        h1 {
            background-color: #C90101;
            color: #fff;
            font: normal bold 20px arial;
        }

        .contenedor {
            overflow: auto;
            direction: rtl;
        }

        .tablaFac {
            direction: ltr;
        }

        .watermarked {
            height: 20px;
            width: 150px;
            padding: 2px 0 0 2px;
            border: 1px solid #BEBEBE;
            color: gray;
            text-align: center;
        }

        .ajax__calendar_header {
            background-color: #8A0808;
            color: snow;
            text-transform: uppercase;
        }

        .ajax__calendar_body {
            background-color: #F2F5A9;
            text-align: center;
        }

        .ajax__calendar_prev {
            background-color: white;
        }

        .ajax__calendar_next {
            background-color: white;
        }
    </style>

</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <span class="titulo">Comprobantes Fiscales Dig. OTM</span>
    <ul id="navigation">
        <%if (!(Session["permisos"].ToString().IndexOf("SubCFDI") < 0))
            { %>
        <li>
            <asp:LinkButton ID="HyperLink12" CssClass="sideMenuComprobantesFiscales" runat="server" OnClick="HyperLink12_Click"> Subir CFDI</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton5" CssClass="sideMenuComprobantesFiscales" runat="server" OnClick="btPagos_Click" OnClientClick="return confirm('Al subir archivos procura que no pasen los 2 MB de tamaño,\nya que por seguridad del portal no se permitirá subir los documentos.');"> Cargar complemento de Pago</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("EditarCom") < 0))
            { %>
        <li>
            <asp:LinkButton ID="HyperLink1" CssClass="sideMenuComprobantesFiscales" OnClick="Button1_Click" runat="server"> Editar CFDI</asp:LinkButton></li>
        <%} %>

        <li>
            <asp:LinkButton ID="HyperLink2" CssClass="sideMenuComprobantesFiscales" OnClick="Button2_Click" runat="server"> Ver Todos</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="HyperLink3" CssClass="sideMenuComprobantesFiscales" OnClick="Button3_Click" runat="server"> Ver Validos</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="HyperLink4" CssClass="sideMenuComprobantesFiscales" OnClick="Button4_Click" runat="server"> Ver En Proceso De Pago</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="HyperLink5" CssClass="sideMenuComprobantesFiscales" OnClick="Button5_Click" runat="server">  Ver Rechazados</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="HyperLink6" CssClass="sideMenuComprobantesFiscales" OnClick="Button6_Click" runat="server"> Ver Cancelados</asp:LinkButton></li>

        <%if (!(Session["permisos"].ToString().IndexOf("DocAdic") < 0))
            { %>
        <li>
            <asp:LinkButton ID="HyperLink7" CssClass="sideMenuComprobantesFiscales" OnClick="Button7_Click" runat="server"> Documentos Adicionales</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("Proc") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton12" CssClass="sideMenuComprobantesFiscales"
                runat="server"
                OnClientClick="return confirm('Seguro que desea mandar el CFDI a Proceso de Pago');"
                OnClick="LinkButton12_Click"> A Proceso de Pago</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("CanCFDI") < 0))
            { %>
        <li>
            <asp:LinkButton ID="lbRetencion" CssClass="sideMenuComprobantesFiscales" OnClick="lbRetencion_Click" runat="server" OnClientClick="return confirm('¿Seguro que desea crear retención de los CFDI seleccionados?');"> Crear Retención</asp:LinkButton>
        </li>
        <li>
            <asp:HyperLink ID="hlRetencionManual" CssClass="sideMenuComprobantesFiscales" runat="server" NavigateUrl="~/nuevo/retencionManual.aspx"> Retención Manual</asp:HyperLink>
        </li>
        <li>
            <asp:LinkButton ID="HyperLink9" CssClass="sideMenuComprobantesFiscales" OnClick="Button9_Click" runat="server"> Cancelar</asp:LinkButton></li>
        <%} %>
        <%if (!(Session["permisos"].ToString().IndexOf("RecCFDI") < 0))
            { %>
        <li>
            <asp:LinkButton ID="HyperLink10" CssClass="sideMenuComprobantesFiscales" OnClick="Button10_Click" runat="server"> Rechazar</asp:LinkButton></li>
        <%} %>
        <li>
            <asp:LinkButton ID="HyperLink11" CssClass="sideMenuComprobantesFiscales" OnClick="Button11_Click" runat="server"> Filtrar</asp:LinkButton></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="width: 370px">Comprobantes Fiscales Digitales OTM</h1>

    <asp:UpdatePanel ID="udpBuscarReferencia_Outter" runat="server">
        <ContentTemplate>
            <input id="bAviso_Trigger" type="button" style="display: none" runat="server" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mpeAviso" BehaviorID="mpeAviso" PopupControlID="pnlAviso" BackgroundCssClass="modalBackground"
                DropShadow="true" TargetControlID="bAviso_Trigger" CancelControlID="bAviso_Close" />
            <asp:Panel ID="pnlAviso" runat="server" CssClass="modalPopup">
                <asp:Button ID="bAviso_Close" runat="server" Text="Cerrar" Style="float: right;" />
                <center><span class="style5" style="color: #d40511; font-size: x-large;">Aviso</span></center>
                <br />
                <asp:Label ID="lblMsgAviso" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>

    <center>
                        <table style="width: 75%; height: 102px">
                           <tr>
                           <td colspan="11">
                           <span ID="bus">
                <center>
                <asp:Panel ID="Pcancelar" CssClass="panelWrapper" runat="server"
                        Height="42px" Visible="False" 
                                            Width="116px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel28" CssClass="panelHeader" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" BorderStyle="Groove">
                        Cancelar CFDI</asp:Panel>
                                            <asp:Panel ID="Panel27" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                                Height="164px" Width="384px">
                                                <table style="width: 383px; height: 86px;">
                                                    <tr>
                                                        <td>
                                                            Proveedor:</td>
                                                        <td>
                                                            <asp:Label ID="Lcancel1" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td>
                                                            <asp:Label ID="Lcancel2" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Folio:</td>
                                                        <td>
                                                            <asp:Label ID="Lcancel3" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Causa de la Cancelación:</td>
                                                        <td>
                                                            <asp:TextBox ID="tbcausa" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                                <asp:Button ID="bgrab" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" onclick="bgrab_Click" ForeColor="White" 
                                                onclientclick="return confirm('Seguro que desea cancelar el comprobante');"/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button50" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button50_Click" ForeColor="White"/>
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

                                        <span ID="bus2">
                <center>
                <asp:Panel ID="Prechazar" CssClass="panelWrapper" runat="server"  
                        Height="32px" Visible="False" 
                                            Width="112px" ViewStateMode="Disabled" 
                        ScrollBars="Auto">
                                            <asp:Panel ID="Panel30" CssClass="panelHeader" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" BorderStyle="Solid">
                        Rechazando CFDI</asp:Panel>
                                            <asp:Panel ID="Panel31" runat="server" BorderStyle="Solid" 
                                                Height="157px" Width="384px" BorderWidth="1px">
                                                <table style="width: 383px; height: 122px;">
                                                    <tr>
                                                        <td>
                                                            Proveedor:</td>
                                                        <td>
                                                            <asp:Label ID="Lrechazar1" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td>
                                                            <asp:Label ID="Lrechazar2" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Folio:</td>
                                                        <td>
                                                            <asp:Label ID="Lrechazar3" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Causa del Rechazo:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tbrechazar" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                                <asp:Button ID="Button46" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" onclick="Button46_Click" ForeColor="White" 
                                                onclientclick="return confirm('Seguro que desea rechazar el comprobante');" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button51" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button51_Click" ForeColor="White" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

                                        <span ID="bus3">
                <center>
                <asp:Panel ID="Paceptar" CssClass="panelWrapper" runat="server" BackColor="#d1d1d1" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="51px" Visible="False" 
                                            Width="212px" ScrollBars="Auto" 
                        ViewStateMode="Disabled">
                                            <asp:Panel ID="Panel33" CssClass="panelHeader" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        CFDI Aceptado</asp:Panel>
                                            <asp:Panel ID="Panel34" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
                                                Height="126px" Width="384px">
                                                <table style="width: 383px; height: 116px;">
                                                    <tr>
                                                        <td>
                                                            Proveedor:</td>
                                                        <td>
                                                            <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td>
                                                            <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Folio:</td>
                                                        <td>
                                                            <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Fecha de Pago</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox17" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="35px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                                <asp:Button ID="Button48" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" ForeColor="White" 
                                                onclientclick="return confirm('Seguro que desea aceptar el comprobante');" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="Button52" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" ForeColor="White" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

<span ID="bus4">
                <center style="height: 86px">
                <asp:Panel ID="PanelBusca" CssClass="panelWrapper" runat="server"
                         BorderStyle="Groove" Height="440px" Visible="False"  Width="410px" ScrollBars="Vertical">
                                            <asp:Panel ID="Panel45" CssClass="panelHeader" runat="server" BackColor="#d40511" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" BorderStyle="Groove">
                        Filtro</asp:Panel>
                                            <asp:Panel ID="Panel46" runat="server" BorderColor="#666666" BorderStyle="Solid" 
                                                Height="310px" Width="364px" BorderWidth="1px">
                                                <table style="width: 363px; height: 290px;">
                                                    <tr>
                                                        <td>
                                                            Proveedor:</td>
                                                        <td colspan="2">
                                                           <asp:TextBox ID="Tprov" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Tipo de Proveedor:</td>
                                                        <td colspan="2">
                                                         <asp:TextBox ID="Ttip" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td colspan="2">
                                                           <asp:TextBox ID="Tser" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            UUID:</td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="Tfol" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Moneda:</td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="Tmon" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="21px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            Total:</td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="Ttot" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="24px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                           No. Sabana:</td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="Tcod" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="20px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="char" valign="top">
                                                           Intervalo Fechas:
                                                        </td>
                                                        <td valign="baseline" align="left">
                                                                <asp:TextBox ID="tbFechaIni" runat="server" Width="110px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                                                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="tbFechaIni" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy">
                                                                </ajaxtoolkit:CalendarExtender>
                                                                <ajaxtoolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="tbFechaIni" WatermarkText="Fecha Inicial" WatermarkCssClass="watermarked"  >
                                                                </ajaxtoolkit:TextBoxWatermarkExtender>
                                                                <br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                                                runat="server" ControlToValidate="tbFechaIni" 
                                                                ErrorMessage="Formato yyyy/MM/dd" ForeColor="OrangeRed" Font-Size="XX-Small" 
                                                                ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"></asp:RegularExpressionValidator>
                                                          </td> 
                                                        <td valign="baseline"  align="left">
                                                            -
                                                                <asp:TextBox ID="tbFechaFin" runat="server" Width="110px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                                                              <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbFechaFin" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy">
                                                                </ajaxtoolkit:CalendarExtender>
                                                                <ajaxtoolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="tbFechaFin" WatermarkText="Fecha Final" WatermarkCssClass="watermarked" >
                                                                </ajaxtoolkit:TextBoxWatermarkExtender>
                                                                <br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                                runat="server" ControlToValidate="tbFechaFin"
                                                                ErrorMessage="Formato yyyy/MM/dd" ForeColor="OrangeRed" Font-Size="XX-Small" 
                                                                ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"></asp:RegularExpressionValidator>
                                                         
                                                          </td>                                                   
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button49" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Buscar" Width="87px" ForeColor="White" onclick="Button49_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button12" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button12_Click" ForeColor="White" />
                                            <br />
                                             <br />
                                        </asp:Panel>
                                        </center>
                                        </span>


                                         <span ID="bus5">
             <center style="height: 86px">
                <asp:Panel ID="Peditar" CssClass="panelWrapper" runat="server" BackColor="#d1d1d1" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="42px" Visible="False" 
                                            Width="106px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel2" CssClass="panelHeader" runat="server" BackColor="#d40511" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Editar CFDI</asp:Panel>
                                            <asp:Panel ID="Panel3" runat="server" BorderColor="#666666" BorderStyle="Ridge" 
                                                Height="181px" Width="384px">
                                                <table style="width: 383px; height: 86px;">
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td>
                                                            <asp:Label ID="Labelser" runat="server" Text="Label" Font-Bold="True" Font-Size="11px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Folio:</td>
                                                        <td>
                                                         <asp:Label ID="Labelfol" runat="server" Text="Label" Font-Bold="True" Font-Size="11px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Código GL:</td>
                                                        <td>
                                                           <asp:TextBox ID="Textgl" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Correo de Contacto DHL:</td>
                                                        <td>
                                                            <asp:TextBox ID="Textcorreo" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Moneda:</td>
                                                        <td>
                                                            <asp:DropDownList ID="DropListMon" runat="server" DataSourceID="SqlDatamon" 
                                                                DataTextField="codigoISO" DataValueField="codigoISO" Height="17px" 
                                                                Width="145px">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDatamon" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                                                SelectCommand="SELECT [codigoISO] FROM [monedas]"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button14" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" ForeColor="White" onclick="Button14_Click" 
                                                onclientclick="return confirm('Seguro que desea Editar el comprobante');" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button13" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button13_Click" ForeColor="White" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>


                                        <span ID="bus6">
             <center style="height: 86px">
                <asp:Panel ID="PdocAdi" runat="server" CssClass="panelWrapper" BackColor="#d1d1d1" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="65px" Visible="False" 
                                            Width="117px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel4" CssClass="panelHeader" runat="server" BackColor="#d40511" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="458px">
                        Documentos Adicionales</asp:Panel>
                                            <asp:Panel ID="Panel5" runat="server" BorderColor="#666666" BorderStyle="Ridge" 
                                                Height="264px" Width="434px">
                                                <table style="width: 415px; height: 86px;">
                                                    <tr>
                                                        <td>
                                                            Emisor:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tdocadiemi" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Receptor:</td>
                                                        <td>
                                                         <asp:TextBox ID="Tdocadirec" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td>
                                                           <asp:TextBox ID="Tdocadiser" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Folio:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tdocadifol" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                         <asp:Panel ID="Panel1" runat="server" BorderColor="#666666" BorderStyle="Ridge" 
                                                Height="97px" Width="412px" ScrollBars="Auto">
                                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource7" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="413px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
        <asp:TemplateField HeaderText="Archivo">
            <ItemTemplate>
            <center>
            <a href='../download.aspx?file=<%# Eval("ADIARC") %>'>
                <img  src="../imagenes-dhl/D5.PNG" alt="xml" border="0" align="middle" 
                    height="22" width="22"></a>
            </center>
            </ItemTemplate> 
    </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo de Archivo" SortExpression="codiso">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NOMARC") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NOMARC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="nom">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NOMBRE") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No hay documentos adicionales.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFFFF" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="select [ADIARC],[NOMARC],[NOMBRE] from [documentosAdicionales]">
    </asp:SqlDataSource>
                                                </asp:Panel>
                                                         </td>
                                                    </tr>

                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button15" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" ForeColor="White" onclick="Button15_Click" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>


                                         <span ID="bus7">
             <center style="height: 86px">
                <asp:Panel ID="Psubirfact" CssClass="panelWrapper" runat="server" BackColor="#d1d1d1" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="37px" Visible="False" 
                                            Width="135px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel7" CssClass="panelHeader" runat="server" BackColor="#d40511" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Subir CFDI</asp:Panel>
                                            <asp:Panel ID="Panel8" runat="server" BorderColor="#666666" BorderStyle="Ridge" 
                                                Height="89px" Width="384px">
                                                <table style="width: 383px; height: 86px;">
                                                    <tr>
                                                        <td>
                                                            Tipo de Proveedor:</td>
                                                        <td>
                                                            <asp:DropDownList ID="DropCargar" runat="server" DataSourceID="SqlDataprov" 
                                                                DataTextField="nombre" DataValueField="nombre">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataprov" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                                                SelectCommand="SELECT [nombre] FROM [tipoProveedor]"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    

                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button2" runat="server" BackColor="#d40511" BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" ForeColor="White" OnClientClick="return confirm('Al subir archivos procura que no pasen los 2 MB de tamaño,\nya que por seguridad del portal no se permitirá subir los documentos.');" onclick="Button2_Click1" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button1" runat="server" BackColor="#d40511" BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button1_Click1" ForeColor="White" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>
                           </td>
                           </tr>
                              <tr>
                               
                              
                                <td colspan="11">
                      
                               <asp:Panel ID="Panel14" runat="server" BorderColor="#CC0000" BorderStyle="none" Height="475px" Width="1050px" ScrollBars="Horizontal">
              <br />
                 <div style =" border: 3px solid #d40511; background-color:#d40511; height:auto; width:2891px; margin:0; padding:0" >
                </div>
               <%-- <asp:Panel ID="Panel6" class="contenedor" runat="server" BorderColor="#CC0000" BorderStyle="none" 
              Height="405px"  Width="2897px" ScrollBars="Vertical">--%>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" >
                                          <ContentTemplate>
                                <asp:GridView ID="gvFacturas" class="tablaFac" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
                                         CellPadding="1" DataKeyNames="idFactura" ForeColor="#333333" GridLines="None"  style="margin-top: 0px; Width:2790px" BorderColor="#CC0000" 
        BorderStyle="solid" Font-Size="10px" Font-Bold="True" CellSpacing="1" AllowPaging="True" onselectedindexchanged="gvFacturas_SelectedIndexChanged" OnRowDataBound="gvFacturas_RowDataBound">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
    <Columns >
     <asp:ImageField DataImageUrlField="EDOFAC" 
                        DataImageUrlFormatString="~/Imagenes/{0}.png" HeaderText="Estatus" Visible="false" >
                        <ControlStyle Height="35px" Width="35px" />
                        <HeaderStyle Width="7%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ImageField>
<asp:TemplateField HeaderText="Marcar" ItemStyle-Width="35px">
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server"/>
                            <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idFactura")%>' />
                            <asp:HiddenField ID="checkMP" runat="server" Value='<%#Bind("metodoDePago")%>' />
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
        <asp:TemplateField HeaderText="XML" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink3" height="15" width="15" runat="server" BorderWidth="0px" BorderStyle="None" 
                             NavigateUrl='<%# Eval("XMLARC","~/download.aspx?file={0}") %>' Visible="true" >       
                                <img  src="../imagenes/xml32x32.png" alt="xml" height="22" width="22">
                            </asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle Width="1%" />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="PDF" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" height="15" width="15" runat="server" BorderWidth="0px" BorderStyle="None" 
                             Visible='<%# Eval("facSAT").ToString() == ("0") %>' NavigateUrl='<%# Eval("PDFARC","~/download.aspx?file={0}") %>' >       
                                <img  src="../imagenes/pdf32x32.png" alt="pdf" height="22" width="22">
                            </asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle Width="1%" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Versión CFDI" SortExpression="version" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox88" runat="server" Text='<%# Bind("version") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label88" runat="server" Text='<%# Bind("version") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
        <asp:TemplateField HeaderText="Complemento de Pago" SortExpression="idFactura" ItemStyle-Width="50px" ItemStyle-Font-Size="XX-Large">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idFactura") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btPagos" runat="server" CssClass="btGrisNegrita" Text="Ver" Width="40px" CommandArgument='<%#Bind("idFactura") %>' OnClick="btComplementoPago_Click" Visible="false"></asp:LinkButton>
                                    <asp:HiddenField ID="checkHdID" runat="server" Value='<%# Eval("idFactura") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>

        <asp:TemplateField HeaderText="Retención" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblRet" runat="server" Text='<%# (Eval("estadoRetencion") != null ? (Eval("estadoRetencion").ToString().Equals(Boolean.TrueString) ? "1" : "0") : "0") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"/>
            <HeaderStyle Width="1%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Proveedor" SortExpression="NOMEMI" ItemStyle-Width="220px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NOMEMI") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("NOMEMI") %>' Width="220px"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="220px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No. Sabana" SortExpression="sab" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("noSabana") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label31" runat="server" Text='<%# Bind("noSabana") %>' Width="100px"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Site Origen" SortExpression="ori" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("siteOrigen") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label310" runat="server" Text='<%# Bind("siteOrigen") %>' Width="80px"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tipo de Proveedor" SortExpression="tipProv" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("tipProv") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Width="90px" Text='<%# Bind("tipProv") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receptor" SortExpression="RFCREC" ItemStyle-Width="200px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("razonSoc") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("razonSoc") %>' Width="200px"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="200px"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UUID" SortExpression="UUID" ControlStyle-Width="225px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("UUID") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("UUID") %>' Width="215px"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CFDI Tipo" SortExpression="tipCfdi" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("tipCfdi") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label8" runat="server" Width="63px" Text='<%# Bind("tipCfdi") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de Emisión" SortExpression="FECHA" ControlStyle-Width="130px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label46" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Fecha de Recepción" SortExpression="FECHA" ControlStyle-Width="130px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label90" runat="server" Text='<%# Bind("fechaRec") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Usuario" SortExpression="fechUlt" ControlStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox91" runat="server" Text='<%# Bind("persFac") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label91" runat="server" Text='<%# Bind("persFac") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de Ultimo Cambio" SortExpression="fechUlt" ControlStyle-Width="130px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("fechaUltimCam") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label9" runat="server" Text='<%# Bind("fechaUltimCam") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="Status" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("estatus") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label151" runat="server" Width="60" Text='<%# Bind("estatus") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Moneda" SortExpression="Moneda" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:TextBox ID="tbMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lMon" runat="server" Width="50px" Text='<%# Bind("Moneda") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Subtotal" SortExpression="Subtotal">
            <EditItemTemplate>
                <asp:TextBox ID="tbSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lSubtotal" runat="server" Width="70px" Text='<%# Bind("subtotal") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Descuentos" SortExpression="Descuento">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("descuento") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label10" runat="server" Width="70px" Text='<%# Bind("descuento") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Impuestos" SortExpression="Impuestos">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("totalImpuestosTrasladados") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label11" runat="server" Width="70px" Text='<%# Bind("totalImpuestosTrasladados") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Retenciones" SortExpression="Retenciones">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("retenciones") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label12" runat="server" Width="70px" Text='<%# Bind("retenciones") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total" SortExpression="Total">
            <EditItemTemplate>
                <asp:TextBox ID="tbTotal" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lTotal" runat="server" Width="70px" Text='<%# Bind("total") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Propinas" SortExpression="Propinas">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("propinas") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label13" runat="server" Width="70px" Text='<%# Bind("propinas") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Correo de Contacto DHL" SortExpression="correCont">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("correoContac") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label14" runat="server" Width="220px" Text='<%# Bind("correoContac") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de Rechazo" SortExpression="fechRecha" ItemStyle-Width="110px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("fechaRechazo") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label152" runat="server" Width="110px" Text='<%# Bind("fechaRechazo") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Causa de Rechazo" SortExpression="cauRecha" ItemStyle-Width="220px">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label78" runat="server" Width="220px" Text='<%# Bind("causaRechazo") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No de Intentos" SortExpression="No_intent" ItemStyle-Width="25px">
            <EditItemTemplate>
                <asp:TextBox ID="TBNI" runat="server" Text='<%# Bind("No_intentos") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="TBNI2" runat="server" Width="25px" Text='<%# Bind("No_intentos") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UUID Complemento de pago" SortExpression="UUIDP">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox199" runat="server" Text='<%# Bind("UUIDP") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label798" runat="server" Text='<%# Bind("UUIDP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Recepcion de Complemento de pago" SortExpression="fechaP">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("fechaP") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label789" runat="server" Text='<%# Bind("fechaP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
    <asp:TemplateField HeaderText="Resultado Validación" Visible="False">
            <ItemTemplate>
             <a href="javascript:openPopup('ResultadoVal.aspx?idfa=<%# Eval("idFactura") %>')">
                <img  src="../../imagenes/info.ico" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
            </ItemTemplate>  
    </asp:TemplateField>

         <asp:TemplateField HeaderText="ENVIAR" Visible="False">
            <ItemTemplate>
             <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idFactura") %>')">
                <center>
                <img  src="imagenes/mail.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a></center>
            </ItemTemplate>         
        </asp:TemplateField>

    </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No existen registros.
        </EmptyDataTemplate>
    <FooterStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#C31A1A" Font-Bold="True" ForeColor="White" 
            Font-Size="10px" Wrap="False" BorderColor="White" />
    <PagerStyle BackColor="#d40511" ForeColor="White" 
            HorizontalAlign="Left" Wrap="False" />
        <RowStyle BackColor="#f2f2ed" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#E9E7E2"/>
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
                                              </ContentTemplate>
                                              </asp:UpdatePanel>
<%--</asp:Panel>--%>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
        SelectCommand="PA_facturas_basico_rec_2" SelectCommandType="StoredProcedure" >
    <SelectParameters>
        <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
        <asp:Parameter DefaultValue=" " Name="RFC" Type="String" />
            <asp:SessionParameter Name="MODULO" Type="String" SessionField="empresas" />
        <asp:Parameter DefaultValue=" " Name="ESTADO" Type="String" />
        <asp:Parameter DefaultValue="OTM|" Name="PI" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
                                </asp:Panel>
                                </td>
                              </tr>
                        </table>       
                    </center>

    <asp:Label runat="server" ID="alone" Enabled="false"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="vPaymentComplement" PopupControlID="pnlPaymen" runat="server" BackgroundCssClass="modalBackground" TargetControlID="alone"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlPaymen" CssClass="modalPopup" runat="server" align="center" Style="display: none">
        <div class="modal-body rowsSpaced" style="-ms-align-content: center; -webkit-align-content: center; align-content: center;">
            <div class="modal-header ">
                <h4 class="modal-title">HISTORIAL DE PAGOS DEL COMPROBANTE</h4>
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="gvComplementoPago" runat="server" AutoGenerateColumns="False" CssClass=" table table-condensed table-responsive table-hover"
                            PageSize="10" BackColor="White" AllowPaging="True" AllowSorting="True" Font-Size="Small" GridLines="None" DataSourceID="SqlDataSourceCPago"
                            DataKeyNames="idComPago" EnableModelValidation="False" Width="700px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="1px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="XML" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink3" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                            NavigateUrl='<%# Eval("XMLARC","~/download.aspx?file={0}").ToString().Replace("&","_") %>' Visible="true">       
                                <img  src="../imagenes/xml32x32.png" alt="xml" height="22" width="22">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PDF" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink3" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                            NavigateUrl='<%# Eval("PDFARC","~/download.aspx?file={0}").ToString().Replace("&","_") %>' Visible="true">       
                                <img  src="../imagenes/pdf32x32.png" alt="xml" height="22" width="22">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UUID Complemento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxU" runat="server" Text='<%# Bind("uuidP") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelU" runat="server" Text='<%# Bind("uuidP") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="280px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monto">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxMto" runat="server" Text='<%# Bind("impPagado") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelMto" runat="server" Text='<%# Bind("impPagado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Metodo Pago">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxMP" runat="server" Text='<%# Bind("metodoDePagoDR") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelMP" runat="server" Text='<%# Bind("metodoDePagoDR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxDate" runat="server" Text='<%# Bind("fechaPago") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelDate" runat="server" Text='<%# Bind("fechaPago") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="155px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Moneda">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3M" runat="server" Text='<%# Bind("monedaP") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelM" runat="server" Text='<%# Bind("monedaP") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No existen complementos de pago para esta factura.</EmptyDataTemplate>
                            <FooterStyle />
                            <HeaderStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="12px" />
                            <PagerStyle CssClass="bs-pagination" HorizontalAlign="Center" />
                            <PagerSettings />
                            <RowStyle />
                            <SelectedRowStyle />
                            <SortedAscendingCellStyle />
                            <SortedAscendingHeaderStyle />
                            <SortedDescendingCellStyle />
                            <SortedDescendingHeaderStyle />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceCPago" runat="server" ConnectionString=""
                            SelectCommand="PA_facturas_basico_rec_ComPago" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
                                <asp:Parameter DefaultValue=" " Name="SiO" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <br />
                    <div>
                        <asp:Label ID="lbResT" runat="server" Text="Resto a pagar:" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="tbResT" runat="server" Width="70px" Style="text-align: center" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                        <asp:Label ID="lbPagT" runat="server" Text="Total pagado:" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="tbPagT" runat="server" Width="70px" Style="text-align: center" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                        <asp:Label ID="lbTotal" runat="server" Text="Total a pagar:" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="tbTotal" runat="server" Width="70px" Style="text-align: center" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="modal-footer">
                        <asp:LinkButton ID="lbAddPaymentClose" runat="server" CssClass="btGrisNegrita" Width="60px" OnClick="blClosePayment_Click">Cerrar</asp:LinkButton>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:Label runat="server" ID="alone2" Enabled="false"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="vAddPagos" PopupControlID="pnlEditar" runat="server" BackgroundCssClass="modalBackground" TargetControlID="alone2"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlEditar" runat="server" align="center" Style="display: none" CssClass="modalPopupMP" Width="500px" Height="200px">
        <div class="modal-header ">
            <h4 class="modal-title ">CARGAR COMPLEMENTO DE PAGO CFDI</h4>
        </div>
        <asp:UpdatePanel ID="pnlEditarL" runat="server" align="center" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblXML" runat="server" Text="Cargar XML:" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="style60" align="left" style="border-style: ridge none outset none; border-width: thin; border-color: #000">
                                <ajaxToolkit:AsyncFileUpload ID="fuXML" runat="server" Width="223px" Font-Names="Arial" Font-Size="12px" OnUploadedComplete="fuXML_UploadedComplete" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblPDF" runat="server" Text="Cargar PDF:" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="text-align: left" style="border-style: ridge none outset none; border-width: thin; border-color: #000" class="style58">
                                <ajaxToolkit:AsyncFileUpload ID="fuPDF" runat="server" Width="223px" Font-Names="Arial" Font-Size="12px" OnUploadedComplete="fuPDF_UploadedComplete" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true" ForeColor="#d40511" Visible="true"></asp:Label>
                            </td>
                        </tr>
                        <tr></tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="msjError" runat="server" Text="" Font-Bold="true" Font-Size="X-Small" ForeColor="#d40511" Visible="true" Width="500px" Height="10px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div class="modal-footer">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cerrar" Width="115px" Style="font-weight: 700" BackColor="#d40511" BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Cargar" Width="115px" Style="font-weight: 700" BackColor="#d40511" BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" OnClick="btnLoad_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
