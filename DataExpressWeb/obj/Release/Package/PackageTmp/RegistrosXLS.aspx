<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrosXLS.aspx.cs" Inherits="DataExpressWeb.RegistrosXLS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .panelBodyWrapper
{
    border:1px ridge #666666;
    }
                 .panelHeader
{
    background-color:#d40511;

    border:1px groove black;
    font-family:Arial;
    font-weight:bold;
    font-size:14px;
   
    color:#fff;
     height:20px;
     width:auto;

    }
.panelWrapper
    {
    background-color:#e8e8e4;
    border-style: solid;
        border-color: #d40511;
        border-width:1px;
    }      
    
.formEditar
{
    width: 342px; 
    height: 86px; 
  
    font-family: Arial; 
    font-weight: bold;
    font-size:12px;
    line-height:18px;
    
    color: #666666; 
    text-align:right;
    
    
    }
.textboxForm
{
    font: Normal 12px Arial;
    }
/*Estilo para el boton*/    
.botonForm
{
    background-color:#d40511;
    border-bottom-style:ridge;
    font-weight:normal;
    font-size:11px;
    color:#ffffff;
    width:87px;
        border-left-color: #e4b918;
        border-right-color: #e4b918;
        border-top-color: #e4b918;
        border-bottom-color: #e4b918;
    }
.botonForm:hover
{
    color:#ffcc00;
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
     #navigation
        {
            text-decoration:none;
            }
            .sideMenuComprobantesFiscales:hover
            {
                 text-decoration:underline;
                 color:#C90101 ;
                
                }
                 ul#navigation
             {
                 padding: 0 0 1em 1.75em;
                 list-style-image:url(../imagenes/arrow.png);
                 list-style-position:inside;
                 
                 
                 }
                 .titulo
                 {
                      padding: 0 0 1em 1.75em;
                 
                 list-style-position:inside;
                 font: normal bold 12px Arial;
                     }
                     h1 {
	background-color:#C90101 ;
	color: #fff ;
	font:normal bold 20px arial;
	
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
</style>
</asp:Content>
<asp:Content ID="MenuIzquierdo" ContentPlaceHolderID="MenuIzquierdo" runat="server">
    <span class="titulo">
    <asp:label ID="titulo_interfaz" Text="Interface de registros pendientes Oracle" runat="server" >
    </asp:label>
    </span>
<ul id="navigation">

</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style=" width:400px" >
    <asp:label ID="Titulo_interface" Text="Interface de registros pendientes Oracle" runat="server" >
    </asp:label>
    </h1>                     
  <table>
    <tr>
       <td>
          <asp:Panel ID="Panel23" runat="server" BorderColor="#CC0000" BorderStyle="none" 
                    Height="400px" Width="100%" ScrollBars="Vertical">
               <div style="overflow-x:auto;width:1000px">
                         <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource8" 
        CellPadding="1" ForeColor="#333333" GridLines="None" Width="85%" AllowPaging="True" 
              BorderColor="#CC0000" BorderStyle="Groove"  Font-Size="10px" Font-Bold="True" style="margin-top: 0px" 
                                             CellSpacing="1" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
             <asp:TemplateField ShowHeader="true" HeaderText="Marcar" >
                <ItemTemplate>
                 <asp:CheckBox runat="server" ID="chkValidar"></asp:CheckBox>
                </ItemTemplate>
             </asp:TemplateField> 
             <asp:BoundField DataField="RECORD_TYPE" HeaderText="RECORD_TYPE"  />  
             <asp:BoundField DataField="INVOICE_NUM" HeaderText="INVOICE_NUM" />  
             <asp:BoundField DataField="SUPPLIER_NUM" HeaderText="SUPPLIER_NUM"  />
             <asp:BoundField DataField="INVOICE_DATE" HeaderText="INVOICE_DATE"  />  
             <asp:BoundField DataField="INVOICE_CURR" HeaderText="INVOICE_CURR" />  
             <asp:BoundField DataField="CURRENCY_RATE" HeaderText="CURRENCY_RATE"  />
             <asp:BoundField DataField="INVOICE_AMOUNT" HeaderText="INVOICE_AMOUNT" />  
             <asp:BoundField DataField="No_inv_Detail" HeaderText="No_inv_Detail" />  
             <asp:BoundField DataField="Num" HeaderText="Num"  />
             <asp:BoundField DataField="UUID_CFDI" HeaderText="UUID_CFDI"  />  
             <asp:BoundField DataField="Supplier_Num2" HeaderText="Supplier_Num2" />  
             <asp:BoundField DataField="MontoTotal" HeaderText="MontoTotal"  />
             <asp:BoundField DataField="Moneda" HeaderText="Moneda" />  
             <asp:BoundField DataField="TipCamb" HeaderText="TipCamb"/>  
             <asp:BoundField DataField="No_inv_detail2" HeaderText="No_inv_detail2"/>
             <asp:BoundField DataField="Type_Tax" HeaderText="Type_Tax" />  
             <asp:BoundField DataField="CC" HeaderText="CC" />  
             <asp:BoundField DataField="Amount" HeaderText="Amount" />
             <asp:BoundField DataField="idRegistro" HeaderText="idRegistro" Visible="true" />
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
                   </div>
    <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT [idRegistro],[RECORD_TYPE]
      ,[INVOICE_NUM]
      ,[SUPPLIER_NUM]
      ,[INVOICE_DATE]
      ,[INVOICE_CURR]
      ,[CURRENCY_RATE]
      ,[INVOICE_AMOUNT]
      ,[No_inv_Detail]
      ,[Num]
      ,[UUID_CFDI]
      ,[Supplier_Num2]
      ,[MontoTotal]
      ,[Moneda]
      ,[TipCamb]
      ,[No_inv_detail2]
      ,[Type_Tax]
      ,[CC]
      ,[Amount]
      ,[NombreArchivo]
  FROM [Registros_pendientes_Oracle] WHERE estado=0">
    </asp:SqlDataSource>
                     </asp:Panel>
       </td>
    </tr>
    <tr align="center">
        <td >
             <asp:Button ID="btnEnviar_registros" runat="server" CssClass="boton"  Text="Validar" OnClick="btnEnviar_registros_Click" />
             <asp:Button ID="btnRegresar" CssClass="boton" Text="Regresar" runat="server" OnClick="btnRegresar_Click"/>                 
         </td>
   </tr>
  </table>  
 
</asp:Content>
