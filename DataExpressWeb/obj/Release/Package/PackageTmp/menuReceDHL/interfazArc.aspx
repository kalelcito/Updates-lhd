<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="interfazArc.aspx.cs" Inherits="DataExpressWeb.Formulario_web112" Async="true" %>

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
            width: 342px;
            height: 86px;
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
            border-bottom-style: ridge;
            font-weight: normal;
            font-size: 11px;
            color: #ffffff;
            width: 87px;
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
            height: 24px;
            width: 94px;
        }

        #bus11 {
            position: absolute;
            left: 626px;
            top: 143px;
            z-index: 1;
            height: 55px;
            width: 160px;
        }

        #bus12 {
            position: absolute;
            left: 626px;
            top: 143px;
            z-index: 1;
            height: 30px;
            width: 110px;
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
</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <span class="titulo">Interface de Archivos</span>
    <ul id="navigation">

        <%if (!(Session["permisos"].ToString().IndexOf("GenInt") < 0))
            { %>
        <li>
            <asp:LinkButton ID="HyperLink1" OnClick="Button1_Click" CssClass="sideMenuComprobantesFiscales" runat="server"> Generar Archivo de Interfaz</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="hlComple" OnClick="hlInter_Click" CssClass="sideMenuComprobantesFiscales" runat="server">Generar Interfaz de Complemento</asp:LinkButton></li>
        <%} %>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="width: 210px">Interface de Archivos</h1>


    <table style="width: 250px; height: 25px">
        <tr>
            <td>
                <span id="bus10">
                    <center>
                              <asp:Panel CssClass="panelWrapper" ID="Pinterfaz" runat="server" ScrollBars="Auto" 
                                      Height="23px" Width="89px" Visible="false">
        <asp:Panel CssClass="panelHeader" ID="Panel56" runat="server">Generar archivo</asp:Panel>
            <asp:Panel CssClass="panelBodyWrapper" ID="Panel57" runat="server" Width="408px">
                <table class="formEditar">
                <tr>
                        <td >Compañia:</td>
                        <td>
                            <asp:DropDownList CssClass="textboxForm" ID="DropRZ" runat="server" 
                                DataSourceID="SqlDatainterfaz" DataTextField="razonSoc" 
                                DataValueField="razonSoc">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDatainterfaz" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT DISTINCT [razonSoc] FROM [receptorCFDI]"></asp:SqlDataSource>
                        </td>
                    </tr>
                     <tr>
                        <td > Tipo de Proveedor:</td>
                        <td>
                            <asp:DropDownList CssClass="textboxForm" ID="DropProv" runat="server" 
                                DataSourceID="SqlDataiterfaz2" DataTextField="nombre" DataValueField="nombre">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataiterfaz2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:recepcionConnectionString %>" 
                                SelectCommand="SELECT DISTINCT [nombre] FROM [tipoProveedor]"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
<br />
<asp:Button CssClass="botonForm"  ID="Button38" runat="server"  Text="Grabar" onclick="Button38_Click"  OnClientClick="return confirm('Seguro que desea generar los Archivos');" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="Button37" runat="server"  Text="Cancelar" onclick="Button37_Click" /> <%--onclick="Button12_Click"--%>
<br />
    </asp:Panel>
                              </center>
                </span>

                <span id="bus12">
                    <center>
                              <asp:Panel CssClass="panelWrapper" ID="PanelSeg" runat="server" ScrollBars="Auto" 
                                      Height="23px" Width="102px" Visible="False">
                         
                <br />
<asp:Button CssClass="botonForm"  ID="But2" runat="server"  Text="Reprocesar" 
                                      onclick="But2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button CssClass="botonForm" ID="But" runat="server"  Text="Cancelar" onclick="But_Click" /> <%--onclick="Button12_Click"--%>
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
                <asp:Panel ID="Panel23" runat="server" BorderColor="#CC0000" BorderStyle="none"
                    Height="400px" Width="1229px" ScrollBars="Vertical">
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource8"
                        CellPadding="1" ForeColor="#333333" GridLines="None" Width="85%" AllowPaging="True"
                        BorderColor="#CC0000" BorderStyle="Groove" Font-Size="10px" Font-Bold="True" Style="margin-top: 0px"
                        CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Marcar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="check" runat="server" />
                                    <asp:HiddenField ID="checkInt" runat="server" Value='<%#Bind("idInterfaz")%>' />
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Archivos">
                                <ItemTemplate>
                                    <center>
                            <asp:HyperLink ID="HyperLink1" height="15" width="15" runat="server" BorderWidth="0px" BorderStyle="None" 
                             Visible='<%# Eval("estatus").ToString() == ("Finalizado").ToString()%>'                             
                             NavigateUrl='<%# Eval("rutaArcInterfaz","~/download.aspx?file={0}").ToString() %>' >
                                <img  src="../imagenes-dhl/TXT.png" alt="pdf" height="22" width="22">
                                </asp:HyperLink>
                               </center>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Ejecución" SortExpression="nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaEjecucion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fechaEjecucion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Estatus" SortExpression="nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox111" runat="server" Text='<%# Bind("estatus") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label111" runat="server" Text='<%# Bind("estatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tipo" SortExpression="permPropServ">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tipo") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Receptor de CFDI" SortExpression="ac0">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("receptor") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("receptor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre del Archivo" SortExpression="ac0">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("nombreArc") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label476" runat="server" Text='<%# Bind("nombreArc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. de Registros" SortExpression="ac0">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("numRegistros") %>'
                                        Width="320px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label49" runat="server" Text='<%# Bind("numRegistros") %>'></asp:Label>
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
                    <asp:SqlDataSource ID="SqlDataSource8" runat="server"
                        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
                        SelectCommand="SELECT [idInterfaz],[fechaEjecucion],[estatus],[tipo],[receptor],[nombreArc],[numRegistros],[rutaArcInterfaz] FROM [interfaz] order by [idInterfaz] desc"></asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>


</asp:Content>
