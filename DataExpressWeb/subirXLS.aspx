<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subirXLS.aspx.cs" Inherits="DataExpressWeb.subirXLS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
       
    <style type="text/css">
        
    body,
    html {
    margin:0;
    padding:0;
    color:#000;
   /* background:#a7a09a;*/
    }

        .wrapper
        {
            width:100%;
margin:0 auto;
background:#fff;
            }
            .main
            {
                            width:98%;
margin:0 auto;
background:#fff;
                }
        .header
        {
            border: 0px solid #ffcc00; 
            width:100%;          
             background-color: #ffcc00; 
             height: 68px;
            }
        .logo
        {
            height:29px;
            width:100px;
            
            padding:1em 0 0 1.75em;
            }
              
            .boton
{
color:#ffffff;
font-family:Arial;
border-color:#C90101 ;
background-color:#C90101 ;
border-style:solid;
font-size:normal;

}
.boton:hover
{
color:#ffcc00;
}

        .style1
        {
            font-family: Arial;
            font-size: 12px;
        }
        .style2
        {
            font-family: Arial;
        }

    </style>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js">
    </script>
        <script type="text/javascript">
            function limpia() {
                $('input[type="text"]').val('');
            }
        </script>
</head>
<body>
<form id="Form1" runat="server"  enctype="multipart/form-data">
<div class="wrapper">
  <div class="header">
    <asp:Image ID="Image1" CssClass="logo" runat="server" ImageUrl="~/Imagenes-dhl/logo-dhl.png"/>
    </div>
<div class="main">
        <table style="width:100%;">
            <tr>
                <td>
                <center>
               
               <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
                    <asp:Panel ID="Panel2" runat="server" Height="250px" Width="500px" 
                        style="margin-top: 9px; "  BackColor="#FCFCFC" BorderColor="gray" 
                        BorderStyle="solid" Visible="true">
                        <asp:Panel ID="Panel5" runat="server" BackColor="#CC0000" ForeColor="white" 
                            Font-Bold="True">
                            SUBIR ARCHIVO .XLS</asp:Panel>
                        <asp:linkbutton runat="server" ID="CrearXls" Text="Generar Registro" OnClick="CrearXls_click"/>
                        <br />
                            <br />
                           
                            <table style="border-style: solid; border-color: #000; width: 90%; height: 100px; background-color: #FCFCFC;">
                                <tr>
                                  <td>
                                      <span class="style1">Archivo .xls</span>
                                  </td>
                                  <td>
                                      <asp:FileUpload ID="examAdi" runat="server" Font-Names="Arial" Font-Size="12px" />                              
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:center">
                                      <asp:CheckBox ID="CheckExtranjero" runat="server" Text="Es archivo extranjero" /> 
                                    </td>
                                </tr>
                                <tr>
                                    <td/>
                                    <td colspan="2" style="text-align:center">
                                        <asp:Label ID="lMsj" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td/>
                                </tr>
                            </table>
                            <br />
                        <asp:Button ID="bSubir" runat="server" CssClass="boton" style="text-align: center; height: 26px;" Text="Cargar" 
                            ValidationGroup="Cargar" onClick="bSubir_Click"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="caN" runat="server" CssClass="boton"  style="text-align: center; margin-top: 0px;" Text="Regresar" onClick="can_Click"/>                       
                        <br />
                        <br/>
                        <center>
                            <asp:Label ID="lbPermisoUUID" runat="server"></asp:Label> 
                        </center>
                    </asp:Panel>
                    <br/>
                    <asp:Panel runat="server" ID="RegistrosError">
                        <asp:Label runat="server" ID="lberrorResgistros" Text="Registros erroneos en el archivo" Visible="false"></asp:Label>
                       <asp:GridView ID="gvRegistrosError" runat="server" OnRowDataBound="gvRegistrosError_DataBound"
                         ForeColor="#333333" GridLines="Both" style="margin-top: 0px" BorderColor="black" BorderStyle="Solid" BorderWidth="2px">
                         <Columns>
                          <asp:TemplateField ShowHeader="true" HeaderText="Marcar" visible="false">
                            <ItemTemplate>
                             <asp:CheckBox runat="server" ID="chkValidar" Visible="false"></asp:CheckBox>
                             </ItemTemplate>
                            </asp:TemplateField>       
                         </Columns>
                         <EmptyDataRowStyle CssClass="table" />
                        </asp:GridView> 
                        <br/>
                        <asp:Button ID="btnEnviar_registros" runat="server" CssClass="boton" style="text-align: center; height: 26px;" Text="Guardar para validar" visible="false" OnClick="btnEnviar_registros_Click" OnClientClick="return confirm('Solo se podran validar los errorres en diferencias')"/>
                    </asp:Panel>
                    </center>

                        <asp:Panel ID="PanelTITULO" runat="server" BackColor="#CC0000" ForeColor="white" 
                            Font-Bold="True" Visible="false">
                            GENERAR ARCHIVO .XLS</asp:Panel>
                    <asp:Panel runat="server" ID="PanelXsl" Visible="false" Height="250px" Width="500px">
                        <table>
                            <tr>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                    <asp:Label runat="server" ID="lbRecordType" Text="Record_Type" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                    <asp:Label runat="server" ID="Label1" Text="INVOICE_NUM" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label2" Text="SUPPLIER NUM" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label3" Text="INVOICE DATE" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label4" Text="INVOICE CURR" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label5" Text="Currency_Rate" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label6" Text="INVOICE AMOUNT" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label7" Text="No inv Detail" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label8" Text="Num" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label9" Text="UUID_CFDI" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label10" Text="Supplier Num" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label11" Text="MontoTotal" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label12" Text="Moneda" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label13" Text="TipCambio" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label14" Text="No inv detail" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label15" Text="TYPE_TAX" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label16" Text="CC" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                                <td style="border-top:solid;border-left:solid;border-right:solid;border-bottom:solid">
                                   <asp:Label runat="server" ID="Label17" Text="Amount" Font-Bold="true" Font-Size="Smaller" Width="100%"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="tb1" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb2" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb3" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb4" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb5" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb6" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb7" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb8" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb9" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb10" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb11" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb12" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb13" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb14" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb15" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb16" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb17" Width="100%"/>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tb18" Width="100%"/>
                                </td>
                            </tr>
                        </table>
                        <br/>
 <asp:GridView ID="gvRegistros" runat="server" OnRowCommand="btnEliminar_Click" OnRowDataBound="gvRegistros_DataBound"
     ForeColor="#333333" GridLines="Both" 
      style="margin-top: 0px" BorderColor="black" 
        BorderStyle="Solid" BorderWidth="2px">
     <Columns>
            <asp:TemplateField ShowHeader="true" HeaderText="" >
                <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkbtnEliminar" Text="Eliminar" CommandName="SelectRow" CommandArgument='<%#Eval("No")%>'><img src="/Imagenes-dhl/adve.png" alt="delete group" title="Eliminar renglon" width="20px" height="20px" /></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>       
     </Columns>
        <EmptyDataRowStyle CssClass="table" />
        <EmptyDataTemplate>
            No existen datos.
        </EmptyDataTemplate>
    </asp:GridView>      
                        <br/>                                             
                        <br/>
                        <div style="align-content:center">
                        <asp:Button ID="btnAgregar" CssClass="boton" Text="Agregar" runat="server" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnGenerarArchivo" CssClass="boton" Text="GenerarArchivo" runat="server" OnClick="btnGenerarArchivo_Click"/>                          
                        <asp:Button ID="btnRegresar" CssClass="boton" Text="Regresar" runat="server" OnClick="btnRegresar_Click"/> 
                        </div>
                    </asp:Panel>  
                    </td>
            </tr>
            <tr>
                <td class="style61" style="align-content:center;">
                <asp:Label ID="lMsj2" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
   </div>
</div>    
</form>
</body>
</html>
