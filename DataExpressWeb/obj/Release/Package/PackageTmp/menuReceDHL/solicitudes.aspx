<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="solicitudes.aspx.cs" Inherits="DataExpressWeb.Formulario_web116" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .panelBodyWrapper {
            border: 1px ridge #666666;
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
            width: 383px;
            height: 152px;
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
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 23px;
            width: 103px;
        }

        #bus11 {
            position: absolute;
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 20px;
            width: 61px;
        }

        #bus12 {
            position: absolute;
            left: 615px;
            top: 152px;
            z-index: 1;
            height: 27px;
            width: 81px;
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
            width: 390px;
        }

        .trzap {
        }

        .trfcap {
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

        <%if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
            { %>
        <li>
            <asp:HyperLink ID="HyperLink11" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx" runat="server"><strong>Proveedores</asp:HyperLink></li>
        <%} %>

        <li><span class="tituloActive">Solicitudes de Registro</span></li>
        <%if (!(Session["permisos"].ToString().IndexOf("RecSolicitud") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton2" OnClick="Button24_Click" CssClass="sideMenu" runat="server">Rechazar Solicitud</asp:LinkButton></li>
        <%} %>
        <%if (!(Session["permisos"].ToString().IndexOf("AprSolicitud") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton3" OnClick="Button25_Click" CssClass="sideMenu" runat="server">Aprobar Solicitud</asp:LinkButton></li>
        <%} %>
        <li>
            <asp:LinkButton ID="LinkButton7" OnClick="Button26_Click" CssClass="sideMenu" runat="server">Ver Todos</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton8" OnClick="Button27_Click" CssClass="sideMenu" runat="server">Ver Pendientes</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton1" OnClick="Button28_Click" CssClass="sideMenu" runat="server">Ver Rechazados</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton4" OnClick="Button29_Click" CssClass="sideMenu" runat="server">Ver Aprobados</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton5" OnClick="LinkButton5_Click" CssClass="sideMenu" runat="server">Buscar por RFC</asp:LinkButton></li>
        <br />

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
    <h1>Solicitudes de Registro de Proveedores</h1>

    <table style="width: 752px; height: 33px">

        <td>
            <span id="bus10">
                <center style="height: 17px; width: 64px">
                                  <asp:Panel CssClass="panelWrapper" ID="Prechazar" runat="server" 
                                       ScrollBars="Auto" Height="23px" Width="66px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel26" runat="server">Rechazar solicitud de registro</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel27" runat="server" Width="388px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Razón Social:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trzrec" runat="server" 
                                TextMode="SingleLine" Width="175px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfcrec" runat="server"  
                                TextMode="SingleLine" Width="174px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Causa del Rechazo:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tcaurec" runat="server" 
                                TextMode="Multiline" Height="41px" Width="175px"  ></asp:TextBox>
                        </td>
                    </tr>
                  
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button18" runat="server"  Text="Aceptar" onclick="Button18_Click"  OnClientClick="return confirm('Seguro que desea rechazar la solicitud');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button17" runat="server"  Text="Cancelar" onclick="Button17_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
    </center>
            </span>




            <span id="bus11">
                <center style="height: 61px; width: 149px">
         <asp:Panel CssClass="panelWrapper" ID="Paprov" runat="server" ScrollBars="Auto" 
              Height="16px" Width="52px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel29" runat="server">Aprobar solicitud de registro</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel30" runat="server" 
                 Height="200px" Width="428px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Razón Social::</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trzap" runat="server" 
                                TextMode="SingleLine" Width="152px" ></asp:TextBox><%--ontextchanged="filtro_TextChanged"--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            RFC:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Trfcap" runat="server"
                                TextMode="SingleLine" Width="152px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Vendor ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tvendap" runat="server" 
                                TextMode="SingleLine" Width="152px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Vendor Site ID:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tsiteap" runat="server" 
                                TextMode="SingleLine" Width="151px"  ></asp:TextBox>
                        </td>
                    </tr>
                  <tr>
                        <td>
                            Tipo:</td>
                        <td>
                           
                    <asp:DropDownList  TextBoxCssClass="textboxForm" ID="Drotipap" runat="server" 
                                DataSourceID="SqlDataProv" DataTextField="nombre" DataValueField="nombre">
                    </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataProv" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT DISTINCT [nombre] FROM [tipoProveedor] ORDER BY nombre ASC"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                      <td colspan="2" align="center">
                          <asp:Label ID="msjAp" runat="server" Font-Names="Arial" 
                              Font-Size="12px" ForeColor="#CC0000"></asp:Label>
                      </td>
                    </tr>
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button20" runat="server"  Text="Grabar" 
                 onclick="Button20_Click"  OnClientClick="return confirm('Seguro que desea aprobar la solicitud');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button19" runat="server"  Text="Cancelar" 
                 onclick="Button19_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
      </center>
            </span>


            <span id="bus12">
                <center style="height: 29px; width: 90px">
        <asp:Panel CssClass="panelWrapper" ID="Panelbusc" runat="server" ScrollBars="Auto" 
               Visible="false" Height="24px" Width="82px">
          <asp:Panel CssClass="panelHeader" ID="Panel2" runat="server">Buscar por RFC</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel3" runat="server" >
                 <table style="width: 327px; height: 56px">
                 <tr>
                 <td align="right">
                     <asp:Label ID="Label1" runat="server" Text="RFC:" Font-Names="Arial" 
                         Font-Size="12px"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBusc" runat="server" Font-Names="Arial" Font-Size="12px" 
                         Height="23px" Width="163px"></asp:TextBox>
                 </td>
                 </tr>
                 <tr>
                 <td align="center">
                 <asp:Button CssClass="botonForm"  ID="Button2" runat="server"  Text="Aceptar" 
                         onclick="Button2_Click" />
                 </td>
                 <td align="right">
                 <asp:Button CssClass="botonForm" ID="Button1" runat="server"  Text="Cancelar" 
                         onclick="Button1_Click"/>
                 </td>
                 </tr>
                 </table>
    </asp:Panel>
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
                <asp:Panel ID="Panel18" runat="server" BorderColor="#CC0000" BorderStyle="none" BorderWidth="1px"
                    Style="width: 73%" ScrollBars="Auto">
                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource9"
                        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1356px"
                        DataKeyNames="idProveedor" AllowPaging="True"
                        BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Style="margin-top: 0px"
                        CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="idProveedor" HeaderText="idProveedor"
                                InsertVisible="False" ReadOnly="True" SortExpression="idProveedor"
                                Visible="False" />

                            <asp:TemplateField HeaderText="Marcar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idProveedor")%>' />
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha de Solicitud" SortExpression="fecSol">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaSolicitud") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label111" runat="server" Text='<%# Bind("fechaSolicitud") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Estado" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label112" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label113" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Razón Social" SortExpression="razonSocial">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("razonSocial") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("razonSocial") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre del Contacto" SortExpression="contacto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("contacto") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("contacto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Teléfono" SortExpression="telefono">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("telefono") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Correo" SortExpression="correo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("correo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label511" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Causa de Rechazo" SortExpression="cauRec">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("causaRechazo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label512" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White"
                            Font-Size="12px" Font-Names="Arial" />
                        <PagerSettings PageButtonCount="20" />
                        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Left" Font-Size="12px"
                            Font-Names="Arial" />
                        <RowStyle BackColor="#f2f2ed" ForeColor="#333333" Font-Size="12px" Font-Names="Arial" />
                        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource9" runat="server"
                        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
                        SelectCommand="PA_Solicitudes" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue=" " Name="STATUS" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="RFC" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
