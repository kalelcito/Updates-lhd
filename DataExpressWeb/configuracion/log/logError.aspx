<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logError.aspx.cs" Inherits="DataExpressWeb.configuracion.log.logError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #Text1
        {
            width: 189px;
            margin-top: 0px;
        }
        #Text2
        {
            width: 474px;
        }
        #Text3
        {
            width: 164px;
        }
        #Text5
        {
            width: 139px;
        }
        #Text6
        {
            width: 138px;
        }
        .style1
        {
        }
        .style3
        {
            width: 214px;
        }
        .style4
        {
            width: 187px;
        }
    .style5
    {
        width: 199px;
    }
        .style6
        {
            font-size: medium;
        }
    </style>
    
    <script type="text/javascript" language="javascript">
        function openPopup(strOpen) {
            open(strOpen, "Info",
         "status=1, width=750, height=400, top=100, left=300");
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                <strong>LOG</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                No. Documento:</td>
            <td class="style5">
                Nombre Archivo:</td>
            <td>
                Tipo:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:TextBox ID="tbNoOrden" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:TextBox ID="tbArchivo" runat="server"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="tbTipo" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                Detalle:<br />
                <asp:TextBox ID="tbDetalle" runat="server" Width="354px"></asp:TextBox>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Calendar ID="calFechaAnterior" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="183px" NextPrevFormat="FullMonth" Width="200px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="White" BorderWidth="4px" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#003151" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
            <td colspan="2">
                &nbsp;
                <asp:Calendar ID="calFechaFin" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="200px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="White" BorderWidth="4px" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#003151" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Button ID="bBuscarReg" runat="server" onclick="bBuscarReg_Click" 
                    Text="Buscar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bActualizar" runat="server" onclick="bActualizar_Click" 
                    Text="Actualizar" />
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" CellPadding="4" 
    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
     Width="904px" AllowPaging="True" DataKeyNames="idErrorFactura" 
        style="text-align: center" >
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns >
<asp:BoundField DataField="idErrorFactura" HeaderText="idErrorFactura" 
            SortExpression="idErrorFactura" InsertVisible="False" ReadOnly="True" 
            Visible="False"></asp:BoundField>
        <asp:BoundField DataField="detalle" HeaderText="Detalle" 
            SortExpression="detalle" />
        <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
        <asp:BoundField DataField="archivo" HeaderText="Archivo" 
            SortExpression="archivo" />
        <asp:BoundField DataField="linea" HeaderText="Línea" SortExpression="linea" />
        <asp:BoundField DataField="numeroDocumento" HeaderText="No. Documento" 
            SortExpression="numeroDocumento" />
        <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />
     
        <asp:BoundField DataField="detalleTecnico" HeaderText="detalleTecnico" 
            SortExpression="detalleTecnico" Visible="False" />

            <asp:BoundField DataField="email" HeaderText="E-mail_proveedor" 
            SortExpression="email" />

             <asp:TemplateField HeaderText="Resultado Validación">
            <ItemTemplate>
             <a href="javascript:openPopup('enviar.aspx?idfa=<%# Eval("idErrorFactura") %>')">
                <img  src="../../imagenes/info.ico" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
            </ItemTemplate>         
        </asp:TemplateField>

        <asp:TemplateField></asp:TemplateField>

    </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No existen datos.
        </EmptyDataTemplate>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#003151" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" 
            HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        
        SelectCommand="PA_Log_basico" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
<br />
</asp:Content>