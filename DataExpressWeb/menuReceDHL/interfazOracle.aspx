<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="interfazOracle.aspx.cs" Inherits="DataExpressWeb.Formulario_webOracle" %>

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
    <span class="titulo">
        <asp:Label ID="titulo_interfaz" Text="Interface de registros Oracle" runat="server">
        </asp:Label>
    </span>
    <ul id="navigation">

        <li>
            <asp:LinkButton ID="HyperLink1" CssClass="sideMenuComprobantesFiscales" OnClick="Button1_Click" runat="server"> Subir archivo Excel de Oracle</asp:LinkButton></li>
        <li runat="server" id="li1" visible="false">
            <asp:LinkButton ID="LinkButton1" CssClass="sideMenuComprobantesFiscales" OnClick="Button2_Click" runat="server"> Registros pendientes</asp:LinkButton></li>

    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="width: 400px">
        <asp:Label ID="Titulo_interface" Text="Interface de registros Oracle" runat="server">
        </asp:Label>
    </h1>
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
                            <asp:TemplateField HeaderText="Archivos">
                                <ItemTemplate>
                                    <center>
            <a href='../download.aspx?file=<%# Eval("rutaArcInterfaz") %>'>
                <img  src="../imagenes-dhl/TXT.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resumen">
                                <ItemTemplate>
                                    <center>
            <a href='../download.aspx?file=<%# Eval("rutaArcLog") %>'>
                <img  src="../imagenes-dhl/TXT.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Ejecución" SortExpression="nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaEjecucion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fechaEjecucion") %>'></asp:Label>
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
                        SelectCommand="SELECT [idInterfaz],[fechaEjecucion],[tipo],[nombreArc],[numRegistros],[rutaArcInterfaz],[rutaArcLog] FROM [interfazOracle] order by [idInterfaz] desc"></asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>


</asp:Content>
