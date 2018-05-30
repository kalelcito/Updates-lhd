<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentos.aspx.cs" Inherits="DataExpressWeb.Documentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .form-control-det {
            display: block;
            width: 350px;
            height: 200px;
            padding: 6px 12px;
            font-size: 12px;
            line-height: 1.428571429;
            align-content: center;
            color: #555555;
            vertical-align: middle;
            background-color: #F2EFEF;
            border: 1px solid #d40511;
            border-radius: 4px;
            font-family: Arial;
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
            -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            overflow: auto;
        }

        .btGrisNegrita {
            background-color: #F6CECE; /*#666666;*/
            color: #FFFFFF;
            font-size: 13px;
            border: 1px solid #333333;
            text-decoration: none;
            border-bottom-color: aliceblue;
            border-color: red;
            border-radius: 3px;
            text-align: center;
        }

        .modalPopup {
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

        #Text1 {
            width: 189px;
            margin-top: 0px;
        }

        #Text2 {
            width: 474px;
        }

        #Text3 {
            width: 164px;
        }

        #Text5 {
            width: 139px;
        }

        #Text6 {
            width: 138px;
        }

        .style22 {
            width: 105px;
        }

        .style23 {
            width: 49px;
        }

        #bus {
            position: absolute;
            left: 468px;
            top: 197px;
            z-index: 1;
            height: 32px;
            width: 72px;
        }

        #bus2 {
            position: absolute;
            left: 461px;
            top: 250px;
            z-index: 1;
            width: 151px;
            height: 39px;
        }

        #bus3 {
            position: absolute;
            left: 461px;
            top: 250px;
            z-index: 1;
            width: 150px;
            height: 40px;
        }

        .style26 {
            height: 6px;
        }

        .style28 {
            width: 36px;
        }

        .style31 {
            width: 140px;
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
    </style>

    <script type="text/javascript" language="javascript">
        function openPopup(strOpen) {
            open(strOpen, "Info",
         "status=1, width=500, height=300, top=100, left=300");
        }
    </script>
</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <span class="titulo">Mis Comprobantes &nbsp;&nbsp;&nbsp;</span>
    <ul id="navigation">

        <li>
            <asp:LinkButton ID="LinkButton1" CssClass="sideMenuComprobantesFiscales"
                runat="server" OnClick="LinkButton1_Click" OnClientClick="return confirm('Al subir archivos procura que no pasen los 2 MB de tamaño,\nya que por seguridad del portal no se permitirá subir los documentos.');"> Cargar CFDI</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton5" CssClass="sideMenuComprobantesFiscales"
                runat="server" OnClick="btPagos_Click" OnClientClick="return confirm('Al subir archivos procura que no pasen los 2 MB de tamaño,\nya que por seguridad del portal no se permitirá subir los documentos.');"> Cargar complemento de Pago</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton2" CssClass="sideMenuComprobantesFiscales" runat="server" OnClick="LinkButton2_Click"> Editar CFDI</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton4" CssClass="sideMenuComprobantesFiscales" runat="server" OnClick="LinkButton4_Click"> Ver Todos</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton3" CssClass="sideMenuComprobantesFiscales" runat="server" OnClick="LinkButton3_Click"> Filtrar</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="lbReportsM" CssClass="sideMenuComprobantesFiscales" runat="server" OnClick="lbReports_Click">Reportes</asp:LinkButton></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <span id="bus">

        <asp:Panel ID="Pbuscar" runat="server" BackColor="#FFEA1E"
            BorderColor="#E4B918"
            BorderStyle="Groove" Height="31px" Visible="False"
            Width="52px" ScrollBars="Auto">
            <br />
            <asp:Panel ID="Panel2" runat="server" BorderColor="#E4B918" BorderStyle="Ridge"
                Height="126px" Width="384px">
                <table style="width: 383px; height: 86px;">
                    <tr>
                        <td>RFC:</td>
                        <td>
                            <asp:TextBox ID="tbRFC" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Folio o Folios:<br />
                            &nbsp;Formato(1,2,3,4-8)</td>
                        <td>
                            <asp:TextBox ID="tbFolioAnterior" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Serie:</td>
                        <td>
                            <asp:TextBox ID="tbSerie" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Razón Social</td>
                        <td>
                            <asp:TextBox ID="tbNombre" runat="server" Width="244px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:Button ID="bBuscar" runat="server" BackColor="#FFD307"
                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px"
                OnClick="Button1_Click" Text="Buscar" Width="87px" />
            <br />
        </asp:Panel>
    </span>
    <span id="bus2">
        <asp:Panel ID="otro"
            runat="server" BackColor="#d1d1d1"
            BorderColor="#000"
            BorderStyle="Solid" Height="33px" Visible="False" BorderWidth="1px"
            Width="143px" ScrollBars="Auto">
            <center>
                                             <asp:Panel ID="Panel5" runat="server" BackColor="#d40511" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Solid" BorderWidth="1px"
                        Width="415px">
                        Editar CFDI</asp:Panel>
                        </center>
            <br />
            <center>
                                <asp:Panel ID="Panel1" runat="server" BorderColor="#000" BorderStyle="Solid" 
                                              BorderWidth="1px"   Height="183px" Width="375px">
                                               
                                                <table style="width: 375px; height: 125px">
                                                <tr>
                                                <td colspan="2"><center>Folio: </center></td>
                                                </tr>
                                                <tr>
                                                <td colspan="2">
                                                <center>
                                                    <asp:TextBox ID="TFol" runat="server" Width="128px" Enabled="false"></asp:TextBox>
                                                    </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td colspan="2"><center>Campos a Editar</center></td>
                                                </tr>
                                                <tr>
                                                <td class="style31">Moneda:</td>
                                                <td>
                                                    <asp:DropDownList ID="lMon" runat="server" DataSourceID="SqlDataMon" 
                                                        DataTextField="codigoISO" DataValueField="codigoISO">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataMon" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                                        SelectCommand="SELECT [codigoISO] FROM [monedas]"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td class="style31">
                                                    <asp:Label ID="LIden" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                <td>
                                                    <asp:TextBox ID="TcodCo" runat="server" MaxLength="21" Width="193px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                </table>
                                         </asp:Panel>
                                         
                                  </center>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             
           

           



            <center>
                                 <asp:Button ID="But" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Editar" Width="87px" ForeColor="White" onclick="But_Click" OnClientClick="return confirm('Seguro que desea editar el comprobante');" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                               
                                <asp:Button ID="Button2" runat="server" BackColor="#d40511" 
                                    BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                    Text="Cancelar" Width="87px" onclick="Button2_Click1" ForeColor="White" />
                                                </center>
        </asp:Panel>
    </span>
    <span id="bus3">
        <center style="height: 43px; width: 149px;">
                <asp:Panel ID="PanelBusca" runat="server" BackColor="#d1d1d1" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="26px" Visible="False" 
                                            Width="97px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel45" runat="server" BackColor="#d40511" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Filtro</asp:Panel>
                                            <asp:Panel ID="Panel46" runat="server" BorderColor="#666666" BorderStyle="Ridge" 
                                                Height="242px" Width="384px">
                                                <table style="width: 383px; height: 86px;">
                                                    <tr>
                                                        <td>
                                                            Proveedor:</td>
                                                        <td>
                                                           <asp:TextBox ID="Tprov" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Tipo de Proveedor:</td>
                                                        <td>
                                                         <asp:TextBox ID="Ttip" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%--<td>
                                                            Serie:</td>--%>
                                                        <td>
                                                           <asp:TextBox ID="Tser" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" Visible="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            UUID:
                                                            </td>
                                                        <td>
                                                            <asp:TextBox ID="Tuuid" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" Visible="True"></asp:TextBox>
                                                            <asp:TextBox ID="Tfol2" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Moneda:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tmon" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="21px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            Total:</td>
                                                        <td>
                                                            <asp:TextBox ID="Ttot" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="24px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LbusId" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="Tcod" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="20px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="butonBus" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Buscar" Width="87px" ForeColor="White" onclick="butonBus_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button12" runat="server" BackColor="#d40511" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button12_Click" ForeColor="White" />
                                            <br />
                                        </asp:Panel>
                                        </center>
    </span>
    <tr>
        <td class="style20" colspan="3"></td>
    </tr>
    <asp:Panel Visible="false" ID="Panel3" runat="server" BackColor="#FFEA1E" BorderColor="#E4B918"
        BorderStyle="Groove" Height="116px" Width="1244px"
        Style="margin-right: 6px; margin-top: 17px;">
        <asp:Panel ID="Panel6" runat="server" BackColor="#CC0000" BorderColor="White" Font-Bold="True" ForeColor="White" Height="16px">
            MIS COMPROBANTES
        </asp:Panel>
        <br />
        <asp:Panel Visible="false" ID="Panel4" runat="server" BorderColor="#E4B918" BorderStyle="Ridge"
            Height="76px" Width="1232px">
            <table style="width: 135px; height: 68px; font-size: xx-small;">
                <tr>
                    <td class="style28" style="border: thin solid #FF0000">
                        <center style="width: 37px">
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" onclick="ImageButton1_Click" 
                                        Width="23px" />
                    </td>
                    <td class="style23"
                        style="border: thin solid #FFFF00; background-color: #FFFF99">
                        <center>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                        ImageUrl="~/Imagenes-dhl/D5.PNG" Width="23px" onclick="ImageButton2_Click" />
                    </td>
                    <td class="style22" style="border: thin solid #FF0000">
                        <center>
                                    <asp:ImageButton ID="ImageButton3" runat="server" Height="23px" 
                                        ImageUrl="~/Imagenes-dhl/D1.PNG" onclick="ImageButton3_Click" 
                                        Width="21px" />
                    </td>
                </tr>

                <tr>
                    <td class="style26" colspan="3">
                        <center>
                                            <asp:Label ID="lMensaje" runat="server" ForeColor="#FF5050"></asp:Label>
                                        </center>
                    </td>
                </tr>
            </table>

        </asp:Panel>
    </asp:Panel>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                   </td>
        </tr>
    <tr>
        <td colspan="3"></td>
    </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:CheckBox ID="ChackSabCom" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="12px" OnCheckedChanged="ChackSabCom_CheckedChanged" Text="Comprobantes con No. de Sabana" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PaneFa" runat="server" BorderColor="#CC0000" BorderStyle="none" Height="440px" Width="1055px" ScrollBars="Horizontal">
                    <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                        Width="2700px" Style="margin-top: 0px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="1px"
                        OnSelectedIndexChanged="gvFacturas_SelectedIndexChanged" AllowPaging="True" PageSize="7" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gvFacturas_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#000" Font-Names="Arial" Font-Size="12px" />
                        <Columns>
                            <asp:ImageField DataImageUrlField="EDOFAC"
                                DataImageUrlFormatString="~/Imagenes/{0}.png" HeaderText="Estatus" Visible="false">
                                <ControlStyle Height="35px" Width="35px" />
                                <HeaderStyle Width="7%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:ImageField>

                            <asp:TemplateField HeaderText="Marcar" ItemStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idFactura")%>' />
                                    <asp:HiddenField ID="checkMP" runat="server" Value='<%#Bind("metodoDePago")%>' />
                                </ItemTemplate>
                                <HeaderStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="O/C" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink2" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                        Visible='<%# Eval("facSAT").ToString() == ("0") %>' NavigateUrl='<%# Eval("ORDENARC","~/download.aspx?file={0}") %>'>       
                                <img  src="imagenes-dhl/D5.PNG" alt="xml" height="22" width="22">
                                    </asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="XML" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink3" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                        NavigateUrl='<%# Eval("XMLARC","~/download.aspx?file={0}") %>' Visible="true">       
                                <img  src="imagenes/xml32x32.png" alt="xml" height="22" width="22">
                                    </asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PDF" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                        Visible='<%# Eval("facSAT").ToString() == ("0") %>' NavigateUrl='<%# Eval("PDFARC","~/download.aspx?file={0}") %>'>       
                                <img  src="imagenes/pdf32x32.png" alt="pdf" height="22" width="22">
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
                            <asp:TemplateField HeaderText="Complemento de Pago" SortExpression="idFactura" ItemStyle-Width="50px" ItemStyle-Font-Size="XX-Large" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idFactura") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btPagos" runat="server" CssClass="btGrisNegrita" Text="Ver" Width="40px" CommandArgument='<%#Bind("idFactura") %>' OnClick="btComplementoPago_Click" Visible="false"></asp:LinkButton>
                                    <asp:HiddenField ID="checkHdID" runat="server" Value='<%# Eval("idFactura") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Proveedor" SortExpression="NOMEMI" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NOMEMI") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NOMEMI") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Proveedor" SortExpression="tipProv">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("tipProv") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("tipProv") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receptor" SortExpression="RFCREC" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("razonSoc") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("razonSoc") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de CFDI" SortExpression="tipCfdi">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("tipCfdi") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("tipCfdi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UUID" SortExpression="uuid">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxuuid" runat="server" Text='<%# Bind("uuid") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Labeluuid" runat="server" Text='<%# Bind("uuid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Emisión" SortExpression="FECHA">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label46" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Recepción" SortExpression="FECHA">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label90" runat="server" Text='<%# Bind("fechaRec") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Ultimo Cambio" SortExpression="fechUlt">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("fechaUltimCam") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("fechaUltimCam") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("estatus") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label151" runat="server" Text='<%# Bind("estatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Moneda" SortExpression="Moneda">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtotal" SortExpression="Subtotal">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descuentos" SortExpression="Descuento">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("descuento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("descuento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Impuestos" SortExpression="Impuestos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("totalImpuestosTrasladados") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("totalImpuestosTrasladados") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Retenciones" SortExpression="Retenciones">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("retenciones") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("retenciones") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbTotal" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lTotal" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Propinas" SortExpression="Propinas">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("propinas") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("propinas") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Código Contable" SortExpression="Código Contable">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbCodCont" runat="server" Text='<%# Bind("CodCont") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lCodCont" runat="server" Text='<%# Bind("CodCont") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Correo de Contacto DHL" SortExpression="correCont">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("correoContac") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("correoContac") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Rechazo" SortExpression="fechRecha">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("fechaRechazo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label152" runat="server" Text='<%# Bind("fechaRechazo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Causa de Rechazo" SortExpression="cauRecha">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label78" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:Label>
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
                                        <img src="imagenes/info.ico" alt="pdf" border="0" align="middle"
                                            height="22" width="22"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ENVIAR" Visible="False">
                                <ItemTemplate>
                                    <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idFactura") %>')">
                                        <center>
                <img  src="imagenes/mail.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22">
                                    </a></center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#d40511" Font-Bold="True" ForeColor="White"
                            Font-Names="Arial" Font-Size="12px" />
                        <PagerStyle BackColor="#d40511" ForeColor="White"
                            HorizontalAlign="Left" Font-Names="Arial" Font-Size="12px" />
                        <RowStyle BackColor="#f2f2ed" ForeColor="#000" Font-Names="Arial" Font-Size="12px" />
                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"
                            HorizontalAlign="Left" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PaneOt" runat="server" BorderColor="#CC0000" BorderStyle="none"
                    Height="440px" Width="1055px" ScrollBars="Auto" Visible="false">
                    <asp:GridView ID="gvFacturas2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
                        Width="2700px" Style="margin-top: 0px" BorderColor="#CC0000"
                        BorderStyle="Solid" BorderWidth="1px"
                        OnSelectedIndexChanged="gvFacturas_SelectedIndexChanged"
                        AllowPaging="True" PageSize="7" OnRowDataBound="gvFacturas_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#000" Font-Names="Arial" Font-Size="12px" />
                        <Columns>
                            <asp:ImageField DataImageUrlField="EDOFAC"
                                DataImageUrlFormatString="~/Imagenes/{0}.png" HeaderText="Estatus" Visible="false">
                                <ControlStyle Height="35px" Width="35px" />
                                <HeaderStyle Width="7%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:ImageField>
                            <asp:TemplateField HeaderText="Marcar" ItemStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idFactura")%>' />
                                    <asp:HiddenField ID="checkMP" runat="server" Value='<%#Bind("metodoDePago")%>' />
                                </ItemTemplate>
                                <HeaderStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="XML" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink3" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                        NavigateUrl='<%# Eval("XMLARC","~/download.aspx?file={0}") %>' Visible="true">       
                                <img  src="imagenes/xml32x32.png" alt="xml" height="22" width="22">
                                    </asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PDF" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" Height="15" Width="15" runat="server" BorderWidth="0px" BorderStyle="None"
                                        Visible='<%# Eval("facSAT").ToString() == ("0") %>' NavigateUrl='<%# Eval("PDFARC","~/download.aspx?file={0}") %>'>       
                                <img  src="imagenes/pdf32x32.png" alt="pdf" height="22" width="22">
                                    </asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Versión CFDI" SortExpression="version" ItemStyle-HorizontalAlign="center">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox80" runat="server" Text='<%# Bind("version") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label80" runat="server" Text='<%# Bind("version") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Complemento de Pago" SortExpression="idFactura" ItemStyle-Width="50px" ItemStyle-Font-Size="XX-Large" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idFactura") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btPagos" runat="server" CssClass="btGrisNegrita" Text="Ver" Width="40px" CommandArgument='<%#Bind("idFactura") %>' OnClick="btComplementoPago_Click"></asp:LinkButton>
                                    <asp:HiddenField ID="checkHdID" runat="server" Value='<%# Eval("idFactura") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proveedor" SortExpression="NOMEMI" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NOMEMI") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NOMEMI") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. Sabana" SortExpression="nosab">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbSab" runat="server" Text='<%# Bind("noSabana") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lSab" runat="server" Text='<%# Bind("noSabana") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Proveedor" SortExpression="tipProv">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("tipProv") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("tipProv") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receptor" SortExpression="RFCREC" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("razonSoc") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("razonSoc") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UUID" SortExpression="uuid">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxuuid" runat="server" Text='<%# Bind("uuid") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Labeluuid" runat="server" Text='<%# Bind("uuid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de CFDI" SortExpression="tipCfdi">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("tipCfdi") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("tipCfdi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Emisión" SortExpression="FECHA">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label46" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Recepción" SortExpression="FECHA">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label90" runat="server" Text='<%# Bind("fechaRec") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Ultimo Cambio" SortExpression="fechUlt">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("fechaUltimCam") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("fechaUltimCam") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("estatus") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label151" runat="server" Text='<%# Bind("estatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Moneda" SortExpression="Moneda">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lMon" runat="server" Text='<%# Bind("Moneda") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtotal" SortExpression="Subtotal">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lSubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descuentos" SortExpression="Descuento">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("descuento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("descuento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Impuestos" SortExpression="Impuestos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("totalImpuestosTrasladados") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("totalImpuestosTrasladados") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Retenciones" SortExpression="Retenciones">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("retenciones") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("retenciones") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbTotal" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lTotal" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Propinas" SortExpression="Propinas">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("propinas") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("propinas") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Correo de Contacto DHL" SortExpression="correCont">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("correoContac") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("correoContac") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Rechazo" SortExpression="fechRecha">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("fechaRechazo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label152" runat="server" Text='<%# Bind("fechaRechazo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Causa de Rechazo" SortExpression="cauRecha">
                                <EditItemTemplate>
                                    <asp:TextBox ID="causaRechazo" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="causaRechazo" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UUID Complemento de pago" SortExpression="UUIDP">
                                <EditItemTemplate>
                                    <asp:TextBox ID="UUIDP" runat="server" Text='<%# Bind("UUIDP") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="UUIDP" runat="server" Text='<%# Bind("UUIDP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Recepcion de Complemento de pago" SortExpression="fechaP">
                                <EditItemTemplate>
                                    <asp:TextBox ID="fechaP" runat="server" Text='<%# Bind("fechaP") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="fechaP" runat="server" Text='<%# Bind("fechaP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resultado Validación" Visible="False">
                                <ItemTemplate>
                                    <a href="javascript:openPopup('ResultadoVal.aspx?idfa=<%# Eval("idFactura") %>')">
                                        <img src="imagenes/info.ico" alt="pdf" border="0" align="middle"
                                            height="22" width="22"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ENVIAR" Visible="False">
                                <ItemTemplate>
                                    <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idFactura") %>')">
                                        <center>
                <img  src="imagenes/mail.png" alt="pdf" border="0" align="middle"   height="22" width="22">
                                    </a></center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#d40511" Font-Bold="True" ForeColor="White"
                            Font-Names="Arial" Font-Size="12px" />
                        <PagerStyle BackColor="#d40511" ForeColor="White"
                            HorizontalAlign="Left" Font-Names="Arial" Font-Size="12px" />
                        <RowStyle BackColor="#f2f2ed" ForeColor="#000" Font-Names="Arial" Font-Size="12px" />
                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"
                            HorizontalAlign="Left" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>"
        SelectCommand="PA_facturas_basico_rec_2" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
            <asp:SessionParameter Name="RFC" Type="String" SessionField="rfcUser" />
            <asp:Parameter DefaultValue=" " Name="MODULO" Type="String" />
            <asp:Parameter DefaultValue=" " Name="ESTADO" Type="String" />
            <asp:Parameter DefaultValue="ORACLE|REN|" Name="PI" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>"
        SelectCommand="PA_facturas_basico_rec_2" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
            <asp:SessionParameter Name="RFC" Type="String" SessionField="rfcUser" />
            <asp:Parameter DefaultValue=" " Name="MODULO" Type="String" />
            <asp:Parameter DefaultValue=" " Name="ESTADO" Type="String" />
            <asp:Parameter DefaultValue="OTM|" Name="PI" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click3"
        Text="Limpiar" Visible="False" />
    <asp:Label ID="lSeleccionDocus" runat="server" Text="Documentos Seleccionado:"
        Visible="False"></asp:Label>
    <br />

    <asp:Label runat="server" ID="alone" Enabled="false"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="vPaymentComplement" PopupControlID="pnlPaymen" runat="server" BackgroundCssClass="modalBackground" TargetControlID="alone"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlPaymen" CssClass="modalPopup" runat="server" align="center" Style="display: none">
        <div class="modal-body rowsSpaced" style="-ms-align-content: center; -webkit-align-content: center; align-content: center;">
            <div class="modal-header ">
                <h4 class="modal-title">HISTORIAL DE PAGOS DEL COMPROBANTE</h4>
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
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
                                <img  src="../imagenes/pdf32x32.png" alt="pdf" height="22" width="22">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UUID Complemento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="uuidP" runat="server" Text='<%# Bind("uuidP") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="uuidP" runat="server" Text='<%# Bind("uuidP") %>'></asp:Label>
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
    <asp:Panel ID="pnlEditar" runat="server" align="center" Style="display: none" CssClass="modalPopup" Width="500px" Height="200px">
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

    <asp:Label runat="server" ID="alone1" Enabled="false"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="vReports" PopupControlID="pnlReports" runat="server" BackgroundCssClass="modalBackground" TargetControlID="alone1"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlReports" runat="server" align="center" Style="display: none" CssClass="modalPopup">
        <div class="modal-header ">
            <h4 class="modal-title ">GENERAR REPORTE PARA PROVEEDOR</h4>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" align="center" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div title="Filters" class="centrar">
                    <table style="width: 90%;" align="center">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label1" runat="server" Style="font-weight: 400;" Font-Names="Arial" Font-Size="12px" Font-Bold="True">Tipo de reporte: </asp:Label>
                                <asp:DropDownList ID="DropRep" runat="server" Font-Names="Arial" AutoPostBack="true" Font-Size="12px" Height="16px" Style="margin-bottom: 0px" Width="200px">
                                    <asp:ListItem>GENERAL</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:TextBox ID="tbFechaIni" runat="server" Width="120px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="tbFechaIni" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="tbFechaIni" WatermarkText="Selecciona la fecha" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender>
                                <br />
                            </td>
                            <td>
                                <asp:TextBox ID="tbFechaFin" runat="server" Width="120px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbFechaFin" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="tbFechaFin" WatermarkText="Selecciona la fecha" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2" colspan="3" align="center">
                                <br />
                                <asp:Label ID="lErrorCalendar" runat="server" ForeColor="Red" Width="632px" Height="16px" EnableViewState="False"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div class="modal-footer">
                    <asp:Button ID="Button3" runat="server" BackColor="#d40511" BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" Text="Cerrar" Width="87px" OnClick="btnCancel" ForeColor="White" />
                    <asp:Button ID="Button4" runat="server" Text="Generar" OnClick="bGenerar_Click" Style="font-weight: 700" BackColor="#d40511" BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
