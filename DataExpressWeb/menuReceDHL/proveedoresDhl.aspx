<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="proveedoresDhl.aspx.cs" Inherits="DataExpressWeb.Formulario_web115" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .panelBodyWrapper {
            border: 1px ridge #666666;
        }

        .header {
            overflow: hidden;
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

        .formEditar {
            width: 301px;
            height: 176px;
            font-family: Arial;
            font-weight: bold;
            font-size: 12px;
            line-height: 18px;
            color: #666666;
            text-align: right;
        }

        .textboxForm {
            font: Normal 12px Arial;
        }
        /*Estilo para el boton*/
        .botonForm {
            background-color: #d40511;
            border-color: #e4b918;
            border-bottom-style: ridge;
            font-weight: normal;
            font-size: 11px;
            color: #ffffff;
            height: 23px;
            width: 87px;
        }

            .botonForm:hover {
                color: #ffcc00;
            }

        #bus10 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 36px;
            width: 146px;
        }

        #bus11 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 44px;
            width: 129px;
        }

        #bus12 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 44px;
            width: 128px;
        }

        #bus13 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 64px;
            width: 127px;
        }

        .navigation {
            text-decoration: none;
        }

        .reportes {
            text-decoration: none;
        }

        ul.navigation {
            padding: 0 0 1em 1.75em;
            list-style-image: url(../imagenes/arrow.png);
            list-style-position: inside;
        }

        .sideMenu {
            text-decoration: none;
            font-family: Arial;
            font-weight: normal;
            font-size: 12px;
        }

            .sideMenu:hover {
                text-decoration: underline;
                color: #C90101;
            }

        .tituloActive {
            /*padding: 0 0 1em 1.75em;*/
            list-style-position: inside;
            font: normal bold 12px Arial;
        }

        .titulo {
            list-style-position: inside;
            font: normal normal 12px Arial;
        }

        h1 {
            background-color: #C90101;
            color: #fff;
            font: normal bold 20px arial;
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <ul class="navigation">
        <%if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/menuReceDHL/UsuariosDhl.aspx" runat="server">Administración de Usuarios</asp:HyperLink></span><br />
        <%} %>

        <span class="tituloActive">Administración de Proveedores</span>
        <li><span class="tituloActive">Proveedores</span></li>
        <%if (!(Session["permisos"].ToString().IndexOf("CrearPro") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="sideMenu" runat="server">Crear</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("EditarPro") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton4" OnClick="Button20_Click" CssClass="sideMenu" runat="server">Editar</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("InhabilitarPro") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton5" OnClick="Button21_Click" CssClass="sideMenu" runat="server">Inhabilitar</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("RehabilitarPro") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton6" OnClick="Button22_Click" CssClass="sideMenu" runat="server">Rehabilitar</asp:LinkButton></li>
        <%} %>

        <li>
            <asp:LinkButton ID="LinkButton293" CssClass="sideMenu" runat="server" OnClick="LinkButton293_Click">Ver todos</asp:LinkButton></li>

        <li>
            <asp:LinkButton ID="LinkButton253" CssClass="sideMenu" runat="server"
                OnClick="LinkButton253_Click">Filtrar</asp:LinkButton></li>

        <%if (!(Session["permisos"].ToString().IndexOf("SolicReg") < 0))
            { %>
        <li>
            <asp:HyperLink ID="HyperLink12" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/solicitudes.aspx" runat="server">Solicitudes de Registro</asp:HyperLink></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/menuReceDHL/receptoresCfdi.aspx" runat="server">Administración de Receptores de CFDI</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx" runat="server">Administración de Configuración</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx" runat="server">Administración de Mensaje</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmCat") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink6" NavigateUrl="~/menuReceDHL/adminCat.aspx" runat="server">Administración de Catálogos</asp:HyperLink></span><br />
        <%} %>
        <%if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/reportes/reporteSucursalesA.aspx" runat="server">Reportes</asp:HyperLink></span><br />
        <%} %>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Proveedores</h1>

    <table style="width: 416px; height: 33px">

        <tr>
            <td>
                <span id="bus10">
                    <center style="height: 39px; width: 108px">
                                   <asp:Panel CssClass="panelWrapper" ID="Peditar" runat="server" ScrollBars="Auto" 
                                        Height="39px" Width="77px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel12" runat="server">Editando Proveedor</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel13" runat="server" Height="290px" Width="374px">
                <table class="formEditar">
                    <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfc" runat="server" TextMode="SingleLine" ></asp:TextBox><%--ontextchanged="filtro_TextChanged"--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Razón Social:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trs" runat="server"  TextMode="SingleLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Correo Contacto:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tcorr" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Correo Notificaciones:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tnoti" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Vendor ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tven" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Vendor Site ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tsite" runat="server" TextMode="SingleLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                     <td>
                     Nombre Usuario:
                     </td>
                     <td>
                     <asp:TextBox CssClass="textboxForm" ID="Tusa" runat="server"></asp:TextBox>
                     </td>
                    </tr>
                    <tr>
                      <td>Contraseña:</td>
                      <td><asp:TextBox CssClass="textboxForm" ID="TexPass" runat="server" TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>Forma Pago:</td>
                      <td><asp:TextBox CssClass="textboxForm" ID="TbFP" runat="server" TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td>
                            Tipo:</td>
                        <td>
                           <asp:DropDownList CssClass="textboxForm" ID="Droptip" runat="server" 
                                DataSourceID="SqlDatapr" DataTextField="nombre" DataValueField="nombre">
                                </asp:DropDownList>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
<asp:Button CssClass="botonForm"  ID="Button8" runat="server"  Text="Grabar" onclick="Button8_Click"  OnClientClick="return confirm('Seguro que desea editar el proveedor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button7" runat="server"  Text="Cancelar" onclick="Button7_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                                </center>
                </span>

                <span id="bus11">
                    <center style="height: 28px; width: 90px">
                                    <asp:Panel CssClass="panelWrapper" ID="Pina" runat="server" ScrollBars="Auto" 
                                         Height="35px" Width="97px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel20" runat="server">Inhabilitar Proveedor</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel21" runat="server" Height="164px" Width="399px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Razón Social:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trzin" runat="server" 
                                TextMode="SingleLine" Width="181px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfcin" runat="server"  
                                TextMode="SingleLine" Width="181px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Causa de la inhabilitación:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tcausain" runat="server" 
                                TextMode="MultiLine" Height="32px" Width="184px"  ></asp:TextBox>
                        </td>
                    </tr>
                  
                </table>
        </asp:Panel>
        <br />
<asp:Button CssClass="botonForm"  ID="Button14" runat="server"  Text="Grabar" onclick="Button14_Click"  OnClientClick="return confirm('Seguro que desea inhabilidar el proveedor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button13" runat="server"  Text="Cancelar" onclick="Button13_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                                 </center>
                </span>

                <span id="bus12">
                    <center>
                                  <asp:Panel CssClass="panelWrapper" ID="Phabi" runat="server" ScrollBars="Auto" 
                                        Height="45px" Width="128px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel23" runat="server">Rehabilitar Proveedor</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel24" runat="server" Height="161px" Width="399px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Razón Social:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trzhabi" runat="server" 
                                TextMode="SingleLine"  Width="181px" ></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfchabi" runat="server"  
                                TextMode="SingleLine" Width="183px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Causa de la rehabilitación:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tcauhabi" runat="server" 
                                TextMode="Multiline" Height="33px" Width="188px"  ></asp:TextBox>
                        </td>
                    </tr>
                  
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button16" runat="server"  Text="Grabar" onclick="Button16_Click"  OnClientClick="return confirm('Seguro que desea rehabilitar el proveedor');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button15" runat="server"  Text="Cancelar" onclick="Button15_Click" />
<br />
    </asp:Panel>
                                </center>
                </span>

                <span id="bus13">
                    <center style="height: 43px; width: 132px">
                                    <asp:Panel CssClass="panelWrapper" ID="PanFiltProv" runat="server" ScrollBars="Auto" 
                                         Height="55px" Width="151px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel2" runat="server">Filtrar Proveedor</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel3" runat="server" Height="79px" Width="399px">
            <table style="height: 68px; width: 357px">
              <tr>
              <td>
                  <asp:Label ID="Label599" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Text="RFC:"></asp:Label>
                  </td>
              <td>
                  <asp:TextBox ID="TrfcBus" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Height="25px" Width="132px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
              <td><asp:Label ID="Label900" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Text="Tipo de Proveedor:"></asp:Label></td>
              <td>
                  <asp:TextBox ID="TtipBus" runat="server" Font-Names="Arial" Height="25px" 
                      Width="133px"></asp:TextBox>
                  </td>
              </tr>
            </table>
            </asp:Panel>
            <br />
<asp:Button CssClass="botonForm"  ID="Button252" runat="server"  Text="Buscar" onclick="Button252_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button151" runat="server"  Text="Cancelar" onclick="Button151_Click"  />
<br />
            </asp:Panel>
            </center>
                </span>

            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <br />
                <asp:Panel ID="Panel17" runat="server" BorderColor="#CC0000" BorderStyle="none"
                    Width="20%" ScrollBars="Auto">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"
                        CellPadding="1" ForeColor="#333333" GridLines="None" Width="5000px"
                        DataKeyNames="idProveedor"
                        BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="1px"
                        Style="margin-top: 0px; height: auto" Font-Size="10px"
                        CellSpacing="1" AllowPaging="True" Visible="false">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Arial" Font-Size="12px" />
                        <Columns>
                            <asp:BoundField DataField="idProveedor" HeaderText="idProveedor"
                                InsertVisible="False" ReadOnly="True" SortExpression="idProveedor"
                                Visible="False" />

                            <asp:TemplateField HeaderText="Marcar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idProveedor")%>' />
                                </ItemTemplate>
                                <%--<HeaderStyle Width="5%" />--%>
                                <ItemStyle HorizontalAlign="Center" />
                                <%--<ItemStyle Width="50px" />--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RFC" SortExpression="rfc" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Razón Social" SortExpression="razonSocial" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("razonSocial") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("razonSocial") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Habilitado" SortExpression="habilitado" ItemStyle-Width="200px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("habilitado") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%# Bind("habilitado") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Vendor ID" SortExpression="vendor" ItemStyle-Width="200px">

                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("vendorID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>

                                    <asp:Label ID="Label309" runat="server" Text='<%# Bind("vendorID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Vendor Site ID" SortExpression="venSite">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("vendorSite") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label343" runat="server" Text='<%# Bind("vendorSite") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tipo de Proveedor" SortExpression="tProv">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tipoProveedor") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label365" runat="server" Text='<%# Bind("tipoProveedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Privacidad Aceptada" SortExpression="priv">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("privacidad") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label398" runat="server" Text='<%# Bind("privacidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha de Aceptación" SortExpression="fechAcept">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fechaAceptacion") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label338" runat="server" Text='<%# Bind("fechaAceptacion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre del Contacto" SortExpression="contacto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("contacto") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label329" runat="server" Text='<%# Bind("contacto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Correo de Contacto" SortExpression="correo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("correo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label598" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Teléfono de Contacto" SortExpression="telefono">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("telefono") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Correo Notificaciones" SortExpression="correo2">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("correo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label593" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Causa de inhabilitación / rehabilitación" SortExpression="inha">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("causaHabilitar") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label537" runat="server" Text='<%# Bind("causaHabilitar") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Calle" SortExpression="calle">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("calle") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label512" runat="server" Text='<%# Bind("calle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="No. Exterior" SortExpression="ext">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("noExt") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label584" runat="server" Text='<%# Bind("noExt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="No. Interior" SortExpression="inte">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("noInt") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label519" runat="server" Text='<%# Bind("noInt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Colonia" SortExpression="colinia">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("colonia") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label594" runat="server" Text='<%# Bind("colonia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Localidad / Ciudad" SortExpression="loc">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("localidad") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label576" runat="server" Text='<%# Bind("localidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Referencia" SortExpression="ref">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("referencia") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label515" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Municipio / Delegación" SortExpression="mun">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("municipio") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label573" runat="server" Text='<%# Bind("municipio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Estado" SortExpression="estado">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("estado") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label524" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="País" SortExpression="pais">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("pais") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label505" runat="server" Text='<%# Bind("pais") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Código Postal" SortExpression="codPos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codPostal") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label590" runat="server" Text='<%# Bind("codPostal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="header" BackColor="#CC0000" Font-Bold="True" ForeColor="White"
                            Font-Names="Arial" Font-Size="12px" />
                        <PagerSettings PageButtonCount="20" />
                        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Left" Font-Names="Arial" Font-Size="12px" />
                        <RowStyle BackColor="#f2f2ed" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" />
                        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
                        SelectCommand="SELECT [rfc], [idProveedor], [razonSocial], [contacto], [telefono], [correo],[habilitado], [vendorID],
         [vendorSite], [tipoProveedor], [privacidad], [fechaAceptacion], [causaHabilitar], [calle], [noExt], [noInt],
         [colonia], [localidad], [referencia], [municipio], [estado], [pais], [codPostal], [causaRechazo] FROM [Proveedores] WHERE [status]='aprobado' order by [idProveedor] desc"
                        UpdateCommand="UPDATE Proveedores SET rfc= @rfc, razonSocial= @razonSocial WHERE (idProveedor= @idProveedor)"
                        DeleteCommand="DELETE FROM Proveedores WHERE (idProveedor= @idProveedor)">


                        <UpdateParameters>
                            <asp:Parameter Name="rfc" />
                            <asp:Parameter Name="razonSocial" />
                            <asp:Parameter Name="contacto" />
                            <asp:Parameter Name="telefono" />
                            <asp:Parameter Name="correo" />
                            <asp:Parameter Name="idProveedor" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDatapr" runat="server"
                        ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>"
                        SelectCommand="SELECT [nombre] FROM [tipoProveedor]"></asp:SqlDataSource>

                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
