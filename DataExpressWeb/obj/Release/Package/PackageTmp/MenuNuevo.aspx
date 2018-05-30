<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuNuevo.aspx.cs" Inherits="DataExpressWeb.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server" >
    <link href="StylesEx.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style10
        {
            height: 14px;
            width: 91px;
            
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
        .style11
        {
            height: 14px;
        }
        .style12
        {
            width: 237px;
        }
        .style14
        {
            width: 157px;
        }
        .style15
        {
            width: 188px;
        }
        .style16
        {
            width: 352px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 1286px">
   
                <ContentTemplate>
                <asp:Label ID="TimeLabel" runat="server" Text="" />                            
         <asp:Menu ID="menu" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
         StaticSelectedStyle-CssClass="selectedtab" CssClass="menu" runat="server"
             Font-Bold="True" Font-Size="Medium" onmenuitemclick="Menu_MenuItemClick">
            <Items>
            <asp:MenuItem  Text="Portal de consultas CDFI" Value="0" Selected="true">
            </asp:MenuItem>
            <asp:MenuItem Text="Administración" Value="1"></asp:MenuItem>          
            </Items>
             <StaticMenuItemStyle CssClass="tab" />
             <StaticSelectedStyle CssClass="selectedtab" />
        </asp:Menu>
        <table style="width: 204px">
        <tr>
        <td>
         <span ID="bus">
                <center>
                <asp:Panel ID="Pcancelar" runat="server" BackColor="#FFEA1E" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="54px" Visible="False" 
                                            Width="89px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel28" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Cancelar CFDI</asp:Panel>
                                            <asp:Panel ID="Panel27" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
                                                Height="126px" Width="384px">
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
                                            <asp:Button ID="bgrab" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" onclick="bgrab_Click" />
                                            <asp:Button ID="Button50" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button50_Click" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

                                        <span ID="bus2">
                <center>
                <asp:Panel ID="Prechazar" runat="server" BackColor="#FFEA1E" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="47px" Visible="False" 
                                            Width="72px" ViewStateMode="Disabled" 
                        ScrollBars="Auto">
                                            <asp:Panel ID="Panel30" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Rechazando CFDI</asp:Panel>
                                            <asp:Panel ID="Panel31" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
                                                Height="126px" Width="384px">
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
                                            <asp:Button ID="Button46" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" onclick="Button46_Click" />
                                            <asp:Button ID="Button51" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button51_Click" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

                                        <span ID="bus3">
                <center>
                <asp:Panel ID="Paceptar" runat="server" BackColor="#FFEA1E" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="51px" Visible="False" 
                                            Width="212px" ScrollBars="Auto" 
                        ViewStateMode="Disabled">
                                            <asp:Panel ID="Panel33" runat="server" BackColor="#CC0000" BorderColor="Black" 
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
                                           <asp:Button ID="Button48" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" />
                                            <asp:Button ID="Button52" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

<span ID="bus4">
                <center style="height: 86px">
                <asp:Panel ID="PanelBusca" runat="server" BackColor="#FFEA1E" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="75px" Visible="False" 
                                            Width="101px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel45" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Filtro</asp:Panel>
                                            <asp:Panel ID="Panel46" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
                                                Height="215px" Width="384px">
                                                <table style="width: 383px; height: 86px;">
                                                    <tr>
                                                        <td>
                                                            Proveedor:</td>
                                                        <td>
                                                           <asp:TextBox ID="Tprov" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Tipo de Proveedor:</td>
                                                        <td>
                                                         <asp:TextBox ID="Ttip" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Serie:</td>
                                                        <td>
                                                           <asp:TextBox ID="Tser" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Folio:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tfol" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="26px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Moneda:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tmon" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="21px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            Total:</td>
                                                        <td>
                                                            <asp:TextBox ID="Ttot" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="24px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            Código GL:</td>
                                                        <td>
                                                            <asp:TextBox ID="Tcod" runat="server" Width="244px" Font-Size="Smaller" 
                                                                TextMode="SingleLine" Height="20px" ontextchanged="filtro_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button49" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Buscar" Width="87px" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>


                                         <span ID="bus5">
                <center>
                <asp:Panel ID="Pdias" runat="server" BackColor="#FFEA1E" 
                                            BorderColor="#E4B918" BorderStyle="Groove" 
                        Height="16px" Visible="False" 
                                            Width="40px" ScrollBars="Auto">
                                            <asp:Panel ID="Panel32" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="415px">
                        Editando día de la operación</asp:Panel>
                                            <asp:Panel ID="Panel44" runat="server" BorderColor="#E4B918" BorderStyle="Ridge" 
                                                Height="126px" Width="384px">
                                                <table style="width: 383px; height: 119px;">
                                                    <tr>
                                                        <td>
                                                            Día de la semana:</td>
                                                        <td>
                                                            <asp:Label ID="Ldia1" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                          </td>
                                                        <td>
                                                            
                                                            <asp:CheckBox ID="Checkdia" runat="server" Text="Habilitado" />
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Hora de Inicio:</td>
                                                        <td>
                                                            
                                                            <asp:DropDownList ID="Dropdia1" runat="server" Height="16px" Width="69px">
                                                                <asp:ListItem>08:00</asp:ListItem>
                                                                <asp:ListItem>09:00</asp:ListItem>
                                                                <asp:ListItem>10:00</asp:ListItem>
                                                                <asp:ListItem>11:00</asp:ListItem>
                                                                <asp:ListItem>12:00</asp:ListItem>
                                                                <asp:ListItem>13:00</asp:ListItem>
                                                                <asp:ListItem>14:00</asp:ListItem>
                                                                <asp:ListItem>15:00</asp:ListItem>
                                                                <asp:ListItem>16:00</asp:ListItem>
                                                                <asp:ListItem>17:00</asp:ListItem>
                                                                <asp:ListItem>18:00</asp:ListItem>
                                                                <asp:ListItem>19:00</asp:ListItem>
                                                                <asp:ListItem>20:00</asp:ListItem>
                                                            </asp:DropDownList>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Hora de finalización:</td>
                                                        <td>
                                                          <asp:DropDownList ID="Dropdia2" runat="server" Height="17px" Width="68px">
                                                                <asp:ListItem>08:00</asp:ListItem>
                                                                <asp:ListItem>09:00</asp:ListItem>
                                                                <asp:ListItem>10:00</asp:ListItem>
                                                                <asp:ListItem>11:00</asp:ListItem>
                                                                <asp:ListItem>12:00</asp:ListItem>
                                                                <asp:ListItem>13:00</asp:ListItem>
                                                                <asp:ListItem>14:00</asp:ListItem>
                                                                <asp:ListItem>15:00</asp:ListItem>
                                                                <asp:ListItem>16:00</asp:ListItem>
                                                                <asp:ListItem>17:00</asp:ListItem>
                                                                <asp:ListItem>18:00</asp:ListItem>
                                                                <asp:ListItem>19:00</asp:ListItem>
                                                                <asp:ListItem>20:00</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Button ID="Button53" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Grabar" Width="87px" onclick="Button53_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button54" runat="server" BackColor="#FFD307" 
                                                BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
                                                Text="Cancelar" Width="87px" onclick="Button54_Click" />
                                            <br />
                                        </asp:Panel>
                                        </center>
                                        </span>

        </td>
        </tr>
        </table>
        <div class="tabcontents">
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:View ID="View1" runat="server">
     
               <asp:Panel ID="Panel3" runat="server" BackColor="#ffcc00" BorderColor="#E4B918" 
                    BorderStyle="Groove"  Height="74px" Width="524px" 
                   style="margin-right: 6px; margin-top: 17px;" >
                     <asp:Panel ID="Panel4" runat="server" BorderColor="#FFE88C" BorderStyle="Outset" 
                         Font-Bold="True" ForeColor="Black" style="text-align: center">
                         Portal de consulta de CFDI</asp:Panel>
                         <center style="height: 47px; width: 520px">
                         <center>
                     <asp:Menu ID="menu1" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
                 StaticSelectedStyle-CssClass="selectedtab" CssClass="menu" runat="server"
                    Font-Bold="True" Font-Size="Medium" onmenuitemclick="Menu1_MenuItemClick">
                    <Items>
                    <asp:MenuItem  Text="Comprobantes Fiscales Digitales" Value="0" Selected="true"></asp:MenuItem>
                    <asp:MenuItem Text="Interface de Archivos" Value="1"></asp:MenuItem>          
                    </Items>
                         <StaticMenuItemStyle CssClass="tab" />
                         <StaticSelectedStyle CssClass="selectedtab" />
                 </asp:Menu>
                 </center>
                     <br />
                     </center>
               </asp:Panel>
        <asp:MultiView ID="MultiView2" ActiveViewIndex="0" runat="server">
                <asp:View ID="View3" runat="server">
                <asp:Panel ID="Panel6" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                         style="width: auto" Font-Names="Arial" Font-Size="11px">
                        Comprobantes Fiscales Digitales</asp:Panel>

                    <center>
                        <table style="width: auto; height: 102px">
                              <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Button ID="Button1" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar CFDI" 
                                        Width="67px" />
                                        </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                <center>
                                    <asp:Button ID="Button2" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Todos" 
                                        Width="72px" onclick="Button2_Click" />
                                        </center>
                                </td>
                                
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                <center>
                                    <asp:Button ID="Button3" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Validados" 
                                        Width="84px" onclick="Button3_Click" />
                                        </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                    <center>
                                    <asp:Button ID="Button4" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver En Proceso De Pago" 
                                        Width="128px" onclick="Button4_Click" />
                                        </center>
                                </td>
                               
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                               <center>
                                    <asp:Button ID="Button5" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Rechazados" 
                                        Width="94px" onclick="Button5_Click" />
                                </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                    <center>
                                    <asp:Button ID="Button6" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Cancelados" 
                                        Width="93px" onclick="Button6_Click" />
                                        </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                    <center>
                                    <asp:Button ID="Button7" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Documentos Adicionales" 
                                        Width="131px" />
                               </center>
                                </td>

                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                               <center>
                                    <asp:Button ID="Button8" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Historial" 
                                        Width="55px" />
                                </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                    <center>
                                    <asp:Button ID="Button9" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Cancelar" Width="63px" 
                                            onclick="Button9_Click" />
                                </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                    <center>
                                    <asp:Button ID="Button10" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Rechazar" Width="70px" 
                                            onclick="Button10_Click" />
                                </center>
                                </td>
                                <td class="style11" style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                    <center>
                                    <asp:Button ID="Button11" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" Width="52px" 
                                            onclick="Button11_Click" />
                                </center>
                                </td>
                              </tr>
                              <tr>
                                <td colspan="11">
                                <asp:Panel ID="Panel14" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
              Height="240px" Width="1229px" ScrollBars="Auto">
              <br />
                               
                                <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="1"  DataKeyNames="idFactura"
    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
     Width="1541px" style="margin-top: 0px" BorderColor="#CC0000" 
        BorderStyle="Groove" Font-Size="10px" Font-Bold="True" CellSpacing="1" AllowPaging="True" 
                                        onselectedindexchanged="gvFacturas_SelectedIndexChanged" >
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns >
        <asp:CommandField ShowSelectButton="True" />
     <asp:ImageField DataImageUrlField="EDOFAC" 
                        DataImageUrlFormatString="~/Imagenes/{0}.png" HeaderText="Estatus" Visible="false" >
                        <ControlStyle Height="35px" Width="35px" />
                        <HeaderStyle Width="7%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ImageField>

   <asp:TemplateField HeaderText="XML">
            <ItemTemplate>
            <a href='download.aspx?file=<%# Eval("XMLARC") %>'>
                <img  src="imagenes/xml32x32.png" alt="xml" border="0" align="middle" 
                    height="22" width="22"></a>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PDF">
            <ItemTemplate>
            <a href='download.aspx?file=<%# Eval("PDFARC") %>'>
                <img  src="imagenes/pdf32x32.png" alt="pdf" border="0" align="middle" 
                    height="22" width="22"></a>
            </ItemTemplate>         
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
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NOMREC") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("NOMREC") %>' Width="200px"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serie" SortExpression="SERIE">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("SERIE") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("SERIE") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folio" SortExpression="FOLIO">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("FOLIO") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("FOLIO") %>'></asp:Label>
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
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Fecha de Recepción" SortExpression="FECHA">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fechaRec") %>'></asp:Label>
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
                <asp:Label ID="Label15" runat="server" Text='<%# Bind("estatus") %>'></asp:Label>
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
                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("impuestos") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label11" runat="server" Text='<%# Bind("impuestos") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Código Contable" SortExpression="Código Contable" >
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
                <asp:Label ID="Label15" runat="server" Text='<%# Bind("fechaRechazo") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>



        <asp:TemplateField HeaderText="Causa de Rechazo" SortExpression="cauRecha">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:Label>
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
            No existen datos.
        </EmptyDataTemplate>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="10px" Wrap="False" />
    <PagerStyle BackColor="#284775" ForeColor="White" 
            HorizontalAlign="Center" Wrap="False" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#E9E7E2"/>
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:receHiltonSFConnectionString %>" 
        SelectCommand="PA_facturas_basico_rec_2" SelectCommandType="StoredProcedure" >
    <SelectParameters>
        <asp:Parameter DefaultValue="-" Name="QUERY" Type="String" />
        <asp:SessionParameter DefaultValue="S--X" Name="SUCURSAL" 
            SessionField="sucursalUser" Type="String" />
        <asp:SessionParameter DefaultValue="R---" Name="RFC" SessionField="rfcCliente" 
            Type="String" />
        <asp:SessionParameter DefaultValue="false" Name="ROL" SessionField="coFactTodas" 
            Type="Boolean" />
        <asp:Parameter DefaultValue="" Name="MODULO" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
                                </asp:Panel>
                                </td>
                              </tr>
                        </table>
                    </center>
                    <br />
                </asp:View> 
                <asp:View ID="View4" runat="server">
                
                </asp:View> 

                <asp:View ID="View25" runat="server">
               
                                                       
                </asp:View> 
                
       </asp:MultiView>
        </asp:View>
        <asp:View ID="View2" runat="server">
           <table style="width: 1208px">
              <tr>
                <td class="style14">
                <asp:Panel ID="Panel1" runat="server" BackColor="#ffcc00" BorderColor="#E4B918" 
                    BorderStyle="Groove" Height="59px" Width="170px" 
                   style="margin-right: 6px; margin-top: 17px;">
                     <asp:Panel ID="Panel2" runat="server" BorderColor="#FFE88C" BorderStyle="Outset" 
                         Font-Bold="True" ForeColor="Black" style="text-align: center" 
                         Font-Size="Smaller" Width="160px">
                         Administración de Usuarios</asp:Panel>
                         <center style="height: 26px; width: 165px">
                         <center style="width: 177px">
                     <asp:Menu ID="menu2" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
                 StaticSelectedStyle-CssClass="selectedtab" CssClass="menu2" runat="server"
                    onmenuitemclick="Menu2_MenuItemClick" Font-Bold="False" Font-Size="8px">
                    <Items>
                    <asp:MenuItem  Text="Usuarios" Value="0" Selected="true"></asp:MenuItem>
                    <asp:MenuItem Text="Grupos" Value="1"></asp:MenuItem>          
                    </Items>
                         <StaticMenuItemStyle CssClass="tab" />
                         <StaticSelectedStyle CssClass="selectedtab" />
                 </asp:Menu>
                 </center>
                     <br />
                     </center>
               </asp:Panel></td>
                <td class="style15">
                <asp:Panel ID="Panel5" runat="server" BackColor="#ffcc00" BorderColor="#E4B918" 
                    BorderStyle="Groove" Height="58px" Width="240px" 
                   style="margin-right: 6px; margin-top: 17px;">
                     <asp:Panel ID="Panel7" runat="server" BorderColor="#FFE88C" BorderStyle="Outset" 
                         Font-Bold="True" ForeColor="Black" style="text-align: center" 
                         Font-Size="Smaller" Width="229px">
                         Administración de Preveedores</asp:Panel>
                         <center style="height: 32px; width: 240px">
                         
                     <asp:Menu ID="menu3" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
                 StaticSelectedStyle-CssClass="selectedtab" CssClass="menu2" runat="server"
                    onmenuitemclick="Menu2_MenuItemClick" Font-Bold="False" Font-Size="8px">
                    <Items>
                    <asp:MenuItem  Text="Proveedores" Value="2" Selected="true"></asp:MenuItem>
                    <asp:MenuItem Text="Solicitudes de Registro" Value="3"></asp:MenuItem>          
                    </Items>
                         <StaticMenuItemStyle CssClass="tab" />
                         <StaticSelectedStyle CssClass="selectedtab" />
                 </asp:Menu>
                 </center>
                     <br />
                 
               </asp:Panel>
                </td>
                <td class="style12">
                    <asp:Panel ID="Panel8" runat="server" BackColor="#ffcc00" BorderColor="#E4B918" 
                    BorderStyle="Groove" Height="57px" Width="238px" 
                   style="margin-right: 6px; margin-top: 17px;">
                     <asp:Panel ID="Panel9" runat="server" BorderColor="#FFE88C" BorderStyle="Outset" 
                         Font-Bold="True" ForeColor="Black" style="text-align: center" 
                            Font-Size="Smaller" Width="230px">
                         Administración de Receptores de CFDI</asp:Panel>
                         <center style="height: 33px; width: 233px">
                         
                     <asp:Menu ID="menu4" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
                 StaticSelectedStyle-CssClass="selectedtab" CssClass="menu2" runat="server"
                    onmenuitemclick="Menu2_MenuItemClick" Font-Bold="False" Font-Size="8px">
                    <Items>
                    <asp:MenuItem  Text="Receptores de CFDI" Value="4" Selected="true"></asp:MenuItem>
                    <asp:MenuItem Text="Códigos de IVA" Value="5"></asp:MenuItem>          
                    </Items>
                         <StaticMenuItemStyle CssClass="tab" />
                         <StaticSelectedStyle CssClass="selectedtab" />
                 </asp:Menu>
                 </center>
                     <br />
                 
               </asp:Panel>
                </td>
                <td class="style16">
                   <asp:Panel ID="Panel10" runat="server" BackColor="#ffcc00" BorderColor="#E4B918" 
                    BorderStyle="Groove" Height="56px" Width="338px" 
                   style="margin-right: 6px; margin-top: 17px;">
                     <asp:Panel ID="Panel11" runat="server" BorderColor="#FFE88C" BorderStyle="Outset" 
                         Font-Bold="True" ForeColor="Black" style="text-align: center" 
                           Font-Size="Smaller" Width="327px">
                         Administración de Configuración</asp:Panel>
                         <center style="height: 25px; width: 325px">
                         
                     <asp:Menu ID="menu5" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
                 StaticSelectedStyle-CssClass="selectedtab" CssClass="menu2" runat="server"
                    onmenuitemclick="Menu2_MenuItemClick" Font-Bold="False" Font-Size="8px">
                    <Items>
                    <asp:MenuItem  Text="Días de Operación" Value="6" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Monedas" Value="7"></asp:MenuItem>
                    <asp:MenuItem Text="Tipo de Proveedor" Value="8"></asp:MenuItem>          
                    </Items>
                         <StaticMenuItemStyle CssClass="tab" />
                         <StaticSelectedStyle CssClass="selectedtab" />
                 </asp:Menu>
                 </center>
                     <br />
                 
               </asp:Panel>
                </td>
                <td>
                
                <asp:Panel ID="Panel12" runat="server" BackColor="#ffcc00" BorderColor="#E4B918" 
                    BorderStyle="Groove" Height="57px" Width="102px" 
                   style="margin-right: 6px; margin-top: 17px;">
                     <asp:Panel ID="Panel13" runat="server" BorderColor="#FFE88C" BorderStyle="Outset" 
                         Font-Bold="True" ForeColor="Black" style="text-align: center" 
                            Font-Size="Smaller" Width="89px">
                         Reportes</asp:Panel>
                         <center style="height: 30px; width: 98px">
                         
                     <asp:Menu ID="menu6" Orientation="Horizontal" IncludeStyleBlock="False" StaticMenuItemStyle-CssClass="tab"
                 StaticSelectedStyle-CssClass="selectedtab" CssClass="menu2" runat="server"
                    onmenuitemclick="Menu2_MenuItemClick" Font-Bold="False" Font-Size="8px">
                    <Items>
                    <asp:MenuItem  Text="Reportes" Value="9" Selected="true"></asp:MenuItem>
                    </Items>
                         <StaticMenuItemStyle CssClass="tab" />
                         <StaticSelectedStyle CssClass="selectedtab" />
                 </asp:Menu>
                 </center>
                     <br />
                 
               </asp:Panel>
                </td>
              </tr>
              <tr>
                <td colspan="5">
                   <asp:MultiView ID="MultiView4" ActiveViewIndex="0" runat="server">

                   <asp:View ID="View15" runat="server">
                      <asp:Panel ID="Panel25" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Usuarios</asp:Panel>

                        <table style="width: 416px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Button ID="Button12" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Nuevo registro" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Button ID="Button13" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Button ID="Button14" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Desactivar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Button ID="Button15" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View16" runat="server">
                          <asp:Panel ID="Panel35" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Grupos de Usuarios</asp:Panel>

                        <table style="width: 416px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image16" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button16" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Nuevo registro" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image17" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button17" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image18" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button18" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Desactivar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image19" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button19" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View17" runat="server">
                          <asp:Panel ID="Panel36" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Proveedores</asp:Panel>

                        <table style="width: 416px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image20" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button20" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image21" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button21" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Inhabilitar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image22" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button22" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Rehabilitar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image23" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button23" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View18" runat="server">
                         <asp:Panel ID="Panel37" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Solicitudes de Registro de Proveedores</asp:Panel>

                        <table style="width: 752px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image24" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button24" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Rechazar Solicitud" 
                                        Width="99px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image25" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button25" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Aprobar Solicitud" 
                                        Width="95px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image26" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button26" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Todos" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image27" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button27" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Pendientes" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image28" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button28" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Rechazados" 
                                        Width="90px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image29" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button29" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ver Aprobados" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image30" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button30" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>

                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View19" runat="server">
                            <asp:Panel ID="Panel38" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Receptores de CFDI</asp:Panel>

                        <table style="width: 288px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image31" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button31" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Nuevo registro" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image32" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button32" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image34" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button34" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View20" runat="server">
                                                <asp:Panel ID="Panel39" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Códigos IVA</asp:Panel>

                        <table style="width: 301px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image33" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button33" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Nuevo registro" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image35" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button35" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image36" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button36" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View21" runat="server">
                                                <asp:Panel ID="Panel40" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Días de Operación</asp:Panel>

                        <table style="width: 173px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image37" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button37" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" onclick="Button37_Click" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image39" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button39" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View22" runat="server">
                                                 <asp:Panel ID="Panel41" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">Monedas</asp:Panel>

                        <table style="width: 251px; height: 33px">
                            <tr>
                               <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image38" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button38" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Nuevo registro" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image40" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button40" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image41" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button41" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View23" runat="server">
                                                <asp:Panel ID="Panel42" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Tipo de Proveedor</asp:Panel>

                        <table style="width: 236px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image42" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button42" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Nuevo registro" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image43" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button43" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Editar" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image44" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button44" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                    <asp:View ID="View24" runat="server">
                                                  <asp:Panel ID="Panel43" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Reportes</asp:Panel>

                        <table style="width: 202px; height: 33px">
                            <tr>
                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image45" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button45" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Ejecutar Reporte" 
                                        Width="87px" />
                                        </center>
                                </td>

                                <td class="style10" 
                                      style="border-style: none solid none solid; border-width: thin; border-color: #000000">
                                      <center>
                                    <asp:Image ID="Image47" runat="server" Height="19px" 
                                        ImageUrl="~/Imagenes-dhl/D4.PNG" Width="19px" />
                                    <asp:Button ID="Button47" runat="server" BackColor="#D40511" Font-Names="Arial" 
                                        Font-Size="11px" ForeColor="White" Height="21px" Text="Filtrar" 
                                        Width="87px" />
                                        </center>
                                </td>
                            </tr>
                       </table>
                   </asp:View>

                   </asp:MultiView>
                </td>
              </tr>
              <tr>
                <td colspan="5">
                  <asp:MultiView ID="MultiView3" ActiveViewIndex="0" runat="server">
                  <asp:View ID="View5" runat="server">
                   <asp:Panel ID="Panel15" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                       <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" 
        DataKeyNames="idUsuario" AllowPaging="True"  
              BorderColor="#CC0000" BorderStyle="Groove" style="margin-top: 0px" Font-Size="10px" 
                           Font-Bold="True" CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" 
                InsertVisible="False" ReadOnly="True" SortExpression="idUsuario" 
                Visible="False" />
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

            <asp:TemplateField HeaderText="Longin" SortExpression="login">
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
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("proveedor") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("proveedor") %>'></asp:Label>
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
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [idUsuario], [nombre], [grupo], [login], [proveedor],[activo] FROM [usuarios]" 
        
    UpdateCommand="UPDATE Usuarios SET nombre= @nombre WHERE (idUsuario= @idUsuario)"
    DeleteCommand="DELETE FROM Usuarios WHERE (idUsuario= @idUsuario)">
   

        <UpdateParameters>
            <asp:Parameter Name="nombre" />
            <asp:Parameter Name="grupo" />
            <asp:Parameter Name="login" />
            <asp:Parameter Name="proveedor" />
            <asp:Parameter Name="activo" />
            <asp:Parameter Name="idUsuario" />
        </UpdateParameters>
    </asp:SqlDataSource>
                     </asp:Panel>
                  </asp:View>

                  <asp:View ID="View6" runat="server">
                   <asp:Panel ID="Panel16" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                        <asp:Panel ID="Panel26" runat="server" BackColor="#CC0000" BorderColor="Black" 
                        Font-Bold="True" ForeColor="White" Height="16px" BorderStyle="Groove" 
                        Width="1253px">
                        Grupos</asp:Panel>
                     </asp:Panel>
                  </asp:View>
                  <asp:View ID="View7" runat="server">
                                     <asp:Panel ID="Panel17" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="807px" 
        DataKeyNames="idProveedor" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove" style="margin-top: 0px" Font-Size="10px" Font-Bold="True" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="idProveedor" HeaderText="idProveedor" 
                InsertVisible="False" ReadOnly="True" SortExpression="idProveedor" 
                Visible="False" />
            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
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

            <asp:TemplateField HeaderText="Habilitado" SortExpression="habilitado">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("habilitado") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("habilitado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Vendor ID" SortExpression="vendor">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("vendorID") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendorID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Vendor Site ID" SortExpression="venSite">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("vendorSite") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendorSite") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo de Proveedor" SortExpression="tProv">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tipoProveedor") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("tipoProveedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Privacidad Aceptada" SortExpression="priv">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("privacidad") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("privacidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha de Aceptación" SortExpression="fechAcept">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fechaAceptacion") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("fechaAceptacion") %>'></asp:Label>
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

                        <asp:TemplateField HeaderText="Correo de Contacto" SortExpression="correo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("correo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
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
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                       <asp:TemplateField HeaderText="Causa de inhabilitación / rehabilitación" SortExpression="inha">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("causaHabilitar") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("causaHabilitar") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                       <asp:TemplateField HeaderText="Calle" SortExpression="calle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("calle") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("calle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="No. Exterior" SortExpression="ext">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("noExt") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("noExt") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="No. Interior" SortExpression="inte">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("noInt") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("noInt") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Colonia" SortExpression="colinia">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("colonia") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("colonia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Localidad / Ciudad" SortExpression="loc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("localidad") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("localidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Referencia" SortExpression="ref">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("referencia") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Municipio / Delegación" SortExpression="mun">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("municipio") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("municipio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Estado" SortExpression="estado">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("estado") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="País" SortExpression="pais">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("pais") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("pais") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Código Postal" SortExpression="codPos">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codPostal") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codPostal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
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
         [colonia], [localidad], [referencia], [municipio], [estado], [pais], [codPostal], [causaRechazo] FROM [Proveedores]" 
        
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
                       
                     </asp:Panel>
                  </asp:View>
                  <asp:View ID="View8" runat="server">
                                     <asp:Panel ID="Panel18" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource9" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" 
        DataKeyNames="idProveedor" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="idProveedor" HeaderText="idProveedor" 
                InsertVisible="False" ReadOnly="True" SortExpression="idProveedor" 
                Visible="False" />

                   <asp:TemplateField HeaderText="Fecha de Solicitud" SortExpression="fecSol">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fechaSolicitud") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fechaSolicitud") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


                <asp:TemplateField HeaderText="Estado" SortExpression="status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
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
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Causa de Rechazo" SortExpression="cauRec">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("causaRechazo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("causaRechazo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>


  <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [fechaSolicitud],[status],[rfc], [idProveedor], [razonSocial], [contacto], [telefono],[correo], [causaRechazo] FROM [Proveedores] " 
        UpdateCommand="UPDATE Proveedores SET rfc= @rfc, razonSocial= @razonSocial WHERE (idProveedor= @idProveedor)) "
        DeleteCommand="DELETE FROM Proveedores WHERE (idProveedor= @idProveedor)">

        <UpdateParameters>
            <asp:Parameter Name="rfc" />
            <asp:Parameter Name="razonSocial" />
            <asp:Parameter Name="contacto" />
            <asp:Parameter Name="telefono" />
            <asp:Parameter Name="correo" />
            <asp:Parameter Name="idProveedor" />
            <asp:Parameter Name="tipo" />
        </UpdateParameters>

    </asp:SqlDataSource>

                    </asp:Panel>
                  </asp:View>

          <asp:View ID="View9" runat="server">
                <asp:Panel ID="Panel19" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                         <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" 
                             style="margin-top: 0px" CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razón Social" SortExpression="raz">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("razonSoc") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("razonSoc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Org ID" SortExpression="or">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OrdID") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("OrdID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Oracle ID" SortExpression="ora">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OracleID") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("OracleID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Código GL IVA Retenido" SortExpression="cod">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGLret") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigoGLret") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Código GL ISR Retenido" SortExpression="codis">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGLISRret") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigoGLISRret") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo de Proveedor Flete" SortExpression="tipProv">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("tipProvFlet") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("tipProvFlet") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Código GL IVA Retenido Flete" SortExpression="fle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGLIVAret") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigoGLIVAret") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Habilitado" SortExpression="habi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("habilitado") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("habilitado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [rfc],[razonSoc],[OrdID],[OracleID],[codigoGLret] ,[codigoGLISRret],[tipProvFlet],[codigoGLIVAret],[habilitado] FROM [receptorCFDI]">
    </asp:SqlDataSource>
                     </asp:Panel>
                  </asp:View>

                  <asp:View ID="View10" runat="server">
                                     <asp:Panel ID="Panel20" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rfc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("rfc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razón Social" SortExpression="raz">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("razonSoc") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("razonSoc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Impuesto" SortExpression="impu">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("impuesto") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("impuesto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tasa" SortExpression="tasa">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tasa") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("tasa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Código" SortExpression="codi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Código GL" SortExpression="codig">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigoGL") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigoGL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [rfc],[razonSoc],[impuesto],[tasa],[codigo] ,[codigoGL] FROM [codigosIVA]">
    </asp:SqlDataSource>
                     </asp:Panel>
                  </asp:View>

                  <asp:View ID="View11" runat="server">
                                     <asp:Panel ID="Panel21" runat="server" BorderColor="#CC0000" 
                                         BorderStyle="Solid" Width="1229px" ScrollBars="Auto">
                         <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
        CellPadding="1" ForeColor="#333333" DataKeyNames="dia" GridLines="None" Width="1229px" AllowPaging="True" 
                                             PageSize="7" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" CellSpacing="1" 
                                             onselectedindexchanged="GridView5_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Día" SortExpression="dia">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dia") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("dia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Habilitado" SortExpression="hab">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("habilitado") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("habilitado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Hora de Inicio" SortExpression="HI">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("horaIni") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("horaIni") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Hora de Finalización" SortExpression="HF">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("horaFin") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("horaFin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [dia],[habilitado],[horaIni],[horaFin] FROM [diasOperacion]">
    </asp:SqlDataSource>
                     </asp:Panel>
                  </asp:View>
                  <asp:View ID="View12" runat="server">
                                     <asp:Panel ID="Panel22" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource7" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Código (ISO)" SortExpression="codiso">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("codigoISO") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("codigoISO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="nom">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nombre") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Activa" SortExpression="ac">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("activa") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("activa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [codigoISO],[nombre],[activa] FROM [monedas]">
    </asp:SqlDataSource>
                     </asp:Panel>
                  </asp:View>
                  <asp:View ID="View13" runat="server">
                                     <asp:Panel ID="Panel23" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                         <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource8" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="1229px" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" 
                                             CellSpacing="1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Nombre" SortExpression="nome">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Permitir Carga de Propinas o Servicios" SortExpression="permPropServ">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("permPropServ") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("permPropServ") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Activo" SortExpression="ac0">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("activo") %>' 
                        Width="320px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" 
            Font-Size="Smaller" />
        <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="#CC0000" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFEA1E" ForeColor="#333333" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [nombre],[permPropServ],[activo] FROM [tipoProveedor]">
    </asp:SqlDataSource>
                     </asp:Panel>
                  </asp:View>
                  <asp:View ID="View14" runat="server">
                                     <asp:Panel ID="Panel24" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                    Height="256px" Width="1229px" ScrollBars="Auto">
                     </asp:Panel>
                  </asp:View>
                  </asp:MultiView>
                </td>
              </tr>
           </table>
        </asp:View>       
        </asp:MultiView>
        </div> 
        </ContentTemplate>
         
    </div>
</asp:Content>
