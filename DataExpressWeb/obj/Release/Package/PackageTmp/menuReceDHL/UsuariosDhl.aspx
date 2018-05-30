<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuariosDhl.aspx.cs" Inherits="DataExpressWeb.Formulario_web113" %>

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
            Width: 244px;
            Height: 21px;
            font: Normal 12px Arial;
        }
        /*Estilo para el boton*/
        .botonForm {
            background-color: #d40511;
            border-bottom-style: ridge;
            font-weight: normal;
            font-size: 11px;
            color: #ffffff;
            border-left-color: #e4b918;
            border-right-color: #e4b918;
            border-top-color: #e4b918;
            border-bottom-color: #e4b918;
        }

            .botonForm:hover {
                color: #ffcc00;
            }

        #bus10 {
            position: absolute;
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 54px;
            width: 105px;
        }

        #bus11 {
            position: absolute;
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 55px;
            width: 112px;
        }

        #bus12 {
            position: absolute;
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 55px;
            width: 112px;
        }

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
            width: 90px;
            color: #fff;
            font: normal bold 20px arial;
        }
    </style>
</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <ul class="navigation">
        <span class="tituloActive">Administración de Usuarios</span>
        <li><span class="tituloActive">Usuarios</span></li>
        <%if (!(Session["permisos"].ToString().IndexOf("NuevoUs") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton1" CssClass="sideMenu" OnClick="Button12_Click" runat="server">Nuevo Registro</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("EditarUs") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton2" CssClass="sideMenu" OnClick="Button13_Click" runat="server">Editar</asp:LinkButton></li>
        <%} %>


        <%if (!(Session["permisos"].ToString().IndexOf("DesactivarUs") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton3" CssClass="sideMenu" OnClick="Button14_Click" runat="server" OnClientClick="return confirm('Seguro que desea desactivar el usuario');">Desactivar/Activar</asp:LinkButton></li>
        <%} %>

        <li>
            <asp:LinkButton ID="LinkButton233" CssClass="sideMenu" runat="server" OnClick="LinkButton233_Click">Ver todos</asp:LinkButton></li>

        <li>
            <asp:LinkButton ID="LinkButton213" CssClass="sideMenu" runat="server" OnClick="LinkButton213_Click">Filtrar</asp:LinkButton></li>

        <%if (!(Session["permisos"].ToString().IndexOf("GrupUs") < 0))
            { %>
        <li>
            <asp:HyperLink ID="HyperLink81" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/GruposUsuarios.aspx" runat="server">Grupos</asp:HyperLink></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx" runat="server">Administración de Proveedores</asp:HyperLink></span><br />
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
            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx" runat="server">Administración de Mensaje</asp:HyperLink></span><br />
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
    <h1>Usuarios</h1>

    <table style="width: 416px; height: 33px">
        <tr>
            <td>
                <span id="bus10">
                    <center>
                            <asp:Panel CssClass="panelWrapper" ID="PeditarUs" runat="server" ScrollBars="Auto" 
                                    Height="31px" Width="68px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel17" runat="server">Editando Usuario</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel18" runat="server" Height="297px" Width="398px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Nombre:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Textnom" runat="server" TextMode="SingleLine" ></asp:TextBox><%--ontextchanged="filtro_TextChanged"--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Textus" runat="server"  TextMode="SingleLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contraseña:
                        </td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Textpass" runat="server" 
                                TextMode="Password"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Confirme Contrasena:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="TextBox27" runat="server" TextMode="SingleLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grupo:</td>
                        <td>
                            <asp:DropDownList ID="Textgr" runat="server" DataSourceID="SqlDatagru2" 
                                DataTextField="grupo" DataValueField="grupo">
                            </asp:DropDownList>
                            <asp:TextBox CssClass="textboxForm" ID="ObtsesionIDe" runat="server" TextMode="SingleLine" Visible="false"></asp:TextBox>
                            
                            <asp:SqlDataSource ID="SqlDatagru2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT [grupo] FROM [grupos] where (nivelRol>=@nRe) and [activo]='si' order by [nivelRol] asc">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ObtsesionIDe" Name="nRe" Type="Int32"/>
                                </SelectParameters>
                            </asp:SqlDataSource>
                           
                           
                        </td>
                    </tr> 
                

                    <tr>
                      <td colspan="2" align="center">
                          <asp:Button ID="Button2" CssClass="botonForm"  runat="server" 
                              Text="Ver empresas del Usuario" onclick="Button2_Click" Height="25px" 
                              Width="150px" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2" align="center">
                        <asp:ListBox ID="ListEditar" runat="server" DataSourceID="SqlDataEdit" 
                              DataTextField="razonSoc" DataValueField="razonSoc" Width="357px" 
                              Font-Names="Arial" Font-Size="12px" SelectionMode="Multiple" Height="84px"></asp:ListBox>
                          <asp:SqlDataSource ID="SqlDataEdit" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                              SelectCommand="SELECT [razonSoc] FROM [receptorCFDI] WHERE habilitado='si'"></asp:SqlDataSource>
                      </td>
                    </tr>                   
                </table>
        </asp:Panel>
    <br />
    <asp:Button CssClass="botonForm"  ID="Button1" runat="server"  Text="Grabar" onclick="Button1_Click"  OnClientClick="return confirm('Seguro que desea editar el usuario');" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button CssClass="botonForm" ID="Button11" runat="server"  Text="Cancelar" onclick="Button11_Click" /> <%--onclick="Button12_Click"--%>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button CssClass="botonForm" ID="Button5" runat="server"  Text="Cerrar" onclick="Button20_Click" />
    <br />
    </asp:Panel>
    </center>
                </span>

                <span id="bus11">
                    <center>
           <asp:Panel CssClass="panelWrapper" ID="PcrearUs" runat="server" ScrollBars="Auto" 
               Height="41px" Width="85px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel5" runat="server">Crear Usuario</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel6" runat="server" Width="409px" 
                   Height="318px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Nombre:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tnom" runat="server" TextMode="SingleLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tus" runat="server"  TextMode="SingleLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contraseña:
                        </td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tps" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Confirme Contrasena:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="Tconfps" runat="server" TextMode="SingleLine"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grupo:</td>
                        <td>
                        <asp:DropDownList ID="Tgrup" runat="server" DataSourceID="SqlDataGru" 
                                DataTextField="grupo" DataValueField="grupo">
                        </asp:DropDownList>
                            <asp:TextBox CssClass="textboxForm" ID="ObtsesionID" runat="server" TextMode="SingleLine" Visible="false"></asp:TextBox>
                       <%--     <asp:DropDownList ID="DropDownList19" runat="server" DataSourceID="SqlDataGru" 
                                DataTextField="nivelRol" DataValueField="nivelRol" Visible="false">
                        </asp:DropDownList>--%>

                           <%-- <asp:SqlDataSource ID="SqlDataGru" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT concat([nivelRol], ': ', [grupo]) FROM [grupos] where [activo]='si' order by [nivelRol] asc"></asp:SqlDataSource>
                        --%>
                            <asp:SqlDataSource ID="SqlDataGru" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT [grupo] FROM [grupos] where (nivelRol>=@nR) and [activo]='si' order by [nivelRol] asc">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ObtsesionID" Name="nR" Type="String"/>
                                </SelectParameters>
                            </asp:SqlDataSource>
                               
                        </td>
                    </tr>  
                    <tr>
                      <td colspan="2" align="center">Empresa</td>
                    </tr>
                    <tr>
                      <td colspan="2" align="center">
                        <asp:ListBox ID="ListCrear" runat="server" DataSourceID="SqlDataRecep" 
                              DataTextField="razonSoc" DataValueField="razonSoc" Width="315px" 
                              Font-Names="Arial" Font-Size="12px" SelectionMode="Multiple" Height="84px"></asp:ListBox>
                          <asp:SqlDataSource ID="SqlDataRecep" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                              SelectCommand="SELECT [razonSoc] FROM [receptorCFDI] WHERE habilitado='si'"></asp:SqlDataSource>
                      </td>
                    </tr>
                     <tr>
                    <td colspan="2">
                    Este Usuario Está Activo &nbsp;&nbsp; <asp:CheckBox ID="ChecAct" runat="server" />
                    </td>
                    </tr>
                                      
                </table>
        </asp:Panel>
    <br />
    <asp:Button CssClass="botonForm"  ID="Button4" runat="server"  Text="Grabar" 
                   onclick="Button4_Click"  OnClientClick="return confirm('Seguro que desea crear un usuario');" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    <asp:Button CssClass="botonForm" ID="Button3" runat="server"  Text="Cancelar" 
                   onclick="Button3_Click" />  
    <br />
    </asp:Panel>
   </center>
                </span>

                <span id="bus12">
                    <center style="height: 43px; width: 132px">
                                    <asp:Panel CssClass="panelWrapper" ID="PanFiltUs" runat="server" ScrollBars="Auto" 
                                         Height="199px" Width="335px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel2" runat="server">Filtrar Usuario</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel3" runat="server" Height="118px" Width="295px">
            <table style="height: 68px; width: 243px">
              <tr>
              <td>
                  <asp:Label ID="Label549" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Text="Nombre:"></asp:Label>
                  </td>
              <td>
                  <asp:TextBox ID="TnomBus" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Height="25px" Width="132px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
              <td><asp:Label ID="Label910" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Text="Usuario:"></asp:Label></td>
              <td>
                  <asp:TextBox ID="TUspBus" runat="server" Font-Names="Arial" Height="25px" 
                      Width="133px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
              <td><asp:Label ID="Label619" runat="server" Font-Names="Arial" Font-Size="12px" 
                      Text="Grupo:"></asp:Label></td>
              <td>
                  <asp:TextBox ID="TeGrBus" runat="server" Font-Names="Arial" Height="25px" 
                      Width="133px"></asp:TextBox>
                  </td>
              </tr>
            </table>
            </asp:Panel>
            <br />
<asp:Button CssClass="botonForm"  ID="Button232" runat="server"  Text="Buscar" onclick="Button232_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button121" runat="server"  Text="Cancelar" onclick="Button121_Click" />
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
                <asp:Panel ID="Panel15" runat="server" Width="75%" BorderColor="#CC0000" BorderStyle="none"
                    Style="width: auto" ScrollBars="Auto">
                    <asp:GridView ID="GridView35" runat="server" AutoGenerateColumns="False" BorderWidth="1px" DataSourceID="SqlDataSource4"
                        CellPadding="1" ForeColor="#333333" Font-Names="arial" GridLines="None" Width="1000px" AllowPaging="True"
                        BorderColor="#CC0000" BorderStyle="solid" Style="margin-top: 0px" Font-Size="10px" CellSpacing="1"
                        Visible="false">
                        <AlternatingRowStyle BackColor="White" ForeColor="#000" Font-Names="Arial" Font-Size="12px" />
                        <Columns>
                            <asp:BoundField DataField="idUsuario" HeaderText="idUsuario"
                                InsertVisible="False" ReadOnly="True" SortExpression="idUsuario"
                                Visible="False" />
                            <asp:TemplateField HeaderText="Marcar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idUsuario")%>' />
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grupo" SortExpression="grupo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("grupo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("grupo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre" SortExpression="nom">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Usuario" SortExpression="login">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("login") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("login") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Proveedor" SortExpression="prov">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("empresas") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("empresas") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activo" SortExpression="activo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("activo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White"
                            Font-Names="Arial" Font-Size="12px" />
                        <PagerSettings PageButtonCount="20" />
                        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" />
                        <RowStyle BackColor="#f2f2ed" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" />
                        <SelectedRowStyle BackColor="White" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
                        SelectCommand="SELECT [idUsuario], [nombre], [grupo], [login], [proveedor],[activo],[empresas] FROM [usuarios] order by [idUsuario] desc"
                        UpdateCommand="UPDATE Usuarios SET nombre= @nombre WHERE (idUsuario= @idUsuario)"
                        DeleteCommand="DELETE FROM Usuarios WHERE (idUsuario= @idUsuario)">


                        <UpdateParameters>
                            <asp:Parameter Name="nombre" />
                            <asp:Parameter Name="grupo" />
                            <asp:Parameter Name="login" />
                            <asp:Parameter Name="proveedor" />
                            <asp:Parameter Name="activo" />
                            <asp:Parameter Name="empresas" />
                            <asp:Parameter Name="idUsuario" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
