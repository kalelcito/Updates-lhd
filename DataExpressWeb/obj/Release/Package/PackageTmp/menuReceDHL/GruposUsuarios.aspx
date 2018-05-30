<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GruposUsuarios.aspx.cs" Inherits="DataExpressWeb.Formulario_web114" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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
            width: 195px;
            height: 26px;
        }

        #bus10 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 25px;
            width: 62px;
        }

        #bus9 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 21px;
            width: 63px;
        }

        .style8 {
            width: 216px;
        }

        .formEditar {
            width: 441px;
        }

        .panelBodyWrapper {
        }

        .textboxForm {
        }
    </style>

    <style type="text/css">
        .panelWrapper {
        }
    </style>

</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <ul class="navigation">
        <span class="tituloActive">Administración de Usuarios</span>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
            { %>
        <li>
            <asp:HyperLink ID="HyperLink7" CssClass="sideMenu" NavigateUrl="~/menuReceDHL/UsuariosDhl.aspx" runat="server">Usuarios</asp:HyperLink></li>
        <%} %>

        <li><span class="tituloActive">Grupos</span></li>
        <%if (!(Session["permisos"].ToString().IndexOf("NuevoGru") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton4" CssClass="sideMenu" runat="server" OnClick="LinkButton4_Click">Nuevo Registro</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("EditarGru") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton5" CssClass="sideMenu" runat="server" OnClick="LinkButton5_Click">Editar</asp:LinkButton></li>
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("DesactivarGru") < 0))
            { %>
        <li>
            <asp:LinkButton ID="LinkButton6" CssClass="sideMenu" runat="server" OnClick="LinkButton6_Click">Desactivar</asp:LinkButton></li>
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
    <h1>Grupos de Usuarios</h1>
    <table>
        <tr>
            <td class="style8">
                <span id="bus9">
                    <center style="width: 76px">
    <asp:Panel CssClass="panelWrapper" ID="PCrearGru" runat="server" ScrollBars="Auto" 
                                        Height="16px" Width="71px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel23" runat="server">Crear Grupo</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel24" runat="server" 
            Height="256px" Width="459px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Nombre:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="nomPer" runat="server" 
                                TextMode="SingleLine"  Width="222px" Height="20px" ></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descripción:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="desPer" runat="server"  
                                TextMode="MultiLine" Width="222px" Height="20px" Font-Names="Arial" 
                                Font-Size="12px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    Activo: 
                    </td>  
                      <td>
                      <asp:CheckBox ID="ChecAct" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Nivel de Rol:
                        &nbsp;&nbsp;&nbsp;
                            <asp:TextBox CssClass="textboxForm" ID="nivelRol" runat="server"  
                                TextMode="Number" Width="50px" Height="20px" Font-Names="Arial"
                                Font-Size="12px"></asp:TextBox>
                        </td>
                    </tr>
                                 

                    <tr>
                        <td colspan="2" align="left">
                        <asp:Panel CssClass="panelHeader" ID="Panel2" runat="server"><center>Permisos</center></asp:Panel>
                            <asp:Panel CssClass="panelBodyWrapper" ID="Panel1" runat="server" ScrollBars="Auto" BackColor="White">
                                     <asp:TreeView runat="server" Height="167px" ImageSet="XPFileExplorer" 
                                    NodeIndent="15" ShowCheckBoxes="Leaf" ShowLines="True" Width="408px" 
                                    Font-Names="Arial" Font-Size="12px" ID="tree" 
                                         onselectednodechanged="tree_SelectedNodeChanged">
                            
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <Nodes>
                                    <asp:TreeNode Text="Portal-Consultas" Value="" SelectAction="Select">
                                        <asp:TreeNode Text="Comprobantes Fiscales" Value="">
                                            <asp:TreeNode Text="Consultar CFDI" Value="PorConsultas" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Subir CFDI" Value="SubCFDI" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarCom" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Doc. Adicionales" Value="DocAdic" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="A proceso de pago" Value="Proc" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Cancelar CFDI" Value="CanCFDI" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Rechazar CFDI" Value="RecCFDI" SelectAction="None"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Interfaz" Value="" SelectAction="Select">
                                            <asp:TreeNode Text="Generar Interfaz" Value="GenInt" SelectAction="None"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Interfaz Oracle" Value="" >
                                            <asp:TreeNode Text="Generar Interfaz" Value="OraGenIt" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Validar diferencia en registros" Value="Valdif" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Permitir registros sin UUID" Value="PermiUUID" SelectAction="None"></asp:TreeNode>
                                        </asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Administración" Value="" SelectAction="Select">
                                        <asp:TreeNode Text="Administración de Usuarios" 
                                            Value="" SelectAction="Select">
                                            <asp:TreeNode Text="Nuevo Registro" Value="NuevoUs" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarUs" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Desactivar" Value="DesactivarUs" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Grupos de Usuarios" Value="" SelectAction="Select">
                                                <asp:TreeNode Text="Nuevo Registro" Value="NuevoGru" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarGru" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Desactivar" Value="DesactivarGru" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Proveedores" 
                                            Value="" SelectAction="Select">
                                            <asp:TreeNode Text="Crear" Value="CrearPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Inhabilitar" Value="InhabilitarPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Rehabilitar" Value="RehabilitarPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Solicitudes de Registro" Value="" SelectAction="Select">
                                                <asp:TreeNode Text="Rechazar Solicitud" Value="RecSolicitud" SelectAction="None">
                                                </asp:TreeNode>
                                                <asp:TreeNode Text="Aprobar Solicitud" Value="AprSolicitud" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Receptores" 
                                            Value="" SelectAction="Select">
                                            <asp:TreeNode Text="Nuevo Registro" Value="NuevoRec" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarRec" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Códigos IVA" Value="" SelectAction="Select">
                                                <asp:TreeNode Text="Nuevo Registro" Value="NuevoIVA" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarIVA" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Configuración" 
                                            Value="" SelectAction="Select">
                                            <asp:TreeNode Text="Días de Operación" Value="" SelectAction="Select">
                                                <asp:TreeNode Text="Editar" Value="EditarDia" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode Text="Monedas" Value="" SelectAction="Select">
                                                <asp:TreeNode Text="Nuevo Regisro" Value="NuevaMon" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarMon" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode Text="Tipo de Proveedor" Value="" SelectAction="Select">
                                                <asp:TreeNode Text="Nuevo Registro" Value="NuevoProv" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarProv" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Mensajes" 
                                            Value="AdmMensajes" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Administración de Catálogos" 
                                            Value="AdmCat" SelectAction="None"></asp:TreeNode>
                                        <asp:TreeNode Text="Reportes" Value="Reportes" SelectAction="None"></asp:TreeNode>
                                    </asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#FFFF99" Font-Underline="False" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                            
                            </asp:TreeView>
                            </asp:Panel>
                       </td>
                    </tr>
                  
                </table>
        </asp:Panel>
        <br/>
<br />
<br />
<asp:Button CssClass="botonForm"  ID="Button16" runat="server"  Text="Crear" 
            OnClientClick="return confirm('Seguro que desea crear Grupo');" 
            onclick="Button16_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button15" runat="server"  Text="Cancelar" 
            onclick="Button15_Click" />
    </asp:Panel>
    </center>
                </span>
                <span id="bus10">
                    <center>
    <asp:Panel CssClass="panelWrapper" ID="Peditar" runat="server" ScrollBars="Auto" 
                                        Height="16px" Width="50px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="PeditarGru" runat="server">Editar Grupo</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel5" runat="server" 
            Height="256px" Width="459px">
                <table class="formEditar">
                    <tr>
                        <td>
                            Nombre:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="TeditNom" runat="server" 
                                TextMode="SingleLine"  Width="222px" Height="20px" ></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descripción:</td>
                        <td>
                            <asp:TextBox CssClass="textboxForm" ID="TeditDes" runat="server"  
                                TextMode="MultiLine" Width="222px" Height="24px" Font-Names="Arial" 
                                Font-Size="12px" ></asp:TextBox>
                        </td>
                    </tr>

               

                    <tr> 
                    <td>
                    Activo: 
                    </td>  
                      <td>
                      <asp:CheckBox ID="Checedit" runat="server" />
                      </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                        <asp:Panel CssClass="panelHeader" ID="Panel6" runat="server"><center>Permisos</center></asp:Panel>
                            <asp:Panel CssClass="panelBodyWrapper" ID="Panel7" runat="server" ScrollBars="Auto" BackColor="White">
                                     <asp:TreeView runat="server" Height="167px" ImageSet="XPFileExplorer" 
                                    NodeIndent="15" ShowCheckBoxes="Leaf" ShowLines="True" Width="408px" 
                                    Font-Names="Arial" Font-Size="12px" ID="Tree2" 
                                         onselectednodechanged="tree_SelectedNodeChanged2">
                            
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <Nodes>
                                    <asp:TreeNode Text="Portal-Consultas" Value="" >
                                        <asp:TreeNode Text="Comprobantes Fiscales" Value="">
                                            <asp:TreeNode Text="Consultar CFDI" Value="PorConsultas" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Subir CFDI" Value="SubCFDI" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarCom" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Doc. Adicionales" Value="DocAdic" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="A proceso de pago" Value="Proc" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Cancelar CFDI" Value="CanCFDI" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Rechazar CFDI" Value="RecCFDI" SelectAction="None"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Interfaz" Value="" >
                                            <asp:TreeNode Text="Generar Interfaz" Value="GenInt" SelectAction="None"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Interfaz Oracle" Value="" >
                                            <asp:TreeNode Text="Generar Interfaz" Value="OraGenIt" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Validar diferencia en registros" Value="Valdif" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Permitir registros sin UUID" Value="PermiUUID" SelectAction="None"></asp:TreeNode>
                                        </asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Administración" Value="" >
                                        <asp:TreeNode Text="Administración de Usuarios" 
                                            Value="">
                                            <asp:TreeNode Text="Nuevo Registro" Value="NuevoUs" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarUs" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Desactivar" Value="DesactivarUs" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Grupos de Usuarios" Value="">
                                                <asp:TreeNode Text="Nuevo Registro" Value="NuevoGru" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarGru" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Desactivar" Value="DesactivarGru" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Proveedores" 
                                            Value="">
                                            <asp:TreeNode Text="Crear" Value="CrearPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Inhabilitar" Value="InhabilitarPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Rehabilitar" Value="RehabilitarPro" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Solicitudes de Registro" Value="">
                                                <asp:TreeNode Text="Rechazar Solicitud" Value="RecSolicitud" SelectAction="None">
                                                </asp:TreeNode>
                                                <asp:TreeNode Text="Aprobar Solicitud" Value="AprSolicitud" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Receptores" 
                                            Value="">
                                            <asp:TreeNode Text="Nuevo Registro" Value="NuevoRec" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Editar" Value="EditarRec" SelectAction="None"></asp:TreeNode>
                                            <asp:TreeNode Text="Códigos IVA" Value="">
                                                <asp:TreeNode Text="Nuevo Registro" Value="NuevoIVA" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarIVA" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Configuración" 
                                            Value="" >
                                            <asp:TreeNode Text="Días de Operación" Value="" >
                                                <asp:TreeNode Text="Editar" Value="EditarDia" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode Text="Monedas" Value="" >
                                                <asp:TreeNode Text="Nuevo Regisro" Value="NuevaMon" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarMon" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode Text="Tipo de Proveedor" Value="">
                                                <asp:TreeNode Text="Nuevo Registro" Value="NuevoProv" SelectAction="None"></asp:TreeNode>
                                                <asp:TreeNode Text="Editar" Value="EditarProv" SelectAction="None"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Catálogos" 
                                            Value="AdmCat" SelectAction="None"></asp:TreeNode>
                                        <asp:TreeNode Text="Administración de Mensajes" 
                                            Value="AdmMensajes" SelectAction="None"></asp:TreeNode>
                                        <asp:TreeNode Text="Reportes" Value="Reportes" SelectAction="None"></asp:TreeNode>
                                    </asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#FFFF99" Font-Underline="False" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                            
                            </asp:TreeView>
                            </asp:Panel>
                       </td>
                    </tr>
                  
                </table>
        </asp:Panel>
        <br/>
<br />
<br />
<asp:Button CssClass="botonForm"  ID="Button2" runat="server"  Text="Editar" 
            OnClientClick="return confirm('Seguro que desea editar el Grupo');" 
            onclick="Button2_Click"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button1" runat="server"  Text="Cancelar" 
            onclick="Button1_Click" />
    </asp:Panel>
    </center>
                </span>

                <span id="bus9">
                    <center>
            <asp:Panel CssClass="panelWrapper" ID="MenuVis" runat="server" ScrollBars="Auto" Height="10px" Width="71px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel4" runat="server">Actualizar Grupo</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel8" runat="server" 
            Height="256px" Width="459px">
                <table class="formEditar" width="400px">
                     <tr>
                         <td>

                         </td>
                         <td>
                            Los siguientes grupos se desplazaran un nivel hacia abajo, si crea este grupo en este nivel: 
                            </td>  
                      </tr>
                       <tr>
                          <td colspan="2" align="left">
                          <asp:Panel CssClass="panelBodyWrapper" ID="Panel10" runat="server" ScrollBars="Auto" BackColor="White" Width="450px">
                      
                                
                    <asp:Panel ID="Panel3" runat="server" BorderColor="#CC0000" BorderStyle="none" Width="450px" ScrollBars="Auto">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource8" 
                        CellPadding="1" ForeColor="#333333" GridLines="None" Width="450px" AllowPaging="True" 
                              BorderColor="#CC0000" BorderStyle="solid" BorderWidth="1px"  Font-Size="10px"  style="margin-top: 0px" 
                                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#000"/>
        <Columns>
            
            <asp:TemplateField HeaderText="Grupo" HeaderStyle-Wrap="true" SortExpression="grupo" HeaderStyle-Width="150px" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("grupo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("grupo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Activo" SortExpression="Act" HeaderStyle-Width="40px">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("activo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Nivel" SortExpression="Nivel" HeaderStyle-Width="40px">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("nivelRol") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("nivelRol") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>
            No existen registros.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="12px" Font-Names="arial" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center"  Font-Size="12px" Font-Names="arial" Width="459"/>
        <RowStyle BackColor="#f2f2ed" ForeColor="#000" Font-Size="12px" Font-Names="arial" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [grupo], [activo], [nivelRol] FROM [grupos] WHERE (nivelRol>=@nR) order by [nivelRol] asc">
        <SelectParameters>
            <asp:ControlParameter ControlID="nivelRol" Name="nR" Type="String"/>
        </SelectParameters>
    </asp:SqlDataSource>                  
                     </asp:Panel>
                            </asp:Panel>
                       </td>
                    </tr>
                </table>
        </asp:Panel>
        <br/>
<br /> 
<br /> 
<asp:Button CssClass="botonForm"  ID="Mostrar1" runat="server"  Text="Crear/Actualizar" Width="100"
            OnClientClick="return confirm('Seguro que desea crear Grupo');" 
            onclick="Mostrar_onClick" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button11" runat="server"  Text="Cancelar" 
            onclick="Button30_Click" />
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
                <asp:Panel ID="Panel22" runat="server" BorderColor="#CC0000" BorderStyle="none"
                    Width="100%" ScrollBars="Auto">
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource7"
                        CellPadding="1" ForeColor="#333333" GridLines="None" Width="573px" AllowPaging="True"
                        BorderColor="#CC0000" BorderStyle="solid" BorderWidth="1px" Font-Size="10px" Style="margin-top: 0px"
                        CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" ForeColor="#000" />
                        <Columns>
                            <asp:TemplateField HeaderText="Marcar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkFol" runat="server" Value='<%#Bind("idGrupo")%>' />
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grupo" SortExpression="grupo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("grupo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("grupo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nivel Grupo" SortExpression="nivelRol">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox100" runat="server" Text='<%# Bind("nivelRol") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label100" runat="server" Text='<%# Bind("nivelRol") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activo" SortExpression="Act">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("activo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White"
                            Font-Size="12px" Font-Names="arial" />
                        <PagerSettings PageButtonCount="20" />
                        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" Font-Size="12px" Font-Names="arial" />
                        <RowStyle BackColor="#f2f2ed" ForeColor="#000" Font-Size="12px" Font-Names="arial" />
                        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server"
                        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
                        SelectCommand="SELECT [idGrupo],[grupo],[activo], [nivelRol] FROM [grupos] order by [nivelRol] asc"></asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
