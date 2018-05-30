<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reporteSucursalesA.aspx.cs" Inherits="DataExpressWeb.reporteSucursalesA" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 668px;
            text-align: left;
        }

        .style2 {
            text-align: center;
        }

        .style4 {
            text-align: center;
            font-size: 12pt;
        }

        .style5 {
            text-align: left;
            width: 602px;
        }

        .style6 {
            width: 602px;
        }

        .style7 {
            text-align: center;
            width: 602px;
        }

        .style8 {
            text-align: left;
            font-size: 9pt;
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
            width: 100px;
        }

        .style9 {
            font-size: 14px;
        }

        .style10 {
            width: 58px;
            text-align: left;
            font-size: 12px;
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

        <%if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/menuReceDHL/proveedoresDhl.aspx" runat="server">Administración de Proveedores</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/menuReceDHL/receptoresCfdi.aspx" runat="server">Administración  de Receptores de CFDI</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink4" NavigateUrl="~/menuReceDHL/diasOperacion.aspx" runat="server">Administración de Configuración</asp:HyperLink></span><br />
        <%} %>

        <%if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
            { %>
        <span class="titulo">
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/menuReceDHL/AdminMensaje.aspx" runat="server">Administración de Mensaje</asp:HyperLink></span><br />
        <%} %>

        <span class="tituloActive">Reportes</span>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Reportes</h1>
    <asp:Panel ID="Panel2" runat="server" Height="530px" Width="800px"
        Style="margin-top: 9px;" BackColor="#FCFCFC" BorderColor="gray"
        BorderStyle="solid" ScrollBars="Horizontal">
        <table style="width: 90%;" align="center">
            <tr>
                <td align="right">
                    <br />
                    <asp:Label ID="Label1" runat="server" Style="font-weight: 700;"
                        Font-Names="Arial" Font-Size="12px" Font-Bold="True">Seleccionar el tipo de reporte: </asp:Label>
                    <br />
                    <br />
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="DropRep" runat="server" Font-Names="Arial" AutoPostBack="true"
                        Font-Size="12px" Height="16px" Style="margin-bottom: 0px" Width="200px">
                        <asp:ListItem>GENERAL</asp:ListItem>
                        <asp:ListItem>OTM</asp:ListItem>
                        <asp:ListItem>PROVEEDORES</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>
            <%--       ////////////////////////reporte por empresa--%>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Style="font-weight: 700;"
                        Font-Names="Arial" Font-Size="12px" Font-Bold="True">Seleccionar Empresa: </asp:Label>
                    <br />
                    <br />
                </td>
                <td>
                    <asp:DropDownList ID="ddlPtoEmi" runat="server" DataSourceID="SqlDataSourcePtoEmi" CssClass="form-control"
                        DataTextField="razonSoc" DataValueField="razonSoc" AppendDataBoundItems="True" Width="200px">
                        <asp:ListItem Selected="True" Value="0">TODAS</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <strong>Selecciona Rango de Fechas</strong>
            </tr>
            <tr>
                <td align="right">
                    <strong>
                        <br />
                        Fecha Inicial&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></td>
                <td class="style5">
                    <strong>
                        <br />
                        Fecha Final</strong></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:TextBox ID="tbFechaIni" runat="server" Width="120px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="tbFechaIni" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="tbFechaIni" WatermarkText="Selecciona la fecha" WatermarkCssClass="watermarked">
                    </ajaxToolkit:TextBoxWatermarkExtender>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        runat="server" ControlToValidate="tbFechaIni"
                        ErrorMessage="Formato yyyy/mm/dd" ForeColor="OrangeRed" Font-Size="XX-Small"
                        ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbFechaFin" runat="server" Width="120px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbFechaFin" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="tbFechaFin" WatermarkText="Selecciona la fecha" WatermarkCssClass="watermarked">
                    </ajaxToolkit:TextBoxWatermarkExtender>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ControlToValidate="tbFechaFin"
                        ErrorMessage="Formato yyyy/mm/dd" ForeColor="OrangeRed" Font-Size="XX-Small"
                        ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <br />
                    <asp:Button ID="bGenerar" runat="server" Text="Generar"
                        OnClick="bGenerar_Click" Style="font-weight: 700"
                        BackColor="#d40511" BorderColor="#E4B918"
                        BorderStyle="Ridge" Font-Bold="True" ForeColor="White" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="lErrorCalendar" runat="server" ForeColor="Red" Width="632px"
                        Height="16px" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="pnlReportes" runat="server" BorderColor="#CC0000" BorderStyle="none"
                        Height="150" Width="790px" ScrollBars="Vertical">
                        <asp:GridView ID="gdvReportes" runat="server" AutoGenerateColumns="False" DataSourceID="dtsReportes"
                            CellPadding="1" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True"
                            BorderColor="#CC0000" BorderStyle="Groove" Font-Size="10px" Font-Bold="True" Style="margin-top: 0px"
                            CellSpacing="1">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Marcar" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="check" runat="server" />
                                        <asp:HiddenField ID="checkInt" runat="server" Value='<%#Bind("id")%>' />
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reporte" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                            <asp:HyperLink ID="HyperLink1" height="15" width="15" runat="server" BorderWidth="0px" BorderStyle="None" 
                             Visible='<%# Eval("estatus").ToString() == ("Finalizado").ToString()%>'                             
                             NavigateUrl='<%# Eval("Ruta","~/download.aspx?file={0}").ToString() %>' >
                                <img  src="../imagenes/excel.png" alt="pdf" height="22" width="22">
                                </asp:HyperLink>
                               </center>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo" SortExpression="permPropServ" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Tipo") %>'
                                            Width="320px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Tipo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Empresa" SortExpression="ac0" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Empresa") %>'
                                            Width="320px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Empresa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Periodo" SortExpression="ac0" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Periodo") %>'
                                            Width="320px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label42" runat="server" Text='<%# Bind("Periodo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estatus" SortExpression="nome" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox111" runat="server" Text='<%# Bind("Estatus") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label111" runat="server" Text='<%# Bind("Estatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha de Ejecución" SortExpression="nome" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FechaCreacion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FechaCreacion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No existen registros.
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White"
                                Font-Size="10px" />
                            <PagerSettings PageButtonCount="20" />
                            <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#f2f2ed" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dtsReportes" runat="server"
                            ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
                            SelectCommand="DHL_spGetReportes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:DropDownList ID="ddlSucursal" runat="server"
                        DataSourceID="SqlDataSourceSucursal" DataTextField="Sucursal"
                        DataValueField="idSucursal" Visible="False">
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td class="style1">
                    <asp:SqlDataSource ID="SqlDataSourceSucursal" runat="server"
                        ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>"
                        SelectCommand="SELECT idSucursal, clave + ': ' + sucursal AS Sucursal FROM Sucursales"></asp:SqlDataSource>


                    <asp:SqlDataSource ID="SqlDataSourcePtoEmi" runat="server" ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>"
                        SelectCommand="SELECT razonSoc FROM receptorCFDI WHERE habilitado = 'si' GROUP BY razonSoc">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSucursal" DefaultValue="0" Name="estab" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
                        SelectCommand="PA_reporte_gen_rec_2" SelectCommandType="StoredProcedure" >
                    <SelectParameters>
                        <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
                        <asp:Parameter DefaultValue=" " Name="RFC" Type="String" />
                            <asp:SessionParameter Name="MODULO" Type="String" SessionField="empresas" />
                        <asp:Parameter DefaultValue=" " Name="ESTADO" Type="String" />
                        <asp:Parameter DefaultValue="ORACLE|REN|" Name="PI" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>


                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
